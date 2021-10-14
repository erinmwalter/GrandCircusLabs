using System;
using System.Collections.Generic;
using System.Text;

namespace ClassmateInfoObjectsApp
{
    class ClassroomRosterBuilder
    {
        //this method will take all the information from each of the lists
        //and then run them through a for loop and build a student list
        public List<Student> FillRoster() 
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
                studentList.Add(student);
            }

            return studentList;
    } 
        }
}
