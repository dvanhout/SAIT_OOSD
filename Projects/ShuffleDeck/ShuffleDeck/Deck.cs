using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeck {

    class Deck {
        const int DECK_SIZE = 52;
        private Card[] cards = new Card[DECK_SIZE]; // declare array of cards (52 in a deck)
        
        // constructor
        public Deck() {
            int i = 0;
           
            char[] suit = new char[4]; // array of chars for suits
            suit[0] = '\u2660';
            suit[1] = '\u2665';
            suit[2] = '\u2663';
            suit[3] = '\u2666';
            foreach (char c in suit) {
                for (int rank = 1; rank < 14; rank++) {
                    cards[i] = new Card(rank, c);
                    i++;
                }
            }
        }

        // string representation of card e.g. rank-suit
        public string CardString(int i) {
            string str = "";
            // 1 = Ace, 11 = Jack, 12 = Queen, 13 = King, else use number
            switch (cards[i].Rank) {
                case 1: 
                    str += "A" + "-" + cards[i].Suit;
                    break;
                case 11:
                    str += "J" + "-" + cards[i].Suit;
                    break;
                case 12:
                    str += "Q" + "-" + cards[i].Suit;
                    break;
                case 13:
                    str += "K" + "-" + cards[i].Suit;
                    break;
                default:
                    str += cards[i].Rank.ToString() + "-" + cards[i].Suit;
                    break;
            }                
            return str;  
        }

        // method - shuffles the deck
        public void ShuffleDeck() { // need out statement? 
            Random rnd = new Random();
            for (int i = 0; i < cards.Length - 1; i++) {
                int rn = rnd.Next(i, cards.Length); // get new random number

                // swap cards with random one
                Card crd = new Card(); // temp card for the swap
                crd = cards[i];
                cards[i] = cards[rn]; 
                cards[rn] = crd;
            }
        }
    }
}
