using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    public class VariavelLinguistica<T> : IVariavelLinguistica
    {
        public T MinValor
        {
            get;
            set;
        }

        public T MaxValor
        {
            get;
            set;
        }

        public IList<String> Termos
        {
            get;
            set;
        }

        public Dictionary<String, IFuncaoPertinencia<T>> Conjuntos
        {
            get;
            set;
        }

        public VariavelLinguistica(T min, T max)
        {
            this.MinValor = min;
            this.MaxValor = max;
            Conjuntos = new Dictionary<string, IFuncaoPertinencia<T>>();
            Termos = new List<String>();
        }

        public void AddTermo(String nome, TipoFuncaoPertinencia tipo, float[] parametros){
            IFuncaoPertinencia<T> funcao = null;

            if(tipo == TipoFuncaoPertinencia.Triangular)
                funcao = new Triangular<T>();
            else if (tipo == TipoFuncaoPertinencia.Trapezoidal)
                funcao = new Trapezoidal<T>();

            funcao.Configurar(parametros);
            Conjuntos.Add(nome, funcao);
            Termos.Add(nome);
        }

        public float[] Pertinencia(Object value)
        {
            return Pertinencia((T)value);
        }

        public float[] Pertinencia(T value)
        {
            float[] retorno = new float[Conjuntos.Keys.Count];
            int count = 0;
            foreach (String termo in Conjuntos.Keys)
            {
                retorno[count] = Conjuntos[termo].Pertinencia(value);
                count++;
            }
            return retorno;

        }

        public float Pertinencia(String termo, Object value)
        {
            return Pertinencia(termo,(T)value);
        }

        public float Pertinencia(String termo, T value)
        {
            return Conjuntos[termo].Pertinencia(value);
        }

        public String ImprimePertinencia(T value)
        {
            String resultado = "";
            float[] retorno = Pertinencia(value);
            int count = 0;
            foreach (String termo in Conjuntos.Keys)
            {
                resultado += termo + " = " + retorno[count].ToString() + "\n";
                count++;
            }

            return resultado;
        }

        public float Centroide(string termo)
        {
            return Conjuntos[termo].Centroide();
        }

    }
}
