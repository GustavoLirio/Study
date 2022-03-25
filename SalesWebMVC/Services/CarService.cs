using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
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

    public void Insert(Car obj)
    {
      _context.Add(obj);
      _context.SaveChanges();
    }

    public Car FindById(int id)
    {
      return _context.Car.FirstOrDefault(x => x.Id == id);
    }

    public void Remove (int id)
    {
      var obj = _context.Car.Find(id);
      _context.Remove(obj);
      _context.SaveChanges();
    }

    public void Update(Car obj)
    {
      var hasAny = _context.Car.Any(x => x.Id == obj.Id);

      if (!hasAny)
      {
        throw new NotFoundException("Id não encontrado");
      }

      _context.Update(obj);
      _context.SaveChanges();
    }
  }
}
