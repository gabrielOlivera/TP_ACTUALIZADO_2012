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
using Validacion;
using System.Collections;

namespace TpDiseñoCSharp
{
    public partial class Modificar_Puesto_o_Funcion : Form
    {
        //Enlace a la ventana anterior
        Form ventanaAnterior, ventanaMenuConsultor;


        public int i = 0;/*Variable global a la pantalla de Alta 
        de puesto usada para llevar la cuenta de cuantos text boxs se agregaron y quitaron*/

       
        //Puesto que va a ser modificado
        Puesto puesto_A_Modificar;

        //Listas para distintas ocaciones
        List<Caracteristica> CaractPuesto = new List<Caracteristica>();
        List<Caracteristica> listaDeCaracteristica = new List<Caracteristica>();
        List<Competencia> listaDeCompetencias = new List<Competencia>();
        List<CheckBox> listaDeCheckBox = new List<CheckBox>();


        //Gestor usado
        GestorCompetencias gestorCompetencias = new GestorCompetencias();



        //Variable que es usada para dar el tamaño al mayor combo box
        int mayor = 0;


        /*
         * ====================================================
         * INICIALIZA LA PANTALLA DE MODIFICAR PUESTO O FUNCION
         * ====================================================
         */        
        public Modificar_Puesto_o_Funcion(string User,Form menuConsultor , Form gestPuesto,string codigo)
        {
            ventanaAnterior = gestPuesto;
            ventanaMenuConsultor = menuConsultor;
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.ToLongDateString();
            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = User;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);

            GestorPuesto gestorPuesto = new GestorPuesto();
            //Instancia el puesto que corresponde con el codigo en puesto_A_Modificar
            puesto_A_Modificar = gestorPuesto.recuperarUnPuesto(codigo);

            //Se procede a colocar los datos del puesto que se desea moficiar en los lugares correspondientes
            Codigo.Text = puesto_A_Modificar.Codigo;
            NombreDePuesto.Text = puesto_A_Modificar.Nombre;
            Descripcion.Text = puesto_A_Modificar.Descripcion;
            Empresa.Text = puesto_A_Modificar.Empresa;

            //Se listan todas las competencias existentes en la BD
            listaDeCompetencias = gestorCompetencias.listarCompetencias();

            //Se listan las caracteristicas asociadas al puesto a modificar
            listaDeCaracteristica = gestorPuesto.recuperarCaracteristicas(codigo);

            //Se llama a la funcion para que agregue los combo boxes con las caracteristicas asociadas al puesto
            agregarCaracteristicasPuesto(listaDeCaracteristica);

            FormClosed += menuConsultor_Click;
        }


        /*
         * =========================================================================================================
         * FUNCION QUE SE ENCARGA DE CREAR Y AGREGAR LOS COMBO Y CHECK BOX EN LA PANTALLA MODIFICAR PUESTO O FUNCION
         * CON LOS COMBO SETEADOS CADA UNO CON LA COMPETENCIA Y LA PONDERACION SELECCIONADA
         * =========================================================================================================
         */
        private void agregarCaracteristicasPuesto(List<Caracteristica> listaDeCaracteristica)
        {
            for (int j = 0; j < listaDeCaracteristica.Count; j++)
            {
                Caracteristica Elemento;


                //Crea los CheckBox
                CheckBox check = new CheckBox();


                //Crea los nuevos ComboBox
                ComboBox Comp = new ComboBox();
                ComboBox Pond = new ComboBox();

                for (int n = 0; n <= 10; n++)
                {
                    Pond.Items.Add(n);
                }
                int elementoSeleccionado = Int32.Parse(listaDeCaracteristica[j].dato2.ToString());
                Pond.SelectedIndex = elementoSeleccionado;

                int indice = 0;
                for (int k = 0; k < listaDeCompetencias.Count; k++)
                {

                    Comp.Items.Add(listaDeCompetencias[k]);
                    if (listaDeCompetencias[k].Nombre.ToString() == listaDeCaracteristica[j].dato1.ToString())
                        indice = k;

                    if (mayor < listaDeCompetencias[k].Nombre.Length)
                    {
                        mayor = listaDeCompetencias[k].Nombre.Length;
                    }

                }
                Comp.SelectedIndex = indice;
                Comp.Width = (mayor) * 8;

                check.Text = "";
                //Inicializa cada miembro de elemento con el text box correspondiente
                Elemento.dato1 = Comp;
                Elemento.dato2 = Pond;


                //Agrega elemente a la "lista CaracPuesto"
                CaractPuesto.Add(Elemento);
                listaDeCheckBox.Add(check);

                //Inicializa las propiedades de los text boxes para ser mostrados de manera alineada
                Comp.Location = new Point((labelComp.Location.X) - (labelComp.Size.Width / 2), (j * 30));
                Pond.Location = new Point((labelPond.Location.X) - (labelPond.Size.Width / 2), Comp.Top);
                check.Location = new Point((labelComp.Location.X) - (labelComp.Size.Width), Comp.Top);
                Comp.DropDownStyle = ComboBoxStyle.DropDownList;
                Pond.DropDownStyle = ComboBoxStyle.DropDownList;

                //Agrega los text boxes al panel que se encuentra en "Alta de Puesto o Funcion"
                panelCaracteristicas.Controls.Add((ComboBox)Elemento.dato1);
                panelCaracteristicas.Controls.Add((ComboBox)Elemento.dato2);
                panelCaracteristicas.Controls.Add(check);
                i++;
            }
            
        }


        /*
         * ===================================================
         * FUNCION QUE SE ENCARGA DE CREAR Y AGREGAR LOS COMBO
         * Y CHECK BOX EN LA PANTALLA ALTA DE PUESTO O FUNCION
         * ==================================================
         */
        private void agregarComboBox(int i)
        {
            Caracteristica Elemento;


            //Crea los CheckBox
            CheckBox check = new CheckBox();


            //Crea los nuevos ComboBox
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

            check.Text = "";
            //Inicializa cada miembro de elemento con el text box correspondiente
            Elemento.dato1 = Comp;
            Elemento.dato2 = Pond;


            //Agrega elemente a la "lista CaracPuesto"
            CaractPuesto.Add(Elemento);
            listaDeCheckBox.Add(check);

            //Inicializa las propiedades de los text boxes para ser mostrados de manera alineada
            Comp.Location = new Point((labelComp.Location.X) - (labelComp.Size.Width / 2), (i * 30));
            Pond.Location = new Point((labelPond.Location.X) - (labelPond.Size.Width / 2), Comp.Top);
            check.Location = new Point((labelComp.Location.X) - (labelComp.Size.Width), Comp.Top);
            Comp.DropDownStyle = ComboBoxStyle.DropDownList;
            Pond.DropDownStyle = ComboBoxStyle.DropDownList;

            //Agrega los text boxes al panel que se encuentra en "Alta de Puesto o Funcion"
            panelCaracteristicas.Controls.Add((ComboBox)Elemento.dato1);
            panelCaracteristicas.Controls.Add((ComboBox)Elemento.dato2);
            panelCaracteristicas.Controls.Add(check);
        }



        /*
        * ================================================================================
        * FUNCION QUE SE ENCARGA ELIMINAR LOS COMBO BOX QUE ESTAN TILDADOS 
        * DE LA PANTALLA MODIFICAR PUESTO O FUNCION Y QUITARLOS DE LA LISTA "CaractPuesto"
        * ================================================================================
        */
        private void eliminarTextBox(ArrayList listaDeIndices_a_Eliminar)
        {
            for (int n = 0; n < listaDeIndices_a_Eliminar.Count; n++)
            {
                int indice_a_Eliminar = (int)listaDeIndices_a_Eliminar[n];
                //Se eliminan los text box puestos en el panel de la pantalla
                panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[indice_a_Eliminar].dato1);
                panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[indice_a_Eliminar].dato2);
                panelCaracteristicas.Controls.Remove(listaDeCheckBox[indice_a_Eliminar]);

                //Elimina la caracteristica que se agrego a puesto
                CaractPuesto.Remove(CaractPuesto[indice_a_Eliminar]);
                listaDeCheckBox.Remove(listaDeCheckBox[indice_a_Eliminar]);
            }
        }



        private void eliminarComboBox()
        {
            //Se eliminan los text box puestos en el panel de la pantalla
            panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[i - 1].dato1);
            panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[i - 1].dato2);
            panelCaracteristicas.Controls.Remove(listaDeCheckBox[i - 1]);
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
            Label error = new Label();
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
                                        error.Name = "error" + controlBox.Name;
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
                                    if (((ComboBox)controlComboBox).SelectedItem.ToString() != "")
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
                if (errorpanelCaracteristicas.Name == listaDeErrores[i].ToString())
                {
                    errorpanelCaracteristicas.Text = "Debe seleccionar una competencia y una ponderacion en cada ComboBox";
                    errorpanelCaracteristicas.Visible = true;
                }


            }
        }

        //BOTON MAS
        /*
        * ===================================================================
        * SE ENCARGA DE LLAMAR A LA FUNCION "agregarComboBox"
        * Y SUMA UNO A i PARA LLEVAR LA CUENTA DE LOS COMBO Y CHECK BOXES
        * ===================================================================
        */
        private void Agregar_Click(object sender, EventArgs e)
        {
            agregarComboBox(i);
            i++;
        }

        //BOTON MENOS
        /*
        * ======================================================================================
        * SE ENCARGA DE LLAMAR A LA FUNCION "elimnarTextBox" PARA QUE ELIMINE LOS
        * COMBO BOXES QUE FUERON SELECCIONADOS MEDIANTE UN TILDE EN EL CHECK BOX CORRESPONDIENTE
        * Y RESTA A i LA CANTIDAD DE COMBO BOXES ELIMINADOS PARA LLEVAR LA CUENTA DE LOS MISMOS
        * ======================================================================================
        */
        private void Quitar_Click(object sender, EventArgs e)
        {
            ArrayList aux = new ArrayList();
            if (i > 0)
            {
                //Se recorre la lista con los checkbox para ver si alguno fue tildado
                for (int n = 0; n < listaDeCheckBox.Count; n++)
                {
                    int estadoCheckBox = (int)listaDeCheckBox[n].CheckState;
                    if (estadoCheckBox == 1)
                    {
                        aux.Add(n);//se guardan el indice de los checkbox tildados, para saber cual combo box eliminar
                    }
                }

                aux.Reverse();//Se da vuelta la lista, y se eliminan los combo y checks desde el final de la lista
                eliminarTextBox(aux);
                i -= aux.Count;//Se restan a i la cantidad que fueron eliminados
            }
        }

       /*
       * =================================================
       * CIERRA LA PANTALLA Modificar Puesto o Funcion", CIERRA
       * LA PANTALLA "Gestionar Puestos o Funciones"
       * Y RETORNA AL MENU CONSULTOR
       * =================================================
       */
        private void Cancelar_Click(object sender, EventArgs e)
        {
            ventanaMenuConsultor.Visible = true;
            /*Segun especificacion al cerrarse la ventana alta puesto, 
             * se tiene que cerrar la ventana de gestion de puesto y
             * volver al menu principal del consultor*/
            ventanaAnterior.Close();



            //Se encarga de cerrar la ventana actual
            Close();
        }

        /*
      * =======================================================================
      * SE ENCARGA DE REVISAR QUE NO HAYA NINGUN ERROR EN EL FORMULARIO Y LUEGO
      * SE ACTUALIZA EL PUESTO CON LOS DATOS SUMINISTRADOS EN EL FORMULARIO
      * =======================================================================
      */
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if ((FuncionesVarias.validarCamposAlfanum(NombreDePuesto.Text)) || (FuncionesVarias.validarCamposAlfanum(Descripcion.Text))
                   || (FuncionesVarias.validarCamposAlfanum(Empresa.Text)))
            {
                MessageBox.Show("Los campos solo aceptan letras y/o números");

            }
            else
            {
                //Se crea la lista y se la inicializa en null
                ArrayList listaDeErrores = new ArrayList();
                listaDeErrores = null;

                //Se ocultan todos los errores
                errorNombreDePuesto.Visible = false;
                errorEmpresa.Visible = false;
                errorDescripcion.Visible = false;
                errorpanelCaracteristicas.Visible = false;

                //Se llama a la funcion encontrarTextBoxVacios para ver si alguno de los text box esta en blanco
                listaDeErrores = encontrarTextBoxVacios(this);

                //Si se encuentran errores, se informa de ellos y se muestra debajo de cada campo que contiene el error
                if ((listaDeErrores.Count > 0) || (i == 0))
                {
                    //si no se agregó ninguna competencia se informa de ello
                    if (i == 0)
                    {
                        errorpanelCaracteristicas.Visible = true;
                        errorpanelCaracteristicas.Text = "Para poder dar de alta un puesto se debe " +
                                                             "cargar al menos una competencia " +
                                                             "con su debida ponderación";
                    }
                    //si se encontraron campos vacios se informa de ello
                    if (listaDeErrores.Count > 0)
                    {

                        imprimirErrores(listaDeErrores);
                    }
                    System.Media.SystemSounds.Asterisk.Play();
                }




                //Si todos los campos se encuentran completos, verifica que el puesto y/o nombre existan
                else if ((listaDeErrores.Count == 0) && (i > 0))
                {
                    Puesto objPuesto;
                    GestorPuesto gestPuesto = new GestorPuesto();
                    objPuesto = gestPuesto.buscarPuesto(Codigo.Text, NombreDePuesto.Text);
                    //Si existe el nombre se informa de ello
                    if (objPuesto.Nombre == NombreDePuesto.Text)
                    {
                        errorNombreDePuesto.Text = "El nombre ya existe";
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
                            errorpanelCaracteristicas.Visible = true;
                            errorpanelCaracteristicas.Text = "No puede haber competencias repetidas";
                            System.Media.SystemSounds.Asterisk.Play();
                        }

                        //Si no existen competencias repetidas, se pasa a crear el puesto
                        else
                        {
                            List<Caracteristica> listaAuxiliarCaracteristicaPuesto = new List<Caracteristica>();
                            Caracteristica auxiliarCompetencia = new Caracteristica();
                            for (int n = 0; n < listaAuxiliarCompetenciaPonderacion.Count; n += 2)
                            {
                                auxiliarCompetencia.dato1 = listaAuxiliarCompetenciaPonderacion[n];
                                auxiliarCompetencia.dato2 = listaAuxiliarCompetenciaPonderacion[n + 1];
                                listaAuxiliarCaracteristicaPuesto.Add(auxiliarCompetencia);
                            }
                            //Si se pudo modificar el puesto se informa de ello
                            if (gestPuesto.modificarPuesto(Codigo.Text, NombreDePuesto.Text, Empresa.Text,
                                listaAuxiliarCaracteristicaPuesto, Descripcion.Text))
                            {

                                if (MessageBox.Show("La operación ha culminado con éxito",
                                    "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    ventanaAnterior.Refresh();
                                    this.Close();

                                }

                            }
                            //Si se produjo un error en la creación del puesto se informa de ello
                            else
                            {
                                MessageBox.Show("Error en la modificación del puesto, intente nuevamente", "ERROR",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void menuConsultor_Click(object sender, EventArgs e)
        {
            ventanaMenuConsultor.Visible = true;
            ventanaAnterior.Close();
            Close();
        }

        private void CerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea CerrarSesion?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ventanaAnterior.Close();
                ventanaMenuConsultor.Close();
                Close();
            }
        } 

    }
}
