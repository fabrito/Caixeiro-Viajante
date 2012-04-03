using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FuzzyLogic;

namespace FuzzyLogic.Presentation.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            VariavelLinguistica<int> atendimento = new VariavelLinguistica<int>(0, 10);
            atendimento.AddTermo("Ruim", TipoFuncaoPertinencia.Trapezoidal, new float[] { -1, 0, 2.5f, 5 });
            atendimento.AddTermo("Medio", TipoFuncaoPertinencia.Triangular, new float[] { 2.5f, 5, 7.5f });
            atendimento.AddTermo("Bom", TipoFuncaoPertinencia.Trapezoidal, new float[] { 5, 7.5f, 10, 11 });

            VariavelLinguistica<int> comida = new VariavelLinguistica<int>(0, 10);
            comida.AddTermo("Ruim", TipoFuncaoPertinencia.Trapezoidal, new float[] { -1, 0, 2.5f, 5 });
            comida.AddTermo("Medio", TipoFuncaoPertinencia.Triangular, new float[] { 2.5f, 5, 7.5f });
            comida.AddTermo("Bom", TipoFuncaoPertinencia.Trapezoidal, new float[] { 5, 7.5f, 10, 11 });

            VariavelLinguistica<int> gorjeta = new VariavelLinguistica<int>(0, 15);
            gorjeta.AddTermo("Ruim", TipoFuncaoPertinencia.Trapezoidal, new float[] { -1, 0, 3.5f, 7.5f });
            gorjeta.AddTermo("Medio", TipoFuncaoPertinencia.Triangular, new float[] { 3.5f, 7.5f, 11 });
            gorjeta.AddTermo("Bom", TipoFuncaoPertinencia.Trapezoidal, new float[] { 7.5f, 11, 15, 16 });

            MotorInferencia inferencia = new MotorInferencia();

            inferencia.VariaveisEstado.Add(atendimento);
            inferencia.VariaveisEstado.Add(comida);

            inferencia.VariaveisControle.Add(gorjeta);

            inferencia.AddRegra(new Regra()
                .Se(atendimento, "Ruim", Conector.AND)
                .Se(comida, "Ruim", Conector.AND)
                .Entao(gorjeta, "Ruim", Conector.AND));
            
            inferencia.AddRegra(new Regra()
                .Se(atendimento, "Medio", Conector.AND)
                .Se(comida, "Ruim", Conector.AND)
                .Entao(gorjeta, "Medio", Conector.AND));

            inferencia.AddRegra(new Regra()
                .Se(atendimento, "Medio", Conector.AND)
                .Se(comida, "Medio", Conector.AND)
                .Entao(gorjeta, "Medio", Conector.AND));

            inferencia.AddRegra(new Regra()
                .Se(atendimento, "Ruim", Conector.AND)
                .Se(comida, "Medio", Conector.AND)
                .Entao(gorjeta, "Ruim", Conector.AND));

            inferencia.AddRegra(new Regra()
                .Se(atendimento, "Bom", Conector.AND)
                .Se(comida, "Ruim", Conector.AND)
                .Entao(gorjeta, "Medio", Conector.AND));

            inferencia.AddRegra(new Regra()
                .Se(atendimento, "Bom", Conector.AND)
                .Se(comida, "Medio", Conector.AND)
                .Entao(gorjeta, "Bom", Conector.AND));

            inferencia.AddRegra(new Regra()
                .Se(atendimento, "Medio", Conector.AND)
                .Se(comida, "Bom", Conector.AND)
                .Entao(gorjeta, "Bom", Conector.AND));

            inferencia.AddRegra(new Regra()
                .Se(atendimento, "Bom", Conector.AND)
                .Se(comida, "Bom", Conector.AND)
                .Entao(gorjeta, "Bom", Conector.AND));


            inferencia.Entrada(atendimento, 7);
            inferencia.Entrada(comida, 7);


            System.Console.WriteLine(inferencia.Saida(gorjeta));

            System.Console.ReadLine();

        }
    }
}
