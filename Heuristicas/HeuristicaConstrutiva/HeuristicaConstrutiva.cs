using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeuristicaConstrutiva
{
    public abstract class HeuristicaConstrutiva
    {
        public ISolucao Solucao { get; set; }

        public abstract List<IComponente> GerarComponentes();
        public abstract IComponente EscolheMelhorComponente(List<IComponente> Componentes);
        public abstract ISolucao CriaSolucaoVazia();
        public abstract bool VerificaSolucaoCompleta();

        public void GerarSolucao()
        {
            Solucao = CriaSolucaoVazia();
            
            while (!VerificaSolucaoCompleta())
            {
                List<IComponente> Componentes = GerarComponentes();
                IComponente Temp = EscolheMelhorComponente(Componentes);

                Solucao.AddComponente(Temp);
                
            }        
        }







    }
}
