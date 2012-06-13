using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace CaixeiroViajante
{
    public class Viagem : ISolucao
    {
        public string cidPartida;
        public float kmPercorridos;
        public List<IComponente> Componentes { get; set; } 

        public float Avaliacao
        {
            get { return kmPercorridos; }
        }

        public Viagem()
        {
            Componentes = new List<IComponente>();
            kmPercorridos = 0;
        }

        public void AddComponente(IComponente Componente)
        {
            if (Componente == null)
                return;
            if (!Componentes.Contains(Componente))
            {
                Componentes.Add(Componente);
                kmPercorridos += (float)Componente.Valor;
            }
        }

        public void RemoveComponente(IComponente Componente)
        {
            if (Componente == null)
                return;
            if (Componentes.Contains(Componente))
                Componentes.Remove(Componente);
        }
    }
}