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
    public partial class FormResultados : Form
    {
        public Quiniela quiniela;
        public JObject JSONquinielaGanadora;
        public FormResultados()
        {
            InitializeComponent();
        }

        public FormResultados(Quiniela quiniela, JObject quinielaGanadora)
        {
            InitializeComponent();
            this.quiniela = quiniela;
            this.JSONquinielaGanadora = quinielaGanadora;


            Console.WriteLine(quiniela.arrayQuiniela);

            cargaQuiniela();
        }

        private void cargaQuiniela()
        {
            for (int i = 0; i < quiniela.arrayQuiniela.Count(); i++)
            {
                JObject jsonParticipante = (JObject) quiniela.arrayQuiniela.ElementAt(i);
                
                JObject jsonRonda1 = (JObject)jsonParticipante.GetValue("ronda1");
                JObject jEnfrentamiento1 = (JObject)jsonRonda1.GetValue("enfrentamiento1");
                JObject jEnfrentamiento2 = (JObject)jsonRonda1.GetValue("enfrentamiento2");
                JObject jEnfrentamiento3 = (JObject)jsonRonda1.GetValue("enfrentamiento3");
                JObject jEnfrentamiento4 = (JObject)jsonRonda1.GetValue("enfrentamiento4");


                JObject jsonRonda2 = (JObject)jsonParticipante.GetValue("ronda2");
                JObject jEnfrentamiento5 = (JObject)jsonRonda2.GetValue("enfrentamiento1");
                JObject jEnfrentamiento6 = (JObject)jsonRonda2.GetValue("enfrentamiento2");


                JObject jsonRonda3 = (JObject)jsonParticipante.GetValue("ronda3");
                JObject jEnfrentamiento7 = (JObject)jsonRonda3.GetValue("enfrentamiento1");

                this.dataGridView1.Rows.Insert(i, jsonParticipante.GetValue("nombre"),
                    jEnfrentamiento1.ToString(),
                    jEnfrentamiento2.ToString(),
                    jEnfrentamiento3.ToString(),
                    jEnfrentamiento4.ToString(),
                    jEnfrentamiento5.ToString(),
                    jEnfrentamiento6.ToString(),
                    jEnfrentamiento7.ToString()
                    );
            }

        }

        private string datos(JObject jsonRonda, string enfrentamiento)
        {
            string datos = "";
            JObject jsonEnfrentamiento = (JObject)jsonRonda.GetValue(enfrentamiento);
            datos += jsonEnfrentamiento.GetValue("ganador") + System.Environment.NewLine + jsonEnfrentamiento.GetValue("marcador");
            return datos;
        }

        private void pBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
