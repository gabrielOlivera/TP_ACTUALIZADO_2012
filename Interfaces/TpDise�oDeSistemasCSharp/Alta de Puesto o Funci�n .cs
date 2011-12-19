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
using System.Collections;

namespace TpDiseñoCSharp
{
    public partial class Alta_De_Puesto : Form
    {
        private Gestionar_Puestos ventanaAnterior;
        public int i = 0;/*Variable global a la pantalla de Alta 
        de puesto usada para llevar la cuenta de cuantos text boxs se agregaron y quitaron*/

        /*Estructura usada para crear las caracteristicas de los puestos*/
        public struct Caracteristicas
        {
            public Object Competencia;
            public Object Ponderacion;
        }

        /*Lista de caracteristicas de los puestos*/
        List<Caracteristicas> CaractPuesto = new List<Caracteristicas>();



        GestorCompetencias gestorCompetencias = new GestorCompetencias();

        List<Competencia> listaDeCompetencias = new List<Competencia>();


        ArrayList listaNombresDeCompetencia = new ArrayList();

        int mayor=0;
        /*
         * ===================================================
         * INICIALIZA LA PANTALLA DE ALTA DE PUESTO O FUNCION
         * ==================================================
         */
        public Alta_De_Puesto(string User, Gestionar_Puestos gestPuesto)
        {
            ventanaAnterior= gestPuesto;
            InitializeComponent();
            this.Consultor.Text = User;
            listaDeCompetencias = gestorCompetencias.listarCompetencias();

            

            for (int i = 0; i < listaDeCompetencias.Count; i++)
            {
                
                listaNombresDeCompetencia.Add(listaDeCompetencias[i].Nombre);

                if (mayor < listaDeCompetencias[i].Nombre.Length)
                {
                    mayor = listaDeCompetencias[i].Nombre.Length;
                }
            }
        }


        /*
         * ===================================================
         * FUNCION QUE SE ENCARGA DE CREAR Y AGREGAR LOS TEXT
         * BOX EN LA PANTALLA ALTA DE PUESTO O FUNCION
         * ==================================================
         */
        private void agregarComboBox(int i)
        {
            Caracteristicas Elemento;

            //Crea los nuevos text boxs
            ComboBox Comp = new ComboBox();
            ComboBox Pond = new ComboBox();

            Comp.Width = (mayor)*8;
            Comp.DataSource = listaNombresDeCompetencia;

            //Inicializa cada miembro de elemento con el text box correspondiente
            Elemento.Competencia = Comp;
            Elemento.Ponderacion = Pond;

            //Agrega elemente a la "lista CaracPuesto"
            CaractPuesto.Add(Elemento);

            //Inicializa las propiedades de los text boxes para ser mostrados de manera alineada
            Comp.Location = new Point(labelComp.Height, (i * 30));
            Pond.Location = new Point(Comp.Width + 50, Comp.Top);

            //Agrega los text boxes al panel que se encuentra en "Alta de Puesto o Funcion"
            panelCaracteristicas.Controls.Add((ComboBox)Elemento.Competencia);
            panelCaracteristicas.Controls.Add((ComboBox)Elemento.Ponderacion);
        }



        /*
        * ===================================================================
        * FUNCION QUE SE ENCARGA ELIMINAR LOS TEXT BOX DE LA PANTALLA ALTA DE
        * PUESTO O FUNCION Y QUITARLOS DE LA LISTA "caractPuesto"
        * ===================================================================
        */
        private void eliminarTextBox()
        {
            //Se eliminan los text box puestos en el panel de la pantalla
            panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[i - 1].Competencia);
            panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[i - 1].Ponderacion);

            //Elimina la caracteristica que se agrego a puesto
            CaractPuesto.Remove(CaractPuesto[i - 1]);
        }

        //BOTON MAS
        /*
        * ===================================================================
        * SE ENCARGA DE LLAMAR A LA FUNCION "agregarTextBox"
        * Y SUMA UNO A i PARA LLEVAR LA CUENTA DE LOS TEXT BOXES
        * ===================================================================
        */
        private void Agregar_Click(object sender, EventArgs e)
        {
            agregarComboBox(i);
            i++;
        }

        /*
        * ===================================================================
        * SE ENCARGA DE LLAMAR A LA FUNCION "elimnarTextBox"
        * Y RESTA UNO A i PARA LLEVAR LA CUENTA DE LOS TEXT BOXES
        * ===================================================================
        */
        private void Quitar_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                eliminarTextBox();
                i--;
            }
        }



        /*
        * =================================================
        * CIERRA LA PANTALLA "Alta de Puesto o Funcion", CIERRA
         * LA PANTALLA "Gestionar Puestos o Funciones"
         * Y RETORNA AL MENU CONSULTOR
        * =================================================
        */
        private void Cancelar_Click(object sender, EventArgs e)
        {

            /*Segun especificacion al cerrarse la ventana alta puesto, 
             * se tiene que cerrar la ventana de gestion de puesto y
             * volver al menu principal del consultor*/
            ventanaAnterior.Close();
            
            
            
            //Se encarga de cerrar la ventana actual
            Close();
        }
    }
}
