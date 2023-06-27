using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }


    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string city = tokens[3];
                Students std = new Students()
                {
                    FirstName = tokens[0],
                    LastName = tokens[1],
                    Age = int.Parse(tokens[2]),
                    HomeTown = tokens[3]
                };
                students.Add(std);
                line = Console.ReadLine();
            }
            string filterLastName = Console.ReadLine();
            List<Students> filteredStudents = students.Where(x => x.LastName == filterLastName).ToList();
            foreach (Students student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
            //foreach (Students student in students)
            //{
            //    if (student.HomeTown==filterCity)
            //    {
            //        Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            //    }
            //}
        }
            
        
        
                

            

        
    }
}
