using System.Collections.Generic;
using PieWebApp.Models;

namespace PieWebApp.ViewModels
{
  public class HomeViewModel
  {
    public IEnumerable<Pie> PiesOfTheWeek { get; set; }
  }
}