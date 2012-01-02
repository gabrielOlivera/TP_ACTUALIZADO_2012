using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Validacion;
using Entidades;
using Gestores;
using System.Collections;


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
            if (!validarAlphanum.validarCamposAlfanum(Usuario.Text))
            {
                if (!validarAlphanum.validarCamposAlfanum(Contraseña.Text))
                {
                    if (Contraseña.Text.Length > 7)
                    {
                        MenuPrincipalConsultor menuConsultor = new MenuPrincipalConsultor(Usuario.Text);
                        this.Close();
                        menuConsultor.Show();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe ser de 8 caracteres como mínimo", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        limpiarTextBoxFormulario(this);
                        this.ActiveControl = Usuario;

                    }
                }
                else
                {
                    MessageBox.Show("El usuario o la contraseña no son válidos","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                    limpiarTextBoxFormulario(this);
                    this.ActiveControl = Usuario;
                }
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña no son válidos", "Mensaje de Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiarTextBoxFormulario(this);
                this.ActiveControl = Usuario;
            }
        }

        //Si presiona el boton cancelar, se cierra la pantalla "LoginConsultor" y se vuelve a la "PantallaPrincipal"
        private void Cancelar_Click(object sender, EventArgs e)
        {
            /*AdministradorBD admBD = new AdministradorBD();
            CompetenciaEvaluada comp_ = new CompetenciaEvaluada("C02", "MONO");
            FactorEvaluado fac_ = new FactorEvaluado("F00", "algo", null, 1);
            PreguntaEvaluada preg_Ad = new PreguntaEvaluada("PR11", "pred", "pre", fac_);


            MessageBox.Show(fac_.Codigo.ToString());

            ArrayList fact_ret = admBD.reconstruirRelaciones(;

            for (int i = 0; i < fact_ret.Count; i++)
            {
                CompetenciaEvaluada fact_ = (CompetenciaEvaluada)fact_ret[i];
                MessageBox.Show(fact_.Codigo + " " + fact_.ListaFactores + " " + fact_.Nombre);
            }

            /*for (int i = 0; i < preg_ret.Count; i++)
            {
                if ((preg_ret[i] is string) == false)
                {
                    PreguntaEvaluada preg_ = (PreguntaEvaluada)preg_ret[i];
                    List<OpcionesEvaluadas> listaopc_ = preg_.ListaOpcionesEv;
                    //if (listaopc_[0] != null)
                        MessageBox.Show(preg_.Codigo + " " + preg_.Nombre + " " + preg_.FactorAsociado.Nombre + " " + listaopc_[i].Nombre);
                    //else
                        //MessageBox.Show("No funciona la lista de opciones");
                }
                else
                    MessageBox.Show(preg_ret[i].ToString());
            }*/
            Close();
        }
        
       // Declaramos nuestro metodo que hara la limpieza de los textbox
        private void limpiarTextBoxFormulario(Form formulario)
        {
            // hace un chequeo por todos los textbox del formulario
            foreach(Control controlDeFormulario in formulario.Controls)
            {
                if (controlDeFormulario is GroupBox)
                {
                    foreach (Control controlTextBox in controlDeFormulario.Controls)
                    {
                        if (controlTextBox is TextBox)
                        {
                            controlTextBox.Text = null;
                        }
                    }
                }
            }
        }
    }
}
