using Microsoft.AspNetCore.Mvc;
using PieWebApp.Models;
using PieWebApp.ViewModels;

namespace PieWebApp.Controllers
{
  public class HomeController: Controller
  {
    private readonly IPieRepository _pieRepository;

    public HomeController(IPieRepository pieRepository)
    {
      _pieRepository = pieRepository;   
    }

    public IActionResult Index()
    {
      var homeView = new HomeViewModel
      {
        PiesOfTheWeek = _pieRepository.PiesOfTheWeek
      };
      return View(homeView);
    }
  }
}