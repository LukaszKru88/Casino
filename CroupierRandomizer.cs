using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class CroupierRandomizer : Croupier
    {
        private string[] deck;
        private List<string[]> deckList = new List<string[]>();

        public string[] RandomizeTheDeck(string[] lines)
        {
            foreach (string line in lines)
            {
                key = GetCardRange(line);
                if (key[0] == "Task impossible – improper CardDeck in the first line")
                    return key;
                else
                    deckList.Add(CreateTheDeck(key));
            }

            deck = randomizeDeck();
            return deck;
        }

        private string[] randomizeDeck()
        {
            string[] exception = new string[1] { "Task 3 impossible - too less cards in decks to get 10 random cards" };
            List<string> allCards = new List<string>();
            foreach (string[] cards in deckList)
            {
                foreach (string card in cards)
                {
                    allCards.Add(card);
                }
            }

            if (allCards.Count < 10)
                return exception;

            string[] randomCards = new string[10];
            Random randomizer = new Random();
            for (int i = 0; i < 10; i++)
            {
                var index = randomizer.Next(allCards.Count);
                var card = allCards[index];
                allCards.RemoveAt(index);
                randomCards[i] += card;
            }

            return randomCards;
        }
    }
}
