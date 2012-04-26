using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace ProblemaMochila
{
    class ConstroiMochila : HeuristicaConstrutiva.HeuristicaConstrutiva
    {

        public override List<IComponente> GerarComponentes()
        {
            throw new NotImplementedException();
        }

        public override IComponente EscolheMelhorComponente(List<IComponente> Componentes)
        {
            throw new NotImplementedException();
        }

        public override ISolucao CriaSolucaoVazia()
        {
            return new Mochila();
        }

        public override bool VerificaSolucaoCompleta()
        {
            throw new NotImplementedException();
        }
    }
}
