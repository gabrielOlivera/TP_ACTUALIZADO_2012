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

            // Para mostrar los candidatos SIN_CONTESTAR alcanza con la lista definida mas abajo como "sinContestar" 
            // solo se necesitan los datos que ya se tienen en esa lista: nombre apellido tipo y nro de doc


            //List<Object> incompletos_visualizar = new List<object>(); //Accesos | ape, nom, tipo y nroDoc | fecha inicio | ultimo acceso
            
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
                List<Object> sinContestar = new List<object>();
                sinContestar = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo_puesto_evaluado, 3);
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

                // TIENE LISTAS EN ESTE ORDEN (lista de candidatos | lista de nro de Accesos | lista de fecha inicio | lista de ultimo acceso)
                List<Object> incompletos = new List<object>(); 

                List<DateTime> primeros_accesos_inc = new List<DateTime>();
                List<DateTime> ultimos_accesos_inc = new List<DateTime>();

                //listamos los "Incompletos" estado 4                
                
                incompletos = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo_puesto_evaluado, 4);
                

                if (incompletos != null)
                {
                    List<Candidato> listaCandidatos_Incompletos = (List<Candidato>)incompletos[0];
                    List<int> listaAccesos_Incompletos = (List<int>)incompletos[1];
                    
                    MessageBox.Show("Lista de INCOMPLETOS");
                    for (int r = 0; r < listaCandidatos_Incompletos.Count; r++)
                    {
                        MessageBox.Show(listaCandidatos_Incompletos[r].Nombre.ToString() + " " + listaAccesos_Incompletos[r].ToString());
                        primeros_accesos_inc.Add( AdminBD.primer_acceso(listaCandidatos_Incompletos[r].NroDoc, fecha, codigo_puesto_evaluado));
                        ultimos_accesos_inc.Add(AdminBD.ultimo_acceso(listaCandidatos_Incompletos[r].NroDoc, fecha, codigo_puesto_evaluado));
                    }
                    incompletos.Add(primeros_accesos_inc);
                    incompletos.Add(ultimos_accesos_inc);
                }

                

                List<Object> completos = new List<object>();
                //listamos los "completos" estado 5                

                completos = AdminBD.listarCandidatosPorEvaluacion(fecha, codigo_puesto_evaluado, 5);
                
                int cantidad_de_preguntas_por_competencia = 0;
                
                if (completos != null)
                {
                    List<Candidato> listaCandidatos_completos = (List<Candidato>)completos[0];
                    List<int> listaAccesos_completos = (List<int>)completos[1];
                    

                    // lista de candidatos | lista de nro de Accesos | lista de fecha inicio | lista de fecha fin | puntuacion
                    List<Object> listaCandidatos_No_Alcanzo_Minimos = new List<Object>();

                    List<Candidato> cand_NO = new List<Candidato>();
                    List<int> acces_NO = new List<int>();
                    List<DateTime> fecha_inicio_NO = new List<DateTime>();
                    List<DateTime> fecha_fin_NO = new List<DateTime>();
                    List<int> puntuacion_total_NO = new List<int>();

                    // lista de candidatos | lista de nro de Accesos | lista de fecha inicio | lista de fecha fin | puntuacion
                    List<Object> listaCandidatos_Si_Alcanzo_Minimos = new List<Object>();
                    
                    List<Candidato> cand_SI = new List<Candidato>();
                    List<int> acces_SI = new List<int>();
                    List<DateTime> fecha_inicio_SI = new List<DateTime>();
                    List<DateTime> fecha_fin_SI = new List<DateTime>();
                    List<int> puntuacion_total_SI = new List<int>();


                    MessageBox.Show("Lista de COMPLETOS");

                    competenciasPorPuesto = AdminBD.competencias_segun_puesto(fecha, codigo_puesto_evaluado);
                    
                    for (int r = 0; r < listaCandidatos_completos.Count; r++)
                    {
                        MessageBox.Show(listaCandidatos_completos[r].Nombre.ToString() + " puntuacion_total: " + AdminBD.obtener_puntuacion(listaCandidatos_completos[r].NroDoc.ToString(), fecha, codigo_puesto_evaluado).ToString() );
                        for (int a = 0; a < competenciasPorPuesto.Count; a++)
                        {
                            cantidad_de_preguntas_por_competencia = AdminBD.cantidad_De_Preguntas_Por_Competencia(competenciasPorPuesto[a].Codigo, fecha, codigo_puesto_evaluado);

                            int puntaje_obtenido = cantidad_de_preguntas_por_competencia * 10;
                            int minimo = competenciasPorPuesto[a].Ponderacion;
                            int porcentaje_obtenido = (puntaje_obtenido * 100) / minimo;

                            if (porcentaje_obtenido < minimo * 100) //si no llega con uno de los minimos
                            {
                                cand_NO.Add(listaCandidatos_completos[r]);
                                acces_NO.Add(listaAccesos_completos[r]);
                                break; //deja de ver el resto de las competencias y sigue con el siguiente candidato
                            }
                        }

                        cand_SI.Add(listaCandidatos_completos[r]);
                        acces_SI.Add(listaAccesos_completos[r]);
                    

                    
                    
                    }

                    listaCandidatos_No_Alcanzo_Minimos.Add(cand_NO);
                    listaCandidatos_No_Alcanzo_Minimos.Add(acces_NO);
                    listaCandidatos_Si_Alcanzo_Minimos.Add(cand_SI);
                    listaCandidatos_Si_Alcanzo_Minimos.Add(acces_SI);

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
