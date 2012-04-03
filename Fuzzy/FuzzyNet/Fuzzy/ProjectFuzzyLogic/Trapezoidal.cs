using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
   

    public class Trapezoidal<T>: IFuncaoPertinencia<T> 
    {
        float a,b,c,d;
        public TipoFuncaoPertinencia Tipo
        {
            get{
                return TipoFuncaoPertinencia.Trapezoidal;
            }
        }

        public void Configurar (float[] parametros)
        {
            a = parametros[0];
            b = parametros[1];
            c = parametros[2];
            d = parametros[3];
        }

        public float Pertinencia( T entrada)
        {
            float x = float.Parse( entrada.ToString());
            float tmp = Math.Min((x - a) / (b - a),1);
            tmp = Math.Min(tmp, (d - x) / (d - c));
            return Math.Max(tmp, 0);
        }

        public float Centroide()
        {
            return (b+c)/2;
        }
    }
    
    
}
 