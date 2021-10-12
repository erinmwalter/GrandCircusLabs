using System;
using System.Collections.Generic;

namespace SimpleDiceRollGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerData player = new PlayerData("none", '!');
            GamePlay startPlaying= new GamePlay();
            PlayerData person;
            string userChoice;
            
            List<PlayerData> playerRoster = new List<PlayerData>();

            Console.WriteLine("Welcome to the Dice Roll Game!");
            Console.WriteLine($"Dice Roll Game is a 2-4 player game. \nRace your friends (or a computer) to the finish line!");
            bool runAgain = true;
            bool startGame = false;
           

            while (runAgain)
            {
                startGame = false;
                while (!startGame)
                {
                    Console.WriteLine("\nMain Menu:");
                    Console.WriteLine("1: Add New Player. ");
                    Console.WriteLine("2: Add Computer Player. ");
                    Console.WriteLine("3: Print Current Player Roster. ");
                    Console.WriteLine("4: Start New Game! ");
                    Console.WriteLine("5: Exit Game ");
                    if (playerRoster.Count < 4)
                    {
                        userChoice = HelperMethods.GetInput("Enter Your Choice: ");
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer Capacity Reached.");
                        userChoice = "4";
                    }

                    if(userChoice == "1")
                    {
                        Console.WriteLine("1");
                        player.SetPlayerInfo();
                        player.GetPlayerInfo(out person);
                        playerRoster.Add(person);
                    }
                    else if (userChoice == "2")
                    {
                        Console.WriteLine("2");
                        player.SetComputerPlayerInfo();
                        player.GetPlayerInfo(out person);
                        playerRoster.Add(person);
                    }
                    else if (userChoice == "3")
                    {
                        Console.WriteLine("\nPlayer List:");
                        foreach (PlayerData piece in playerRoster)
                        {
                            piece.PrintData();
                        }
                    }
                    else if (userChoice == "4")
                    {

                        Console.WriteLine("Starting Game!");
                        startGame = true;
                        break;
                    }
                    else if (userChoice == "5")
                    {
                        Console.WriteLine("Goodbye!");
                        runAgain = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry, invalid selection. Try again.");

                    }
                }

               startPlaying.InitializeGame(playerRoster);

                if(!runAgain)
                {
                    break;
                }
                else
                {
                    runAgain = HelperMethods.Continue();
                }
            }

        }

    }
}
