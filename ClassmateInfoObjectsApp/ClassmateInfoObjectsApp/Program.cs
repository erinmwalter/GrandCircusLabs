using System;
using System.Collections.Generic;

namespace ClassmateInfoObjectsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string userChoice= "0";
            ClassList classRoster = new ClassList();
       
            Console.WriteLine("Welcome to the Classmate App");
            Console.WriteLine("Let's get to know your classmates...");
            Console.WriteLine("Press any key to get started...");
            Console.ReadKey();

            //fills up initial roster.
            classRoster.FillRoster();

            while (userChoice != "5")
            {
                //gets user's choice for search method.
                MainMenuDisplay();
                userChoice = GetInput("Enter Your Choice: ");

                if(userChoice == "1")
                {
                    //finds student by name
                    classRoster.FindByName();
                }
                else if(userChoice == "2")
                {
                    //finds student by number
                    classRoster.FindByNumber();
                }
                else if(userChoice == "3")
                {
                    //adds new student
                    classRoster.AddNewStudent();
                }
                else if (userChoice == "4") 
                {
                    //prints list of all students
                    classRoster.PrintList();
                }
                else if (userChoice == "5")
                {
                    Console.WriteLine("Program Exiting, goodbye");
                    break;
                }
                else
                {
                    //error handling.
                    Console.WriteLine("I'm sorry, i don't understand. Try again.");
                    continue;
                }
                Console.ReadKey();
            }
        }

        //Main menu display method
        public static void MainMenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1.Find student by name");
            Console.WriteLine("2. Find student by number");
            Console.WriteLine("3. Add New Student.");
            Console.WriteLine("4. Display all students.");
            Console.WriteLine("5. Exit Program");
        }

        //method to get input from user and return a string
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

    }
}
