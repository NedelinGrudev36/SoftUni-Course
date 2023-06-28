using System;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string command; string[] token;
            string[] tokens = Console.ReadLine().Split(", ");
            string title = tokens[0];
            string content = tokens[1];
            string author = tokens[2];
            Article article = new Article(title,content,author);
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
                 token = Console.ReadLine().Split(":");
                command = token[0];
                if (command=="Edit")
                {
                    article.Edit(token[1]);
                }
                else if (command== "ChangeAuthor")
                {
                    article.ChangeAuthor(token[1]);
                }
                else if (command== "Rename")
                {
                    article.Rename(token[1]);
                }
            }
            Console.WriteLine(article.ToString());
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string title)
        {
            Title = title;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
