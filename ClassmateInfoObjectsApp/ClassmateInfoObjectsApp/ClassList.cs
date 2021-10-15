using System;
using System.Collections.Generic;
using System.Text;

namespace ClassmateInfoObjectsApp
{
    class ClassList
    {
        private List<Student> classList = new List<Student>();

        //this method will take all the information from each of the lists
        //and then run them through a for loop and build a student list
        public void FillRoster()
        {
            List<Student> studentList = new List<Student>();
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

            for (int i = 0; i < studentFirstNames.Count; i++)
            {
                Student student = new Student(studentFirstNames[i], studentLastNames[i], favoriteFoods[i], hometowns[i]);
                classList.Add(student);
            }
        }

        //searches for student in class list by name
        public void FindByName()
        {
            bool wasFound = false;
            string classmateName = GetInput("Enter classmate name to search: ");
            foreach (Student student in classList)
            {
                if (student.FirstName == classmateName)
                {
                    int index = classList.IndexOf(student);
                    classList[index].GetStudentInfo();
                    wasFound = true;
                }
            }
            if (!wasFound)
            {
                Console.WriteLine("Student not found. Please try again.");
                FindByName();
            }
        }

        //an add-on to the assignment I made just to practice OOP
        //prints entire class roster to screen
        //one thing that i could do in the future is have it check by first AND last name to ensure entry is unique.
        //though all names in our class are unique, there could easily be two people with the same first name in a class.
        //for purposes of this lab, did not do that. 
        public void PrintList()
        {
            Console.WriteLine("\n====================List of All Students:=====================");
            Console.WriteLine($"First Name   LastName     Favorite Food               Hometown");
            foreach (Student student in classList)
            {
                Console.WriteLine($"{student.FirstName,10}{student.LastName,11}\t{student.FavoriteFood,15}\t{student.Hometown,22}");
            }
            Console.WriteLine("==============================================================");
        }

        //adds student to roster if they are not already on the roster
        public void AddNewStudent()
        {
            string firstName = GetInput("Enter Student First Name: ");
            string lastName = GetInput("Enter student Last Name: ");
            string favoriteFood = GetInput("Enter student Favorite Food: ");
            string hometown = GetInput("Enter Hometown: ");
            bool studentFound = false;

            foreach (Student student in classList)
            {
                if (student.FirstName == firstName)
                {
                    Console.WriteLine($"I'm sorry, {firstName} already exists in list. Unable to add.");
                    studentFound = true;
                    break;
                }
            }
            if(!studentFound)
            {
                    Student student = new Student(firstName, lastName, favoriteFood, hometown);
                    classList.Add(student);
                    Console.WriteLine($"{firstName} successfully added.");
            }
        }

        //method to get input from user and return a string
        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();

        }

        //finds classmate by index # reference
        public void FindByNumber()
        {
            int index=0;
            bool goodInput = false;
            while (!goodInput)
            {
                try
                {
                    index = int.Parse(GetInput($"Enter number 1-{classList.Count}: "));
                    if (index <= 0 || index > classList.Count)
                    {
                        throw new NumOutOfBounds();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input invalid, try again.");
                    continue;
                }
                catch(NumOutOfBounds e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            classList[index - 1].GetStudentInfo();

        }

        //custom exception block for the try catch in the find by number method 
        public class NumOutOfBounds : Exception
        {
            public override string Message
            {
                get
                {
                    return "Out of Range, must be > 0 and less than class roster size. Try again.";
                }
            }
        }

    }

}