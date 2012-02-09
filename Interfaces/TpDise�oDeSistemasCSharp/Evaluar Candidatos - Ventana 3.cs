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

            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = user;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);
        }
    }
}
