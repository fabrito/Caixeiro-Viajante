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
            Descricao = "";
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

        public override String ToString()
        {
            return Descricao;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Item item = (Item)obj;
            if (item == null)
                return false;
            return this.Descricao.Equals(item.Descricao) && this.Peso == item.Peso && this.Utilidade == item.Utilidade;
        }

        public override int GetHashCode()
        {
            return 31*Descricao.GetHashCode() * Peso * Utilidade;
        }

    }
}
