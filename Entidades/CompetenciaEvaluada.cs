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

        public CompetenciaEvaluada(string cod, string nom, string des)
        {
            codigo = cod; // solo se inicializa aqui este codigo.
            nombre =  nom;
            Descripcion = des;
            listaFactores = new List<FactorEvaluado>();
        }

        public void addFactor(FactorEvaluado fact) { listaFactores.Add(fact); }


    }
}
