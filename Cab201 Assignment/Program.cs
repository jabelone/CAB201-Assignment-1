using System;

namespace Cab201_Assignment
{

    /*
 * Calculates fuel consumption in l/100km and the equivalent mpg,
 * input units of measurement are litres (l) for the fuel used and
 * kilometres (km) for the distance travelled
 *
 * Author Jaimyn Mayer, n9749331
 * Date: August 2016
 *
 */

    class Program
    {

        // Probably bad but lets declare "global variables" to make life easy
        Double kms = 0;
        Double fuel = 0;

        // Get our distance from the user
        public bool getInputKms()
        {
           try // Try to get it, catch any errors (ie probably not a number)
            {

                Console.WriteLine("Hey fam, please enter a number of kilometers: "); // Tell them what we're asking
                kms = Double.Parse(Console.ReadLine()); // Get the input
                Console.Clear();
                Console.WriteLine("That's totally lit, you entered a total distance of: {0}", kms); // Let them know what they entered
                return true; // Why not, we successfully got input
            }

            catch // The user done goofed
            {
                Console.Clear();
                Console.WriteLine("Lol enter a number you numpty..."); // Tell the user they were stupid
                return false; //Why not, we didn't successfully get input
            }
        }

        // Get the amount of fuel used from user
        public bool getInputFuel()
        {
            try // Try to get it, catch any errors (ie probably not a number)
            {
                Console.WriteLine("Yo fam, please enter fuel used in litres: "); // Tell them what we're asking
                fuel = Double.Parse(Console.ReadLine()); // Get the input
                Console.Clear();
                Console.WriteLine("Hey mah man, you entered a total fuel use (in litres) of: {0}", fuel); // Let them know what they entered
                return true; // Why not, we successfully got input
            }

            catch // The user done goofed
            {
                Console.Clear();
                Console.WriteLine("Lol, you entered an invalid value numpty.  It must be an actual number that's greater than 20 litres."); // Tell the user they were stupid
                return false; //Why not, we didn't successfully get input
            }
        }

        // Calculate the litres per hundred kilometres
        public double litrePerHundred(Double fuel, Double kilometers)
        {
            // the formula is pretty basic - fuel / kilometers * 100
            // We round to two decimal places to avoid horrible looking outputs
            return Math.Round((fuel / kilometers) * 100.0, 2);
        }

        public double MPG(Double litres)
        {
            // the formula is pretty basic - 282.48 / litres per 100km
            // We round to two decimal places to avoid horrible looking outputs
            return Math.Round(282.48 / litres, 2);
        }

        public bool exitGraceful()
        {
            // I don't really know how you're meant to exit gracefully
            int input; // Temp variable
            Console.WriteLine("Press y then enter to continue with another calculation or just enter to exit");
            input = Console.Read();
            if (input == 89 || input == 121) // Check the input
            {
                return true; // Return true it it's Y or y
            }
            else
            {
                return false;
            }
        }

        void reset()
        {
            // Reset the values to nothing and clear console
            Console.Clear();
            kms = 0;
            fuel = 0;
        }

        void run()
        {

            while (fuel < 20) // Keep trying to get input until a valid number is entered
            {
                if (fuel > 0) // If this isn't the first time
                {
                    Console.WriteLine("Lol, you're a numpty.  Enter an actual number that's at least 20 litres."); // Tell the user they were stupid
                }

                getInputFuel();
            }

            while (kms < fuel * 8) // Keep trying to get input until a valid number is entered
            {
                if (kms > 0) // If this isn't the first time
                {
                    Console.WriteLine("Lol, you're a numpty.  Enter an actual number that's at least {0} kms.", fuel * 8); // Tell the user they were stupid
                }

                getInputKms();
            }
            
            Console.WriteLine("\nYour effiency in litres/100km is: {0} ", litrePerHundred(fuel, kms)); //Print litres per hundred kms
            Console.WriteLine("Your effiency in MPG is: {0} ", MPG(litrePerHundred(fuel, kms))); //Print MPG
        }

        static void Main(string[] args) //Main program
        {
            Program p = new Program(); // Make an instance of the class

            p.run(); //Always run at least once

            while (p.exitGraceful()) // If we should keep going, then keep going
            {
                p.reset(); // Reset everything before we do another
                p.run(); // Do another calculation
            }


        }
    }
}
