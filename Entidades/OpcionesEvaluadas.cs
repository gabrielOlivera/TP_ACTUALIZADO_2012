using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class OpcionesEvaluadas
    {
        private string nombre;
        private int valor;
        private int ordenDeVisualizacion;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }

        }

        public int OrdenDeVisualizacion
        {
            get { return ordenDeVisualizacion; }
            set { ordenDeVisualizacion = value; }

        }

        public OpcionesEvaluadas(string nom, int ponderacion, int ordenVisualizacion)
        {
            nombre = nom;
            valor = ponderacion;
            ordenDeVisualizacion = ordenVisualizacion;
        }



    }
}
