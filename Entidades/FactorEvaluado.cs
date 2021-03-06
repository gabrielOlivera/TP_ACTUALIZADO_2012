﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Entidades
{
    public class FactorEvaluado
    {
        private string codigo;
        private string nombre;
        private CompetenciaEvaluada competenciaAsociadaEv;
        private string descripcion;
        private int nro_orden;
        private List<PreguntaEvaluada> listaPreguntasEv;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }

        }

        public int Nro_orden
        {
            get { return nro_orden; }
            set { nro_orden = value; }

        }

        public List<PreguntaEvaluada> ListaPreguntasEv
        {
            get { return listaPreguntasEv; }
            set { listaPreguntasEv = value; }

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public CompetenciaEvaluada CompetenciaAsociadaEv
        {
            get { return competenciaAsociadaEv; }
            set { competenciaAsociadaEv = value; }

        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }

        //Competencia -> Factor -> Pregunta
        public FactorEvaluado(string cod, string nomFactor, CompetenciaEvaluada competenciaAsociada, int nOrden, string des = null)
        {
            this.Codigo = cod;
            this.Nombre = nomFactor;
            this.CompetenciaAsociadaEv = competenciaAsociada;
            this.Nro_orden = nOrden; 
            this.Descripcion = des;
            this.listaPreguntasEv = new List<PreguntaEvaluada>();
        }

        public void addPregunta(PreguntaEvaluada preg) { listaPreguntasEv.Add(preg); }

    }
}

