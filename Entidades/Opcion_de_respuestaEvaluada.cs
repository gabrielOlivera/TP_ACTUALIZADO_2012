using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Entidades
{
    public class OpciondeRespuestaEvaluada // Una opcion de respuesta seria "Bueno, Muy bueno, Excelente"
    {
        private string nombre;
        private string descripcion;
        private List<OpcionesEvaluadas> listaOpcionesEv; // (lista de opcion) ej de opcion: "Excelente = 10" Excelente es el 'nombre' y 10 el 'valor'

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

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }

        public OpciondeRespuestaEvaluada(string nom, string des)
        {
            nombre =nom;
            Descripcion = des;
            listaOpcionesEv = new List<OpcionesEvaluadas>();
        }

        public void addOpcion(OpcionesEvaluadas opcion) { listaOpcionesEv.Add(opcion); }
    }
}
