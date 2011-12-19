using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TpDiseñoCSharp
{
    public partial class AutenticarUsuario : Form
    {
        public AutenticarUsuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Fecha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void PanelSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SeleccionDeAcceso_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginConsultor_Click(object sender, EventArgs e)
        {
            LoginConsultor logCons= new LoginConsultor();
            logCons.ShowDialog();
        }

        private void LoginCandidato_Click(object sender, EventArgs e)
        {
            LoginCandidato logCand = new LoginCandidato();
            logCand.ShowDialog();
        }

        
    }
}
