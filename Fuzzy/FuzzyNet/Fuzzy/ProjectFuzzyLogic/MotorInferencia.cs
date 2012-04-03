using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    public class MotorInferencia
    {
        public IList<Regra> BaseConhecimento
        {
            get;
            set;
        }

        public IList<IVariavelLinguistica> VariaveisEstado
        {
            get;
            set;
        }

        public IList<IVariavelLinguistica> VariaveisControle
        {
            get;
            set;
        }

        public MotorInferencia()
        {
            BaseConhecimento = new List<Regra>();
            VariaveisEstado = new List<IVariavelLinguistica>();
            VariaveisControle = new List<IVariavelLinguistica>();
        }

        public void AddRegra(Regra r)
        {
            BaseConhecimento.Add(r);
        }
            
      
        public void Entrada(IVariavelLinguistica variavel, Object valor)
        {
            foreach (Regra regra in BaseConhecimento)
                regra.Entrada(variavel, valor);
        }

        public object Saida(IVariavelLinguistica variavel)
        {
            float saida = 0;
            foreach (Regra regra in BaseConhecimento)
            {
                regra.Implicacao();

                foreach (String termo in variavel.Termos)
                {
                    float ativacao = regra.Saida(variavel, termo);
                    float centroide = variavel.Centroide(termo);
                    saida += ativacao * centroide;
                }
            }

            return saida;
        }
    }
}
