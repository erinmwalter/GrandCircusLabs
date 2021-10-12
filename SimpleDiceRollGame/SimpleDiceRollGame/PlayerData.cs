using System;

namespace SimpleDiceRollGame
{
    class PlayerData
    {
        private string playerName;
        private char playerToken;
        private int comPlayerCounter = 1;

        public PlayerData(string playerName, char playerToken)
        {
            this.playerName = playerName;
            this.playerToken = playerToken;
        }

        public void SetPlayerInfo()
        {
            playerName = HelperMethods.GetInput("Enter Player Name: ");
            playerToken = char.Parse(HelperMethods.GetInput("Enter Player Token (#, $, %, &, or @: )"));
            ValidateToken(playerToken);
        }

        public void SetComputerPlayerInfo()
        {
            playerName = $"CP {comPlayerCounter}";
            playerToken = char.Parse(HelperMethods.GetInput("Enter Computer Player Token (#, $, %, &, or @): "));
            ValidateToken(playerToken);
            comPlayerCounter++;
        }

        public void GetPlayerInfo(out PlayerData player)
        {
            PlayerData person = new PlayerData(playerName, playerToken);
            player = person;
        }

        public string GetName()
        {
            return playerName;
        }

        public char GetToken()
        {
            return playerToken;
        }

        private bool ValidateToken(char token)
        {
            if (token != '#' && token != '$' && token != '%' && token != '&' && token != '@')
            {
                Console.Write("\nToken Invalid. Must be #, $, %, &, or @. Try Again. ");
                playerToken = char.Parse(HelperMethods.GetInput("\nTry Again: "));
                return ValidateToken(playerToken);
            }
            else return true;
        }

        public void PrintData()
        {
            Console.WriteLine($"Name: {playerName,10}, Token: {playerToken,2} ");
        }

    }
}
