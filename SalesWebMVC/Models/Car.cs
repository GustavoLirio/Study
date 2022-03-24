using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
  public class Car
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public int Ano { get; set; }

    public Car()
    {
    }

    public Car(string nome, string modelo, string cor, int ano)
    {
      Nome = nome;
      Modelo = modelo;
      Cor = cor;
      Ano = ano;
    }
  }
}
