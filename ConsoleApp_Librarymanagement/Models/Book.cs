// File: Book.cs
using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp_Librarymanagement.Models
{
    public class Book
      {
           //step 1: Set the field on parent classusing csharp properties getter and seter
           /* International Standard Book Number. This is a 13 or 10 digit number assigned
           * to all books and book-like publications that are published */
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

}
}