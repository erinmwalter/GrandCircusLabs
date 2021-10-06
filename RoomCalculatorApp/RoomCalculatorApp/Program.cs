using System;

namespace RoomCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double roomHeight, roomLength, roomWidth, floorArea, roomVolume, wallArea, roomPerimeter;
            int numCarpetSquares, gallonsPaint;
            char runAgain = 'y';


            Console.WriteLine("Welcome to the Room Calculator App.");

            while (runAgain == 'y')
            {
                //get user input for length, height, width of room
                roomLength = GetRoomLength();
                roomWidth = GetRoomWidth();
                roomHeight = GetRoomHeight();

                //calculate room dimensions
                floorArea = GetFloorArea(roomLength, roomWidth);
                roomVolume = GetRoomVolume(roomLength, roomWidth, roomHeight);
                roomPerimeter = GetRoomPerimeter(roomLength, roomWidth);
                wallArea = GetWallArea(roomPerimeter, roomHeight);

                //calculate amount of carpet and paint needed
                numCarpetSquares = GetCarpetAmount(floorArea);
                gallonsPaint = GetGallonsPaint(wallArea);

                //display all values to user
                Console.WriteLine();
                Console.WriteLine("You Entered: ");
                Console.WriteLine($"Room Length: {roomLength}, Room Width: {roomWidth}, Room Height: {roomHeight}");
                Console.WriteLine();
                Console.WriteLine($"Room Area: {floorArea}");
                Console.WriteLine($"Room Perimeter: {roomPerimeter}");
                Console.WriteLine($"Room Volume: {roomVolume}");
                Console.WriteLine();
                Console.WriteLine($"You need {numCarpetSquares} carpet squares and {gallonsPaint} gallons paint.");
                Console.WriteLine();

                //prompt user if they want to run program again
                Console.WriteLine("Would you like to enter a different room (y/n)?");
                runAgain = char.Parse(Console.ReadLine());
            }

            Console.WriteLine("Program Exited. Goodbye.");


        }

        //method to have user enter room length
        public static double GetRoomLength()
        {
            double roomLength;

            Console.Write("Enter Length of Room: ");
            string userInput = Console.ReadLine();
            roomLength = double.Parse(userInput);

            return roomLength;
        }

        //method to have user enter room width
        public static double GetRoomWidth()
        {
            double roomWidth;

            Console.Write("Enter Width of Room: ");
            string userInput = Console.ReadLine();
            roomWidth = double.Parse(userInput);

            return roomWidth;
        }

        //method to have user enter height of room
        public static double GetRoomHeight()
        {
            double roomHeight;

            Console.Write("Enter Height of Room: ");
            string userInput = Console.ReadLine();
            roomHeight = double.Parse(userInput);

            return roomHeight;
        }
       

        //method calculates the area of the floor 
        public static double GetFloorArea(double roomWidth, double roomLength)
        {
            return (roomWidth * roomLength);

        }

        //method calculates the area of the walls
        public static double GetWallArea(double roomPerimeter, double roomHeight)
        {
            return (roomPerimeter * roomHeight);

        }

        //method calculates the volume of the room
        public static double GetRoomVolume(double roomWidth, double roomLength, double roomHeight)
        {
            return roomHeight * roomWidth * roomLength;

        }

        //method calculates the perimeter of the room
        public static double GetRoomPerimeter(double roomWidth, double roomLength)
        {
            return ((2 * roomWidth) + (2 * roomLength));

        }
        //method calculates number of carpet tiles needed (rounded up to nearest integer value)
        public static int GetCarpetAmount(double floorArea)
        {
            return (int)Math.Ceiling(floorArea / 5);
        }

        //method calculates how many gallons of pain needed for walls (rounded up to nearest integer value)
        public static int GetGallonsPaint(double wallArea)
        {
            return (int)Math.Ceiling(wallArea / 5);
        }
    }
}