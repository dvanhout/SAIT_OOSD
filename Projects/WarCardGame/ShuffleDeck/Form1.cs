using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuffleDeck {

    public partial class btnFlip : Form {
        int inx1 = 0;
        int inx2 = 1;
        const int DECK_SIZE = 52; // size of deck
        Deck dk = new Deck(); // init deck 

        public btnFlip() {
            InitializeComponent();
        }

        // List unshuffled deck at start
        private void Form1_Load(object sender, EventArgs e) {
            ListCards(dk);
        }

        // clear contents of list box, shuffle deck, and show shuffled deck
        private void btnShuffle_Click(object sender, EventArgs e) {
            dk.ShuffleDeck(); // shuffle the deck
            // ListCards(dk); // display

        }

        // clear list box and show deck array
        private void ListCards(Deck d) {
            lstDeck.Items.Clear();
            for (int i = 0; i < DECK_SIZE; i++) {
                lstDeck.Items.Add(d.CardString(i));
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            txtCard1.Text = dk[inx1]

        }
    }
}
