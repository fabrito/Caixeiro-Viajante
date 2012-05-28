using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public interface IFuncaoAtivacao{
        double Ativacao(double a);
        double Derivada(double a);
    }
}
