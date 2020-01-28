using System.Collections.Generic;

namespace library.Models
{
  public class Book
  {
    public string Title { get; set; }
    public string Author { get; set; }
    public bool Available { get; set; }
    public List<Genre> Genres { get; protected set; }

    public Book(string title, string author, List<Genre> genres)
    {
      Title = title;
      Author = author;
      Genres = genres;
      Available = true;
    }
  }
  public enum Genre
  {
    Children,
    Action,
    Adventure,
    Mystery,
    Thriller,
    Horror,
    SciFi,
    Fantasy,
    Autobiography,
    Magazine,
    Historical,
    Romance

  }
}