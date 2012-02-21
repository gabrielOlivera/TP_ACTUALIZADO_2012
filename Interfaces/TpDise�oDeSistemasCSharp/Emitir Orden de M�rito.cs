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
    public partial class Emitir_Orden_de_Mérito : Form
    {
        public Emitir_Orden_de_Mérito(string user)
        {
            InitializeComponent();
            this.Consultor.Text = user;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            ResultadosDeBusqueda.Visible = true;
        }
    }
}
