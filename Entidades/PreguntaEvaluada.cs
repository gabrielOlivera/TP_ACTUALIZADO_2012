using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Entidades
{
    public class PreguntaEvaluada
    {
        private string pregunta;
        private string nombre;
        private string descripcion;
        private FactorEvaluado factorAsociado;
        private OpciondeRespuestaEvaluada op_respuestaEv; // Una opcion de respuesta seria "Bueno, Muy bueno, Excelente"
        private List<OpcionesEvaluadas> listaOpcionesEv; // ej de opcion: "Excelente = 10" Excelente es el 'nombre' y 10 el 'valor'

        public OpciondeRespuestaEvaluada Op_respuestaEv
        {
            get { return op_respuestaEv; }
            set { op_respuestaEv = value; }

        }

        public List<OpcionesEvaluadas> ListaOpcionesEv
        {
            get { return listaOpcionesEv; }
            set { listaOpcionesEv = value; }

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public string Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }

        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }

        public FactorEvaluado FactorAsociado
        {
            get { return factorAsociado; }
            set { factorAsociado = value; }

        }

        public PreguntaEvaluada(string preg, string nom, FactorEvaluado fact, string des, OpciondeRespuestaEvaluada Op_res_Ev)
        {
            pregunta = preg;
            factorAsociado = fact;
            nombre = nom;
            descripcion = des;
            op_respuestaEv = Op_res_Ev;
            listaOpcionesEv = new List<OpcionesEvaluadas>();
        }


        public void addOpcion(OpcionesEvaluadas opcion) { listaOpcionesEv.Add(opcion); }

    }
}
