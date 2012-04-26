using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace ProblemaMochila
{
    class Mochila : ISolucao
    {
        public int CapacidadeMaxima { get; set; }
        public int CapacidadeAtual { get; set; }
        public int UtilidadeAtual { get; set; }

        public Mochila(int ValorCapacidade) 
        {
            CapacidadeAtual = 0;
            UtilidadeAtual = 0;
            CapacidadeMaxima = ValorCapacidade;
            Componentes = new List<IComponente>();
        }

        public List<IComponente> Componentes
        {
            get;
            set;
        }

        public float Avaliacao
        {
            get { return UtilidadeAtual; }
        }


        public void AddComponente(IComponente Componente)
        {
            Item item = (Item)Componente;
            if (item.Peso + CapacidadeAtual > CapacidadeMaxima)
                throw new Exception("Capacidade da mochila excedida");

            CapacidadeAtual += item.Peso;
            UtilidadeAtual += item.Utilidade;
 
            Componentes.Add(item);
        }

        public void RemoveComponente(IComponente Componente)
        {
            throw new NotImplementedException();
        }
    }
}
