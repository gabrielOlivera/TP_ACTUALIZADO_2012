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
        Form ventanaAnterior, ventanaMenuConsultor;


        public int i = 0;/*Variable global a la pantalla de Alta 
        de puesto usada para llevar la cuenta de cuantos text boxs se agregaron y quitaron*/

        

        //Listas usadas para distintas ocaciones
        List<Caracteristica> CaractPuesto = new List<Caracteristica>();
        List<CheckBox> listaDeCheckBox = new List<CheckBox>();
        List<Competencia> listaDeCompetencias = new List<Competencia>();

        //Gestores usados
        GestorCompetencias gestorCompetencias = new GestorCompetencias();

        //Variable que es usada para dar el tamaño al mayor combo box
        int mayor = 0;


        /*
         * ===================================================
         * INICIALIZA LA PANTALLA DE ALTA DE PUESTO O FUNCION
         * ==================================================
         */
        public Alta_De_Puesto(string User,Form ventanaConsultor ,Form gestPuesto)
        {
            ventanaAnterior= gestPuesto;
            ventanaMenuConsultor = ventanaConsultor;
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.ToLongDateString();

            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = User;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);

            //Se llena una lista con todas las competencias que se encuentran creadas en la BD
            listaDeCompetencias = gestorCompetencias.listarCompetencias();

            FormClosed += menuConsultor_Click;
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

            for (int j = 1; j <= 10; j++)
            {
                //Agrega numeros del 0-10 en el combo box para poder elegir la ponderacion de cada competencia
                Pond.Items.Add(j);
            }

            for (int k = 0; k < listaDeCompetencias.Count; k++)
            {
                //Agrega a los combo box las competencias
                Comp.Items.Add(listaDeCompetencias[k]);


                if (mayor < listaDeCompetencias[k].Nombre.Length)
                {
                    mayor = listaDeCompetencias[k].Nombre.Length;
                }

            }
            //Este valor es para darle el tamaño al check box de el nombre de la competencia mas larga
            Comp.Width = (mayor) * 8;

            check.Text = "";

            //Inicializa cada miembro de elemento con el combo box correspondiente
            Elemento.dato1 = Comp;
            Elemento.dato2 = Pond;


            //Agrega "Elemento" a la lista "CaractPuesto" y agrega los check box en una lista para luego saber cual fue seleccionado
            CaractPuesto.Add(Elemento);
            listaDeCheckBox.Add(check);

            //Inicializa las propiedades de los combo boxes y los check box para ser mostrados de manera alineada
            Comp.Location = new Point((labelComp.Location.X) - (labelComp.Size.Width / 2), (i * 30));
            Pond.Location = new Point((labelPond.Location.X) - (labelPond.Size.Width / 2), Comp.Top);
            check.Location = new Point((labelComp.Location.X) - (labelComp.Size.Width), Comp.Top);
            Comp.DropDownStyle = ComboBoxStyle.DropDownList;
            Pond.DropDownStyle = ComboBoxStyle.DropDownList;

            //Agrega los combo boxes y los check boxes al panel que se encuentra en "Alta de Puesto o Funcion"
            panelCaracteristicas.Controls.Add((ComboBox)Elemento.dato1);
            panelCaracteristicas.Controls.Add((ComboBox)Elemento.dato2);
            panelCaracteristicas.Controls.Add(check);
        }



        /*
        * ===================================================================
        * FUNCION QUE SE ENCARGA ELIMINAR LOS COMBO BOX QUE ESTAN TILDADOS 
        * DE LA PANTALLA ALTA DE PUESTO O FUNCION Y QUITARLOS DE LA LISTA "CaractPuesto"
        * ===================================================================
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
            ventanaAnterior.Visible = true;
            //Se encarga de cerrar la ventana actual
            Close();
        }

        /*
       * =======================================================================
       * SE ENCARGA DE REVISAR QUE NO HAYA NINGUN ERROR EN EL FORMULARIO Y LUEGO
       * SE CREA EL PUESTO CON LOS DATOS SUMINISTRADOS EN EL FORMULARIO
       * =======================================================================
       */
        private void Aceptar_Click(object sender, EventArgs e)
        {
            //Se crea la lista y se la inicializa en null
            ArrayList listaDeErrores = new ArrayList();
            listaDeErrores = null;
            bool nombreOpuestoRepetido = false;

            //Se ocultan todos los errores
            errorCodigo.Visible = false;
            errorNombreDePuesto.Visible = false;
            errorEmpresa.Visible = false;
            errorDescripcion.Visible = false;
            errorpanelCaracteristicas.Visible = false;

            //Se llama a la funcion encontrarTextBoxVacios para ver si alguno de los text box esta en blanco
            listaDeErrores = encontrarTextBoxVacios(this);
            
            /*
             * COMIENZO DE LAS VALIDACIONES PARA VER SI HAY ERRORES
             */
            //Si se encuentran errores, se informa de ellos y se muestra debajo de cada campo que contiene el error
            if ((listaDeErrores.Count>0)||(i==0))
            {
                //si no se agregó ninguna competencia se informa de ello
                if (i == 0)
                {
                    errorpanelCaracteristicas.Visible = true;
                    errorpanelCaracteristicas.Text = "Para poder dar de alta un puesto se debe "+
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


            //Si todos los campos se encuentran completos, verifica que el puesto y/o nombre existan y que no hayan agregado caraceters no permitidos
            else if ((listaDeErrores.Count == 0) && (i > 0))
            {
                if ((FuncionesVarias.validarCamposAlfanum(Codigo.Text)) || (FuncionesVarias.validarCamposAlfanum(NombreDePuesto.Text))
                    || (FuncionesVarias.validarCamposAlfanum(Empresa.Text)))
                {
                    MessageBox.Show("Los campos solo aceptan letras y/o números");

                }
                else
                {
                    Puesto objPuesto;
                    GestorPuesto gestPuesto = new GestorPuesto();
                    objPuesto = gestPuesto.buscarPuesto(Codigo.Text, NombreDePuesto.Text);
                    //Si existe el código y/o nombre se informa de ello
                    if (objPuesto.Codigo == Codigo.Text)
                    {
                        errorCodigo.Text = "El código ya existe";
                        errorCodigo.Visible = true;
                        System.Media.SystemSounds.Asterisk.Play();
                        nombreOpuestoRepetido = true;

                    }
                    if (objPuesto.Nombre == NombreDePuesto.Text)
                    {
                        errorNombreDePuesto.Text = "El nombre ya existe";
                        errorNombreDePuesto.Visible = true;
                        System.Media.SystemSounds.Asterisk.Play();
                        nombreOpuestoRepetido = true;
                    }

                    //Sino, se verifica que no haya competencias repetidas
                    if(!nombreOpuestoRepetido)
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

                        /*
                         * FIN DE LAS VALIDACIONES PARA VER SI HAY ERRORES
                         */


                        //Si no existen competencias repetidas, se pasa a crear el puesto
                        else
                        {
                            //Se crea una lista con las caracteristicas del puesto (Nombre de la competencia y su debida Ponderacion)
                            List<Caracteristica> listaAuxiliarCaracteristicaPuesto = new List<Caracteristica>();
                            Caracteristica auxiliarCompetencia = new Caracteristica();
                            for (int n = 0; n < listaAuxiliarCompetenciaPonderacion.Count; n += 2)
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
                                    //Si decide crear otro puesto, se pasa a limpiar el formulario y las listas usadas
                                   FuncionesVarias.limpiarBoxesFormulario(this);
                                    while (i > 0)
                                    {
                                        eliminarComboBox();
                                        i--;
                                    }
                                    CaractPuesto.Clear();
                                    listaDeErrores.Clear();
                                    listaDeCheckBox.Clear();
                                    listaAuxiliarCaracteristicaPuesto.Clear();
                                    listaAuxiliarCompetenciaPonderacion.Clear();
   
                                }
                                //Si no quiere dar de alta otro puesto, se sale de la pantalla "Alta de Puesto o Funcion"
                                else
                                {
                                    this.Close();
                                }
                            }
                            //Si se produjo un error en la creación del puesto se informa de ello
                            else
                            {
                                MessageBox.Show("Error en la creacion del puesto, intente nuevamente", "ERROR",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        /*
        * ====================================================
        * ESTA FUNCION ES LA ENCARGADA DE ELIMINAR LOS COMBO Y 
        * CHECK BOXES QUE FUERON AGREGADOS EN LA PANTALLA
        * ====================================================
        */
        private void eliminarComboBox()
        {
           
                panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[i-1].dato1);
                panelCaracteristicas.Controls.Remove((ComboBox)CaractPuesto[i-1].dato2);
                panelCaracteristicas.Controls.Remove(listaDeCheckBox[i-1]);
        }


        /*
        * ===============================================
        * SE ENCARGA DE ENCONTRAR SI HAY COMBO BOX VACIOS
        * EN EL FORMULARIO Y LOS GUARDA EN UNA LISTA
        * ===============================================
        */
        private ArrayList encontrarTextBoxVacios(Form formulario)
        {
            ArrayList listaDeErrores = new ArrayList();
            Label error = new Label() ;
            // hace un chequeo por todos los CONTROLES del formulario
            foreach (Control controlDeFormulario in this.Controls)
            {
                if (controlDeFormulario is GroupBox)
                {
                    //Si el control del formulario es un GruopBox recorre el mismo para encontral los text boxs
                    foreach (Control controlBox in controlDeFormulario.Controls)
                    {
                        if (controlBox is TextBox)
                        {
                            if (controlBox.Text == "")
                            {
                                //Si se encuentra un text box vacio se agrega a una lista para poder informar cual tiene el error
                                error.Name = "error" + controlBox.Name;
                                listaDeErrores.Add(error.Name);
                            }
                            
                        }
                        else if (controlBox is Panel)
                        {
                            //Si es un panel, se recorre dentro para ver los combo box que están vacios e informar del error
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


        /*
        * =====================================================
        * SE ENCARGA DE LLENAR UNA LISTA CON LAS COMPETENCIAS Y
        * PONDERACIONES QUE FUERON AGREGADAS AL PUESTO
        * =====================================================
        */
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
                if (errorpanelCaracteristicas.Name == listaDeErrores[i].ToString())
                {
                    errorpanelCaracteristicas.Text = "Debe seleccionar una competencia y una ponderacion en cada ComboBox";
                    errorpanelCaracteristicas.Visible = true;
                }

            }
        }

        private void menuConsultor_Click(object sender, EventArgs e)
        {
            if (ventanaMenuConsultor.Created)
            {
                ventanaMenuConsultor.Visible = true;
                ventanaAnterior.Close();
                Close();
            }
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
