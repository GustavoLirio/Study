using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
  public class CarController : Controller
  {
    private readonly CarService _carService;

    public CarController(CarService carService)
    {
      _carService = carService;
    }

    public IActionResult Index()
    {
      var list = _carService.FindAll();
      return View(list);
    }
  }
}
