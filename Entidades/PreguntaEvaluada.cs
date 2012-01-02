using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Entidades
{
    public class PreguntaEvaluada
    {
        private string codigo;
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

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
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

        public PreguntaEvaluada(string cod_, string preg_, string nom_, FactorEvaluado fact_, OpciondeRespuestaEvaluada Op_res_Ev = null, string des = null)
        {
            this.Codigo = cod_;
            this.Pregunta = preg_;
            this.FactorAsociado = fact_;
            this.Nombre = nom_;
            this.Descripcion = des;
            this.Op_respuestaEv = Op_res_Ev;
            this.ListaOpcionesEv = new List<OpcionesEvaluadas>();
        }


        public void addOpcion(OpcionesEvaluadas opcion) { listaOpcionesEv.Add(opcion); }

    }
}
