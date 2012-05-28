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
            /*Perceptron p = new Perceptron(2, 0.1, 1000);
            p.Treinar(new double[] { 0, 0 }, 0);
            p.Treinar(new double[] { 1, 0 }, 0);
            p.Treinar(new double[] { 0, 1 }, 0);
            p.Treinar(new double[] { 1, 1 }, 1);*/
            

            double[] um = new double[] { 
                0, 0, 1, 0, 
                0, 0, 1, 0, 
                0, 0, 1, 0, 
                0, 0, 1 ,0,
                0, 1, 1, 0};
            double[] saidasum = new double[] {
                1,0,0,0};

            double[] dois = new double[] { 
                1, 1, 1, 1, 
                0, 0, 0, 1, 
                1, 1, 1, 1,  
                1, 0, 0 ,0,
                1, 1, 1, 1 };
            double[] saidasdois = new double[] {
                0,1,0,0};
            
            Camada camada = new Camada(4, 20, 0.5, 1000, new FuncaoDegrau());
            camada.Treinar(um, saidasum);
            camada.Treinar(dois, saidasdois);
           
            Console.ReadLine();
            
        }
    }
}
