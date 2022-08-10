using System.Collections.Generic;

namespace PieWebApp.Models
{
  public interface ICategoryRepository
  {
    IEnumerable<Category> AllCategories { get; }
  }
}