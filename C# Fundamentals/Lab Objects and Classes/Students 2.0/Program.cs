using System;
using System.Linq;
using System.Collections.Generic;

namespace Students_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string line = Console.ReadLine();
            while (line!="end") 
            {
                string[] tokens = line.Split();
                IsExisting(students,tokens[0],tokens[1],int.Parse(tokens[2]),tokens[3]);
                //Student std = new Student()
                //{
                //    FirstName = tokens[0],
                //    LastName=tokens[1],
                //    Age=int.Parse(tokens[2]),
                //    HomeTown=tokens[3]
                //};
                line = Console.ReadLine();
                
            }
            
            string homeTown = Console.ReadLine();
            List<Student> repeatedHomeTowns = students.Where(x => x.HomeTown == homeTown).ToList();
            foreach (Student students1 in repeatedHomeTowns)
            {
                Console.WriteLine($"{students1.FirstName} {students1.LastName} is {students1.Age} years old.");
            }
            
            
        }
        static void IsExisting(List<Student> students,string firtsName,string lastName,int age,string city)
        {
            Student existingStudent = students.FirstOrDefault(x => x.FirstName == firtsName && x.LastName == lastName);
            if (existingStudent==null)
            {
               
                Student std = new Student()
                {
                    FirstName = firtsName,
                    LastName = lastName,
                    Age = age,
                    HomeTown = city
                };
                students.Add(std);
            }
            else
            {
                existingStudent.FirstName = firtsName;
                existingStudent.LastName = lastName;
                existingStudent.Age = age;
                existingStudent.HomeTown = city;
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
