using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; //necesario para declarar los arreglos

namespace Entidades
{
    public class Competencia
    {
        private string codigo;
        private string nombre;
        private string descripcion;
        private List<Factor> listaFactores;

        public List<Factor> ListaFactores
        {
            get { return listaFactores; }
            set { listaFactores = value; }

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

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }



        public Competencia(string cod, string nom, string des)
        {
            codigo = cod; // solo se inicializa aqui este codigo.
            Nombre = nom;
            Descripcion = des;
            listaFactores = new List<Factor>();
        }

        public Competencia(string cod, string nom, string des, List<Factor> factores)
        {
            codigo = cod; // solo se inicializa aqui este codigo.
            Nombre = nom;
            Descripcion = des;
            listaFactores = factores;
        }

        public void addFactor(Factor fact) { listaFactores.Add(fact); }


    }
}
