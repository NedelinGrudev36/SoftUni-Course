using System;
using System.Linq;
using System.Collections.Generic;

namespace Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens;
            List<Article> articles = new List<Article>();           
            int countArticle = int.Parse(Console.ReadLine());
            for (int i = 0; i < countArticle; i++)
            {
                tokens = Console.ReadLine().Split(", ");
                string title = tokens[0];
                string content = tokens[1];
                string author = tokens[2];
                Article article = new Article();
                article.Title = title;
                article.Content = content;
                article.Author = author;
                articles.Add(article);
            }
            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
