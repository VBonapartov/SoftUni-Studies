namespace _03.NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private const int MaxTurns = 1000000;
        private static int turns = 0;

        private static Queue<Card> firstPlayerCards;
        private static Queue<Card> secondPlayerCards;

        static void Main(string[] args)
        {
            InitializePlayersCards();            
        }

        private static void InitializePlayersCards()
        {
            string cardsFirstPlayer = Console.ReadLine();
            string cardsSecondPlayer = Console.ReadLine();

            if (cardsFirstPlayer.Equals(cardsSecondPlayer))
            {
                Console.WriteLine("Draw after 1 turns");
                return;
            }

            firstPlayerCards = new Queue<Card>();
            secondPlayerCards = new Queue<Card>();

            foreach (string cardAsStr in cardsFirstPlayer.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                int number = int.Parse(cardAsStr.Substring(0, cardAsStr.Length - 1));
                char letter = cardAsStr.Last();

                firstPlayerCards.Enqueue(new Card(number, letter));
            }

            foreach (string cardAsStr in cardsSecondPlayer.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                int number = int.Parse(cardAsStr.Substring(0, cardAsStr.Length - 1));
                char letter = cardAsStr.Last();

                secondPlayerCards.Enqueue(new Card(number, letter));
            }

            PlayGame();
        }

        private static void PlayGame()
        {
            while(turns < MaxTurns && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                Card firstPlayerCard = firstPlayerCards.Dequeue();
                Card secondPlayerCard = secondPlayerCards.Dequeue();

                List<Card> cardsOnTheField = new List<Card>();
                cardsOnTheField.Add(firstPlayerCard);
                cardsOnTheField.Add(secondPlayerCard);

                if (firstPlayerCard.Number != secondPlayerCard.Number)
                {
                    CollectCards(cardsOnTheField, firstPlayerCard.Number, secondPlayerCard.Number);
                }
                else
                {
                    int firstCardsScore = 0;
                    int secondCardsScore = 0;

                    while (true)
                    {
                        if (firstPlayerCards.Count < 3 || secondPlayerCards.Count < 3)
                        {
                            PrintWinner();
                            return;
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            Card card = firstPlayerCards.Dequeue();
                            firstCardsScore += card.Letter - 96;
                            cardsOnTheField.Add(card);

                            card = secondPlayerCards.Dequeue();
                            secondCardsScore += card.Letter - 96;
                            cardsOnTheField.Add(card);
                        }

                        if (firstCardsScore != secondCardsScore)
                        {
                            CollectCards(cardsOnTheField, firstCardsScore, secondCardsScore);
                            break;
                        }
                    }
                }

                turns++;
            }

            PrintWinner();
        }

        private static void CollectCards(List<Card> cardsOnTheField, int firstPlayerCardPoints, int secondPlayerCardPoints)
        {
            if (firstPlayerCardPoints > secondPlayerCardPoints)
            {
                foreach(Card card in cardsOnTheField.OrderByDescending(card => card.Number).ThenByDescending(card => card.Letter))
                {
                    firstPlayerCards.Enqueue(card);
                }
            }
            else if (secondPlayerCardPoints > firstPlayerCardPoints)
            {
                foreach (Card card in cardsOnTheField.OrderByDescending(card => card.Number).ThenByDescending(card => card.Letter))
                {
                    secondPlayerCards.Enqueue(card);
                }
            }
        }

        private static void PrintWinner()
        {
            if(firstPlayerCards.Count == secondPlayerCards.Count)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if(firstPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
        }
    }

    class Card
    {
        public Card(int number, char letter)
        {
            this.Number = number;
            this.Letter = letter;
        }

        public int Number { get; private set; }
        public char Letter { get; private set; }
    }
}
