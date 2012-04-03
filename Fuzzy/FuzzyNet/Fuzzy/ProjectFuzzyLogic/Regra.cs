using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    public class Regra
    {
        public Regra()
        {
            Antecedente = new List<Proposicao>();
            Consequente = new List<Proposicao>();
        }

        public IList<Proposicao> Antecedente
        {
            get;
            set;
        }

        public IList<Proposicao> Consequente
        {
            get;
            set;
        }


        public void AddAntecedente(Proposicao p)
        {
            Antecedente.Add(p);
        }

        public void AddConsequente(Proposicao p)
        {
            Consequente.Add(p);
        }

        public Regra Se(IVariavelLinguistica var, String termo, Conector con)
        {
            AddAntecedente(new Proposicao(var, termo, con));
            return this;
        }

        public Regra Entao(IVariavelLinguistica var, String termo, Conector con)
        {
            AddConsequente(new Proposicao(var, termo, con));
            return this;
        }

        public void Entrada(IVariavelLinguistica var, Object value)
        {
            foreach(Proposicao p in Antecedente) 
                if(p.Variavel == var)
                    p.Entrada(value);
        }

        public float Implicacao()
        {
            float tmp = 0;
            Proposicao anterior = null;
            foreach (Proposicao p in Antecedente)
            {
                if(anterior != null){
                    if (anterior.Conector == Conector.AND)
                        tmp = Math.Min(tmp, p.Ativavao);
                    else if(anterior.Conector == Conector.AND)
                        tmp = Math.Max(tmp, p.Ativavao);
                } else {
                    tmp = p.Ativavao;
                }
                anterior = p;
            }

            foreach (Proposicao p in Consequente)
                p.Ativavao = Math.Max(p.Ativavao, tmp);

            return tmp;
        }

        public float Saida(IVariavelLinguistica variavel, String termo)
        {
            foreach (Proposicao p in Consequente)
                if (p.Variavel == variavel && p.Termo == termo)
                    return p.Ativavao;

            return 0;
        }
    }
}
