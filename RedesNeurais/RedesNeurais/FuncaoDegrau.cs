using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class FuncaoDegrau: IFuncaoAtivacao
    {

        public double Ativacao(double a)
        {
            if (a > 0)
                return 1;
            else
                return 0;
        }

        public double Derivada(double a)
        {
            return Ativacao(a);
        }
    }
}
