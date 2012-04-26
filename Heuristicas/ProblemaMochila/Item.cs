using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace ProblemaMochila
{
    public class Item : IComponente
    {
        public String Descricao { get; set; }
        public int Peso { get; set; }
        public int Utilidade { get; set; }


        public Item()
        {
            Peso = 1;
            Utilidade = 1;
        }

        public object Valor
        {
            get
            {
                return Utilidade / Peso;
            }
        }
    }
}
