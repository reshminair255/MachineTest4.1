using ConsoleApp_Librarymanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp_Librarymanagement.Services
{
    // ILibrary interface inherited by LibraryImpl class 
    public class LibraryImpl : ILibrary
    {
        // Dictionary creation with key-value pair
        private static Dictionary<string, Book> books = new Dictionary<string, Book>();

        // List of All books
        #region List All Books
        public void ListAllBooks()
        {
            // Exception Handling
            try
            {
                // Validation for empty field. If count is zero, then display book not found.
                if (books.Count == 0)
                {
                    Console.WriteLine("No books found.");
                    return;
                }

                // List of Books in table format
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("| ISBN         |       Title               | Author    |");
                Console.WriteLine("------------------------------------------------------");
                foreach (var book in books.Values)
                {
                    // Set the position
                    Console.WriteLine($"| {book.ISBN,-10} | {book.Title,-13} | {book.Author,-10} |");
                }
                Console.WriteLine("--------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #endregion

        // ADD_BOOK
        #region AddBook
        public void AddBook(Book book)
        {
            try
            {
                // Validate ISBN - a 13 digit number for book identification
                if (string.IsNullOrWhiteSpace(book.ISBN) || book.ISBN.Length != 13 || !IsAllDigits(book.ISBN))
                {
                    Console.WriteLine("Invalid ISBN. Ensure it is a 13-digit number.");
                    return;
                }

                // Check if the book already exists
                if (books.ContainsKey(book.ISBN))
                {
                    Console.WriteLine("A book with this ISBN already exists.");
                    return;
                }

                // Validate Title
                if (string.IsNullOrWhiteSpace(book.Title) || ContainsNumbers(book.Title))
                {
                    Console.WriteLine("Invalid title. Ensure it is not empty and does not contain numbers.");
                    return;
                }

                // Validate Author
                if (string.IsNullOrWhiteSpace(book.Author) || ContainsNumbers(book.Author))
                {
                    Console.WriteLine("Invalid author. Ensure it is not empty and does not contain numbers.");
                    return;
                }

                // Add the book to the collection
                books.Add(book.ISBN, book);
                Console.WriteLine("New book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #endregion

        private bool IsAllDigits(string input)
        {
            return input.All(char.IsDigit);
        }

        private bool ContainsNumbers(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"\d");
        }

        // Edit Book
        #region Edit Book
        public void EditBook(string isbn)
        {
            //exception handling block
            try
            {
                //search book by its isbn number
                if (books.TryGetValue(isbn, out Book book))
                {
                    // Menu to Edit and Update the Book details
                    Console.WriteLine("Select the detail to update:");
                    Console.WriteLine("1. Title");
                    Console.WriteLine("2. Author");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    // Using switch case to select the choice 
                    switch (choice)
                    {
                        case "1":
                            // Editing the Book details - Title
                            Console.WriteLine($"Existing title: {book.Title}");
                            Console.Write("Enter new title: ");
                            string newTitle = Console.ReadLine();

                            // Empty field validation
                            if (!string.IsNullOrWhiteSpace(newTitle))
                            {
                                book.Title = newTitle;
                                
                                //output message or confirmation message
                                Console.WriteLine("Book title updated successfully.");
                            }
                            else
                            {
                                //Error message
                                Console.WriteLine("Title cannot be empty.");
                            }
                            break;

                        case "2":

                            // Editing the Book details - Author
                            Console.WriteLine($"Existing author: {book.Author}");
                            Console.Write("Enter new author: ");
                            string newAuthor = Console.ReadLine();

                            // Author name validation
                            if (!string.IsNullOrWhiteSpace(newAuthor) && !ContainsNumbers(newAuthor))
                            {
                                book.Author = newAuthor;

                                //output message
                                Console.WriteLine("Book author updated successfully.");
                            }
                            else
                            {
                                //Validation error message
                                Console.WriteLine("Invalid input for Author. It should not be empty or contain numbers.");
                            }
                            break;

                        case "3":
                            return;

                        default:
                            //Error message
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Book with ISBN {isbn} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #endregion

        // Remove Book or deactivating the book fdetails from the dictionary
        #region Remove Book
        public void RemoveBook(string isbn)
        {
            try
            {
                //Keey value comparison
                if (books.ContainsKey(isbn))
                {
                    books.Remove(isbn);
                    Console.WriteLine("Book removed successfully.");
                }
                else
                {
                   //Validation Error Message
                    Console.WriteLine($"Book with ISBN {isbn} not found.");
                }
            }
            catch (Exception ex)
            {
                //Validation Error Message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #endregion

        // Search by Author
        #region Search By Author
        //search the book byits author 
        public void SearchByAuthor(string author)
        {
            try
            {
                bool found = false;
                //for each loop
                foreach (var book in books.Values)
                {
                    if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN})");
                        found = true;
                    }
                }
                if (!found)
                {
                    //validation Error message
                    Console.WriteLine("No books found by that author.");
                }
            }
            catch (Exception ex)
            {
                //Error occurrence message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #endregion

        // Search by Title
        #region Search By Title
        public void SearchByTitle(string title)
        {
            //Exception handling
            try
            {
                bool found = false;
                foreach (var book in books.Values)
                {
                    if (book.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN})");
                        found = true;
                    }
                }
                if (!found)
                {
                    //Validation Error message
                    Console.WriteLine("No books found with that title.");
                }
            }
            catch (Exception ex)
            {
                //Error message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #endregion
    }
}
