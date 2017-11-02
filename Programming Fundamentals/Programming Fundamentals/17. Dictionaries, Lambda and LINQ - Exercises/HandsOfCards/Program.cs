using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> playersHandsValue = new Dictionary<string, HashSet<string>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("JOKER"))
            {
                string[] info = input.Trim().Split(':');
                string player = info[0];
                string[] cards = info[1].Trim().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                
                if(playersHandsValue.ContainsKey(player))
                {
                    playersHandsValue[player].UnionWith(new HashSet<string>(cards));
                }
                else
                {
                    playersHandsValue.Add(player, new HashSet<string>(cards));
                }
            }

            PrintPlayersHandValue(playersHandsValue);
        }

        static private int CalculateCardsValue(HashSet<string> cards)
        {
            int result = 0;

            for(int i = 0; i < cards.Count; i++)
            {
                string currentCard = cards.ElementAt(i);
                string powerString = currentCard.Substring(0, currentCard.Length - 1);
                string typeString = currentCard[currentCard.Length - 1].ToString();

                int power = 0;
                switch(powerString)
                {
                    case "J":
                        power = 11;
                        break;
                    case "Q":
                        power = 12;
                        break;
                    case "K":
                        power = 13;
                        break;
                    case "A":
                        power = 14;
                        break;
                    default:
                        power = Convert.ToInt32(powerString);
                        break;
                }

                int type = 0;
                switch (typeString)
                {
                    case "S":
                        type = 4;
                        break;
                    case "H":
                        type = 3;
                        break;
                    case "D":
                        type = 2;
                        break;
                    case "C":
                        type = 1;
                        break;
                }

                result += power * type;
            }

            return result;
        }

        static private void PrintPlayersHandValue(Dictionary<string, HashSet<string>> playersHandsValue)
        {
            foreach (KeyValuePair<string, HashSet<string>> player in playersHandsValue)
            {               
                Console.WriteLine($"{player.Key}: {CalculateCardsValue(player.Value)}");
            }
        }
    }
}
