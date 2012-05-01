using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HeuristicaConstrutiva;

namespace HeuristicaMelhoria
{
    public abstract class HeuristicaMelhoria
    {
        public ISolucao Solucao { get; set; }

        public abstract List<ISolucao> GerarVizinhanca();
        public abstract ISolucao EscolheMelhorVizinho(List<ISolucao> vizinhos);
        public abstract ISolucao CriaSolucaoInicial();
        public abstract bool VerificaCondicaoParada();

        public void GerarSolucao()
        {
            Solucao = CriaSolucaoInicial();

            while (!VerificaCondicaoParada())
            {
                List<ISolucao> vizinhos = GerarVizinhanca();
                ISolucao vizinho = EscolheMelhorVizinho(vizinhos);

                if (Solucao.Avaliacao <= vizinho.Avaliacao)
                    Solucao = vizinho;

            }
        }

    }
}
