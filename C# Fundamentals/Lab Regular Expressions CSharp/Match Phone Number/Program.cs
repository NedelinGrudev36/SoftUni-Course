using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"'\b\+359 2 [1-9]{3} [1-9]{4}|\+359-2-[1-9]{3}-[1-9]{4}"
            string phone = Console.ReadLine();
            MatchCollection phoneMatches = Regex.Matches(phone, regex);
            var matchesPhone = phoneMatches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ",matchesPhone));
        }
    }
}
