using System;
using SeriesChallenge.Enum;

namespace SeriesChallenge.Class
{
  public class Serie : BaseEntity
  {
    private Category Category { get; set; }
    private string Title { get; set; }
    private string Description { get; set; }
    private int Year { get; set; }
    private bool IsActive { get; set; }

    public Serie(int id, Category category, string title, string description, int year)
    {
      this.Id = id;
      this.Category = category;
      this.Title = title;
      this.Description = description;
      this.Year = year;
      this.IsActive = true;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Category: " + this.Category + Environment.NewLine;
      retorno += "Title: " + this.Title + Environment.NewLine;
      retorno += "Description: " + this.Description + Environment.NewLine;
      retorno += "Year: " + this.Year + Environment.NewLine;
      retorno += "Active: " + this.IsActive;
      return retorno;
    }

    public string title
    {
        get { return Title; }
    }

    public bool isActive
    {
      get { return IsActive; }
    }

    public void Inactive()
    {
        this.IsActive = false;
    }

  }
}