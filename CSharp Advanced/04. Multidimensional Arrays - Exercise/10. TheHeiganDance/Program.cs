namespace _10.TheHeiganDance
{
    using System;

    class Program
    {
        private const int ChamberSize = 15;
        private const int CloudDamage = 3500;
        private const int EruptionDamage = 6000;

        private static int[] playerPosition = new int[] { ChamberSize / 2, ChamberSize / 2 };
        private static int playerBlood = 18500;
        private static double playerDamage;

        private static double bossHeiganBlood = 3000000;

        static void Main(string[] args)
        {
            playerDamage = double.Parse(Console.ReadLine());

            bool isHitByCloud = false;
            string spell = string.Empty;

            while (true)
            {
                if (isHitByCloud)
                {
                    playerBlood -= CloudDamage;
                    isHitByCloud = false;
                }

                bossHeiganBlood -= playerDamage;

                if (IsGameOver(spell)) break;

                string[] bossAttack = Console.ReadLine()
                                             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                spell = bossAttack[0];
                int hitRow = int.Parse(bossAttack[1]);
                int hitCol = int.Parse(bossAttack[2]);

                if (IsCellReached(playerPosition[0], playerPosition[1], hitRow, hitCol) &&
                    IsPlayerDamaged(hitRow, hitCol))
                {
                    switch (spell)
                    {
                        case "Cloud":
                            playerBlood -= CloudDamage;
                            isHitByCloud = true;
                            break;

                        case "Eruption":
                            playerBlood -= EruptionDamage;
                            break;

                        default:
                            break;
                    }
                }

                if (IsGameOver(spell)) break;
            }
        }

        private static bool IsGameOver(string spell)
        {
            if (playerBlood <= 0 || bossHeiganBlood <= 0)
            {
                spell = (spell == "Cloud") ? "Plague Cloud" : spell;

                Console.WriteLine(bossHeiganBlood > 0
                    ? $"Heigan: {bossHeiganBlood:F2}"
                    : $"Heigan: Defeated!");

                Console.WriteLine(playerBlood > 0
                    ? $"Player: {playerBlood}"
                    : $"Player: Killed by {spell}");

                Console.WriteLine($"Final position: {playerPosition[0]}, {playerPosition[1]}");

                return true;
            }

            return false;
        }

        private static bool IsCellReached(int playerRow, int playerCol, int hitRow, int hitCol)
        {
            return (playerRow >= hitRow - 1) &&
                    (playerRow <= hitRow + 1) &&
                    (playerCol >= hitCol - 1) &&
                    (playerCol <= hitCol + 1);
        }

        private static bool IsPlayerDamaged(int hitRow, int hitCol)
        {
            // Try move Up
            if (playerPosition[0] > 0 && !IsCellReached(playerPosition[0] - 1, playerPosition[1], hitRow, hitCol))
            {
                playerPosition[0]--;
                return false;
            }

            // Try move Right
            if (playerPosition[1] + 1 < ChamberSize && !IsCellReached(playerPosition[0], playerPosition[1] + 1, hitRow, hitCol))
            {
                playerPosition[1]++;
                return false;
            }

            // Try move Down
            if (playerPosition[0] + 1 < ChamberSize && !IsCellReached(playerPosition[0] + 1, playerPosition[1], hitRow, hitCol))
            {
                playerPosition[0]++;
                return false;
            }

            // Try move Left
            if (playerPosition[1] > 0 && !IsCellReached(playerPosition[0], playerPosition[1] - 1, hitRow, hitCol))
            {
                playerPosition[1]--;
                return false;
            }

            return true;
        }
    }
}
