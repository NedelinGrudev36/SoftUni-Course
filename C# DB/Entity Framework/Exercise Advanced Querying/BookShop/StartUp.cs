namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();

            Console.WriteLine(GetBooksByAgeRestriction(context, "miNor"));

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
            var 
        }


    }
}


