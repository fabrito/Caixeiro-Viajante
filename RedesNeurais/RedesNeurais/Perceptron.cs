using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class Perceptron
    {
        private double[] w;
        private double n;
        private int max;
        private double e = 1;
        
        public Perceptron (int numx, double txaprendizado, int maxit){
            w = new double[numx + 1];
            n = txaprendizado;
            max = maxit;            
         }

        public double Gerar(double[] x){
            if (x.Length != w.Length -1){
                throw new Exception("Número de entradas não suportada.");
            }
            double net = 0;
            for (int c = 0; c < x.Length; c++) {
                net += x[c] * w[c];
            }
            net += w[x.Length]*1;
            return Pertinencia(net);
         }

        public double Pertinencia(double net) {
            if (net > 0)
                return 1;
            else
                return 0;
        }

        public void Treinar(int nn, double[,] x, double[] d)
        {
            int cont = 0;
            while (e != 0 && cont <= max){
                for(int c = 0; c < nn; c++){
                    double[] p = x;
                    Treinar(x,d[c]);
                }
            }
        }

        public void Treinar(double[] x, double d) {
            e = 1;
            int cont = 0;
            while (e != 0 && cont <= max)
            {
                cont++;
                double y = Gerar(x);
                e = d - y;
                Console.WriteLine("Saida Desejada: " + d + "Saida da Rede:" + y);
                if (e != 0)
                {
                    
                    Console.WriteLine("erro: " + e);
                    for (int c = 0; c < x.Length; c++)
                    {
                        w[c] = w[c] + n * x[c] * e;
                    }
                    w[x.Length] = w[x.Length] + n * 1 * e;
                    
                }
            }

        }

    }
}
