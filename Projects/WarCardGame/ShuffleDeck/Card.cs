using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeck {

    public class Card {
        // contents
        private int rank;
        private char suit;

        // properties
        public int Rank { get; set; }
        public char Suit { get; set; }

        // constructor
        public Card() { }

        public Card(int r, char s) {
            Rank = r;
            Suit = s;
        }

    }
}
