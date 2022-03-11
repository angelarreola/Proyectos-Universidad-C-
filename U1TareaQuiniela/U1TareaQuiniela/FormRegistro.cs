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
    public partial class FormRegistro : Form
    {
        private Quiniela quiniela;

        public FormRegistro()
        {
            InitializeComponent();

        }

        public FormRegistro(Quiniela quiniela)
        {
            InitializeComponent(); 
            this.quiniela = quiniela;

        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void pBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (TextBoxNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre");
            }
            else
            {
                JObject json = new JObject();
                json.Add("nombre", TextBoxNombre.Text);
                JObject jsonRonda1 = new JObject();

                jsonRonda1.Add("enfrentamiento1", enfrentamiento(radioBtnEmpate1, radioBtnEquipo1, radioBtnEquipo2, nUpDownEquipo1, nUpDownEquipo2));
                jsonRonda1.Add("enfrentamiento2", enfrentamiento(radioBtnEmpate2, radioBtnEquipo3, radioBtnEquipo4, nUpDownEquipo3, nUpDownEquipo4));
                jsonRonda1.Add("enfrentamiento3", enfrentamiento(radioBtnEmpate3, radioBtnEquipo5, radioBtnEquipo6, nUpDownEquipo5, nUpDownEquipo6));
                jsonRonda1.Add("enfrentamiento4", enfrentamiento(radioBtnEmpate4, radioBtnEquipo7, radioBtnEquipo8, nUpDownEquipo7, nUpDownEquipo8));

                json.Add("ronda1", jsonRonda1);

                Console.WriteLine("JSON: " + json);

                quiniela.arrayQuiniela.Add(json);

                Form formSemifinal = new FormSemiFinal(quiniela);
                this.Close();
                formSemifinal.Show();
                
            }
        }

        public JObject enfrentamiento(RadioButton radioEmpate, RadioButton radio1, RadioButton radio2, NumericUpDown spinner1, NumericUpDown spinner2)
        {
            JObject jsonG = new JObject();
            // Operador Ternario
            jsonG.Add("ganador", radioEmpate.Checked ? "Empate" : (radio1.Checked ? radio1.Text : radio2.Text) );

            JArray arrayMarcador = new JArray();
            arrayMarcador.Add("" + spinner1.Value);
            arrayMarcador.Add("" + spinner2.Value);

            jsonG.Add("marcador", arrayMarcador);

            return jsonG;
        }

    }
}
