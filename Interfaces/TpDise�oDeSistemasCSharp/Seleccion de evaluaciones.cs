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

                List<CompetenciaEvaluada> competenciasPorPuesto = new List<CompetenciaEvaluada>();
                DateTime fecha = (DateTime) selecciondatagridW[0, fila_seleccionada].Value;
                string codigo_puesto_evaluado = selecciondatagridW[1, fila_seleccionada].Value.ToString();
                string empresa = selecciondatagridW[2, fila_seleccionada].Value.ToString();
                string nombre_puesto = selecciondatagridW[3, fila_seleccionada].Value.ToString();
                
                string info_evaluacion = "Orden de merito para la evaluacion del puesto: "+ nombre_puesto + 
                    " tomada para la empresa: " + empresa + " el: " + fecha;
	        
                //listamos los "sin contestar" estado 3
                List<Candidato_Vista_impresion> sinContestar = new List<Candidato_Vista_impresion>();
                
                sinContestar = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo_puesto_evaluado, 3);
                
                if (sinContestar != null)
                {
                    MessageBox.Show("Lista de SIN CONTESTAR");
                    for (int r = 0; r < sinContestar.Count; r++)
                    {
                        MessageBox.Show(sinContestar[r].Nombre + " " + sinContestar[r].Apellido +" "+sinContestar[r].TipoDoc +" "+ sinContestar[r].NroDoc);
                    }
                 }

                List<Candidato_Vista_impresion> incompletos = new List<Candidato_Vista_impresion>(); 

                //listamos los "Incompletos" estado 4                
                
                incompletos = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo_puesto_evaluado, 4);
                

                if (incompletos != null)
                {
                    MessageBox.Show("Lista de INCOMPLETOS");
                    for (int r = 0; r < incompletos.Count; r++)
                    {
                        incompletos[r].Fecha_Inicio = AdminBD.primer_acceso(incompletos[r].NroDoc, fecha, codigo_puesto_evaluado);
                        incompletos[r].Fecha_Fin = AdminBD.ultimo_acceso(incompletos[r].NroDoc, fecha, codigo_puesto_evaluado);

                        MessageBox.Show(incompletos[r].Nombre + " " + incompletos[r].Apellido + " " + incompletos[r].TipoDoc + " " + incompletos[r].NroDoc 
                            + " " + incompletos[r].Nro_Accesos + " " + incompletos[r].Fecha_Inicio + " " + incompletos[r].Fecha_Fin);
                    }
                }
                
                List<Candidato_Vista_impresion> completos = new List<Candidato_Vista_impresion>();
                //listamos los "completos" estado 5                

                completos = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo_puesto_evaluado, 5);
                
                int cantidad_de_preguntas_por_competencia = 0;
                
                if (completos != null)
                {
                    
                    List<Candidato_Vista_impresion> listaCandidatos_No_Alcanzo_Minimos = new List<Candidato_Vista_impresion>();
                    List<Candidato_Vista_impresion> listaCandidatos_Si_Alcanzo_Minimos = new List<Candidato_Vista_impresion>();
                    
                    MessageBox.Show("Lista de COMPLETOS");

                    competenciasPorPuesto = AdminBD.competencias_segun_puesto(fecha, codigo_puesto_evaluado);
                    
                    for (int r = 0; r < completos.Count; r++)
                    {
                        completos[r].Puntuacion = AdminBD.obtener_puntuacion(completos[r].NroDoc, fecha, codigo_puesto_evaluado);
                        completos[r].Fecha_Inicio = AdminBD.primer_acceso(completos[r].NroDoc, fecha, codigo_puesto_evaluado);
                        completos[r].Fecha_Fin = AdminBD.fecha_fin(completos[r].NroDoc, fecha, codigo_puesto_evaluado);


                        MessageBox.Show(completos[r].Nombre + " " + completos[r].Apellido + " " + completos[r].TipoDoc + " " + completos[r].NroDoc
                            + " " + completos[r].Nro_Accesos + " " + completos[r].Fecha_Inicio + " " + completos[r].Fecha_Fin);
                        
                        for (int a = 0; a < competenciasPorPuesto.Count; a++)
                        {
                            cantidad_de_preguntas_por_competencia = AdminBD.cantidad_De_Preguntas_Por_Competencia(competenciasPorPuesto[a].Codigo, fecha, codigo_puesto_evaluado);

                            int puntaje_obtenido = cantidad_de_preguntas_por_competencia * 10;
                            int minimo = competenciasPorPuesto[a].Ponderacion;
                            int porcentaje_obtenido = (puntaje_obtenido * 100) / minimo;

                            if (porcentaje_obtenido < minimo * 100) //si no llega con uno de los minimos
                            {
                                listaCandidatos_No_Alcanzo_Minimos.Add(completos[r]);
                                break; //deja de ver el resto de las competencias y sigue con el siguiente candidato
                            }
                        }

                        listaCandidatos_Si_Alcanzo_Minimos.Add(completos[r]);
                        
                        //Falta llenar las puntuaciones.
                    
                    
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
