using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestores;
using Entidades;

namespace TpDiseñoCSharp
{
    public partial class Orden_de_merito : Form
    {
        public Orden_de_merito(List<Candidato_Vista_impresion> sin_contestar, List<Candidato_Vista_impresion> Incompletos, List<Candidato_Vista_impresion> completos_sin_minimos, List<Candidato_Vista_impresion> completos_con_minimos )
        {
            InitializeComponent();
 
            
            completosCON_minimos_dgv.DataSource = completos_con_minimos;
            completosSIN_minimos_dgv.DataSource = completos_sin_minimos;
            incompletos_dgv.DataSource = Incompletos;
            sin_completar_dgv.DataSource = sin_contestar;

            //completosCON_minimos_dgv.Columns.Remove("Nombre");

        }
    }
}
