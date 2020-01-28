using System;
using System.Collections.Generic;
using library.Models;

namespace library
{
  class Program
  {
    static void Main(string[] args)
    {
      Library Library1 = new Library("123 Street", "Books R' Us");
      Book Book1 = new Book("Harry Pooter Series", "Jk Rowling", new List<Genre>() { Genre.Fantasy, Genre.Adventure, Genre.Children });
      Book Book2 = new Book("Mitch Rapp Series", "Jack Flynn", new List<Genre>() { Genre.Action, Genre.Thriller });
      Book Book3 = new Book("The Change Series", "Sm Sterling", new List<Genre>() { Genre.Fantasy, Genre.Action });
      Library1.AddBook(new List<Book>() { Book1, Book2, Book3 });
      bool inLibrary = true;
      Console.Clear();
      Enum activeMenu = Menus.CheckoutBook;
      while (inLibrary)
      {
        switch (activeMenu)
        {
          case Menus.CheckoutBook:
            System.Console.WriteLine($"Welcome to {Library1.Name}! Here are our books currently. ");
            System.Console.WriteLine("");
            Library1.PrintBooks();
            break;
          case Menus.ReturnBook:
            System.Console.WriteLine($"Here are the books currently checked out. Which one are you returning? ");
            System.Console.WriteLine("");
            Library1.PrintCheckedOut();
            break;
        }
        System.Console.WriteLine("");
        System.Console.WriteLine("Select a number for the corresponding book, press [Q] to quit, press [R] to return a book, or press [C] to go to the checkout page.");
        System.Console.WriteLine("");
        string selection = Console.ReadLine();
        switch (selection)
        {
          case "q":
            Console.Clear();
            inLibrary = false;
            break;
          case "r":
            Console.Clear();
            activeMenu = Menus.ReturnBook;
            break;
          case "c":
            Console.Clear();
            activeMenu = Menus.CheckoutBook;
            break;
          default:
            if (activeMenu.Equals(Menus.CheckoutBook))
            {
              Console.Clear();
              Library1.Checkout(selection);
              activeMenu = Menus.CheckoutBook;
            }
            else
            {
              Console.Clear();
              Library1.Return(selection);
              activeMenu = Menus.ReturnBook;
            }
            break;
        }
      }
    }
    public enum Menus
    {
      CheckoutBook,
      ReturnBook
    }
  }
}
