using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace ProblemaMochila
{
    public class Mochila : ISolucao
    {
        public int CapacidadeMaxima { get; set; }
        public int CapacidadeAtual { get; set; }
        public int UtilidadeAtual { get; protected set; }

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
            if (Componente == null)
                return;

            Item item = (Item)Componente;
            if (item.Peso + CapacidadeAtual > CapacidadeMaxima)
                throw new Exception("Capacidade da mochila excedida");

            if (!Componentes.Contains(Componente))
            {
                CapacidadeAtual = CapacidadeAtual + item.Peso;
                UtilidadeAtual = UtilidadeAtual + item.Utilidade;
                Componentes.Add(item);
            }
        }

        public void RemoveComponente(IComponente Componente)
        {
            if (Componente == null)
                return;

            Item item = (Item)Componente;

            if (Componentes.Contains(Componente))
            {
                CapacidadeAtual =  CapacidadeAtual - item.Peso;
                UtilidadeAtual = UtilidadeAtual - item.Utilidade;

                Componentes.Remove(item);
            }            
        }

        public Mochila Clone()
        {
            Mochila temp = new Mochila(this.CapacidadeMaxima);

            foreach (IComponente it in this.Componentes)
                temp.AddComponente((Item)it);

            return temp;
        }
    }
}
