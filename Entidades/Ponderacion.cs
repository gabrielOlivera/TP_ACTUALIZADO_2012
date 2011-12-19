using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Ponderacion
    {
        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }

        }

        public Ponderacion(int ponderacion)
        {
            valor = ponderacion;
        }

       
    }
}
