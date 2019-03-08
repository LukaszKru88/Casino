using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class CroupierEasyGame : Croupier
    {
        private string[] deck;
        private string[] resultTable = new string[10];
        private string[] cardsColors = new string[2];

        public string[] PlayEasyGame(string line)
        {
            key = GetCardRange(line);
            if (key[0] == "Task impossible – improper CardDeck in the first line")
                return key;
            else
                deck = CreateTheDeck(key);

            resultTable = PlayWarGame(deck);
            return resultTable;
        }

        private string[] PlayWarGame(string[] deck)
        {
            Random randomizer = new Random();
            for (int i = 0; i < 10; i++)
            {
                var index1 = randomizer.Next(deck.Length);
                var index2 = randomizer.Next(deck.Length);
                var card1 = deck[index1];
                var card2 = deck[index2];

                cardsColors = GetCardsColour(card1, card2);
                resultTable[i] = GetBattleResult(card1, card2, cardsColors);
            }

            return resultTable;
        }

        private string[] GetCardsColour(string card1, string card2)
        {
            var colour1 = card1[card1.Length - 1];
            var colour2 = card2[card2.Length - 1];
            cardsColors[0] = colour1.ToString();
            cardsColors[1] = colour2.ToString();

            return cardsColors;
        }


        private string GetBattleResult(string card1, string card2, string[] cardsColors)
        {
            var pairValue = GiveCardsValue();
            var result = LookForWinner(pairValue);
            string[] results = new string[3] { card1, card2, result };
            result = string.Join(", ", results);

            return result;
        }

        private int GiveCardsValue()
        {
            int pairValue = 0;
            for (int i = 0; i < cardsColors.Length; i++)
            {
                if (cardsColors[i] == "C")
                    pairValue += -1;
                else if (cardsColors[i] == "H")
                    pairValue += 1;
                else if (cardsColors[i] == "D" || cardsColors[i] == "S")
                    pairValue += 0;
            }
            return pairValue;
        }

        private string LookForWinner(int pairValue)
        {
            string result = "";

            if (pairValue <= -1)
                result = "loss";
            else if (pairValue >= 1)
                result = "win";
            else
                result = "tie";

            return result;
        }
    }
}
