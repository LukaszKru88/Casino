using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class Croupier
    {
        protected char[] colors = new char[4] { 'S', 'H', 'C', 'D' };
        protected string[] figures = new string[13]
            {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        private int? startPlace = null;
        private int? endPlace = null;
        //private char color;
        protected string[] key;
        //protected char[] symbols;
        char[] colorsKey;
        char[] verifiedColors = new char[4];
        bool correctColorKey = true;


        protected string[] GetCardRange(string line)
        {
            startPlace = null;
            endPlace = null;
            string[] exception = new string[1] {"Task impossible – improper CardDeck in the first line"};
            key = line.Split(new char[] { '[', '-', ']' }, StringSplitOptions.RemoveEmptyEntries);
            colorsKey = key[0].ToCharArray();

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
                for (int i = 0; i < colorsKey.Length; i++)
                {
                    correctColorKey = true;
                    for (int j = 0; j < colors.Length; j++)
                    {
                        if (colorsKey[i] != colors[j])
                        {
                            correctColorKey = false;
                        }
                        else
                        {
                            correctColorKey = true;
                            break;
                        }
                    }
                }

                for (int i = 0; i < figures.Length; i++)
                {
                    if (key[1] == figures[i])
                        startPlace = i;

                    if (key[2] == figures[i])
                        endPlace = i;
                }

                if (correctColorKey == false || !startPlace.HasValue || !endPlace.HasValue)
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
                int range = (eP - sP + 1) * colors.Length;
                deck = new string[range];

                for (int i = 0; i < colors.Length; i++)
                {
                    for (int j = sP; j <= endPlace; j++)
                    {
                        deck[k] = figures[j] + colors[i];
                        k++;
                    }
                }
            }
            else if(key.Length == 3)
            {
                int k = 0;
                int range = (eP - sP + 1) * colorsKey.Length;
                deck = new string[range];

                for (int i = 0; i < colorsKey.Length; i++)
                {
                    for (int j = sP; j <= endPlace; j++)
                    {
                        deck[k] = figures[j] + colorsKey[i];
                        k++;
                    }
                }
            }
            //{
            //    int index = 0;
            //    int range = (eP - sP) + 1;
            //    deck = new string[range];

            //    for (int i = 0; i < colors.Length; i++)
            //    {
            //        if (color == colors[i])
            //            index = i;
            //    }

            //    for(int i = 0; i < deck.Length; i++)
            //    {
            //        deck[i] = figures[sP] + colors[index];
            //        sP++;
            //    }
            //}
            return deck;
        }
    }
}
