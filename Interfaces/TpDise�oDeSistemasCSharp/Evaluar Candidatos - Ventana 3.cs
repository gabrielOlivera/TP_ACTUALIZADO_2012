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

namespace TpDiseñoCSharp
{
    public partial class Evaluar_Candidatos___Ventana_3 : Form
    {
        private Puesto puestoSeleccionado;
        private List<Candidato> candidatoSeleccionados;
        private Form pantallaPrincipal;
        SaveFileDialog guardar;

        public Evaluar_Candidatos___Ventana_3(string user, Puesto puestoSelec_paramentro, List<Candidato> listaSeleccionados_parametro, Form principal, Form anterior)
        {
            InitializeComponent();

            puestoSeleccionado = puestoSelec_paramentro;
            candidatoSeleccionados = listaSeleccionados_parametro;
            pantallaPrincipal = principal;
            anterior.Close();
            this.Fecha.Text = DateTime.Now.ToLongDateString();
            this.GenerarClave(candidatoSeleccionados);

            candidatos_claves.DataSource = candidatoSeleccionados;

            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = user;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);
        }

        private bool GenerarClave(List<Candidato> list_cand_Asociados)
        {
            for (int i = 0; i < list_cand_Asociados.Count; i++)
            {
                Candidato cand_Asociado = list_cand_Asociados[i];

                string clave_generada = cand_Asociado.Nombre[0].ToString() + cand_Asociado.Apellido[0].ToString() + puestoSeleccionado.Empresa[0].ToString()
                + cand_Asociado.NroDoc[5].ToString() + cand_Asociado.NroDoc[6].ToString() + cand_Asociado.NroDoc[7].ToString()
                + puestoSeleccionado.Codigo[0].ToString() + i.ToString();

                cand_Asociado.Clave = clave_generada;
            }
            
            return true;
        }

        private void Finalizar_Click(object sender, EventArgs e)
        {
            guardar = new SaveFileDialog();

            /*guardar.AddExtension = true;
            guardar.Filter = "*.xls";
            guardar.DefaultExt = ".xls";*/
            //guardar.FileOk += Guardar_Click;

            string ruta = guardar.InitialDirectory;
            //guardar.FileName = DateTime.Now.ToString() + puestoSeleccionado.Nombre + ".xls";
            guardar.ShowDialog();

            MessageBox.Show(ruta);
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            guardar.OpenFile().Close();
        }

        private void Atras_Click(object sender, EventArgs e)
        {

        }
    }
}
