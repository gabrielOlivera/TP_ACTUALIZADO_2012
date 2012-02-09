using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; //necesario para declarar los arreglos

namespace Entidades
{
    public class CompetenciaEvaluada
    {
        private string codigo;
        private string nombre;
        private string descripcion;
        private int ponderacion;
        private List<FactorEvaluado> listaFactores;

        public List<FactorEvaluado> ListaFactores
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

        public int Ponderacion
        {
            get { return ponderacion; }
            set { ponderacion = value; }

        }

        public CompetenciaEvaluada(string cod, string nom, string des = null)
        {
            this.Codigo = cod; // solo se inicializa aqui este codigo.
            this.Nombre =  nom;
            this.Descripcion = des;
            this.ListaFactores = new List<FactorEvaluado>();
        }

        public void addFactor(FactorEvaluado fact) { listaFactores.Add(fact); }


    }
}
