using System;
using System.Linq;
using System.Collections.Generic;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> student = new List<Student>();
            string[] token;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                token = Console.ReadLine().Split();
                Student std = new Student();
                std.FirstName = token[0];
                std.LastName = token[1];
                std.Grade = double.Parse(token[2]);
                student.Add(std);
            }
            List<Student> Sort = student.OrderByDescending(x => x.Grade).ToList();
            foreach (Student studentt in Sort)
            {
                Console.WriteLine(studentt);
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }

    }
}
