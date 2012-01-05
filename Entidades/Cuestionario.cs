using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; //necesario para declarar los arreglos

namespace Entidades
{
    public class Cuestionario
    {
        private string clave;
        private int nroAccesos;
        private int maxAccesos;
        private Candidato candidatoAsociado;
        private PuestoEvaluado puestoEvaluado;
        private Bloque ultimoBloque;
        private Estado estado;

        public PuestoEvaluado PuestoEvaluado
        {
            get { return puestoEvaluado; }
            set { puestoEvaluado = value; }

        }

        public Bloque UltimoBloque
        {
            get { return ultimoBloque; }
            set { ultimoBloque = value; }

        }

        public Estado Estado
        {
            get { return estado; }
            set { estado = value; }

        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }

        }

        public int NroAccesos
        {
            get { return nroAccesos; }
            set { nroAccesos = value; }

        }

        public int MaxAccesos
        {
            get { return maxAccesos; }
            set { maxAccesos = value; }

        }

        public Candidato CandidatoAsociado
        {
            get { return candidatoAsociado; }
            set { candidatoAsociado = value; }

        }

        //Constructor
        public Cuestionario(Candidato cand, string claveCuest = null, PuestoEvaluado pEv = null, int maxAccess = 0, int accesos = 0, Bloque bloq = null)
        {
            clave = claveCuest;
            nroAccesos = accesos;
            maxAccesos = maxAccess;
            candidatoAsociado = cand;
            puestoEvaluado = pEv;
            ultimoBloque = bloq;
        }

        public string obtenerEstado()
        {
            return estado.Estado_;
        }
        
        public DateTime obtenerFechaEstado()
        {
            return estado.Fecha_hora;
        }

        public void aumentarAcceso()
        {
            this.nroAccesos += 1;
        }
    }
}
