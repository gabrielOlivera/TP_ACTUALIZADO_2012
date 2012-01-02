using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Gestores;

namespace TpDiseñoCSharp
{
    public partial class Completar_Cuestionario : Form
    {
        private Bloque bloque_a_mostrar;

        public Completar_Cuestionario()
        {
            InitializeComponent();
        }

        public Bloque Bloque_a_mostrar
        {
            get { return bloque_a_mostrar; }
            set { bloque_a_mostrar = value; }

        }
    }
}
