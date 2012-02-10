using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Candidato_Vista_impresion
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

        //el cero indica que puede ser nulo el valor recibido
        public Candidato_Vista_impresion(string nom, string apell, string tipo, string nro, DateTime f_Inicio, DateTime f_fin, int puntuac = 0, int nroAcces = 0 )
        {
            nombre = nom;
            apellido = apell;
            tipoDoc = tipo;
            nroDoc = nro;
            fecha_Fin = f_fin;
            fecha_Inicio = f_Inicio;
            nro_Accesos = nroAcces;
            puntuacion = puntuac; 
        
        }
        //para los sin contestar
        public Candidato_Vista_impresion(string nom, string apell, string tipo, string nro)
        {
            nombre = nom;
            apellido = apell;
            tipoDoc = tipo;
            nroDoc = nro;
        }

    }
}
