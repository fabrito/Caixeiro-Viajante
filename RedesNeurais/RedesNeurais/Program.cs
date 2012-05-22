using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[,] conjTreinamento = new double[,] {
                { 0, 0 },
                { 0, 1 },
                { 1, 0 },
                { 1, 1 } };

            double[] conjTreinamentoSaidas = new double[] {
                0,
                0,
                0,
                1 };

            Perceptron p = new Perceptron(2, 0.1, 1000);

            p.Treinar(4, conjTreinamento, conjTreinamentoSaidas);

            Console.ReadLine();
        }
    }
}
