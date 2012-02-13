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
using nmExcel = Microsoft.Office.Interop.Excel;

namespace TpDiseñoCSharp
{
    public partial class Evaluar_Candidatos___Ventana_3 : Form
    {
        private Puesto puestoSeleccionado;
        private List<Candidato> candidatoSeleccionados;
        SaveFileDialog ventana_guardar;

        private Form ventanaMenuPrincipal, ventanaAnterior;

        public Evaluar_Candidatos___Ventana_3(string user, Puesto puestoSelec_paramentro, 
            List<Candidato> listaSeleccionados_parametro, Form principal, Form anterior)
        {
            InitializeComponent();

            puestoSeleccionado = puestoSelec_paramentro;
            candidatoSeleccionados = listaSeleccionados_parametro;
            ventanaMenuPrincipal = principal;
            ventanaAnterior=anterior;
            this.Fecha.Text = DateTime.Now.ToLongDateString();
            this.GenerarClave(candidatoSeleccionados);

            candidatos_claves.DataSource = candidatoSeleccionados;
            candidatos_claves.Columns.Remove("NroEmpleado");
            candidatos_claves.Columns.Remove("NroCandidato");

            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = user;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);
        }

        private void Finalizar_Click(object sender, EventArgs e)
        {
            nmExcel.Application ExcelApp = new nmExcel.Application();
            ExcelApp.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 7;

            for (int i = 0; i < candidatos_claves.Rows.Count; i++)
            {
                DataGridViewRow Fila = candidatos_claves.Rows[i];
                for (int j = 0; j < Fila.Cells.Count; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = Fila.Cells[j].Value;
                }
            }

            bool terminado = guardar_Candidatos();

            if (!terminado)
            {
                MessageBox.Show("No se guardaron los datos correctamente");
                ventanaMenuPrincipal.Visible = true;
                ventanaAnterior.Close();
                Close();
            }
            else
            {
                // ---------- cuadro de dialogo para Guardar
                ventana_guardar = new SaveFileDialog();
                ventana_guardar.DefaultExt = "xls";
                ventana_guardar.Filter = "Archivo Excel | *.xls";
                ventana_guardar.AddExtension = true;
                ventana_guardar.RestoreDirectory = true;
                ventana_guardar.Title = "Exportar Resultados";
                ventana_guardar.InitialDirectory = @"c:\";
                string nombre_archivo = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + puestoSeleccionado.Nombre;
                ventana_guardar.FileName = nombre_archivo;

                if (ventana_guardar.ShowDialog() == DialogResult.OK)
                {
                    ExcelApp.ActiveWorkbook.SaveCopyAs(ventana_guardar.FileName);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ventana_guardar.Dispose();
                    ventana_guardar = null;
                    ExcelApp.Quit();

                    ventanaMenuPrincipal.Visible = true;
                    ventanaAnterior.Close();
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar Datos .. ");

                    ventanaMenuPrincipal.Visible = true;
                    ventanaAnterior.Close();
                    Close();
                }
            }
        }

        private bool guardar_Candidatos()
        {
            GestorEvaluacion gestorEvaluacion = new GestorEvaluacion();

            bool realizado = gestorEvaluacion.duplicar_Esquema_Para_Evaluacion(puestoSeleccionado, candidatoSeleccionados);

            if (realizado)
                return true;
            else
                return false;
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

        private void Atras_Click(object sender, EventArgs e)
        {
            ventanaAnterior.Visible = true;
            Close();
        }

        private void menuConsultor_Click(object sender, EventArgs e)
        {
            ventanaMenuPrincipal.Visible = true;
            ventanaAnterior.Close();
            Close();
        }
    }
}
