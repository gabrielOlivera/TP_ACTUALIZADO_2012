using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Candidato
    {
        private string nroDoc, nombre, apellido, tipoDoc;
        private int  nroCandidato, nroEmpleado;

        public int NroEmpleado
        {
            get { return nroEmpleado; }
            set { nroEmpleado = value; }

        }

        public int NroCandidato
        {
            get { return nroCandidato; }
            set { nroCandidato = value; }

        }

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

       
        //constructor con nro de documento tipo entero
        public Candidato(string nom, string apell, string tipo, string nro, int nroCand = 0, int nroEmp = 0)//el cero indica que puede ser nulo el valor recibido
        {
            nombre = nom;
            apellido = apell;
            tipoDoc = tipo;
            nroDoc = nro;
            nroCandidato = nroCand;
            nroEmpleado = nroEmp;
        }
    }
}
