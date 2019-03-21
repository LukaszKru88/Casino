using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class CroupierHardGame : CroupierEasyGame
    {
        private int[][] Powers = new int[][]
        {
            new int[] { 3, 0, 0 },
            new int[] { 6, 0, 0 },
            new int[] { 9, 0, 0 }
        };

        private int[][] Bets = new int[][]
        {
            new int[] { 2, 3, 4 },
            new int[] { 0, 3, 6 },
            new int[] { -2, 3, 8 }
        };

        private string[] PowerBetHeaders = new string[]
            {
                "Power: Weak, Bet: Easy. Deck: ",
                "Power: Weak, Bet: Typical. Deck: ",
                "Power: Weak, Bet: Hard. Deck: ",
                "Power: Normal, Bet: Easy. Deck: ",
                "Power: Normal, Bet: Typical. Deck: ",
                "Power: Normal, Bet: Hard. Deck: ",
                "Power: Strong, Bet: Easy. Deck: ",
                "Power: Strong, Bet: Typical. Deck: ",
                "Power: Strong, Bet: Hard. Deck: "
            };
        private int[] DecksLength = new int[9];
        private int[][] PowerBet = new int[9][];
        private string[] GameResults;
        private string[] deck;
        private int index = 0;
        private int loops = 4;

        public string[] PlayHardGame()
        {
            CreateDeck();
            EliminateTriads();
            AssignDecksLength();
            CreateHeaders();
            for (int i = 0; i < PowerBet.Length; i++)
            {
                deck = AssignCardsToValues(i, PowerBet);
                GameResults = PlayWarGame(deck, loops);
                for (int j = 0; j < loops; j++)
                    PowerBetHeaders[i] += Environment.NewLine + "*Game" + (j + 1) + " " + GameResults[j];             
            }
            return PowerBetHeaders;
        }

        private void CreateDeck()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    PowerBet[index] = new int[] { Powers[j][0] + Bets[k][0], Powers[j][1] + Bets[k][1], Powers[j][2] + Bets[k][2] };
                    index++;
                }
            }
        }

        private void EliminateTriads()
        {
            for (int i = 0; i < 9; i++)
            {
                var triad = PowerBet[i][0] / 3;
                PowerBet[i][2] -= triad;
            }
        }

        private string[] AssignCardsToValues(int i, int[][] PowerBet)
        {
            int count = 0;
            int figureNumber = 0;
            int colorNumber = 0;
            
            string[] cards = new string[DecksLength[i]];

            for(int j = 0; j < cards.Length; j++)
            {
                cards[j] = figures[figureNumber] + colors[colorNumber];
                figureNumber++;
                if (figureNumber == PowerBet[i][count] && count < 3)
                {
                    count++;
                    colorNumber++;
                    figureNumber = 0;
                }
            }

            return cards;
        }

        private void AssignDecksLength()
        {
            for (int i = 0; i < PowerBet.Count(); i++)
            {
                DecksLength[i] = PowerBet[i].Sum();
            }
        }

        private void CreateHeaders()
        {
            for(int i = 0; i < PowerBet.Length; i++)
            {
                PowerBetHeaders[i] += "[" + PowerBet[i][0].ToString() + "," + PowerBet[i][1].ToString() + "," + PowerBet[i][2].ToString() + "]";
            }
        }
    }
}
