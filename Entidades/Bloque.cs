using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace Entidades
{
    //Un bloque pertenece a un cuestionario especifico.
    public class Bloque
    {
        private int nroBloque; //numero de identificacion del bloque [ej: 1]
        private bool esultimoBloque;
        private Cuestionario cuestAsociado;
        private List<PreguntaEvaluada> listaPreguntasEv; //preguntas que estan contenidas dentro del bloque
        
        public int NroBloque
        {
            get { return nroBloque; }
            set { nroBloque = value; }

        }

        public bool EsUltimoNloque
        {
            get { return esultimoBloque; }
            set { esultimoBloque = value; }

        }

        public Cuestionario CuestAsociado
        {
            get { return cuestAsociado; }
            set { cuestAsociado = value; }

        }

        public List<PreguntaEvaluada> ListaPreguntasEv
        {
            get { return listaPreguntasEv; }
            set { listaPreguntasEv = value; }

        }
        //constructor
        public Bloque(int nro_Bloq, Cuestionario cuest) 
        { 
            nroBloque = nro_Bloq; 
            cuestAsociado = cuest;
            esultimoBloque = false; //por defecto esta en falso
            listaPreguntasEv = new List<PreguntaEvaluada>(); 
        }
        
        public void addPreguntaEv(PreguntaEvaluada preguntaEv) { listaPreguntasEv.Add(preguntaEv); } //este es el metodo de contruccion de la lista de preguntas
        public void marcarUltimobloque()
        {
            esultimoBloque = true;
        }

        public bool esUltimoBloque() { return esultimoBloque; }

    }
    
}
