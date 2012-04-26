using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeuristicaConstrutiva
{
    public interface ISolucao
    {
        List<IComponente> Componentes { get; set; }
        float Avaliacao { get; }

        void AddComponente(IComponente Componente);
        void RemoveComponente(IComponente Componente);
    }
}
