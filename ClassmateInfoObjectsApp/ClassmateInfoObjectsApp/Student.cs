using System;
using System.Collections.Generic;
using System.Text;

namespace ClassmateInfoObjectsApp
{

    class Student
    {
        //each STUDENT object has these 4 properties:
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteFood { get; set; }
        public string Hometown { get; set; }

        //constructor:
        public Student(string FirstName, string LastName, string FavoriteFood, string Hometown)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.FavoriteFood = FavoriteFood;
            this.Hometown = Hometown;
        }

        //once student located on roster, this will be called to get specific info on student. 
        public void GetStudentInfo()
        {
            string choice = "0";

            while (choice != "5")
            {
                DisplayStudentMenu();
                choice = Program.GetInput("Make your Selection: ");

                if (choice == "1")
                {
                    //will print student's last name
                    PrintLastName();
                }
                else if (choice == "2")
                {
                    //will print favorite food
                    PrintFavoriteFood();
                }
                else if (choice == "3")
                {
                    //will print hometown
                    PrintHometown();
                }
                else if (choice == "4") 
                {
                    //a fun add-on I made to this program to play around with objects more
                    //this will allow user to modify info for the selected student
                    ModifyInfo();
                }
                else if (choice == "5")
                {
                    //breaks to main menu
                    Console.WriteLine("Returning to main menu...");
                    break;
                }
                else
                {
                    //error handling if user enters something invalid
                    Console.WriteLine("I'm sorry, I didn't get that, try again please.");
                }
                Console.ReadKey();
            }
        }


        //these four methods will be used to print student's info to screen. 
        public void PrintLastName()
        {
            Console.WriteLine($"{FirstName}'s last name is {LastName}");
        }

        public void PrintFavoriteFood()
        {
            Console.WriteLine($"{FirstName}'s favorite food is {FavoriteFood}");
        }

        public void PrintHometown()
        {
            Console.WriteLine($"{FirstName}'s hometown is {Hometown}");
        }

        //just a fun add-on method I made to practice with OOP and modifying info for a student
        public void ModifyInfo()
        {
            string choice ="0";
            while (choice != "5")
            {
                DisplayModificationOptions();
                choice = Program.GetInput("Enter Selection: ");
                if (choice == "1")
                {
                    FirstName = Program.GetInput("Enter new First Name: ");
                }
                else if(choice == "2")
                {
                    LastName = Program.GetInput("Enter new Last name: ");
                }
                else if (choice == "3")
                {
                    FavoriteFood = Program.GetInput("Enter new Favorite Food: ");
                }
                else if (choice == "4")
                {
                    Hometown = Program.GetInput("Enter new Hometown: ");
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("I'm sory, I didn't get that, try again... ");
                    continue;
                }
                Console.WriteLine("Success. Info updated.");
            }
        }

        //modification meu
        public void DisplayModificationOptions()
        {
            Console.WriteLine("\nWhat would you like to modify?");
            Console.WriteLine("1. Modify First Name");
            Console.WriteLine("2. Modify Last Name");
            Console.WriteLine("3. Modify Favorite Food");
            Console.WriteLine("4. Modify Hometown");
            Console.WriteLine("5. Return to menu.");
        }

        //main student menu display
        public void DisplayStudentMenu()
        {
            Console.Clear();
            Console.WriteLine($"You Selected {FirstName}");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. See Last Name.");
            Console.WriteLine("2. See Favorite Food.");
            Console.WriteLine("3. See Hometown.");
            Console.WriteLine("4. Modify Student Info");
            Console.WriteLine("5. Exit to Main Menu");
        }
    }
}
