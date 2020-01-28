using System;
using System.Collections.Generic;

namespace library.Models
{
  public class Library
  {
    public string Address { get; set; }
    public string Name { get; set; }

    public List<Book> CheckedOut { get; set; } = new List<Book>();
    public List<Book> AvailableBooks { get; set; } = new List<Book>();

    public void PrintBooks()
    {
      for (int i = 0; i < AvailableBooks.Count; i++)
      {
        Console.WriteLine($"{i + 1}) {AvailableBooks[i].Title} - {AvailableBooks[i].Author}");
      }
    }
    public void PrintCheckedOut()
    {
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Console.WriteLine($"{i + 1} {CheckedOut[i].Title} - {CheckedOut[i].Author}");
      }
    }
    public void AddBook(Book book)
    {
      AvailableBooks.Add(book);
    }
    public void AddBook(List<Book> books)
    {
      AvailableBooks.AddRange(books);
    }

    public void Checkout(string selection)
    {
      Book selectedBook = ValidateBook(selection, AvailableBooks);
      if (selectedBook == null)
      {
        Console.Clear();
        System.Console.WriteLine("Invalid Selection");
        return;
      }
      else
      {
        selectedBook.Available = false;
        CheckedOut.Add(selectedBook);
        AvailableBooks.Remove(selectedBook);
        System.Console.WriteLine($"Congratulations on succesfully checking out {selectedBook.Title}! You have 2 weeks from today's date to return it. Enjoy!");
      }
    }
    public void Return(string selection)
    {
      Book selectedBook = ValidateBook(selection, CheckedOut);
      if (selectedBook == null)
      {
        Console.Clear();
        System.Console.WriteLine("Invalid Selection");
        return;
      }
      else
      {
        selectedBook.Available = true;
        CheckedOut.Remove(selectedBook);
        AvailableBooks.Add(selectedBook);
        System.Console.WriteLine($"Congratulations on succesfully returning {selectedBook.Title}! We hope you enjoyed the read, and please feel free to check out more!");
      }
    }
    private Book ValidateBook(string selection, List<Book> booklist)
    {
      int bookIndex = 0;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > AvailableBooks.Count)
      {
        return null;
      }
      return booklist[bookIndex - 1];
    }

    public Library(string address, string name)
    {
      Address = address;
      Name = name;
    }
  }
}