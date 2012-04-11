using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Restaurante.DomainModel;

namespace Restaurante.Presentation.Desktop
{
    public partial class Form1 : Form
    {
        RadioButton[] comida, atendimento;
        RestauranteFuzzyLogic restaurante;

        public Form1()
        {
            InitializeComponent();
            comida = new RadioButton[] { radioButton1, radioButton2, radioButton3,
                radioButton4,radioButton5,radioButton6,radioButton7,
                radioButton8,radioButton9,radioButton10};
            atendimento = new RadioButton[] { radioButton11, radioButton12, radioButton13,
                radioButton14,radioButton15,radioButton16,radioButton17,
                radioButton18,radioButton19,radioButton20};
            restaurante = new RestauranteFuzzyLogic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int comida_val = 0;
            int atendimento_val = 0;
            float gorJeta = 0;

            foreach (RadioButton r in comida)
                if (r.Checked)
                    comida_val = Int32.Parse(r.Text);

            foreach (RadioButton r in atendimento)
                if (r.Checked)
                    atendimento_val = Int32.Parse(r.Text);

            restaurante.NotaAtendimento(atendimento_val);
            restaurante.NotaComida(comida_val);

            gorJeta = restaurante.GetGorjeta();

            label2.Text = gorJeta.ToString();
        }

       
    }
}
