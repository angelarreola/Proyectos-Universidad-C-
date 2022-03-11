using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace U1TareaQuiniela
{
    public partial class FormSemiFinal : Form
    {
        public Quiniela quiniela;

        private JObject participante;


        public FormSemiFinal()
        {
            InitializeComponent();
        }

        public FormSemiFinal(Quiniela quiniela)
        {
            InitializeComponent();

            this.quiniela = quiniela;

            // Se lee el arrayQuiniela
            participante = (JObject) quiniela.arrayQuiniela.ElementAt(quiniela.arrayQuiniela.Count - 1);
            Console.WriteLine("Participante: " + participante.ToString());

            // Se obtiene la ronda1
            JObject jsonR1 = (JObject)participante.GetValue("ronda1");

            // Se obtiene el ganador 1
            JObject jsonGanador1 = (JObject)jsonR1.GetValue("enfrentamiento1");
            radioBtnEquipo1.Text = ("" + jsonGanador1.GetValue("ganador"));

            // Se obtiene el ganador 2
            JObject jsonGanador2 = (JObject)jsonR1.GetValue("enfrentamiento2");
            radioBtnEquipo2.Text = ("" + jsonGanador2.GetValue("ganador"));

            // Se obtiene el ganador 3
            JObject jsonGanador3 = (JObject)jsonR1.GetValue("enfrentamiento3");
            radioBtnEquipo3.Text = ("" + jsonGanador3.GetValue("ganador"));

            // Se obtiene el ganador 4
            JObject jsonGanador4 = (JObject)jsonR1.GetValue("enfrentamiento4");
            radioBtnEquipo4.Text = ("" + jsonGanador4.GetValue("ganador"));

        }

        private void pBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarSemifinal_Click(object sender, EventArgs e)
        {
            // Del participante se agrega la ronda 2
            JObject jsonRonda2 = new JObject();

            FormRegistro r = new FormRegistro();

            jsonRonda2.Add("enfrentamiento1", r.enfrentamiento(radioBtnEmpate1, radioBtnEquipo1, radioBtnEquipo2, nUpDownEquipo1, nUpDownEquipo2));
            jsonRonda2.Add("enfrentamiento2", r.enfrentamiento(radioBtnEmpate2, radioBtnEquipo3, radioBtnEquipo4, nUpDownEquipo3, nUpDownEquipo4));

            participante.Add("ronda2", jsonRonda2);

            quiniela.arrayQuiniela.RemoveAt(quiniela.arrayQuiniela.Count - 1);
            quiniela.arrayQuiniela.Add(participante);

            Console.WriteLine(quiniela.arrayQuiniela.ToString());

            Form formFinal = new FormFinal(quiniela);
            this.Close();
            formFinal.Show();
            
        }
    }
}
