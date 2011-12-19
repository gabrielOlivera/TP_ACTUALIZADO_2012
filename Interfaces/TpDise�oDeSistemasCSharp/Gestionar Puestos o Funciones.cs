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

        private void BuscarPuesots_Click (object sender, EventArgs e)
        {
            if ((Codigo.Text != null) || (NombreDePuesto.Text != null) || (Empresa.Text != null))
            {
                /*BUSCA LOS PUESTOS O FUNCIONES DE ACUERDO A LOS FILTROS ESPECIFICADOS PARA PODER MODIFICARLOS Y ELIMINAR
                Y LOS MUESTRA EN UNA TABLA*/

                GestorPuesto gestorPuesto = new GestorPuesto();
                listaDePuesto.DataSource = gestorPuesto.listarPuestos(Codigo.Text, NombreDePuesto.Text, Empresa.Text);
                listaDePuesto.Visible = true;
            }
            else 
            {
                MessageBox.Show("Debe ingresar al menos un campo para realizar la búsqueda", "ERROR",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Modificar_Puesto_o_Funcion modificarPuesto = new Modificar_Puesto_o_Funcion(this.Consultor.Text, this);
            modificarPuesto.ShowDialog();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los datos del puesto NOMBRE PUESTO serán eliminados del sistema", "Advertencia", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }
    }
}
