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
using nmExcel = Microsoft.Office.Interop.Excel;

namespace TpDiseñoCSharp
{
    public partial class Orden_de_merito : Form
    {
        public Orden_de_merito(String info_Ev, List<Candidato_Vista_impresion> sin_contestar, List<Candidato_Vista_impresion> Incompletos, List<Candidato_Vista_impresion> completos_sin_minimos, List<Candidato_Vista_impresion> completos_con_minimos )
        {
            InitializeComponent();
 
            
            completosCON_minimos_dgv.DataSource = completos_con_minimos;
            completosSIN_minimos_dgv.DataSource = completos_sin_minimos;
            incompletos_dgv.DataSource = Incompletos;
            sin_completar_dgv.DataSource = sin_contestar;

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            SaveFileDialog ventana_guardar;
            nmExcel.Application ExcelApp = new nmExcel.Application();
            ExcelApp.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 25;
            int filas_ya_ocupadas_excel = 1;

            //------------------------------------------------------------------------
            //-----------------------Completos Con minimos----------------------------
            //------------------------------------------------------------------------
            if (completosCON_minimos_dgv.Rows.Count != 0)
            {
                ExcelApp.Cells[1, 1] = "Completos CON minimos";

                filas_ya_ocupadas_excel++;

                for (int i = filas_ya_ocupadas_excel; i < completosCON_minimos_dgv.Rows.Count + filas_ya_ocupadas_excel; i++)
                {
                    DataGridViewRow Fila = completosCON_minimos_dgv.Rows[i - filas_ya_ocupadas_excel];

                    for (int j = 0; j < Fila.Cells.Count; j++)
                    {
                        ExcelApp.Cells[(i + 1), j + 1] = Fila.Cells[j].Value;
                    }
                }

                filas_ya_ocupadas_excel += completosCON_minimos_dgv.Rows.Count;
            }
            //------------------------------------------------------------------------
            //-----------------------Completos Sin minimos----------------------------
            //------------------------------------------------------------------------
            if (completosSIN_minimos_dgv.Rows.Count != 0)
            {
                ExcelApp.Cells[filas_ya_ocupadas_excel + 1, 1] = "Completos SIN minimos";

                filas_ya_ocupadas_excel++;


                for (int i = filas_ya_ocupadas_excel; i < completosSIN_minimos_dgv.Rows.Count + filas_ya_ocupadas_excel; i++)
                {
                    DataGridViewRow Fila = completosSIN_minimos_dgv.Rows[i - filas_ya_ocupadas_excel];

                    for (int j = 0; j < Fila.Cells.Count; j++)
                    {
                        ExcelApp.Cells[(i + 1), j + 1] = Fila.Cells[j].Value;
                    }
                }

                filas_ya_ocupadas_excel += completosSIN_minimos_dgv.Rows.Count;
            }
            //------------------------------------------------------------------------
            //-----------------------Incompletos--------------------------------------
            //------------------------------------------------------------------------

            if (incompletos_dgv.Rows.Count != 0)
            {

                ExcelApp.Cells[filas_ya_ocupadas_excel + 1, 1] = "Incompletos";

                filas_ya_ocupadas_excel++;


                for (int i = filas_ya_ocupadas_excel; i < incompletos_dgv.Rows.Count + filas_ya_ocupadas_excel; i++)
                {
                    DataGridViewRow Fila = incompletos_dgv.Rows[i - filas_ya_ocupadas_excel];

                    for (int j = 0; j < Fila.Cells.Count; j++)
                    {
                        ExcelApp.Cells[(i + 1), j + 1] = Fila.Cells[j].Value;
                    }
                }

                filas_ya_ocupadas_excel += incompletos_dgv.Rows.Count;
            }

            //------------------------------------------------------------------------
            //-----------------------Sin Contestar------------------------------------
            //------------------------------------------------------------------------

            if (sin_completar_dgv.Rows.Count != 0)
            {

                ExcelApp.Cells[filas_ya_ocupadas_excel + 1, 1] = "Sin Contestar";

                filas_ya_ocupadas_excel++;


                for (int i = filas_ya_ocupadas_excel; i < sin_completar_dgv.Rows.Count + filas_ya_ocupadas_excel; i++)
                {
                    DataGridViewRow Fila = sin_completar_dgv.Rows[i - filas_ya_ocupadas_excel];

                    for (int j = 0; j < Fila.Cells.Count; j++)
                    {
                        ExcelApp.Cells[(i + 1), j + 1] = Fila.Cells[j].Value;
                    }
                }

                filas_ya_ocupadas_excel += sin_completar_dgv.Rows.Count;
            }

            // ---------- cuadro de dialogo para Guardar
            ventana_guardar = new SaveFileDialog();
            ventana_guardar.DefaultExt = "xls";
            ventana_guardar.Filter = "Archivo Excel | *.xls";
            ventana_guardar.AddExtension = true;
            ventana_guardar.RestoreDirectory = true;
            ventana_guardar.Title = "Emitir orden de merito";
            ventana_guardar.InitialDirectory = @"c:\";
            string nombre_archivo = info_Ev + " ";
            ventana_guardar.FileName = nombre_archivo;

            if (ventana_guardar.ShowDialog() == DialogResult.OK)
            {
                ExcelApp.ActiveWorkbook.SaveCopyAs(ventana_guardar.FileName);
                ExcelApp.ActiveWorkbook.Saved = true;
                ventana_guardar.Dispose();
                ventana_guardar = null;
                ExcelApp.Quit();
            }


        }

        private void Orden_de_merito_Load(object sender, EventArgs e)
        {

             
        }
    }
}
