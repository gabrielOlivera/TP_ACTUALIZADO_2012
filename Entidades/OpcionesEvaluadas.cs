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

        public OpcionesEvaluadas(string nom, int valor2)
        {
            nombre = nom;
            valor = valor2;
        }



    }
}
