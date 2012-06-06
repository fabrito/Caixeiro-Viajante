using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace CaixeiroViajante
{
   public class Acesso : IComponente
    {
       public string cidPartida { get; set; }
       public string cidDestino { get; set; }
       public float km { get; set; }

       public object Valor
       {
           get { return km; }
       }

       public Acesso(string part, string dest, float dist)
       {
           km = dist;
           cidPartida = part;
           cidDestino = dest;
       }

       public Acesso()
       {
           km = -1;
           cidPartida = "";
           cidDestino = "";
       }

    }
}
