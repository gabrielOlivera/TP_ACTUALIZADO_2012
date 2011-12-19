using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Gestores
{
    class GestorEvaluacion
    {
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
