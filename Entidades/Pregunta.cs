using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; //necesario para declarar los arreglos

namespace Entidades
{
    public class Pregunta
    {
        private string pregunta_;
        private string nombre;
        private string descripcion;
        private Factor factorAsociado;
        private OpciondeRespuesta Op_respuesta; // Una opcion de respuesta seria "Bueno, Muy bueno, Excelente"
        private List<Opciones> listaOpciones; // ej de opcion: "Excelente = 10" Excelente es el 'nombre' y 10 el 'valor'

        public string Preg_aRealizar
        {
            get { return pregunta_; }
            set { pregunta_ = value; }
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

        public Factor FactorAsociado
        {
            get { return factorAsociado; }
            set { factorAsociado = value; }
        }

        public OpciondeRespuesta OpcionRespuesta_Asociada
        {
            get { return Op_respuesta; }
            set { Op_respuesta = value; }
        }

        public List<Opciones> ListaOpciones
        {
            get { return listaOpciones; }
            set { listaOpciones = value; }
        }


        public Pregunta(string preg, string nom, Factor fact, OpciondeRespuesta op_res = null, string des = null)
        {
            Preg_aRealizar = preg;
            FactorAsociado = fact;
            Nombre = nom;
            Descripcion = des;
            OpcionRespuesta_Asociada = op_res;
            ListaOpciones = new List<Opciones>();
        }

        public void addOpcion(Opciones opcion) { listaOpciones.Add(opcion); }
    }
}
