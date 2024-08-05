using ConsoleApp_Librarymanagement.Models;
using ConsoleApp_Librarymanagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Librarymanagement
{
    public class LibraryApp
    {
        // Fields setting
        //_libraryServic--->object interface
        private readonly ILibrary _libraryService;

        // Constructor Injection
        //libraryService--->Argument interface
        public LibraryApp(ILibrary libraryService)
        {
            
            //Object Interface = Argument interface
            _libraryService = libraryService;
        }

        static void Main(string[] args)
        {
            var libraryApp = new LibraryApp(new LibraryImpl());

            // Menu Driven of Library Management Sysytem
            while (true)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. Search By Author");
                Console.WriteLine("6. Search By Title");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                // Validate Choice
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                // Condition Check
                switch (choice)
                {
                    case 1:
                        libraryApp._libraryService.ListAllBooks();
                        break;
                    case 2:
                        libraryApp.AddBook();
                        break;
                    case 3:
                        libraryApp.EditBook();
                        break;
                    case 4:
                        libraryApp.RemoveBook();
                        break;
                    case 5:
                        libraryApp.SearchByAuthor();
                        break;
                    case 6:
                        libraryApp.SearchByTitle();
                        break;
                    case 7:
                        return;
                }
            }
        }
        //add book
        private void AddBook()
        {
            try
            {
                Console.Write("Enter ISBN: ");
                string isbn = Console.ReadLine();
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                Book book = new Book { ISBN = isbn, Title = title, Author = author };
                _libraryService.AddBook(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        //editing the book details
        private void EditBook()
        {
            try
            {
                Console.Write("Enter ISBN of the book to edit: ");
                string isbn = Console.ReadLine();
                _libraryService.EditBook(isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //to deactivate the book details from the dictionary
        private void RemoveBook()
        {
            try
            {
                Console.Write("Enter ISBN of the book to remove: ");
                string isbn = Console.ReadLine();
                _libraryService.RemoveBook(isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        //srearch the book details using author name
        private void SearchByAuthor()
        {
            try
            {
                Console.Write("Enter author name: ");
                string author = Console.ReadLine();
                _libraryService.SearchByAuthor(author);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        //search the book by title
        private void SearchByTitle()
        {
            try
            {
                Console.Write("Enter book title: ");
                string title = Console.ReadLine();
                _libraryService.SearchByTitle(title);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
