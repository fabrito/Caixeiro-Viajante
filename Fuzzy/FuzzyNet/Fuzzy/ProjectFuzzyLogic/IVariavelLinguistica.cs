using System;
using System.Collections.Generic;
namespace FuzzyLogic
{
    public interface IVariavelLinguistica
    {
        IList<String> Termos { get; set; }
        void AddTermo(string nome, TipoFuncaoPertinencia tipo, float[] parametros);
        float[] Pertinencia(object value);
        float Pertinencia(string termo, object value);
        float Centroide(string termo);
    }
}
