using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using Entidades;

namespace Gestores
{
    class GestorEvaluacion
    {
        /*
         * La mision que justifica la existencia de los gestores es hacer de "intermediario" entre las ENTIDADES y el resto del sistema
         * Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
         */
        public PuestoEvaluado instanciarPuestoEvaluado(string codigo, string nombre, string empresa, string descripcion = null, List<Caracteristica> caracteristicas = null)
        {
            AdministradorBD admBD = new AdministradorBD();
            PuestoEvaluado nuevoPuestoEv = new PuestoEvaluado(codigo, nombre, empresa, DateTime.Now, descripcion, caracteristicas);
            return nuevoPuestoEv;
        }

        public CompetenciaEvaluada instanciarCompetenciaEvaluda(string codigo, string nombre, string descripcion = null)
        {
            CompetenciaEvaluada nuevaCompetenciaEv = new CompetenciaEvaluada(codigo, nombre, descripcion);
            return nuevaCompetenciaEv;
        }

        public FactorEvaluado instanciarFactorEvaluado(string codigo, string nombre, CompetenciaEvaluada competenciaAsociada, int nrOrden, string descripcion = null)
        {
            FactorEvaluado nuevoFactorEv = new FactorEvaluado(codigo, nombre, competenciaAsociada, nrOrden, descripcion);
            return nuevoFactorEv;
        }

        public PreguntaEvaluada instanciarPreguntaEvaluda(string codigo, string pregunta_, string nombre, FactorEvaluado factorAsocido, OpciondeRespuestaEvaluada OpcRespuesta = null, string descripcion = null)
        {
            PreguntaEvaluada nuevaPreguntaEv = new PreguntaEvaluada(codigo, pregunta_, nombre, factorAsocido, OpcRespuesta, descripcion);
            return nuevaPreguntaEv;
        }

        public OpciondeRespuestaEvaluada instanciarOpRespuestaEv(string nombre, string codigo, string descripcion = null)
        {
            OpciondeRespuestaEvaluada nuevaOpRespuestEv = new OpciondeRespuestaEvaluada(nombre, codigo, descripcion);
            return nuevaOpRespuestEv;
        }

        public OpcionesEvaluadas instanciarOpcionEv(string nombre, int ponderacion, int ordenVisualizacion)
        {
            OpcionesEvaluadas nuevoOpcionEv = new OpcionesEvaluadas(nombre, ponderacion, ordenVisualizacion);
            return nuevoOpcionEv;
        }


        public PreguntaEvaluada retornarPreguntaDeLaRelacion(PuestoEvaluado puestoAsociado, string codigo)
        {
            int i = 0;
            PreguntaEvaluada preguntaEncontrada = null;
            while (i < puestoAsociado.Caracteristicas.Count)
            {
                int j = 0;
                CompetenciaEvaluada competenciaAsociada = (CompetenciaEvaluada)puestoAsociado.Caracteristicas[i].dato1;
                while (j < competenciaAsociada.ListaFactores.Count)
                {
                    int w = 0;
                    List<PreguntaEvaluada> listaPreguntas = competenciaAsociada.ListaFactores[j].ListaPreguntasEv;
                    while (w < listaPreguntas.Count)
                    {
                        if ((listaPreguntas[w].Codigo == codigo) == true)
                            return preguntaEncontrada = listaPreguntas[w];
                        w++;
                    }
                    j++;
                }
                i++;

            }
            return preguntaEncontrada;
        }

        //mira nuevamente esta funcionalidad
        public List<PreguntaEvaluada> listarPreguntas(PuestoEvaluado puesto)
        {
            List<PreguntaEvaluada> listaRetorno = new List<PreguntaEvaluada>();
            List<String> factoresNoEvaluados = new List<string>();

            List<Caracteristica> listCaracteristicas = puesto.getCaracteristicas();
            for (int i = 0; i < listCaracteristicas.Count; i++)
            {
                CompetenciaEvaluada compEv = (CompetenciaEvaluada)listCaracteristicas[i].dato1;
                List<FactorEvaluado> factores = compEv.ListaFactores;
                for (int j = 0; j < factores.Count; j++)
                {
                    int apto = factores[j].ListaPreguntasEv.Count;//retorna la cantidad de preguntas en el factor
                    switch (apto >= 5)
                    {
                        case true:
                            List<PreguntaEvaluada> listPreguntas = ordenarLista(factores[j].ListaPreguntasEv);
                            for (int h = 0; h < 5; h++)
                            {
                                listaRetorno.Add(listPreguntas[h]);
                            }
                            break;
                        default:
                            factoresNoEvaluados.Add(factores[j].Nombre);
                            break;
                    }
                }
            }

            if(factoresNoEvaluados.Count != 0)
            {
                string mensajeBox = "Los siguiente factores no fueron evaludos por no cumplir con el minimo de preguntas para la evaluación:\n";
                for (int i = 0; i < factoresNoEvaluados.Count; i++)
                {
                    mensajeBox += factoresNoEvaluados[i] + "\t\n";
                }
                MessageBox.Show(mensajeBox);
            }

            return listaRetorno;
        }

        public List<PreguntaEvaluada> ordenarLista(List<PreguntaEvaluada> listaPreg)
        {
            int selector, i = 0;
            List<int> historial_Selectores = new List<int>();
            Random selectorRamdom = new Random();
            List<PreguntaEvaluada> listaAuxiliar = new List<PreguntaEvaluada>();

            while(i < listaPreg.Count)
            {
                selector = selectorRamdom.Next(listaPreg.Count);
                if (historial_Selectores.Count != 0)
                {
                    bool selectorFueUsado = false;
                    int j = 0; 
                    while (j < historial_Selectores.Count)
                    {
                        if (selector != historial_Selectores[j])
                        {
                            selectorFueUsado = false;
                            j++;
                        }
                        else
                        {
                            selectorFueUsado = true;
                            j = historial_Selectores.Count;
                        }
                    }

                    if (selectorFueUsado == false)
                    {
                        historial_Selectores.Add(selector);
                        listaAuxiliar.Add(listaPreg[selector]);
                        i++;
                    }
                    
                }
                else
                {
                    historial_Selectores.Add(selector);
                    listaAuxiliar.Add(listaPreg[selector]);
                    i++;
                }
            }

            return listaAuxiliar;
        }

        public DateTime obtenerFechaEvaluacion(PuestoEvaluado puestoEv)
        {
            return puestoEv.Fecha_Comienzo;
        }
    }


}
