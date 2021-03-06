﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Validacion;


namespace TpDiseñoCSharp
{
    public partial class LoginConsultor : Form
    {
        private Form pantanllaPrincipal;

        public LoginConsultor(Form pantallaPrincipal_parametro)
        {
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.ToLongDateString();
            pantanllaPrincipal = pantallaPrincipal_parametro;
        }

        /*
        * ==========================================================================
        * SE ENCARGA DE VALIDAR EL CONSULTOR, TANTO QUE INGRESE DATOS VALIDOS 
        * Y DE SER CORRECTA LA VALIDACION MUESTRA LA PANTALLA PRINCIPAL DE CONSULTOR
        * ==========================================================================
        */
        private void Entrar_Click(object sender, EventArgs e)
        {
            if (!FuncionesVarias.validarCamposAlfanum(Usuario.Text))
            {
                if (!FuncionesVarias.validarCamposAlfanum(Contraseña.Text))
                {
                    if (Contraseña.Text.Length > 7)
                    {
                        MenuPrincipalConsultor menuConsultor = new MenuPrincipalConsultor(Usuario.Text, pantanllaPrincipal, this);
                        pantanllaPrincipal.Visible = false;
                        menuConsultor.Show();
                    }
                    else
                    {
                        MessageBox.Show("El usuario o la contraseña no son válidos", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FuncionesVarias.limpiarBoxesFormulario(this);
                        
                        this.ActiveControl = Usuario;

                    }
                }
                else
                {
                    MessageBox.Show("El usuario o la contraseña no son válidos","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                    FuncionesVarias.limpiarBoxesFormulario(this);
                    this.ActiveControl = Usuario;
                }
               
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña no son válidos", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                FuncionesVarias.limpiarBoxesFormulario(this);
                this.ActiveControl = Usuario;
            }
            
        }

        //Si presiona el boton cancelar, se cierra la pantalla "LoginConsultor" y se vuelve a la "PantallaPrincipal"
        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
