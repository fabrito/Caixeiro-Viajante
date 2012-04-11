using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Restaurante.DomainModel;

namespace FuzzyLogic.Presentation.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            RestauranteFuzzyLogic restaurante = new RestauranteFuzzyLogic();

            restaurante.NotaAtendimento(7);
            restaurante.NotaComida(7);


            System.Console.WriteLine(restaurante.GetGorjeta());

            System.Console.ReadLine();

        }
    }
}
