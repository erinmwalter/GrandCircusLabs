using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDiceRollGame
{
    class GameTracker
    {
        private string playerName;
        private char playerToken;
        private int playerScore;

        public GameTracker(string playerName, char playerToken, int playerScore)
        {
            this.playerName = playerName;
            this.playerToken = playerToken;
            this.playerScore = playerScore;
        }

        public void SetPlayerValues(string name, char token, int score)
        {
            this.playerName = name;
            this.playerToken = token;
            this.playerScore = score;
        }

        public void PrintData()
        {
            Console.WriteLine($"Name: {playerName, 10} | Token: {playerToken,3} | Score: {playerScore,5}");
        }

        public void PrintHistogram()
        {
            Console.Write($"{playerName}: ");
            for(int i = 1; i <= playerScore; i++)
            {
                Console.Write(playerToken);
            }
            Console.WriteLine();
        }

        public int GetPlayerScore()
        {
            return playerScore;
        }

        public void GetPlayerData(out GameTracker person)
        {
            GameTracker temp = new GameTracker(playerName, playerToken, playerScore);
            person = temp;
        }

        public int TakeTurn()
        {
            return HelperMethods.RandomIntegerGenerator(1, 6);
        }
    }
}
