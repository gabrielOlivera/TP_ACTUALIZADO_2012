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
    public partial class Seleccion_de_evaluaciones : Form
    {
        public Seleccion_de_evaluaciones(List<PuestoEvaluado> Lista_puestos_ev)
        {
            InitializeComponent();
            panel_evaluaciones.AutoSize = true;
            
            //for (int j = 0; j < 50; j++) //descomenta esta linea si queres ver como funciona cuando hay MUCHAS evaluaciones. (autoscroll)

            for (int i = 0; i < Lista_puestos_ev.Count; i++)
            {
                CheckBox check = new CheckBox();
                check.Width = 20;
                Label renglon = new Label();
                
                check.Location = new Point(0, i * 30); //si usas el for de 50 aca cabia la i por una j
                renglon.Location = new Point(30, i * 30); //si usas el for de 50 aca cabia la i por una j

                renglon.Width = 2000;
                renglon.Text = Lista_puestos_ev[i].Nombre.ToString() + " " + Lista_puestos_ev[i].Codigo.ToString() + " " + Lista_puestos_ev[i].Empresa.ToString() + " " + Lista_puestos_ev[i].Fecha_Comienzo.ToShortDateString() + " " + Lista_puestos_ev[i].Fecha_Comienzo.ToShortTimeString();
                
                panel_evaluaciones.Controls.Add(check);
                panel_evaluaciones.Controls.Add(renglon);
            }
            

        }

        private void todos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panel_evaluaciones.Controls.Count; i+=2)
            {
                CheckBox checkBox = (CheckBox) panel_evaluaciones.Controls[i];
                checkBox.Checked = true;

            }
                
        }

        private void ninguno_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panel_evaluaciones.Controls.Count; i += 2)
            {
                CheckBox checkBox = (CheckBox)panel_evaluaciones.Controls[i];
                checkBox.Checked = false;

            }
        }

       
        
    }
}
