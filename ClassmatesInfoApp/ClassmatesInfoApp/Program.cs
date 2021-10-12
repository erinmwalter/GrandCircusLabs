using System;
using System.Collections.Generic;

namespace ClassmatesInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string classmateName;
            bool runAgain = true, moreInfo = true;
            int classmateIndex;
            string userChoice;

            //these are the three lists of student information, each list's index values correspond to the same student.
            //IE hometown[0], studentFirstNames[0], and favoriteFoods[0] are all the same student's information:

            List<string> studentFirstNames = new List<string>() 
            { 
                "Ramone", "Erin", "Anu", "Huy", "Marjorie", "Calyn", "Rick", "Cordero", "Cullin", "James", "Richard"
            };

            List<string> studentLastNames = new List<string>()
            {
                "Lynch", "Walter", "Reddy", "Phan", "Patton", "Greene", "Magdaleno", "Ebberhart", "Flynn", "Mitchell", "Moss"
            };

            List<string> hometowns = new List<string>() 
            { "Fort Lauderdale, FL", "Troy, MI", "Rochester Hills, MI", "Lansing, MI", "Detroit, MI", "Portage, MI", "Gilbert, AZ", "Berkley, MI", "Fowlerville, MI", "Yap, FSM", "Canton, MI"
            };

            List<string> favoriteFoods = new List<string>() 
            { 
             "Chicken Soup", "Tacos", "Tacos", "Korean BBQ", "Lasagna", "Mac and Cheese", "Hamburger", "Any Type of BBQ", "Pad Thai", "Katsu", "Sushi"
            };


            Console.WriteLine("Welcome! Let's get to know our classmates!");

            while (runAgain)
            {
                //this is the MAIN menu that will give options to search by name or number
                DisplayMainMenu();
                userChoice = GetInput("Enter your choice: ");
                if (userChoice == "1")
                {
                    //subtracts 1 from the user's choice because they are entering num 1-11, however the list is indexed 0-10
                    classmateIndex = int.Parse(GetInput("Enter number 1-11: ")) - 1;
                }
                else if (userChoice == "2")
                {
                    //asks for user input
                    classmateName = GetInput("Enter a name of a classmate: ");
                    //searches for the index of this input, if not found will be -1.
                    classmateIndex = studentFirstNames.IndexOf(classmateName);
                }
                else if (userChoice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Menu Option, let's try again... ");
                    continue;
                }

                //once a classmate index is established, then will enter a secondary set of options to let user choose
                //what sort of information they want to know about the user. Of course, this will only run if their 
                //input is either found (IE not -1), and less than the count of the student names list.
                if (classmateIndex >= 0 && classmateIndex < studentFirstNames.Count)
                {
                    //if the input was valid and found in the classmate name list, then it will ask the user what info
                    //they would like to get about that classmate. 
                    while (moreInfo) {
                        DisplayOptions(studentFirstNames[classmateIndex]);
                        userChoice = GetInput("Choose a number: ");
                        if (userChoice == "1")
                        {
                            Console.WriteLine($"{studentFirstNames[classmateIndex]}'s hometown is {hometowns[classmateIndex]}");
                        }
                        else if (userChoice == "2")
                        {
                            Console.WriteLine($"{studentFirstNames[classmateIndex]}'s favorite food is {favoriteFoods[classmateIndex]}");
                        }
                        else if (userChoice == "3")
                        {
                            Console.WriteLine($"{studentFirstNames[classmateIndex]}'s last name is {studentLastNames[classmateIndex]}");
                        }
                        else if (userChoice == "4")
                        {
                            //just in case they didn't actually want more information.
                            Console.WriteLine("Exiting to main menu...");
                            break;
                        }
                        else
                        {
                            //validating input, anything besides 1, 2, or 3 will give this error and have user retry input
                            Console.WriteLine("I'm sorry, I didn't understand, please enter 1, 2, or 3: ");
                            continue;
                        }

                        moreInfo = Continue($"Do you want another piece of info for {studentFirstNames[classmateIndex]}? (y/n): ");
                     }

                }
                else
                {
                    Console.WriteLine($"I'm sorry, invalid entry. Let's try again...");
                    continue;
                }

                runAgain = Continue("\nDo you want info on another classmate? (y/n): ");
            }

            Console.WriteLine("Program Exited. Goodbye.");

        }

        //method for getting input, will output a message and then return a string of input from user
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();

            return userInput;
        }

        //method to ask user if they want to run program again. 
        public static bool Continue(string prompt)
        {
            string answer = GetInput(prompt).ToLower();
            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I'm sorry, I don't understand, please try again. Enter only y/n.");
                return Continue(prompt);
            }
        }

        //method displays a menu with options for the user to select once they have chosen a classmate. 
        public static void DisplayOptions(string classmateName)
        {
            Console.WriteLine($"\nYou Entered: {classmateName}");
            Console.WriteLine($"What information would you like to know about {classmateName}?");
            Console.WriteLine("1: Hometown.");
            Console.WriteLine("2: Favorite Food.");
            Console.WriteLine("3: Last Name.");
            Console.WriteLine("4: Actually, I don't need more information, get me out of here!");
        }


        // method to display the main menu, just to un-crowd the main method. 
        public static void DisplayMainMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1: Search by Student Number.");
            Console.WriteLine("2: search by Student Name.");
            Console.WriteLine("3: Exit.");
        }

    }
}
