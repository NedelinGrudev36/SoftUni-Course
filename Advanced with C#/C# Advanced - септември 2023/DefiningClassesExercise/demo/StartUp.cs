﻿using DefiningClasses;
using System;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Peter";
            person.Age = 20;
            Console.WriteLine($"{person.Name}: {person.Age}");
        }
    }
}