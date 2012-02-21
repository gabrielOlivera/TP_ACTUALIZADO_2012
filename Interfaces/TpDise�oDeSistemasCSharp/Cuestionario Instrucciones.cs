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

namespace TpDiseñoCSharp
{
    public partial class Cuestionario_Instrucciones : Form
    {
        AdministradorBD administradorBD = new AdministradorBD();

        private Form pantalla_Inicial;
        private Cuestionario cuestionarioAmostrar;

        public Cuestionario Cuestionario_A_mostrar
        {
            get { return cuestionarioAmostrar; }
            set { cuestionarioAmostrar = value; }

        }

        public Cuestionario_Instrucciones(string candidato,Form pantallaPrincipal, Form pantallaAnterior, Cuestionario cuestionario_Asociado)
        {
            InitializeComponent();
            pantalla_Inicial = pantallaPrincipal;
            pantallaAnterior.Close();
            Candidato.Text = candidato;
            this.Cuestionario_A_mostrar = cuestionario_Asociado;
            this.Candidato.Text = Cuestionario_A_mostrar.CandidatoAsociado.Nombre + " " + Cuestionario_A_mostrar.CandidatoAsociado.Apellido;
            this.Fecha.Text = DateTime.Now.ToLongDateString();
            InstruccionesCuestionario.Text = administradorBD.retornarInstruccionesDelcuestionario();
            InstruccionesCuestionario.Text = InstruccionesCuestionario.Text.Replace("@", "\n");

            this.Candidato.Text = candidato;
            int largoTextoConsultor = Candidato.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Candidato.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            GestorCuestionario gestorCuestionarios = new GestorCuestionario();

            Bloque bloqueA_Mostrar = gestorCuestionarios.inicializarCuestionario(this.Cuestionario_A_mostrar);
            if (bloqueA_Mostrar != null)
            {
                Completar_Cuestionario completarCuestionario = new Completar_Cuestionario(Candidato.Text,bloqueA_Mostrar, this, pantalla_Inicial);
                completarCuestionario.Show();
            }
        }
        
    }
}
