using System.Collections.Generic;
using PieWebApp.Models;

namespace PieWebApp.ViewModels
{
  public class PiesListViewModel
  {
    public IEnumerable<Pie> Pies { get; set; }
    public string CurrentCategory { get; set; }
  }
}