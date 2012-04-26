using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HeuristicaConstrutiva;
using ProblemaMochila;

namespace Heuristicas
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstroiMochila heuristica = new ConstroiMochila(50);
            heuristica.AddItem(new Item() { Descricao = "Lanterna", Peso = 5, Utilidade = 10 });
            heuristica.AddItem(new Item() { Descricao = "Canivete Suíço", Peso = 1, Utilidade = 30 });
            heuristica.AddItem(new Item() { Descricao = "Jaca", Peso = 30, Utilidade = 3 });
            heuristica.AddItem(new Item() { Descricao = "Panela", Peso = 5, Utilidade = 10 });
            heuristica.AddItem(new Item() { Descricao = "Carne", Peso = 10, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Arroz", Peso = 7, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Feijão", Peso = 8, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Cerveja", Peso = 15, Utilidade = 8 });
            heuristica.AddItem(new Item() { Descricao = "Mapa", Peso = 1, Utilidade = 20 });
            heuristica.AddItem(new Item() { Descricao = "Celular", Peso = 3, Utilidade = 9 });
            heuristica.AddItem(new Item() { Descricao = "Barraca", Peso = 20, Utilidade = 60 });
            heuristica.AddItem(new Item() { Descricao = "Cobertor", Peso = 8, Utilidade = 24 });
            heuristica.AddItem(new Item() { Descricao = "Jornal", Peso = 1, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Papel Higiênico", Peso = 2, Utilidade = 10 });
            heuristica.AddItem(new Item() { Descricao = "Carvão", Peso = 8, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Repelente", Peso = 2, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Vara de Pescar", Peso = 1, Utilidade = 2 });
            heuristica.AddItem(new Item() { Descricao = "Pente", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Espelho", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Sabão", Peso = 1, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Xampu", Peso = 4, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Luvas", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Violão", Peso = 15, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Fósforo", Peso = 1, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Isqueiro", Peso = 1, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Bússola", Peso = 1, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Roupa", Peso = 5, Utilidade = 25 });
            heuristica.AddItem(new Item() { Descricao = "Sapatos", Peso = 3, Utilidade = 10 });
            heuristica.AddItem(new Item() { Descricao = "Protetor Solar", Peso = 1, Utilidade = 2 });


            heuristica.GerarSolucao();

            foreach (IComponente c in heuristica.Solucao.Componentes)
            {
                Item item = (Item)c;
                System.Console.WriteLine(item.Descricao + " - " + item.Peso + " - " + item.Utilidade);
            }

            System.Console.WriteLine("Peso da Mochila: " + heuristica.Mochila.CapacidadeAtual);
            System.Console.WriteLine("Utilidade da Mochila: " + heuristica.Solucao.Avaliacao);

            System.Console.ReadLine();
        }
    }
}
