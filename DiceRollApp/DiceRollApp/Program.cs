using System;

namespace DiceRollApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName;
            int numDiceSides, numDiceRolled, diceRollResult, diceTotal;
            bool runAgain = true;

            Console.WriteLine("Welcome to the Dice Roll App!");
            userName = HelperMethods.GetInput("Enter Your Name: ");

            while (runAgain)
            {
                diceTotal = 0; //resets total of dice rolls to zero at top of loop.

                //gets user input
                numDiceSides = int.Parse(HelperMethods.GetInput("Enter number of sides on dice: "));
                numDiceRolled = int.Parse(HelperMethods.GetInput("Enter number of dice to roll: "));

                //runs loop to roll dice as many times as user specified and add up dice total.
                Console.WriteLine("Rolling Dice...");

                for (int i = 1; i <= numDiceRolled; i++)
                {
                    diceRollResult = DiceRoll(numDiceSides);
                    Console.WriteLine($"You Rolled a {diceRollResult}.");
                    diceTotal += diceRollResult;
                }

                Console.WriteLine($"Total Dice Roll: {diceTotal}");
                Console.WriteLine("Analyzing dice total...");
                HelperMethods.PauseProgram();

                runAgain = HelperMethods.Continue();
            }


        }

        public static int DiceRoll(int numDiceSides)
        {
            int diceResult;
            Random diceRoll = new Random();

            diceResult = diceRoll.Next(1, numDiceSides);
            return diceResult;
        } 

        public static void AnalyzeDiceTotal(int diceTotal, int numSides, int numRolls)
        {
            
        }

    }
}
