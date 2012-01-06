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
using Validacion;

namespace TpDiseñoCSharp
{
    public partial class Alta_De_Puesto : Form
    {
        private Gestionar_Puestos ventanaAnterior;
        public int i = 0;/*Variable global a la pantalla de Alta 
        de puesto usada para llevar la cuenta de cuantos text boxs se agregaron y quitaron*/

        /*Estructura usada para crear las caracteristicas de los puestos*/
     
        /*Lista de caracteristicas de los puestos*/
        List<Caracteristica> CaractPuesto = new List<Caracteristica>();

        GestorCompetencias gestorCompetencias = new GestorCompetencias();

        List<Competencia> listaDeCompetencias = new List<Competencia>();

        ArrayList listaNombresDeCompetencia = new ArrayList();

        ArrayList listaDePonderaciones = new ArrayList();

        
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
            
            
        }


        /*
         * ===================================================
         * FUNCION QUE SE ENCARGA DE CREAR Y AGREGAR LOS TEXT
         * BOX EN LA PANTALLA ALTA DE PUESTO O FUNCION
         * ==================================================
         */
        private void agregarComboBox(int i)
        {
            Caracteristica Elemento;

            //Crea los nuevos text boxs
            ComboBox Comp = new ComboBox();
            ComboBox Pond = new ComboBox();
           
            for (int j = 0; j <= 10; j++)
            {
                Pond.Items.Add(j);
            }

            for (int k = 0; k < listaDeCompetencias.Count; k++)
            {

                Comp.Items.Add(listaDeCompetencias[k]);

          
                if (mayor < listaDeCompetencias[k].Nombre.Length)
                {
                    mayor = listaDeCompetencias[k].Nombre.Length;
                }

            }
            Comp.Width = (mayor) * 8;

            
            //Inicializa cada miembro de elemento con el text box correspondiente
            Elemento.dato1 = Comp;
            Elemento.dato2 = Pond;


            //Agrega elemente a la "lista CaracPuesto"
            CaractPuesto.Add(Elemento);


            //Inicializa las propiedades de los text boxes para ser mostrados de manera alineada
            Comp.Location = new Point(labelComp.Height, (i * 30));
            Pond.Location = new Point(Comp.Width + 50, Comp.Top);
            Comp.DropDownStyle = ComboBoxStyle.DropDownList;
            Pond.DropDownStyle = ComboBoxStyle.DropDownList;

            //Agrega los text boxes al panel que se encuentra en "Alta de Puesto o Funcion"
            panelCaracteristicas.Controls.Add((ComboBox)Elemento.dato1);
            panelCaracteristicas.Controls.Add((ComboBox)Elemento.dato2);

           /* panelCaracteristicas.Controls.Add((ComboBox)CaractPuesto[i].dato1);
            panelCaracteristicas.Controls.Add((ComboBox)CaractPuesto[i].dato2);*/
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
            panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[i - 1].dato1);
            panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[i - 1].dato2);

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


        private void Aceptar_Click(object sender, EventArgs e)
        {
            ArrayList listaDeErrores = new ArrayList();
            listaDeErrores = null;
            errorCodigo.Visible = false;
            errorNombreDePuesto.Visible = false;
            errorEmpresa.Visible = false;
            errorDescripcion.Visible = false;
            errorCaracteristicasDelPuesto.Visible = false;
            listaDeErrores = encontrarTextBoxVacios(this);
            
            //Si se encuentran errores, se informa de ellos y se muestra debajo de cada campo que contiene el error
            if ((listaDeErrores.Count>0)||(i==0))
            {
                //si no se agregó ninguna competencia se informa de ello
                if (i == 0)
                {
                    errorCaracteristicasDelPuesto.Visible = true;
                    errorCaracteristicasDelPuesto.Text = "Para poder dar de alta un puesto se debe "+
                                                         "cargar al menos una competencia " +
                                                         "con su debida ponderación";
                }
                //si se encontraron campos vacios se informa de ello
                if(listaDeErrores.Count>0)
                {
                   
                    imprimirErrores(listaDeErrores);
                }
                System.Media.SystemSounds.Asterisk.Play();
               

            }


                

            //Si todos los campos se encuentran completos, verifica que el puesto y/o nombre existan
            else if((listaDeErrores.Count == 0)&&(i>0))
            {
                bool existePuesto;
                GestorPuesto gestPuesto = new GestorPuesto();
                existePuesto = gestPuesto.buscarPuesto(Codigo.Text, NombreDePuesto.Text);
                //Si existe el código y/o nombre se informa de ello
                if (existePuesto)
                {
                    errorCodigo.Text = "El código y/o nombre ya existen";
                    errorCodigo.Visible = true;
                    errorNombreDePuesto.Text = "El código y/o nombre ya existen";
                    errorNombreDePuesto.Visible = true;
                    System.Media.SystemSounds.Asterisk.Play();
                }

                //Sino, se verifica que no haya competencias repetidas
                else
                {
                    //Comienzo de verificacion de que no existan competencias repetidas
                    ArrayList listaAuxiliarCompetenciaPonderacion = new ArrayList();
                    listaAuxiliarCompetenciaPonderacion = llenarListaCompetenciaPonderacion(this);
                   
                    bool error = false;

                    for (int j = 0; j < listaAuxiliarCompetenciaPonderacion.Count && !error; j += 2)
                    {
                        for (int k = j + 1; k < listaAuxiliarCompetenciaPonderacion.Count && !error; k++)
                        {
                            if (listaAuxiliarCompetenciaPonderacion[j].Equals(listaAuxiliarCompetenciaPonderacion[k]))
                            {
                                error = true;
                            }
                           
                        }

                    }

                    //Si existen competencias repetidas, se informa del error
                    if (error)
                    {
                        errorCaracteristicasDelPuesto.Visible = true;
                        errorCaracteristicasDelPuesto.Text = "No puede haber competencias repetidas";
                    }

                    //Si no existen competencias repetidas, se pasa a crear el puesto
                    else
                    {
                        List<Caracteristica> listaAuxiliarCaracteristicaPuesto = new List<Caracteristica>();
                        Caracteristica auxiliarCompetencia = new Caracteristica();
                        for (int n = 0; n < listaAuxiliarCompetenciaPonderacion.Count; n+=2)
                        {
                            auxiliarCompetencia.dato1 = listaAuxiliarCompetenciaPonderacion[n];
                            auxiliarCompetencia.dato2 = listaAuxiliarCompetenciaPonderacion[n + 1];
                            listaAuxiliarCaracteristicaPuesto.Add(auxiliarCompetencia);
                        }
                        //Si se pudo crear el puesto se informa de ello
                        if (gestPuesto.altaPuesto(Codigo.Text, NombreDePuesto.Text, Empresa.Text, 
                            listaAuxiliarCaracteristicaPuesto, Descripcion.Text))
                        {

                            if (MessageBox.Show("El nombre de puesto " + NombreDePuesto.Text + " se ha creado correctamente ¿Desea cargar otro?",
                                "Exito", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                FuncionesVarias.limpiarBoxesFormulario(this);
                                while (i > 0)
                                {
                                    eliminarTextBox();
                                    i--;
                                }

                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else 
                        { 
                            MessageBox.Show("Error en la creacion del puesto, intente nuevamente","ERROR",
                                MessageBoxButtons.OK,MessageBoxIcon.Error); 
                        }
                    }
                }
            }
        }




        /*
        * =================================================
        * SE ENCARGA DE ENCONTRAR SI HAY TEXT BOXS VACIOS y
        * COMBO BOX EN EL FORMULARIO Y LOS GUARDA EN UNA LISTA
        * =================================================
        */
        private ArrayList encontrarTextBoxVacios(Form formulario)
        {
            ArrayList listaDeErrores = new ArrayList();
            Label error = new Label() ;
            // hace un chequeo por todos los textbox del formulario
            foreach (Control controlDeFormulario in this.Controls)
            {
                if (controlDeFormulario is GroupBox)
                {
                    foreach (Control controlBox in controlDeFormulario.Controls)
                    {
                        if (controlBox is TextBox)
                        {
                            if (controlBox.Text == "")
                            {
                                error.Name = "error" + controlBox.Name;
                                listaDeErrores.Add(error.Name);
                            }
                            
                        }
                        else if (controlBox is Panel)
                        {
                            foreach (Control controlComboBox in controlBox.Controls)
                            {
                                if (controlComboBox is ComboBox)
                                {
                                    if (controlComboBox.Text == "")
                                    {
                                        error.Name = "errorComboBox";
                                        listaDeErrores.Add(error.Name);
                                    }
                                   
                                }
                            }
                        }
                     }
                }
            }
            return listaDeErrores;
        }



        private ArrayList llenarListaCompetenciaPonderacion(Form formulario)
        {
           ArrayList listaAuxiliar = new ArrayList();
          
            foreach (Control controlDeFormulario in this.Controls)
            {
                if (controlDeFormulario is GroupBox)
                {
                    foreach (Control controlBox in controlDeFormulario.Controls)
                    {
                        if (controlBox is Panel)
                        {
                            foreach (Control controlComboBox in controlBox.Controls)
                            {
                                if (controlComboBox is ComboBox)
                                {
                                    if (((ComboBox)controlComboBox).SelectedItem.ToString()!="")
                                    {
                                         listaAuxiliar.Add(((ComboBox)controlComboBox).SelectedItem);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            return listaAuxiliar;
        }


        /*
        * =================================================
        * SE ENCARGA DE IMPRIMIR EN EL FORMULARIO
        * LAS OMISIONES QUE SE COMETIERON
        * =================================================
        */
        private void imprimirErrores(ArrayList listaDeErrores)
        {

            for (int i = 0; i < listaDeErrores.Count; i++)
            {

                if (errorCodigo.Name == listaDeErrores[i].ToString())
                {
                    errorCodigo.Text = "El campo no puede ser vacío";
                    errorCodigo.Visible = true;
                }
                if (errorNombreDePuesto.Name == listaDeErrores[i].ToString())
                {
                    errorNombreDePuesto.Text = "El campo no puede ser vacío";
                    errorNombreDePuesto.Visible = true;
                }
                if (errorDescripcion.Name == listaDeErrores[i].ToString())
                {
                    errorDescripcion.Text = "El campo no puede ser vacío";
                    errorDescripcion.Visible = true;
                }
                if (errorEmpresa.Name == listaDeErrores[i].ToString())
                {
                    errorEmpresa.Text = "El campo no puede ser vacío";
                    errorEmpresa.Visible = true;
                }
                if (errorCaracteristicasDelPuesto.Text == listaDeErrores[i].ToString())
                {
                    errorCaracteristicasDelPuesto.Text = "Debe seleccionar una competencia y una ponderacion";
                    errorCaracteristicasDelPuesto.Visible = true;
                }
                MessageBox.Show("El item de la lista es:" + listaDeErrores[i].ToString());

            }
        }


    }
}
