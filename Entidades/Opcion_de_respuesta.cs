using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; //necesario para declarar los arreglos

namespace Entidades
{
    public class OpciondeRespuesta // Una opcion de respuesta seria "Bueno, Muy bueno, Excelente"
    {
        private string nombre;
        private string descripcion;
        private List<Opciones> listaOpciones; // (lista de opciones) ej de opcion: "Excelente = 10" Excelente es el 'nombre' y 10 el 'valor'

        public List<Opciones> ListaOpciones
        {
            get { return listaOpciones; }
            set { listaOpciones = value; }

        }

        public string Nombre
        {
            get { return  nombre; }
            set {  nombre = value; }

        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }

        public OpciondeRespuesta(string nom, string des)
        {
            Nombre = nom;
            Descripcion = des;
            listaOpciones = new List<Opciones>();
        }


        public void addOpcion(Opciones opcion) { listaOpciones.Add(opcion);}
    }
}
