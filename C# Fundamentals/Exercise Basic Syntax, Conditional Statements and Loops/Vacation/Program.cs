using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double price=0, totalForGroup=0,totalPrice=0;
            int countPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            switch (groupType)
            {
                case "Students":
                    
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price = 8.45;
                            break;
                        case "Saturday":
                            price = 9.80;
                            break;
                        case "Sunday":
                            price = 10.46;
                            break;
                    }
                    if (countPeople>=30)
                    {
                        totalPrice = countPeople * price - 0.15 * countPeople * price;
                    }
                    else
                    {
                        totalPrice = countPeople * price;
                    }
                    break;
                case "Business":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price =10.90;
                            break;
                        case "Saturday":
                            price = 15.60;
                            break;
                        case "Sunday":
                            price = 16;
                            break;
                    }
                    if (countPeople>=100)
                    {
                        totalPrice = (countPeople - 10) * price;
                    }
                    else
                    {
                        totalPrice = countPeople * price;
                    }
                    break;
                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price = 15;
                            break;
                        case "Saturday":
                            price = 20;
                            break;
                        case "Sunday":
                            price = 22.50;
                            break;
                    }
                    if (countPeople>=10 && countPeople<=20)
                    {
                        totalPrice = countPeople * price - 0.05 * countPeople * price;
                    }
                    else
                    {
                        totalPrice = countPeople * price;
                    }
                    break;
               

            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
            //switch (dayOfWeek)
            //{
            //    case "Friday":
            //        switch (groupType)
            //        {
            //            case "Students":
            //                price = countPeople * 8.45;
            //                break;
            //            case "Business":
            //                price = countPeople * 10.90;
            //                break;
            //            case "Regular":
            //                price = countPeople * 15;
            //                break;
            //        }
            //        break;
            //    case "Saturday":
            //        switch (groupType)
            //        {
            //            case "Students":
            //                price = countPeople * 9.80;
            //                break;
            //            case "Business":
            //                price = countPeople * 15.60;
            //                break;
            //            case "Regular":
            //                price = countPeople * 20;
            //                break;
            //        }
            //        break;
            //    case "Sunday":
            //        switch (groupType)
            //        {
            //            case "Students":
            //                price = countPeople * 10.46;
            //                break;
            //            case "Business":
            //                price = countPeople * 16;
            //                break;
            //            case "Regular":
            //                price = countPeople * 22.50;
            //                break;
            //        }
            //        break;
            //}
            //if (groupType=="Students")
            //{
            //    if (countPeople>=30)
            //    {
            //        double percent = price * 0.15;
            //        price -= percent;

            //    }
            //    Console.WriteLine($"Total price: {price:f2}");

            //}
            //else if (groupType=="Business")
            //{
            //    if (countPeople>=100)
            //    {

            //        int totalCountPeople = countPeople - 10;

            //        switch (dayOfWeek)
            //        {
            //            case "Friday":
            //                 totalForGroup = totalCountPeople * 10.90;
            //                Console.WriteLine($"Total price: {totalForGroup:f2}");
            //                break;
            //            case "Saturday":
            //                 totalForGroup = totalCountPeople * 15.60;
            //                Console.WriteLine($"Total price: {totalForGroup:f2}");
            //                break;
            //            case "Sunday":
            //                totalForGroup = totalCountPeople * 16;
            //                Console.WriteLine($"Total price: {totalForGroup:f2}");
            //                break;

            //        }
            //    }
            //}
            //else if (groupType=="Regular")
            //{
            //    if (countPeople>=10 && countPeople<=20)
            //    {
            //        double percent = price * 0.05;
            //        price -= percent;

            //    }
            //    Console.WriteLine($"Total price: {price:f2}");
            //}
        }
    }
}
