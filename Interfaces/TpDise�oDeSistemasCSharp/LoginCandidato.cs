using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Validacion;
using Entidades;
using Gestores;

namespace TpDiseñoCSharp
{
    public partial class LoginCandidato : Form
    {
        GestorCandidatos gestorCandidatos = new GestorCandidatos();
        Gestores.GestorCuestionario gestorCuestionario = new GestorCuestionario();
        private Form pantallaAnterior;

        public LoginCandidato(Form pantalla_Anterior)
        {
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.ToLongDateString();

            pantallaAnterior = pantalla_Anterior;
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            /*Hacer la validación primero de si son correctos los datos ingresados como caracteres alfanumericos, etc
             y luego mandar a validar al gestor*/
            switch(Tipo.Text)
            {
                case "PP":
                    if (!FuncionesVarias.validarCamposAlfanum(NroDoc.Text))
                    {
                        if (NroDoc.Text.Length == 10)
                        {
                            //Nos Fijamos si los datos ingresados pertenecen a un candidato existente en la base de datos y si posee un cuestionario para ser evaluado
                            object esValido = gestorCandidatos.validarCandidato(Tipo.Text.ToString(), NroDoc.Text.ToString(), Clave.Text.ToString());
                            Cuestionario c = (Cuestionario)esValido;
                            string candidato = c.CandidatoAsociado.Nombre + " " + c.CandidatoAsociado.Apellido;
                                
                            if ((esValido is Cuestionario) == true)
                            {
                                
                                //Con el CUESTIONARIO instanciado, decidimos que acción corresponde tomar (Iniciar el cuestionario, recuperar el cuestionario o finalizar el cuestionario)
                                ArrayList evento_ = gestorCuestionario.crearCuestionario((Cuestionario)esValido);
                                if (evento_.Count != 0)
                                {
                                    if ((evento_[0] is Bloque) == true)//Si se retorno el bloque -> recuperamos el cuestionario
                                    {
                                        Completar_Cuestionario cuest_bloques = new Completar_Cuestionario(candidato,(Bloque)evento_[0], this, pantallaAnterior);
                                        pantallaAnterior.Visible = false;
                                        cuest_bloques.Show();
                                        
                                    }
                                    else if (Equals(evento_[0], "instrucciones") == true)//Si retorno intrucciones -> inicializar el cuestionario
                                    {
                                        Cuestionario_Instrucciones cuestInstruc = new Cuestionario_Instrucciones(candidato,pantallaAnterior, this, (Cuestionario)esValido);
                                        pantallaAnterior.Visible = false;
                                        cuestInstruc.Show();
                                    }
                                    else if (((evento_[0] is Bloque) == false) && (Equals(evento_[0], "instrucciones") == false))//Ninguna de las anteriores -> se finalizo el cuestionario
                                        MessageBox.Show(evento_[0].ToString());
                                }
                            }   
                        }
                        else
                        {
                            MessageBox.Show("El número de caracteres ingresados tiene que ser de 10 digitos", "ADVERTENCIA",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El PP solo acepta caracteres alfanuméricos", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "":
                    MessageBox.Show("El Tipo no puede ser vacío", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                            

                default:
                    if (!FuncionesVarias.validarCamposNumericos(NroDoc.Text))
                    {
                        if (NroDoc.Text.Length == 8)
                        {
                            //Nos Fijamos si los datos ingresados pertenecen a un candidato existente en la base de datos y si posee un cuestionario para ser evaluado
                            object esValido = gestorCandidatos.validarCandidato(Tipo.Text.ToString(), NroDoc.Text.ToString(), Clave.Text.ToString());
                            Cuestionario c = (Cuestionario)esValido;
                            string candidato = c.CandidatoAsociado.Nombre + " " + c.CandidatoAsociado.Apellido;
                                
                            if ((esValido is Cuestionario) == true)
                            {
                                //Con el CUESTIONARIO instanciado, decidimos que acción corresponde tomar (Iniciar el cuestionario, recuperar el cuestionario o finalizar el cuestionario)
                                ArrayList evento_ = gestorCuestionario.crearCuestionario((Cuestionario)esValido);
                                if (evento_.Count != 0)
                                {
                                    if ((evento_[0] is Bloque) == true)//Si se retorno el bloque -> recuperamos el cuestionario
                                    {
                                        Completar_Cuestionario cuest_bloques = new Completar_Cuestionario(candidato,(Bloque)evento_[0], this, pantallaAnterior);
                                        pantallaAnterior.Visible = false;
                                        cuest_bloques.Show();
                                    }
                                    else if (Equals(evento_[0], "instrucciones") == true)//Si retorno intrucciones -> inicializar el cuestionario
                                    {
                                        Cuestionario_Instrucciones cuestInstruc = new Cuestionario_Instrucciones(candidato,pantallaAnterior, this, (Cuestionario)esValido);
                                        pantallaAnterior.Visible = false;
                                        cuestInstruc.Show();
                                    }
                                    else if (((evento_[0] is Bloque) == false) && (Equals(evento_[0], "instrucciones") == false))//Ninguna de las anteriores -> se finalizo el cuestionario
                                        MessageBox.Show(evento_[0].ToString());
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El número de caracteres ingresados tiene que ser de 8 digitos", "ADVERTENCIA",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El tipo de Documento: " + Tipo.Text + " solo acepta caracteres numéricos", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
   
        }

        //Si presiona el boton cancelar, se cierra la ventana "LoginCandidato" y vuelve a la "PantallaPrincipal"
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginCandidato_Load(object sender, EventArgs e)
        {

        }

    }
}
