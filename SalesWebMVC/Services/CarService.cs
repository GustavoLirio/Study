using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
  public class CarService
  {
    private readonly SalesWebMVCContext _context;

    public CarService(SalesWebMVCContext context)
    {
      _context = context;
    }

    public List<Car> FindAll()
    {
      return _context.Car.ToList();
    }
  }
}
