using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace ProblemaMochila
{
    public class Item : IComponente
    {
        public int Peso { get; set; }
        public int Utilidade { get; set; }


        public object Valor
        {
            get
            {
                return Utilidade / Peso;
            }
        }
    }
}
