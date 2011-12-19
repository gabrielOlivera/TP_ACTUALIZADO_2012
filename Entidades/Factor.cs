using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Entidades
{
    public class Factor
    {
        private int codigo;
        private string nombre;
        private Competencia competenciaAsociada;
        private string descripcion;
        private int nro_orden;
        private List<Pregunta> listaPreguntas;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }

        }

        public int Nro_orden
        {
            get { return nro_orden; }
            set { nro_orden = value; }

        }

        public List<Pregunta> ListaPreguntas
        {
            get { return listaPreguntas; }
            set { listaPreguntas = value; }

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public Competencia CompetenciaAsociada
        {
            get { return  competenciaAsociada; }
            set {  competenciaAsociada = value; }

        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }

        //Competencia -> Factor -> Pregunta
        public Factor(int cod, string nom, Competencia comp, string des, int nOrden)
        {
            codigo = cod;
            competenciaAsociada = comp;
            Nombre = nom;
            Descripcion = des;
            nro_orden = nOrden;
            listaPreguntas = new List<Pregunta>();
        }


        public void addPregunta(Pregunta preg) { listaPreguntas.Add(preg); }

    }
}
