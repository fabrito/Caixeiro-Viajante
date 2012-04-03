using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
   

    public class Triangular<T>: IFuncaoPertinencia<T> 
    {
        float a,b,c;
        public TipoFuncaoPertinencia Tipo
        {
            get{
                return TipoFuncaoPertinencia.Triangular;
            }
        }

        public void Configurar (float[] parametros)
        {
            a = parametros[0];
            b = parametros[1];
            c = parametros[2];
        }

        public float Pertinencia( T entrada)
        {
            float x = float.Parse( entrada.ToString());
            float tmp = Math.Min((x - a) / (b - a), (c - x) / (c - b));
            return Math.Max(tmp, 0);
        }

        public float Centroide()
        {
            return c;
        }
    }
    
    
}
 