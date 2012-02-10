using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    class Candidato_Vista_impresion
    {
        private string nroDoc, nombre, apellido, tipoDoc;
        private DateTime fecha_Inicio, fecha_Fin;
        private int puntuacion, nro_Accesos;

        
        public string NroDoc
        {
            get { return nroDoc; }
            set { nroDoc = value; }

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }

        }

        public string TipoDoc
        {
            get { return tipoDoc; }
            set { tipoDoc = value; }
        }

        public DateTime Fecha_Inicio
        {
            get { return fecha_Inicio; }
            set { fecha_Inicio = value; }
        }
        
        public DateTime Fecha_Fin 
        {
            get { return fecha_Fin; }
            set { fecha_Fin = value; }
        }
        
        public int Puntuacion
        {
            get { return puntuacion; }
            set { puntuacion = value; }
        }

        public int Nro_Accesos
        {
            get { return nro_Accesos; }
            set { nro_Accesos = value; }
        }

     
    }
}
