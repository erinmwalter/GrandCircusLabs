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

            while (choice != "4")
            {
                Console.Clear();
                Console.WriteLine($"You Selected {FirstName}");
                Console.WriteLine("What do you want to know?");
                Console.WriteLine("1. Last Name.");
                Console.WriteLine("2. Favorite Food.");
                Console.WriteLine("3. Hometown.");
                Console.WriteLine("4. Exit");
                choice = Program.GetInput("Make your Selection: ");

                if (choice == "1")
                {
                    PrintLastName();
                }
                else if (choice == "2")
                {
                    PrintFavoriteFood();
                }
                else if (choice == "3")
                {
                    PrintHometown();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Returning to main menu...");
                }
                else
                {
                    Console.WriteLine("I'm sorry, I didn't get that, try again please.");
                }
                Console.ReadKey();
            }
        }



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
    }
}
