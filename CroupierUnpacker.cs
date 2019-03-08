using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class CroupierUnpacker : Croupier
    {
        private string[] deck;

        public string[] UnpackTheDeck(string line)
        {
            key = GetCardRange(line);
            if (key[0] == "Task impossible – improper CardDeck in the first line")
                return key;
            else
                deck = CreateTheDeck(key);

            return deck;
        }
    }
}
