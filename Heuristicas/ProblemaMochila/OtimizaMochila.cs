using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HeuristicaMelhoria;
using HeuristicaConstrutiva;

namespace ProblemaMochila
{
    public class OtimizaMochila : HeuristicaMelhoria.HeuristicaMelhoria
    {

        int TamanhoMochila { get; set; }
        List<Item> ItensDisponiveis { get; set; }

        int iteracoes, iteracoesSemMelhoria,itensVariacao;

        public Mochila MochilaOld
        {
            get;
            set;
        }

        public Mochila Mochila
        {
            get
            {
                return (Mochila)Solucao;
            }
        }

        public OtimizaMochila(int tamanho) 
        {
            TamanhoMochila = tamanho;
            ItensDisponiveis = new List<Item>();
            iteracoes = 0;
            iteracoesSemMelhoria = 0;
            itensVariacao = 1;
        }

        public void AddItem(Item item)
        {
            ItensDisponiveis.Add(item);
        }


        public override List<ISolucao> GerarVizinhanca()
        {
            List<ISolucao> vizinhos = new List<ISolucao>();
            
            Random random = new Random();
                        
            for (int c = 0; c < Solucao.Componentes.Count; c++)
            {
                Mochila temp = ((Mochila)Solucao).Clone();
                
                Item item = (Item)temp.Componentes[c];
                
                temp.RemoveComponente(item);
                
                int espaco = temp.CapacidadeMaxima - temp.CapacidadeAtual;

                while (espaco > 0)
                {
                    List<Item> comps = ItensDisponiveis.Where(x => x.Peso <= espaco
                        && !temp.Componentes.Contains(x) && x != item).ToList();

                    Item selected = comps.Where(x => (int)x.Utilidade == comps.Max(z => (int)z.Utilidade))
                        .FirstOrDefault();

                    temp.AddComponente(selected);

                    espaco = temp.CapacidadeMaxima - temp.CapacidadeAtual;
                }

                vizinhos.Add(temp);

            }

            return vizinhos;
        }

        public List<ISolucao> GerarVizinhanca_Alternativo()
        {
            List<ISolucao> vizinhos = new List<ISolucao>();


            Random random = new Random();


            for (int c = 0; c < Solucao.Componentes.Count/*ItensDisponiveis.Count*/; c++)
            {
                Mochila temp = ((Mochila)Solucao).Clone();
                //random.Next();                

                Item item = (Item)temp.Componentes[c];
                //Item item = (Item)temp.Componentes[random.Next(temp.Componentes.Count)];

                temp.RemoveComponente(item);

                int espaco = temp.CapacidadeMaxima - temp.CapacidadeAtual;

                while (espaco > 0)
                {
                    List<Item> comps = ItensDisponiveis.Where(x => x.Peso <= espaco
                        && !temp.Componentes.Contains(x) && x != item).ToList();

                    Item selected = comps.Where(x => (int)x.Utilidade == comps.Max(z => (int)z.Utilidade))
                        .FirstOrDefault();

                    //Item selected = comps[random.Next(comps.Count)];

                    temp.AddComponente(selected);

                    espaco = temp.CapacidadeMaxima - temp.CapacidadeAtual;
                }

                vizinhos.Add(temp);

                //temp = temp.Clone();
            }

            return vizinhos;
        }

        public override ISolucao EscolheMelhorVizinho(List<ISolucao> vizinhos)
        {
            return vizinhos.Where(x => x.Avaliacao == vizinhos.Max(z => z.Avaliacao)).FirstOrDefault();
        }

        public override ISolucao CriaSolucaoInicial()
        {
            ConstroiMochila constroi = new ConstroiMochila(this.TamanhoMochila);
            constroi.ItensDisponiveis = this.ItensDisponiveis;

            constroi.GerarSolucao();

            return constroi.Solucao;
        }

        public override bool VerificaCondicaoParada()
        {
            iteracoes++;

            if (MochilaOld == Mochila)
                iteracoesSemMelhoria++;
            else
                MochilaOld = Mochila;
             

            return (iteracoesSemMelhoria == 100 || iteracoes == 1000);
               
        }
    }
}
