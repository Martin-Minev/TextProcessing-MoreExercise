using System;
using System.Collections.Generic;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            string comment = string.Empty;
            List<string> comments = new List<string>();

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                comments.Add(comment);
            }

            Console.WriteLine("<h1>");
            Console.WriteLine("    {0}", title);
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine("    {0}", content);
            Console.WriteLine("</article>");

            foreach (var item in comments)
            {
                Console.WriteLine("<div>");
                Console.WriteLine("    {0}", item);
                Console.WriteLine("</div>");
            }


        }  
    }
}
