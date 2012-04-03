using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    public enum TipoFuncaoPertinencia
    {
        Triangular,
        Trapezoidal,
        Sigmoide
    }

    public interface IFuncaoPertinencia<T>
    {
        TipoFuncaoPertinencia Tipo { get; }
        void Configurar(float[] parametros);
        float Pertinencia(T entrada);
        float Centroide();
    }
}
