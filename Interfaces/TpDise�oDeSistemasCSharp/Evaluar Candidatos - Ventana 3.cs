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
    public partial class Evaluar_Candidatos___Ventana_3 : Form
    {
        public Evaluar_Candidatos___Ventana_3(string user)
        {
            InitializeComponent();
            this.Consultor.Text = user;
        }
    }
}
