using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Validacion;
using Gestores;
using Entidades;

namespace TpDiseñoCSharp
{
    public partial class LoginCandidato : Form
    {
        public LoginCandidato()
        {
            InitializeComponent();
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            Gestores.GestorCandidatos gestorCandidatos = new GestorCandidatos();
            Gestores.GestorCuestionario gestorCuestionario = new GestorCuestionario();

            /*Hacer la validación primero de si son correctos los datos ingresados como caracteres alfanumericos, etc
             y luego mandar a validar al gestor*/
            switch(Tipo.Text)
            {
                case "PP":
                    if (!validarAlphanum.validarCamposAlfanum(NroDoc.Text))
                    {
                        if (NroDoc.Text.Length == 10)
                        {
                            bool esValido = gestorCandidatos.validarCandidato(Tipo.Text.ToString(), NroDoc.Text.ToString(), Clave.Text.ToString());

                            if (esValido == true)
                            {
                                Candidato cand_ = gestorCandidatos.retornarCandidato(Tipo.Text.ToString(), NroDoc.Text.ToString());
                                //gestorCuestionario.crearCuestionario(cand_);
                                Cuestionario_Instrucciones cuestInstruc = new Cuestionario_Instrucciones();
                                cuestInstruc.ShowDialog();
                            }
                            MessageBox.Show(esValido.ToString());
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
                    if (!validarAlphanum.validarCamposNumericos(NroDoc.Text))
                    {
                        if (NroDoc.Text.Length == 8)
                        {
                            bool esValido = gestorCandidatos.validarCandidato(Tipo.Text.ToString(), NroDoc.Text.ToString(), Clave.Text.ToString());

                            if (esValido == true)
                            {
                                Candidato cand_ = gestorCandidatos.retornarCandidato(Tipo.Text.ToString(), NroDoc.Text.ToString());
                                //gestorCuestionario.crearCuestionario(cand_);
                                Cuestionario_Instrucciones cuestInstruc = new Cuestionario_Instrucciones();
                                cuestInstruc.ShowDialog();
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
                        MessageBox.Show("El tipo de Documento: "+Tipo.Text+" solo acepta caracteres numéricos", "ERROR", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }
   
        }


        //Si presiona el boton cancelar, se cierra la ventana "LoginCandidato" y vuelve a la "PantallaPrincipal"
        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
