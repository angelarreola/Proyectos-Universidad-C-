using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace U1TareaQuiniela
{
    public partial class Quiniela : Form
    {

        public JArray arrayQuiniela;
        public JObject quinielaGanadora;

        public Quiniela()
        {
            InitializeComponent();
            arrayQuiniela = new JArray();
            quinielaGanadora = new JObject();
        }

        private void pBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void desarrolladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por Angel Arreola");
        }

        private void quinielaToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            quinielaToolStripMenuItem.ForeColor = Color.Black;
        }

        private void quinielaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            quinielaToolStripMenuItem.ForeColor = Color.White;

        }

        private void acercaDeToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            acercaDeToolStripMenuItem.ForeColor = Color.Black;


        }

        private void acercaDeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            acercaDeToolStripMenuItem.ForeColor= Color.White;

        }

        private void labelVisual_Click(object sender, EventArgs e)
        {

        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formRegistro = new FormRegistro(this);
            formRegistro.Show();
        }

        private void resultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
