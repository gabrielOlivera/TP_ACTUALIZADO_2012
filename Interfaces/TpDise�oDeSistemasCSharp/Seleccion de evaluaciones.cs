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
    public partial class Seleccion_de_evaluaciones : Form
    {
        public Seleccion_de_evaluaciones(List<PuestoEvaluado> Lista_puestos_ev)
        {
            InitializeComponent();
            selecciondatagridW.DataSource = Lista_puestos_ev;
        }

        private void todos_Click(object sender, EventArgs e)
        {
            selecciondatagridW.SelectAll(); 
        }

        private void ninguno_Click(object sender, EventArgs e)
        {
            selecciondatagridW.ClearSelection();
        
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            AdministradorBD AdminBD = new AdministradorBD();
            List<Candidato> listaCandidatos= new List<Candidato>();

            //por cada evaluacion (p_ev segun fecha) seleccionada
            for (int i = 0; i < selecciondatagridW.SelectedRows.Count ; i++)
            {

                int fila_seleccionada = selecciondatagridW.SelectedRows[i].Index;

                DateTime fecha = (DateTime) selecciondatagridW[0, fila_seleccionada].Value;
                string codigo = selecciondatagridW[1, fila_seleccionada].Value.ToString();
                string empresa = selecciondatagridW[2, fila_seleccionada].Value.ToString();
                string nombre_puesto = selecciondatagridW[3, fila_seleccionada].Value.ToString();
                
                string info_evaluacion = "Orden de merito para la evaluacion del puesto: "+ nombre_puesto + 
                    " tomada para la empresa: " + empresa + " el: " + fecha;

	            //por cada candidato que participo en esta evaluacion
                
                listaCandidatos = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo);
                
                
                for (int r = 0; r < listaCandidatos.Count; r++)
                {
                    MessageBox.Show(listaCandidatos[r].ToString());    
                }
                


                //{
	            /*    completo la evaluacion? NO: a lista de "incompletos" y BREAK
	
    	                obtener puntuacion
	
	                cumple los minimos? NO: a lista de "No Aprobados"
 	                                    SI: Meter en lista "Aprobados" 

	                Ordenar listas "Aprobados" y "No Aprobados" por puntuacion


	            }
	            Mostrar lista "Aprobados"

	            Mostrar lista "No Aprobados"

	            Mostrar lista "Incompletos"

	            Poner "corte de control" 
                }
            }
             */
        
            }

        }

       
        
    }
}
