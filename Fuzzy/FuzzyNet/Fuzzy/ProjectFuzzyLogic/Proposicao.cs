using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    public class Proposicao
    {

        public Proposicao(IVariavelLinguistica var, String termo, Conector con)
        {
            Variavel = var;
            Termo = termo;
            Conector = con;
        }

        public IVariavelLinguistica Variavel
        {
            get;
            set;
        }

        public String Termo
        {
            get;
            set;
        }

        public Conector Conector
        {
            get;
            set;
        }

        public float Ativavao
        {
            get;
            set;
        }

        public void Entrada(Object valor)
        {
            Ativavao = Variavel.Pertinencia(Termo, valor);
        }
    }
}
