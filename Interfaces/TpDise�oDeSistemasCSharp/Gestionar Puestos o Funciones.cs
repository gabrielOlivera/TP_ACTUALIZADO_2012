using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestores;
using Validacion;

namespace TpDiseñoCSharp
{
    public partial class Gestionar_Puestos : Form
    {
        Form ventanaMenuConsultor;

        public Gestionar_Puestos(Form ventana_Anterior,string user)
        {
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.ToLongDateString();

            ventanaMenuConsultor = ventana_Anterior;

            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = user;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);
            FormClosed += menuConsultor_Click;
        }

        /*
        * ===================================================================
        * ESTE BOTON CUANDO ES APRETADO LLAMA A LA PANTALLA DE ALTA DE PUESTO
        * ===================================================================
        */
        private void Nuevo_Click(object sender, EventArgs e)
        {
            Alta_De_Puesto altaPuesto = new Alta_De_Puesto(this.Consultor.Text, ventanaMenuConsultor ,this);
            altaPuesto.ShowDialog();
            this.Visible = false;
        }

        /*
        * ==============================================================================
        * CUANDO SE PRESIONA ESTE BOTON, PRIMERO SE VALIDAN QUE SE HAYAN  
        * INGRESADO AL MENOS UN CAMPO Y QUE NO CONTENGAN DATOS NO DESEADOS
        * SI TODO ESTA BIEN SE LISTAN LOS PUESTOS DE ACUERDO A LOS FILTROS ESPECIFICADOS
        * ==============================================================================
        */
        private void BuscarPuestos_Click (object sender, EventArgs e)
        {
            //Verifica que al menos uno de los campos contenga datos a buscar
            if ((Codigo.Text != "") || (NombreDePuesto.Text != "") || (Empresa.Text != ""))
            {
                //Comprueba que no se ingresen datos no deseados en los text boxes
                if ((FuncionesVarias.validarCamposAlfanum(Codigo.Text)) || (FuncionesVarias.validarCamposAlfanum(NombreDePuesto.Text))
                    || (FuncionesVarias.validarCamposAlfanum(Empresa.Text)))
                {
                    MessageBox.Show("Los campos solo aceptan letras y/o números","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    
                }
                else
                {
                    /*BUSCA LOS PUESTOS O FUNCIONES DE ACUERDO A LOS FILTROS ESPECIFICADOS PARA PODER MODIFICARLOS Y/O ELIMINAR
                    Y LOS MUESTRA EN UNA TABLA*/
                    GestorPuesto gestorPuesto = new GestorPuesto();
                    listaDePuesto.DataSource = gestorPuesto.listarPuestos(Codigo.Text, NombreDePuesto.Text, Empresa.Text);
                    listaDePuesto.Visible = true;
                }
            }
            //Si todos los campos están vacíos se informa de ello
            else 
            {
                MessageBox.Show("Debe ingresar al menos un campo para realizar la búsqueda", "ADVERTENCIA",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
        * ===================================================================
        * SE ENCARGA DE LLAMAR A MODIFICAR PUESTO, CON EL PUESTO QUE FUE 
        * SELECCIONADO
        * ===================================================================
        */
        private void Modificar_Click(object sender, EventArgs e)
        {
            string codigo = (string)listaDePuesto.CurrentRow.Cells["Codigo"].Value;
            Modificar_Puesto_o_Funcion modificarPuesto = new Modificar_Puesto_o_Funcion(this.Consultor.Text, ventanaMenuConsultor, this, codigo);
            modificarPuesto.ShowDialog();
        }

        /*
        * ===================================================================
        * VERIFICA QUE EL PUESTO NO ESTE SIENDO USADO, PARA LUEGO PROCEDER 
        * A ELIMINARLO LOGICAMENTE DE LA BASE DE DATOS
        * ===================================================================
        */

        private void Eliminar_Click(object sender, EventArgs e)
        {
            string codigo = (string)listaDePuesto.CurrentRow.Cells["Codigo"].Value;
            string nomPuesto = (string)listaDePuesto.CurrentRow.Cells["Nombre"].Value;
            GestorPuesto gestorPuesto = new GestorPuesto();
            bool puestoEvaluado,eliminado;

            //En puestoEvaluado guardamos el retorno del método tieneElPuestoEvaluacionesAsociadas
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
        
        private void menuConsultor_Click(object sender, EventArgs e)
        {
            if (ventanaMenuConsultor.Created)
            {
                ventanaMenuConsultor.Visible = true;
                this.Close();
            }
        }

        private void CerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea CerrarSesion?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ventanaMenuConsultor.Close();
                Close();
            }
        }
        
    }
}
