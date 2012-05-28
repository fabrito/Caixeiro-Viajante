using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class RNA 
    {
        private Camada[] camadas;
        private IFuncaoAtivacao ativacao;
        private double taxaAprendizado;
        private int numEntradas, numSaidas, numCamadas;

        public RNA(IFuncaoAtivacao ativacao,
            double taxaAprendizado, int numEntradas,
            int numSaidas, int numCamadas) {
                this.ativacao = ativacao;
                this.taxaAprendizado = taxaAprendizado;
                this.numEntradas = numEntradas;
                this.numSaidas = numSaidas;
                this.numCamadas = numCamadas;
                camadas = new Camada[numCamadas];
        }

        public void ConfiguraCamada(int index, int quantNeuronios) { 
            int qtdEntradas;
            if (index == 0)
                   qtdEntradas = numEntradas;
            else{
                   qtdEntradas = camadas[index - 1].NumeroNeuronios;
                } 
            
            camadas[index] = new Camada(quantNeuronios, qtdEntradas,
            taxaAprendizado, 1000, ativacao);
        }

        public double[] Gerar(double[] x) {
            double[] saida = camadas[0].Gerar(x);
            for (int i = 1; i < numCamadas; i++) {
                saida = camadas[i].Gerar(saida);
            }
            return saida;
        }
    }
}
