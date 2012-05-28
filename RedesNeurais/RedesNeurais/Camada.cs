using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class Camada
    {
        List<Perceptron> neuronios;
        double[] saidas;
        public int NumeroNeuronios        
        {
            get
            {
                return neuronios.Count;
            }
        }
        
        public Camada(int quantNeuronios, int quantEntradas,
            double n, int maxi, IFuncaoAtivacao a) {
            neuronios = new List<Perceptron>();
            saidas = new double[quantNeuronios];
            for (int i = 0; i < quantNeuronios; i++) {
                neuronios.Add(new Perceptron(quantEntradas, 
                    n, maxi, a));
            }
        }

        public double[] Gerar(double[] x) {
            int cont =0; 
            foreach (Perceptron p in neuronios) {
                saidas[cont] = p.Gerar(x);
                cont++;
            }
            return saidas;
        }

        public void Treinar(double[] x, double[] d) {
            int cont = 0;
            Console.WriteLine("Treinando camada");
            foreach (Perceptron p in neuronios)
            {
                p.Treinar(x, d[cont]);
                cont++;
            }            
        }
    }
}
