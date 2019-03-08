using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class Croupier
    {
        protected string[] colours = new string[4] { "S", "H", "C", "D" };
        private string[] figures = new string[13]
            {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        private int? startPlace = null;
        private int? endPlace = null;
        private string colour;
        protected string[] key;
        
        protected string[] GetCardRange(string line)
        {
            startPlace = null;
            endPlace = null;
            string[] exception = new string[1] {"Task impossible – improper CardDeck in the first line"};
            key = line.Split(new char[] { '[', '-', ']' }, StringSplitOptions.RemoveEmptyEntries);

            if (key.Length == 2)
            {
                for (int i = 0; i < figures.Length; i++)
                {
                    if (key[0] == figures[i])
                        startPlace = i;

                    if (key[1] == figures[i])
                        endPlace = i;
                }

                if (!startPlace.HasValue || !endPlace.HasValue)
                {
                    return exception;
                }
            }
            else if(key.Length == 3)
            {
                for (int i = 0; i < colours.Length; i++)
                {
                    if (key[0] == colours[i])
                        colour = colours[i];
                }

                for (int i = 0; i < figures.Length; i++)
                {
                    if (key[1] == figures[i])
                        startPlace = i;

                    if (key[2] == figures[i])
                        endPlace = i;
                }

                if (string.IsNullOrEmpty(colour) || !startPlace.HasValue || !endPlace.HasValue)
                {
                    return exception;
                }
            }
            return key;
        }

        protected string[] CreateTheDeck(string[] key)
        {
            string[] deck = new string[52];
            int eP = endPlace.Value;
            int sP = startPlace.Value;

            if (key.Length == 2)
            {
                int k = 0;
                int range = (eP - sP + 1) * colours.Length;
                deck = new string[range];

                for (int i = 0; i < colours.Length; i++)
                {
                    for (int j = sP; j <= endPlace; j++)
                    {
                        deck[k] = figures[j] + colours[i];
                        k++;
                    }
                }
            }
            else if(key.Length == 3)
            {
                int index = 0;
                int range = eP - sP + 1;
                deck = new string[range];

                for (int i = 0; i < colours.Length; i++)
                {
                    if (colour == colours[i])
                        index = i;
                }

                for(int i = 0; i < deck.Length; i++)
                {
                    deck[i] = figures[sP] + colours[index];
                    sP++;
                }
            }
            return deck;
        }
    }
}
