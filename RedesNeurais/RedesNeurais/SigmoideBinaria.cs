using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class SigmoideBinaria: IFuncaoAtivacao 
    {
        public double Ativacao(double a)
        {
            return 1.0/(Math.Exp(-0.005*a));
        }

        public double Derivada(double a)
        {
            return 0.005 * Ativacao (a)* (1.0 - Ativacao(a));
        }
    }
}
