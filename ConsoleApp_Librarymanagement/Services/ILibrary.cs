using ConsoleApp_Librarymanagement.Models;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp_Librarymanagement.Services
{
    public interface ILibrary
    {
        //library interface with void access specifier =>returns no value
        void ListAllBooks();
        void AddBook(Book book);
        void EditBook(string isbn);
        void RemoveBook(string isbn);
        void SearchByAuthor(string author);
        void SearchByTitle(string title);
    }
}
