//Lucas Persson Öhlin - Klass (SUT22)
using System;

namespace NumbersGame {
    class Program {

        //Variables
        public static int userGuess;
        public static byte userTries;
        //so we don't need to write this line everywhere locally
        public static Random random = new Random();

        private static void Main(string[] args) {
            Console.WriteLine("Välkommen till random nummer spelet!");

            while (true) {
                Console.WriteLine("Välj svårighetsgrad! Mellan 1-5");
                int levelChoice = int.Parse(Console.ReadLine());
                GameHandler(levelChoice);

                Console.WriteLine("\nVill du spela igen? Ja eller Nej\n");
                string userChoice = Console.ReadLine();
                //returns out of the while loop (closes the game) if the inputed answer is "nej" countinues as normal if anything else is written
                if (userChoice.ToLower() == "nej") return;
            }
        }

        private static void GameHandler(int gameLevel) {
            //Handles users difficulty choice, first number in Game() is the 2nd number for the random generator
            //and the 2nd is for the amount of tries availible for the user
            if (gameLevel == 1) { Game(11, 10);}
            if (gameLevel == 2) { Game(21, 8); }
            if (gameLevel == 3) { Game(31, 6); }
            if (gameLevel == 4) { Game(41, 5); }
            if (gameLevel == 5) { Game(51, 5); }
            else
                Console.WriteLine("Inte ett korrekt nummer...");
        }

        private static void Game(byte number, int tries) {
            //Changes the "number" and "tries" depending on difficulty
            Console.WriteLine($"\nVälkommen! Jag tänker på ett nummer. Kan du gissa vilket?\nTalet är mellan 1-{number - 1}. | Du har {tries} fösök.\n");
            byte rndmNum = (byte)random.Next(1, number); //parses the random number to byte
            userTries = 0;

            //Easier to test code if you don't have to guess the number each time lol
            //Console.WriteLine("Generated number: " + rndmNum);

            //Do (run) this code while the two integer's aren't the same
            do {
                userGuess = int.Parse(Console.ReadLine());

                //Checks the user's guess with the generated number
                CheckGuess(userGuess, rndmNum, tries);
                //if the user has guessed the amount of guesses availible for that difficulty
                if (userTries == tries) {
                    Console.WriteLine($"Tyvärr du lyckades inte gissa talet på {tries} försök!");
                    return;
                }
            } while (rndmNum != userGuess);

            //If guess is correct
            Console.WriteLine("Woho! Du gjorde det!");
        }

        private static void CheckGuess(int userInput, int randomNumber, int tries) {
            //Returns if the guess is the same as the generated number
            if (userInput == randomNumber) return;

            userTries += 1;
            //Changes the answer to positive using Math.Abs (Absolute) if it less or equals to two the bool is true
            bool closeGuess = Math.Abs(userInput - randomNumber) <= 2;
            
            //if user guesses doesnt amounts to the given tries 
            if (userTries != tries) {
                if (closeGuess)
                    CloseResponse();
                if (userInput < randomNumber && closeGuess != true)
                    LowResponse();
                if (userInput > randomNumber && closeGuess != true)
                    HighResponse();
            } else {
                return;
            }
        }

        //Different responses for guesses to high
        public static void HighResponse() {
            byte rndmResponse = (byte)random.Next(1, 6);
            if (rndmResponse == 1)
                Console.WriteLine("Tyvärr du gissade för högt!");
            if (rndmResponse == 2)
                Console.WriteLine("Du siktar för högt!");
            if (rndmResponse == 3)
                Console.WriteLine("Inte äns nära! Du är ju uppe i himlen!");
            if (rndmResponse == 4)
                Console.WriteLine("Bra gissat men det var för högt");
            if (rndmResponse == 5)
                Console.WriteLine("Haha! Det var för högt!");
        }

        //Different responses for guesses to low
        public static void LowResponse() {
            byte rndmResponse = (byte)random.Next(1, 6);
            if (rndmResponse == 1)
                Console.WriteLine("Tyvärr du gissade för lågt!");
            if (rndmResponse == 2)
                Console.WriteLine("Du siktar för lågt!");
            if (rndmResponse == 3)
                Console.WriteLine("Du gräver ju! För lågt!");
            if (rndmResponse == 4)
                Console.WriteLine("Bra försök, men det var för lågt!");
            if (rndmResponse == 5)
                Console.WriteLine("Haha! Den där var för låg!");
        }

        //Different responses for guesses that are clsoe
        public static void CloseResponse() {
            byte rndmResponse = (byte)random.Next(1, 3);
            if (rndmResponse == 1)
                Console.WriteLine("Nu bränns det som attans!");
            if (rndmResponse == 2)
                Console.WriteLine("Nu är du nära!");
        }

    }

}


