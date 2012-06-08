using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaixeiroViajante;
using HeuristicaConstrutiva;
using HeuristicaMelhoria;
using ProblemaMochila;

namespace Heuristicas
{
    class Program
    {
        static void Main(string[] args)
        {/*
            OtimizaMochila heuristica = new OtimizaMochila(75);
            heuristica.AddItem(new Item() { Descricao = "Lanterna", Peso = 3, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Canivete Suíço", Peso = 1, Utilidade = 10 });
            heuristica.AddItem(new Item() { Descricao = "Jaca", Peso = 30, Utilidade = 3 });
            heuristica.AddItem(new Item() { Descricao = "Panela", Peso = 5, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Carne", Peso = 10, Utilidade = 20 });
            heuristica.AddItem(new Item() { Descricao = "Arroz", Peso = 7, Utilidade = 20 });
            heuristica.AddItem(new Item() { Descricao = "Feijão", Peso = 8, Utilidade = 20 });
            heuristica.AddItem(new Item() { Descricao = "Cerveja", Peso = 15, Utilidade = 8 });
            heuristica.AddItem(new Item() { Descricao = "Mapa", Peso = 1, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Celular", Peso = 3, Utilidade = 9 });
            heuristica.AddItem(new Item() { Descricao = "Barraca", Peso = 8, Utilidade = 60 });
            heuristica.AddItem(new Item() { Descricao = "Cobertor", Peso = 8, Utilidade = 25 });
            heuristica.AddItem(new Item() { Descricao = "Jornal", Peso = 3, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Papel Higiênico", Peso = 2, Utilidade = 14 });
            heuristica.AddItem(new Item() { Descricao = "Carvão", Peso = 8, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Repelente", Peso = 2, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Vara de Pescar", Peso = 3, Utilidade = 2 });
            heuristica.AddItem(new Item() { Descricao = "Pente", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Espelho", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Sabão", Peso = 2, Utilidade = 7 });
            heuristica.AddItem(new Item() { Descricao = "Xampu", Peso = 4, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Luvas", Peso = 1, Utilidade = 2 });
            heuristica.AddItem(new Item() { Descricao = "Violão", Peso = 15, Utilidade = 4 });
            heuristica.AddItem(new Item() { Descricao = "Fósforo", Peso = 1, Utilidade = 7 });
            heuristica.AddItem(new Item() { Descricao = "Isqueiro", Peso = 1, Utilidade = 9 });
            heuristica.AddItem(new Item() { Descricao = "Bússola", Peso = 2, Utilidade = 14 });
            heuristica.AddItem(new Item() { Descricao = "Roupa", Peso = 5, Utilidade = 28 });
            heuristica.AddItem(new Item() { Descricao = "Sapatos", Peso = 3, Utilidade = 11 });
            heuristica.AddItem(new Item() { Descricao = "Protetor Solar", Peso = 2, Utilidade = 6 });
            heuristica.AddItem(new Item() { Descricao = "Pratos", Peso = 5, Utilidade = 12 });
            heuristica.AddItem(new Item() { Descricao = "Colheres", Peso = 1, Utilidade = 8 });
            heuristica.AddItem(new Item() { Descricao = "Facas", Peso = 1, Utilidade = 13 });
            heuristica.AddItem(new Item() { Descricao = "Binóculos", Peso = 5, Utilidade = 3 });
            heuristica.AddItem(new Item() { Descricao = "GPS", Peso = 5, Utilidade = 20 });
            heuristica.AddItem(new Item() { Descricao = "Notebook", Peso = 15, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Som", Peso = 16, Utilidade = 8 });
            heuristica.AddItem(new Item() { Descricao = "Livro", Peso = 3, Utilidade = 3 });
            heuristica.AddItem(new Item() { Descricao = "Corda", Peso = 5, Utilidade = 15 });
            heuristica.AddItem(new Item() { Descricao = "Lixa Unha", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Esmalte", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Alicate", Peso = 2, Utilidade = 8 });
            heuristica.AddItem(new Item() { Descricao = "Machado", Peso = 15, Utilidade = 50 });
            heuristica.AddItem(new Item() { Descricao = "Linha", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Agulha", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Band Aid", Peso = 1, Utilidade = 12 });
            heuristica.AddItem(new Item() { Descricao = "Mertiolate", Peso = 1, Utilidade = 11 });
            heuristica.AddItem(new Item() { Descricao = "Gaze", Peso = 1, Utilidade = 13 });
            heuristica.AddItem(new Item() { Descricao = "Perfume", Peso = 1, Utilidade = 1 });
            heuristica.AddItem(new Item() { Descricao = "Leite", Peso = 4, Utilidade = 10 });
            heuristica.AddItem(new Item() { Descricao = "Biscoitos", Peso = 4, Utilidade = 10 });
            heuristica.AddItem(new Item() { Descricao = "Sucrilhos", Peso = 3, Utilidade = 7 });
            heuristica.AddItem(new Item() { Descricao = "Bombons", Peso = 3, Utilidade = 5 });
            heuristica.AddItem(new Item() { Descricao = "Meias", Peso = 1, Utilidade = 2 });
            heuristica.AddItem(new Item() { Descricao = "Chapeu", Peso = 3, Utilidade = 7 });
            heuristica.AddItem(new Item() { Descricao = "Estilingue", Peso = 1, Utilidade = 4 });
            heuristica.AddItem(new Item() { Descricao = "Martelo", Peso = 6, Utilidade = 12 });
            heuristica.AddItem(new Item() { Descricao = "Arame", Peso = 6, Utilidade = 15 });
            

            heuristica.GerarSolucao();
            int u = 0;
            foreach (IComponente c in heuristica.Solucao.Componentes)
            {
                Item item = (Item)c;
                u += item.Utilidade;
                System.Console.WriteLine(item.Descricao + " \t\t\tPeso: " + item.Peso + " \tUtilidade: " + item.Utilidade);
            }

            System.Console.WriteLine("\n===================================================\n ");
            System.Console.WriteLine("Peso da Mochila: " + heuristica.Mochila.CapacidadeAtual);
            System.Console.WriteLine("Utilidade da Mochila: " + heuristica.Solucao.Avaliacao);
            */
           
            // Problema Cacheiro Viajante
            
            Viagem viagem = new Viagem();

            viagem.AddComponente(new Acesso("Belo Horizonte", "Salvador",1372 ));
            viagem.AddComponente(new Acesso("Belo Horizonte", "Brasília", 716));
            viagem.AddComponente(new Acesso("Belo Horizonte", "Vitória", 524));
            viagem.AddComponente(new Acesso("Belo Horizonte", "São Paulo", 586));
            viagem.AddComponente(new Acesso("Belo Horizonte", "Rio de Janeiro", 434));
            viagem.AddComponente(new Acesso("Belo Horizonte", "Curitiba", 1004));
            viagem.AddComponente(new Acesso("Belo Horizonte", "Florianópoles", 1301));

            viagem.AddComponente(new Acesso("Salvador", "Belo Horizonte", 1372));
            viagem.AddComponente(new Acesso("Salvador", "Brasília", 1446));
            viagem.AddComponente(new Acesso("Salvador", "Vitória", 1202));
            viagem.AddComponente(new Acesso("Salvador", "São Paulo", 1962));
            viagem.AddComponente(new Acesso("Salvador", "Rio de Janeiro", 1649));
            viagem.AddComponente(new Acesso("Salvador", "Curitiba", 2385));
            viagem.AddComponente(new Acesso("Salvador", "Florianópoles", 2682));

            viagem.AddComponente(new Acesso("Brasília", "Belo Horizonte", 716));
            viagem.AddComponente(new Acesso("Brasília", "Salvador", 1446));
            viagem.AddComponente(new Acesso("Brasília", "Vitória", 1239));
            viagem.AddComponente(new Acesso("Brasília", "São Paulo", 1015));
            viagem.AddComponente(new Acesso("Brasília", "Rio de Janeiro", 1148));
            viagem.AddComponente(new Acesso("Brasília", "Curitiba", 1366));
            viagem.AddComponente(new Acesso("Brasília", "Florianópoles", 1673));

            viagem.AddComponente(new Acesso("Vitória", "Belo Horizonte", 524));
            viagem.AddComponente(new Acesso("Vitória", "Salvador", 1202));
            viagem.AddComponente(new Acesso("Vitória", "Brasília", 1239));
            viagem.AddComponente(new Acesso("Vitória", "São Paulo", 882));
            viagem.AddComponente(new Acesso("Vitória", "Rio de Janeiro", 521));
            viagem.AddComponente(new Acesso("Vitória", "Curitiba", 1300));
            viagem.AddComponente(new Acesso("Vitória", "Florianópoles", 1597));

            viagem.AddComponente(new Acesso("São Paulo", "Belo Horizonte", 586));
            viagem.AddComponente(new Acesso("São Paulo", "Salvador", 1962));
            viagem.AddComponente(new Acesso("São Paulo", "Brasília", 1015));
            viagem.AddComponente(new Acesso("São Paulo", "Vitória", 882));
            viagem.AddComponente(new Acesso("São Paulo", "Rio de Janeiro", 429));
            viagem.AddComponente(new Acesso("São Paulo", "Curitiba", 408));
            viagem.AddComponente(new Acesso("São Paulo", "Florianópoles", 705));

            viagem.AddComponente(new Acesso("Rio de Janeiro", "Belo Horizonte", 434));
            viagem.AddComponente(new Acesso("Rio de Janeiro", "Salvador", 1649));
            viagem.AddComponente(new Acesso("Rio de Janeiro", "Brasília", 1148));
            viagem.AddComponente(new Acesso("Rio de Janeiro", "Vitória", 521));
            viagem.AddComponente(new Acesso("Rio de Janeiro", "São Paulo", 429));
            viagem.AddComponente(new Acesso("Rio de Janeiro", "Curitiba", 852));
            viagem.AddComponente(new Acesso("Rio de Janeiro", "Florianópoles", 1144));

            viagem.AddComponente(new Acesso("Curitiba", "Belo Horizonte", 1004));
            viagem.AddComponente(new Acesso("Curitiba", "Salvador", 2385));
            viagem.AddComponente(new Acesso("Curitiba", "Brasília", 1366));
            viagem.AddComponente(new Acesso("Curitiba", "Vitória", 1300));
            viagem.AddComponente(new Acesso("Curitiba", "São Paulo", 408));
            viagem.AddComponente(new Acesso("Curitiba", "Rio de Janeiro", 852));
            viagem.AddComponente(new Acesso("Curitiba", "Florianópoles", 300));

            viagem.AddComponente(new Acesso("Florianópoles", "Belo Horizonte", 1301));
            viagem.AddComponente(new Acesso("Florianópoles", "Salvador", 2682));
            viagem.AddComponente(new Acesso("Florianópoles", "Brasília", 1673));
            viagem.AddComponente(new Acesso("Florianópoles", "Vitória", 1597));
            viagem.AddComponente(new Acesso("Florianópoles", "São Paulo", 705));
            viagem.AddComponente(new Acesso("Florianópoles", "Rio de Janeiro", 1144));
            viagem.AddComponente(new Acesso("Florianópoles", "Curitiba", 300));

            viagem.GerarViagem("Belo Horizonte");
            
            foreach (Acesso a in viagem.rota)
                System.Console.WriteLine("Partida: " + a.cidPartida + "  Destino: "+a.cidDestino+"  Distancia: "+a.km+"KM\n");

            System.Console.WriteLine("Distância percorrida: " + viagem.kmPercorridos + "KM");

            
            System.Console.ReadLine();
        }
    }
}
