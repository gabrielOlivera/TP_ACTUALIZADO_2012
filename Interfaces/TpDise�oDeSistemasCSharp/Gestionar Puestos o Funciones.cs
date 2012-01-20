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
            Modificar_Puesto_o_Funcion modificarPuesto = new Modificar_Puesto_o_Funcion(this.Consultor.Text, this, codigo);
            modificarPuesto.ShowDialog();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            string codigo = (string)listaDePuesto.CurrentRow.Cells["Codigo"].Value;
            string nomPuesto = (string)listaDePuesto.CurrentRow.Cells["Nombre"].Value;
            GestorPuesto gestorPuesto = new GestorPuesto();
            bool puestoEvaluado,eliminado;
            puestoEvaluado = gestorPuesto.tieneElPuestoEvaluacionesAsociadas(codigo);
            if (!puestoEvaluado)
            {
                
                if (MessageBox.Show("Los datos del puesto " + nomPuesto + " serán eliminados del sistema", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    eliminado = gestorPuesto.eliminarPuesto(codigo);
                    if (eliminado)
                    {
                        MessageBox.Show("Los datos del puesto " + nomPuesto + " han sido eliminados del sistema", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarPuestos_Click(sender,e);
                    }
                    else
                        MessageBox.Show("No se ha podido eliminar el puesto", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    this.Close();
            }
            else
                MessageBox.Show("El puesto " + nomPuesto + " está siendo usado en la base de datos y no puede eliminarse", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
