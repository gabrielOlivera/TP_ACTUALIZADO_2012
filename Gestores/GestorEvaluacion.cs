using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Gestores
{
    class GestorEvaluacion
    {
        /*
         * La mision que justifica la existencia de los gestores es hacer de "interfaz" entre las ENTIDADES y el resto del sistema
         * Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
         */
        public PuestoEvaluado instanciarPuestoEvaluado(string codigo, string nombre, string empresa, string descripcion = null, List<Caracteristica> caracteristicas = null)
        {
            PuestoEvaluado nuevoPuestoEv = new PuestoEvaluado(codigo, nombre, empresa, descripcion, caracteristicas);
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

        public OpcionesEvaluadas instanciarOpcionEv(string nombre, int ponderacion)
        {
            OpcionesEvaluadas nuevoOpcionEv = new OpcionesEvaluadas(nombre, ponderacion);
            return nuevoOpcionEv;
        }


        //mira nuevamente esta funcionalidad
        public List<PreguntaEvaluada> listarPreguntas(PuestoEvaluado puesto)
        {
            List<PreguntaEvaluada> listaRetorno = new List<PreguntaEvaluada>();
            List<String> factoresNoEvaluados = new List<string>();

            List<Caracteristica> listCaracteristicas = puesto.getCaracteristicas();
            for (int i = 0; i <= listCaracteristicas.LongCount(); i++)
            {
                CompetenciaEvaluada compEv = (CompetenciaEvaluada)listCaracteristicas[i].dato1;
                List<FactorEvaluado> factores = compEv.ListaFactores;
                for (int j = 0; j <= factores.LongCount(); j++)
                {
                    int apto = factores[j].ListaPreguntasEv.Count;//retorna la cantidad de preguntas en el factor
                    switch (apto >= 5)
                    {
                        case true:
                            List<PreguntaEvaluada> listPreguntas = factores[j].ListaPreguntasEv;
                            ordenarLista(listPreguntas);
                            for (int h = 0; h <= 5; h++)
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
            if(Equals(factoresNoEvaluados.Count, 0))
            {
                //interfazUsuario.mostrarFactoresNoEvaluados(factoresNoEvaluados);
            }
            return listaRetorno;
        }

        public void ordenarLista(List<PreguntaEvaluada> listaPreg)
        {
            listaPreg.Sort();//deberia tomar algun criterio para reordenar la lista de preguntas
        }

        public DateTime obtenerFechaEvaluacion(PuestoEvaluado puestoEv)
        {
            return puestoEv.getFecha();
        }
    }
}
