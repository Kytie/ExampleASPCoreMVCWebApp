using System.Linq;
using PieWebApp.Models;
using PieWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieWebApp.Controllers
{
  public class ShoppingCartController : Controller
  {
    private readonly IPieRepository _pieRepository;
    private readonly ShoppingCart _shoppingCart;

    public ShoppingCartController(IPieRepository pieRepository, ShoppingCart shoppingCart)
    {
      _pieRepository = pieRepository;
      _shoppingCart = shoppingCart;
    }

    public ViewResult Index()
    {
      var items = _shoppingCart.GetShoppingCartItems();
      _shoppingCart.ShoppingCartItems = items;

      var shoppingCartViewModel = new ShoppingCartViewModel
      {
        ShoppingCart = _shoppingCart,
        ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
      };

      return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int pieId)
    {
      var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

      if (selectedPie != null)
      {
        _shoppingCart.AddToCart(selectedPie, 1);
      }
      return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int pieId)
    {
      var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

      if (selectedPie != null)
      {
        _shoppingCart.RemoveFromCart(selectedPie);
      }
      return RedirectToAction("Index");
    }
  }
}