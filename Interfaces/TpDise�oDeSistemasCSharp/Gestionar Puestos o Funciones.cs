using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestores;

namespace TpDiseñoCSharp
{
    public partial class Gestionar_Puestos : Form
    {
        public Gestionar_Puestos(string user)
        {
            InitializeComponent();
            this.Consultor.Text = user;
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Alta_De_Puesto altaPuesto = new Alta_De_Puesto(this.Consultor.Text, this);
            altaPuesto.ShowDialog();
        }

        private void BuscarPuestos_Click (object sender, EventArgs e)
        {
            if ((Codigo.Text != "") || (NombreDePuesto.Text != "") || (Empresa.Text != ""))
            {
                /*BUSCA LOS PUESTOS O FUNCIONES DE ACUERDO A LOS FILTROS ESPECIFICADOS PARA PODER MODIFICARLOS Y/O ELIMINAR
                Y LOS MUESTRA EN UNA TABLA*/

                GestorPuesto gestorPuesto = new GestorPuesto();
                listaDePuesto.DataSource = gestorPuesto.listarPuestos(Codigo.Text, NombreDePuesto.Text, Empresa.Text);
                listaDePuesto.Visible = true;
            }
            else 
            {
                MessageBox.Show("Debe ingresar al menos un campo para realizar la búsqueda", "ADVERTENCIA",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            string codigo = (string)listaDePuesto.CurrentRow.Cells["Codigo"].Value;
            MessageBox.Show(codigo);
            Modificar_Puesto_o_Funcion modificarPuesto = new Modificar_Puesto_o_Funcion(this.Consultor.Text, this);
            modificarPuesto.ShowDialog();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Los datos del puesto NOMBRE PUESTO serán eliminados del sistema", "Advertencia",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                
            }
        }
    }
}
