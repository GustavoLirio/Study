using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Car car)
    {
      _carService.Insert(car);
      return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
      if(id == null)
      {
        return RedirectToAction(nameof(Error), new { message = "Id não informado" });
      }

      var obj = _carService.FindById(id.Value);
      if (obj == null)
      {
        return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
      }

      return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
      _carService.Remove(id);
      return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int? id)
    {
      if (id == null)
      {
        return RedirectToAction(nameof(Error), new { message = "Id não informado" });
      }

      var obj = _carService.FindById(id.Value);
      if (obj == null)
      {
        return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
      }

      return View(obj);
    }

    public IActionResult Edit(int? id)
    {
      if (id == null)
      {
        return RedirectToAction(nameof(Error), new { message = "Id não informado" });
      }

      var obj = _carService.FindById(id.Value);
      if (obj == null)
      {
        return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
      }

      var view = _carService.FindById(id.Value);

      return View(view);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Car car)
    {
      _carService.Update(car);
      return RedirectToAction(nameof(Index));
    }

    public IActionResult Error(string message)
    {
      var viewModel = new ErrorViewModel
      {
        Message = message,
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
      };

      return View(viewModel);
    }
  }
}
