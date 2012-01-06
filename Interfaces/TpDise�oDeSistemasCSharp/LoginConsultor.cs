using System;
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
        public LoginConsultor()
        {
            InitializeComponent();
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            if (!FuncionesVarias.validarCamposAlfanum(Usuario.Text))
            {
                if (!FuncionesVarias.validarCamposAlfanum(Contraseña.Text))
                {
                    if (Contraseña.Text.Length > 7)
                    {
                        MenuPrincipalConsultor menuConsultor = new MenuPrincipalConsultor(Usuario.Text);
                        menuConsultor.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe ser de 8 caracteres como mínimo", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("El usuario o la contraseña no son válidos", "Mensaje de Error",
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
