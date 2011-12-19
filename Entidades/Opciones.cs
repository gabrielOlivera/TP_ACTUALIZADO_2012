using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Opciones
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
    }
}
