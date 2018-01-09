using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasTree {
    class Program {
        static void Main(string[] args) {
            int spaces, height, stars = 1;

            Console.WriteLine("Enter Height of Christmas Tree");
            height = Convert.ToInt16(Console.ReadLine()); //get tree height from user
            spaces = height - 1; //calculate number of spaces to print

            // height = number of lines
            for (int i = 0; i < height; i++) {
                // print spaces
                for (int j = spaces; j > 0; j--) {
                    Console.Write(" "); 
                }
                // print stars
                for (int k = 0; k < stars;  k++ ) {
                    Console.Write("*"); 
                }
                
                Console.Write("\n"); // new line
                stars = stars + 2; // increment number of stars to print for next loop
                spaces--; // decrease number of spaces to print on next loop

            }

            Console.WriteLine("\n\nPress any key"); //prompt to exit program
            Console.ReadKey(); //exit
        }
    }
}
