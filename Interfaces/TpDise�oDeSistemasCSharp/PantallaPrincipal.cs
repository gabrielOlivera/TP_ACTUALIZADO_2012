using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Entidades;

namespace TpDiseñoCSharp
{
    public partial class PantallaPrincipal : Form
    {

        public PantallaPrincipal()
        {
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void LoginConsultor_Click(object sender, EventArgs e)
        {
            LoginConsultor logCons= new LoginConsultor(this);
            logCons.ShowDialog();

        }

        private void LoginCandidato_Click(object sender, EventArgs e)
        {
            LoginCandidato logCand = new LoginCandidato(this);
            logCand.ShowDialog();
        }
    }
}
