using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IReader reader;
    private IWriter writer;

    private char[,] gameField;
    private IVegetable[,] vegetables;

    private INinja firstNinja;
    private INinja secondNinja;

    private bool isFirstNinjaTurn = true;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        string firstNinjaName = this.reader.ReadLine();
        string secondNinjaName = this.reader.ReadLine();

        int[] fieldDimensions = this.reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
        this.InitializeGameField(fieldDimensions);
        this.InitializeVegetables(fieldDimensions);
        this.ReadInput();

        this.FindNinjas(firstNinjaName, secondNinjaName);
        this.FindVegetables();
                
        this.ExecuteCommands();
    }

    private void InitializeGameField(int[] fieldDimensions)
    {
        this.gameField = new char[fieldDimensions[0], fieldDimensions[1]];
    }

    private void InitializeVegetables(int[] fieldDimensions)
    {
        this.vegetables = new Vegetable[fieldDimensions[0], fieldDimensions[1]];
    }

    private void ReadInput()
    {
        int rows = this.gameField.GetLength(0);
        int cols = this.gameField.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            string line = this.reader.ReadLine();

            for (int col = 0; col < cols; col++)
            {
                this.gameField[row, col] = line[col];
            }
        }
    }

    private void FindNinjas(string firstNinjaName, string secondNinjaName)
    {
        char ninja1Initial = firstNinjaName[0];
        char ninja2Initial = secondNinjaName[0];

        for (int row = 0; row < this.gameField.GetLength(0); row++)
        {
            for (int col = 0; col < this.gameField.GetLength(1); col++)
            {
                char currentChar = this.gameField[row, col];

                if (currentChar.Equals(ninja1Initial))
                {
                    this.firstNinja = new Ninja(firstNinjaName, row, col);
                }

                if (currentChar.Equals(ninja2Initial))
                {
                    this.secondNinja = new Ninja(secondNinjaName, row, col);
                }
            }
        }
    }

    private void FindVegetables()
    {
        for (int row = 0; row < this.vegetables.GetLength(0); row++)
        {
            for (int col = 0; col < this.vegetables.GetLength(1); col++)
            {
                this.vegetables[row, col] = VegetableFactory.GetVegetable(this.gameField[row, col]);
            }
        }
    }

    private INinja GetCurrentNinja()
    {
        INinja currentNinja = this.isFirstNinjaTurn ? this.firstNinja : this.secondNinja;        
        this.isFirstNinjaTurn = !this.isFirstNinjaTurn;

        return currentNinja;
    }
    
    private void GrowVegetables()
    {
        IPosition firstNinjaPos = this.firstNinja.Position;
        IPosition secondNinjaPos = this.secondNinja.Position;

        for (int row = 0; row < this.vegetables.GetLength(0); row++)
        {
            for (int col = 0; col < this.vegetables.GetLength(1); col++)
            {
                // blank or ninja
                if (this.vegetables[row, col] == null)
                {
                    continue;
                }

                bool ninja1IsntStandingHere = firstNinjaPos.X != row || firstNinjaPos.Y != col;
                bool ninja2IsntStandingHere = secondNinjaPos.X != row || secondNinjaPos.Y != col;

                if (ninja1IsntStandingHere && ninja2IsntStandingHere)
                {
                    this.vegetables[row, col].TickGrowth();
                }
            }
        }
    }

    private void ExecuteCommands()
    {
        while (true)
        {
            Queue<char> commands = new Queue<char>(this.reader.ReadLine());

            while (commands.Count > 0)
            {
                INinja currentNinja = this.GetCurrentNinja();

                do
                {
                    if (commands.Count == 0)
                    {
                        commands = new Queue<char>(this.reader.ReadLine());
                    }

                    char command = commands.Dequeue();

                    switch (command)
                    {
                        case 'L':
                            this.MoveNinja(currentNinja, 0, -1);
                            break;

                        case 'R':
                            this.MoveNinja(currentNinja, 0, 1);
                            break;

                        case 'U':
                            this.MoveNinja(currentNinja, -1, 0);
                            break;

                        case 'D':
                            this.MoveNinja(currentNinja, 1, 0);
                            break;
                    }

                    this.GrowVegetables();
                }
                while (currentNinja.Stamina > 0);

                currentNinja.EatCollectedVegetables();
            }            
        }
    }

    private void MoveNinja(INinja currentNinja, int x, int y)
    {
        IPosition newPosition = new Position(currentNinja.Position.X + x, currentNinja.Position.Y + y);

        currentNinja.Stamina--;

        if (this.IsOnGameField(newPosition))
        {
            return;
        }

        currentNinja.Position = newPosition;

        if (this.firstNinja.Position.X == this.secondNinja.Position.X && 
            this.firstNinja.Position.Y == this.secondNinja.Position.Y)
        {
            INinja ninja1 = currentNinja.Name.Equals(this.firstNinja.Name) ? this.firstNinja : this.secondNinja;
            INinja ninja2 = ninja1.Name.Equals(this.firstNinja.Name) ? this.secondNinja : this.firstNinja;

            this.Battle(ninja1, ninja2);   

            Environment.Exit(0);
        }

        IVegetable currentVegetable = this.vegetables[newPosition.X, newPosition.Y];
        if (currentVegetable != null && !currentVegetable.HasBeenCollected)
        {
            currentNinja.CollectVegetable(currentVegetable);
        }
    }

    private bool IsOnGameField(IPosition position)
    {
        return position.X < 0 || position.X > this.gameField.GetLength(0) - 1 ||
               position.Y < 0 || position.Y > this.gameField.GetLength(1) - 1;
    }

    private void Battle(INinja ninja1, INinja ninja2)
    {
        INinja winner = (ninja1.Power >= ninja2.Power) ? ninja1 : ninja2;
        this.PrintWinner(winner);        
    }

    private void PrintWinner(INinja winner)
    {
        this.writer.WriteLine($"Winner: {winner.Name}");
        this.writer.WriteLine($"Power: {winner.Power}");
        this.writer.WriteLine($"Stamina: {winner.Stamina}");
    }
}