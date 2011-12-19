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
    public partial class OrdenDeMerito_VistaImpresion : Form
    {
        public OrdenDeMerito_VistaImpresion()
        {
            InitializeComponent();
        }

        private void OrdenDeMerito_VistaImpresion_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
