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
    public partial class FormFinal : Form
    {

        public Quiniela quiniela;

        private JObject participante;
        public FormFinal()
        {
            InitializeComponent();
        }

        public FormFinal(Quiniela quiniela)
        {
            InitializeComponent();
            this.quiniela = quiniela;


            // Se lee el arrayQuiniela
            participante = (JObject)quiniela.arrayQuiniela.ElementAt(quiniela.arrayQuiniela.Count - 1);
            Console.WriteLine("Participante: " + participante.ToString());

            // Se obtiene la ronda2
            JObject jsonR1 = (JObject)participante.GetValue("ronda2");

            // Se obtiene el ganador 1
            JObject jsonGanador1 = (JObject)jsonR1.GetValue("enfrentamiento1");
            radioBtnEquipo1.Text = ("" + jsonGanador1.GetValue("ganador"));

            // Se obtiene el ganador 2
            JObject jsonGanador2 = (JObject)jsonR1.GetValue("enfrentamiento2");
            radioBtnEquipo2.Text = ("" + jsonGanador2.GetValue("ganador"));
        }

        private void pBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarFinal_Click(object sender, EventArgs e)
        {
            // Del participante se agrega la ronda 3 final
            JObject jsonRonda3 = new JObject();

            FormRegistro r = new FormRegistro();

            jsonRonda3.Add("enfrentamiento1", r.enfrentamiento(radioBtnEmpate1, radioBtnEquipo1, radioBtnEquipo2, nUpDownEquipo1, nUpDownEquipo2));

            participante.Add("ronda3", jsonRonda3);

            quiniela.arrayQuiniela.RemoveAt(quiniela.arrayQuiniela.Count - 1);
            quiniela.arrayQuiniela.Add(participante);

            Console.WriteLine(quiniela.arrayQuiniela.ToString());

            Form formResultados = new FormResultados(quiniela, quiniela.quinielaGanadora);
            this.Close();
            formResultados.Show();
        }
    }
}
