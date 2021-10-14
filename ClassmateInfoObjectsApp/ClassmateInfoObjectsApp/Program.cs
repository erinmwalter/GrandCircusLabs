using System;
using System.Collections.Generic;

namespace ClassmateInfoObjectsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string userChoice= "0";
            int classmateIndex;
            //these will use ClassroomRosterBuilder to make a classroom list of Student objects
            ClassroomRosterBuilder rosterBuilder = new ClassroomRosterBuilder();
            List<Student> classroomRoster = rosterBuilder.FillRoster();

            Console.WriteLine("Welcome to the Classmate App");
            Console.WriteLine("Let's get to know your classmates...");
            Console.WriteLine("Press any key to get started...");
            Console.ReadKey();

            while (userChoice != "5")
            {
                //gets user's choice for search method.
                Console.Clear();
                MainMenuDisplay();
                userChoice = GetInput("Enter Your Choice: ");

                //either gets the classmate's index by NAME or NUMBER: 
                if(userChoice == "1")
                {
                    classmateIndex = FindByName(classroomRoster);
                    classroomRoster[classmateIndex].GetStudentInfo();
                }
                else if(userChoice == "2")
                {
                    classmateIndex = FindByNumber(classroomRoster.Count);
                    classroomRoster[classmateIndex].GetStudentInfo();
                }
                else if(userChoice == "3")
                {
                    AddNewStudent(ref classroomRoster);
                }
                else if (userChoice == "4") 
                {
                    PrintClassRoster(classroomRoster);
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

                
            }

        }


        //Main menu display method
        public static void MainMenuDisplay()
        {
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

        //finds classmate by name
        public static int FindByName(List<Student> classroomRoster)
        {
            string classmateName = GetInput("Enter classmate name to search: ");
            foreach (Student student in classroomRoster)
            {
                if (student.FirstName == classmateName)
                {
                    return classroomRoster.IndexOf(student);
                }
            }
            Console.WriteLine("Student not found. Please try again.");
            return FindByName(classroomRoster);
        }

        //finds classmate by index # reference
        public static int FindByNumber(int numStudents)
        {
            int index = -1;
            bool runAgain = true;
            while (runAgain)
            {
                try
                {
                    index = int.Parse(GetInput("Enter integer 1-11: "));
                    if (index <= 0 || index > numStudents)
                    {
                        throw new NumOutOfBounds();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input, must be an integer. Try again. ");
                    continue;

                }
                catch (NumOutOfBounds e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            return index-1;
        }

        //custom exception block for the try catch in the find by number method 
        public class NumOutOfBounds : Exception
        {
            public override string Message
            {
                get
                {
                    return "Must be between 1-11. Try again.";
                }
            }
        }

        //method will add a new student to classroom roster. 
        public static bool AddNewStudent(ref List<Student> classroomRoster)
        {
            string studentFirstName = GetInput("Enter Student First Name: ");
            string studentLastName = GetInput("Enter Student Last Name: ");
            string studentFavoriteFood = GetInput("Enter favorite food: ");
            string studentHometown = GetInput("Enter hometown: ");

            foreach (Student student in classroomRoster)
            {
                if (student.FirstName == studentFirstName)
                {
                    Console.WriteLine("Unable to add student, student already exists in database");
                    Console.ReadKey();
                    return false;
                }
            }
            Console.WriteLine("Adding new student...");
            Console.ReadKey();
            Student newStudent = new Student(studentFirstName, studentLastName, studentFavoriteFood, studentHometown);
            classroomRoster.Add(newStudent);
            return true;
        }

        //method will print out entire class list
        public static void PrintClassRoster(List<Student> classroomRoster)
        {
            Console.WriteLine("\n====================List of All Students:=====================");
            Console.WriteLine($"First Name   LastName     Favorite Food               Hometown");
            foreach(Student student in classroomRoster)
            {
                Console.WriteLine($"{student.FirstName,10}{student.LastName,11}\t{student.FavoriteFood,15}\t{student.Hometown,22}");
            }
            Console.WriteLine("==============================================================");
            Console.ReadKey();
        }

    }
}
