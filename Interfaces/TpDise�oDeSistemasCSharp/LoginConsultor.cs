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
        /*private void Cancelar_Click(object sender, EventArgs e)
        {
            //GestorCandidatos gestorCand = new GestorCandidatos();

            //MessageBox.Show(gestorCand.validarCandidato("DNI", "32563425", "MNF425P1").ToString());
            /*
            AdministradorBD adminBD = new AdministradorBD();
            ArrayList opcRespuesta = adminBD.recuperarOpcionRespuestaEvaluada(65);
            //ArrayList lista = adminBD.recuperarCandidato("DNI", "32563425");
            MessageBox.Show(opcRespuesta[0].ToString());
            int i = 0;
            OpciondeRespuestaEvaluada cnad = null;
            while (i < opcRespuesta.Count)
            {
                cnad = (OpciondeRespuestaEvaluada)opcRespuesta[i];
                MessageBox.Show(cnad.Nombre + " " + cnad.Codigo);
                i++;
            }
            /*
            GestorCuestionario gestCuest = new GestorCuestionario();

            ArrayList retorno = adminBD.recuperarCuestionarioActivo(cnad);
            i = 0;
            Cuestionario cuets = null;
            while (i < retorno.Count)
            {
                if ((retorno[i] is string) == false)
                {
                    cuets = (Cuestionario)retorno[i];
                    MessageBox.Show(cuets.Clave + " " + cuets.Estado.Estado_ + " " + cuets.NroAccesos);
                    bool si_o_no = gestCuest.validarAcceso(cuets, "MNF425P1");
                    MessageBox.Show(si_o_no.ToString());
                }
                else
                    MessageBox.Show(retorno[i].ToString());
                i++;
            }



            /*GestorCuestionario gestCuest = new GestorCuestionario();
            Cuestionario cuest = gestCuest.cuestionarioAsociado(cnad);
            MessageBox.Show(cuest.Clave + " " + cuest.PuestoEvaluado);

            ArrayList lista3 = adminBD.recuperarUltimoEstado(cuest);
            i = 0;
            Estado est = null;
            while (i < lista.Count)
            {
                est = (Estado)lista3[i];
                MessageBox.Show(est.Estado_ + " " + est.Fecha_hora);
                i++;
            }

            //ArrayList lista2 = adminBD.recuperarCuestionario(cnad);
            /*MessageBox.Show(lista2[0].ToString());
            i = 0;
            while (i < lista2.Count)
            {
                Cuestionario cuest = (Cuestionario)lista2[i];
                MessageBox.Show(cuest.Clave + " " + cuest.PuestoEvaluado);
                i++;
            }
            
            Close();
        }*/
       
        
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

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
      

    }
}
