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

	        
                //listamos los "sin contestar" estado 3                
                List<Object> sinContestar = new List<object>();
                sinContestar = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo, 3);
                if (sinContestar != null)
                {
                    List<Candidato> listaCandidatos_SinContestar = (List<Candidato>)sinContestar[0];
                    List<int> listaAccesos_SinContestar = (List<int>)sinContestar[1];

                    MessageBox.Show("Lista de SIN CONTESTAR");
                    for (int r = 0; r < listaCandidatos_SinContestar.Count; r++)
                    {
                        MessageBox.Show(listaCandidatos_SinContestar[r].Nombre.ToString() + " " + listaAccesos_SinContestar[r].ToString());
                    }
                }

                List<Object> incompletos = new List<object>();
                
                //listamos los "Incompletos" estado 4                
                
                incompletos = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo, 4);
                if (incompletos != null)
                {
                    List<Candidato> listaCandidatos_Incompletos = (List<Candidato>)incompletos[0];
                    List<int> listaAccesos_Incompletos = (List<int>)incompletos[1];
                    
                    MessageBox.Show("Lista de INCOMPLETOS");
                    for (int r = 0; r < listaCandidatos_Incompletos.Count; r++)
                    {
                        MessageBox.Show(listaCandidatos_Incompletos[r].Nombre.ToString() + " " + listaAccesos_Incompletos[r].ToString());
                    }
                }

                List<Object> completos = new List<object>();
                //listamos los "completos" estado 5                

                completos = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo, 5);
                if (completos != null)
                {
                    List<Candidato> listaCandidatos_completos = (List<Candidato>)completos[0];
                    List<int> listaAccesos_completos = (List<int>)completos[1];

                    MessageBox.Show("Lista de COMPLETOS");
                    for (int r = 0; r < listaCandidatos_completos.Count; r++)
                    {
                        MessageBox.Show(listaCandidatos_completos[r].Nombre.ToString() + " " + listaAccesos_completos[r].ToString());
                    }
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
