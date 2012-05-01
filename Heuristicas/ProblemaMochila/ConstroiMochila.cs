using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace ProblemaMochila
{
    public class ConstroiMochila : HeuristicaConstrutiva.HeuristicaConstrutiva
    {
        int TamanhoMochila { get; set; }
        public List<Item> ItensDisponiveis { get; set; }

        public Mochila Mochila
        {
            get
            {
                return (Mochila)Solucao;
            }
        }

        public ConstroiMochila(int tamanho) 
        {
            TamanhoMochila = tamanho;
            ItensDisponiveis = new List<Item>();
        }

        public void AddItem(Item item)
        {
            ItensDisponiveis.Add(item);
        }

        public override List<IComponente> GerarComponentes()
        {
            List<IComponente> itens = new List<IComponente>();
            foreach(Item item in ItensDisponiveis)
            {
                if(Mochila.Componentes.Contains(item))
                    continue;

                if(item.Peso <= Mochila.CapacidadeMaxima - Mochila.CapacidadeAtual)
                    itens.Add(item);
            }
            return itens;
        }

        public override IComponente EscolheMelhorComponente(List<IComponente> Componentes)
        {
            Item melhor = (Item)Componentes.FirstOrDefault();
            foreach (Item item in Componentes)
            {
                if(melhor != null)
                    if ((int)melhor.Valor < (int)item.Valor)
                        melhor = item;
            }
            return melhor;
        }

        public override ISolucao CriaSolucaoVazia()
        {
            return (ISolucao)new Mochila(TamanhoMochila);
        }

        public override bool VerificaSolucaoCompleta()
        {
            int espaco = Mochila.CapacidadeMaxima - Mochila.CapacidadeAtual;
            if (espaco > 0)
                return ItensDisponiveis.Where(x => x.Peso <= espaco && !Mochila.Componentes.Contains(x)).ToList().Count == 0;
            else
                return true;
        }
    }
}
