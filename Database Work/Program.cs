using System.Linq.Expressions;
using static Database_Work.Program;

namespace Database_Work
{
    internal class Program
    {
        //TODO:
        //
        //Figure out how to save books to a database
        //  Json file streams I guess
        //  Some limitations, but it'll work
        //
        //How do I want to do a TBR (new book class?)
        //
        //How can I implement github?
        //
        //Progress Tracker

        public static List<Book> mainLibrary = new List<Book>();
        public enum Library
        {
            Off,
            On,
            Stall,
        }        

        public static Book NewBook(string title)
        {
            Console.WriteLine("Adding book to the library \n");
            
            Console.WriteLine("Author? ");
            string tempAuthor = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Year published? ");            
            int tempPublished = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Rating (0 for none)? ");
            int tempRating = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("How many times you read it? ");
            int tempRead = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Book book = new Book(title, tempAuthor, tempPublished, tempRating, tempRead);

            return book;

        }
        public static void Main()
        {
            Library status = Library.On;


            //this fills the library with temp books
            Book defaultBook = new Book();
            for (int i = 0; i < 10; i++)
            {
                mainLibrary.Add(defaultBook);
                defaultBook.Rating = i;
            }
            

            while (status == Library.On) {
                Console.WriteLine("Welcome to the Library");
                Console.WriteLine();

                Console.WriteLine("What would you like to do? \n");
                Console.WriteLine("1. Library info");
                Console.WriteLine("2. Add a book");
                Console.WriteLine("3. Update rating or read count");
                Console.WriteLine("4. To Be Read - Coming soon");
                Console.WriteLine("5. Progress Tracker");
                Console.WriteLine("10. Exit");

                Console.Write(">");
                int menuChoice = int.Parse(Console.ReadLine());

                status = InitialMenu(menuChoice);

                if (status == Library.Stall)
                {
                    Console.WriteLine("An unexpected error occured");
                    Console.ReadLine();
                }
            }
        }

        public static Library InitialMenu(int menuChoice)
        {
            switch (menuChoice)
            {
                case 1: //Library info

                    SimpleDisplayLibrary();

                    Console.WriteLine("More coming soon");
                    return Library.On;
                    
                case 2: //Add a book

                    Console.WriteLine("Add a book \nWhat is the title? ");

                    string newTitle = Console.ReadLine();

                    mainLibrary.Add(NewBook(newTitle));

                    Console.WriteLine("Book added!");
                    Console.ReadLine();

                    return Library.On;

                case 3: //Update rating or read count

                    Console.WriteLine("Which book would you like to update?");

                    LibraryBookShelf();

                    Console.Write("index: ");
                    int titleQuery = int.Parse(Console.ReadLine());
                    Book modifyThisBook = mainLibrary[titleQuery];                                  

                    Console.WriteLine("Which would you like to edit: \n1.Rating \n2.Read Count");
                    int ratingOrReadCount = int.Parse(Console.ReadLine());

                    EditBookInfo(modifyThisBook, ratingOrReadCount);

                    return Library.On;

                case 4: //To Be Read - Coming soon

                    return Library.Stall;

                case 5: //Progress Tracker



                    return Library.Stall;
                                        
                case 10: //Exit Library app

                    return Library.Off;
                    
                default: //default
                    Console.WriteLine("coming soon");
                    return Library.On;
                    
            }
        }

        public static void LibraryBookShelf()
        {
            int shelf = 5;
            int counter = 0;
            foreach (Book e in mainLibrary)
            {
                
                Console.Write($"{mainLibrary.IndexOf(e)}: {e.Title} ");
                counter++;

                if (counter == shelf)
                {
                    Console.WriteLine(); 
                    counter = 0;
                }
            }
            Console.WriteLine();
        }
        public static void SimpleDisplayLibrary()
        {
            foreach (var e in mainLibrary)
            {
                Console.Write($"Book index: {mainLibrary.IndexOf(e)}"); //the .IndexOf() method only shows index 0 for now
                e.GetInfo();
            }
            Console.ReadLine();
        }
        
        public static void EditBookInfo(Book book, int ratingOrRead)
        {
            switch(ratingOrRead)
            {
                case 1: //edit Rating

                    Console.WriteLine("What is your new rating?");
                    Console.WriteLine($"Old rating: {book.Rating}");
                    int newRating = int.Parse(Console.ReadLine());

                    book.Rating = newRating;

                    break;

                case 2: //edit Read count

                    Console.WriteLine("New read has been added!");
                    book.TimesRead++;

                    break;
            }
        }
    }
}
