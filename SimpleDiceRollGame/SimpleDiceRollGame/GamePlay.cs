using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDiceRollGame
{
    
    class GamePlay
    {
        List<GameTracker> scoreKeeper = new List<GameTracker>();
        GameTracker newPlayer = new GameTracker("name", '!', 0);
        GameTracker tempPlayer;
        public void InitializeGame(List<PlayerData> playerRoster)
        {
            Console.WriteLine("Welome to the Dice Roll Game!");
            Console.WriteLine("Each of you will take turns rolling a die and add that to your total.");
            Console.WriteLine("Whoever gets to 100 first wins!");
            Console.WriteLine("\nLet's get started! Here's who is playing: ");
            foreach (PlayerData player in playerRoster)
            {
                player.PrintData();
                newPlayer.SetPlayerValues(player.GetName(), player.GetToken(), 0);
                newPlayer.GetPlayerData(out tempPlayer);
                scoreKeeper.Add(tempPlayer);
            }

            Console.WriteLine("\nEveryone will start at ZERO, let's update your scores now: ");
            foreach (GameTracker player in scoreKeeper)
            {
                player.PrintData();
            }



                
        }
    }
}
