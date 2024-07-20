﻿using System.Linq;
namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();

            Console.WriteLine(GetAuthorNamesEndingIn(context, "e"));

            //DbInitializer.ResetDatabase(db);
        }

        //02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
            {
                return string.Empty;
            }

            var bookTitle = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine,bookTitle);
        }

        //03

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEEditionBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new {b.Title, b.BookId})
                .OrderBy(b => b.BookId)
                .ToArray();

            return string.Join(Environment.NewLine, goldenEEditionBooks.Select(b => b.Title));
        }


        //04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var mostExpensiveBooks = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            return string.Join(Environment.NewLine, mostExpensiveBooks.Select(a => $"{a.Title} - {a.Price:f2}"));
        }

        //05
        //public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        //{
        //    var bookNotReleasedIn = context.Books
        //        .Where(b => b.ReleaseDate.Value &&
        //                    b.ReleaseDate.Value.Year != year)
        //        .Select(b => new
        //        {
        //            b.Title,
        //            b.BookId
        //        })
        //        OrderBy(b => b.BookId)
        //        .ToArray();

        //    return string.Join(Environment.NewLine, bookNotReleasedIn.Select(b => b.Title));
        //}

        //06

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            var bookByCategory=context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name))
                .Select(bc =>bc.Book.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookByCategory);
        }

        //07

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var bookReleasedBefore = context.Books
               .Where(b => b.ReleaseDate < dt)
               .OrderByDescending(b => b.ReleaseDate)
               .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
               .ToArray();

            return string.Join(Environment.NewLine, bookReleasedBefore);
        }

        //08

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(n => n)
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        //09

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string loweredInput = input.ToLower();

            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(loweredInput))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //10

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string inputLowered = input.ToLower();

            var booksAndAuthotInfo = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(inputLowered))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, booksAndAuthotInfo);
        }

        //11

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(b => b.Title.Length == lengthCheck);
        }

        //12

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsCopies = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            return string.Join(Environment.NewLine, authorsCopies.Select(ac => $"{ac.FirstName} {ac.LastName} - {ac.Copies}"));
        }

        //13

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesByProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();

            return string.Join(Environment.NewLine,categoriesByProfit.Select(cbp => $"{cbp.Name} ${cbp.Profit:f2}"))
        }

        //14

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesWithLatestThreebooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    MostRecentBooks = c.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Take(3)
                    .Select(b => $"{b.Book.Title} ){b.Book.ReleaseDate.Value.Year})")
                }).ToArray()
                .OrderBy(c => c.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var c in categoriesWithLatestThreebooks)
            {
                sb.AppendLine($"--{c.Name}");
                foreach (var b in c.MostRecentBooks)
                {
                    sb.AppendLine(b);
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        //16

        public static int RemoveBooks(BookShopContext context)
        {
            var bookToDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(bookToDelete);
            context.SaveChanges();

            return bookToDelete.Length;
        }



    }
}


