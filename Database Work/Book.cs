using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Work
{
    internal class Book
    {
        //properties
        public string Title { get; }
        public string Author { get; }
        public int Published { get; }
        public int Rating { get; set; }
        public int TimesRead { get; set; }

        public Book()
        {
            Title = "Moby-Dick";
            Author = "Herman Melville";
            Published = 1851;
            Rating = 0;
            TimesRead = 0;
        }
        public Book(string title, string author, int published, int rating, int timesRead)
        {
            Title = title;
            Author = author;
            Published = published;
            Rating = rating;
            TimesRead = timesRead;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Title: \"{Title}\" \nAuthor: {Author} \nPublished: {Published} \nRating: {Rating}; Times read: {TimesRead} ");
            Console.WriteLine();
        }




    }
}
