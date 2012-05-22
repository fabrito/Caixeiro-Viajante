using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class Perceptron
    {
        private double[] Pesos;
        private double TaxaAprendizado;
        private int MaximoIteracoes;
        private double ErroGlobal = 1;
        
        public Perceptron (int numx, double txaprendizado, int maxit){
            Pesos = new double[numx + 1];
            TaxaAprendizado = txaprendizado;
            MaximoIteracoes = maxit;            
         }

        public double Gerar(double[] x){
            if (x.Length != Pesos.Length -1){
                throw new Exception("Número de entradas não suportada.");
            }
            double net = 0;
            for (int c = 0; c < x.Length; c++) {
                net += x[c] * Pesos[c];
            }
            net += Pesos[x.Length]*1;
            return FuncaoAtivacao(net);
         }

        public double FuncaoAtivacao(double net) {
            if (net > 0)
                return 1;
            else
                return 0;
        }

        public void Treinar(int nn, double[,] x, double[] d)
        {
            int cont = 0;
            while (cont <= MaximoIteracoes){
                for(int c = 0; c < nn; c++){
                    double[] tmp = new double[Pesos.Length-1];
                    for (int tc = 0; tc < Pesos.Length-1; tc++)
                        tmp[tc] = x[c, tc];
                    Treinar(tmp,d[c]);
                }
            }
        }

        public void Treinar(double[] x, double d) {
            ErroGlobal = 1;
            int cont = 0;
            while (ErroGlobal != 0 && cont <= MaximoIteracoes)
            {
                cont++;
                double y = Gerar(x);
                ErroGlobal = d - y;
                Console.WriteLine("Saida Desejada: " + d + "\tSaida da Rede:" + y+"\tErro:"+ErroGlobal);
                if (ErroGlobal != 0)
                {
                    
                    Console.WriteLine("erro: " + ErroGlobal);
                    for (int c = 0; c < x.Length; c++)
                    {
                        Pesos[c] = Pesos[c] + TaxaAprendizado * x[c] * ErroGlobal;
                    }
                    Pesos[x.Length] = Pesos[x.Length] + TaxaAprendizado * 1 * ErroGlobal;
                    
                }
            }

        }

    }
}
