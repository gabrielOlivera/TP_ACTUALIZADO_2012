using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Entidades
{
    public class PuestoEvaluado
    {
        //Atributos de la clase Puesto
        private string codigo;
        private string nombre;
        private string empresa;
        private string descripcion;
        private List<Caracteristica> caracteristicas;
        private DateTime fecha_Comienzo;

        public DateTime Fecha_Comienzo
        {
            get { return fecha_Comienzo; }
            set { fecha_Comienzo = value; }

        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }

        }

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public List<Caracteristica> Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }

        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }

        /* Metodo Constructor */
        public PuestoEvaluado(string cod, string nomb, string emp, DateTime fecha, string desc = null, List<Caracteristica> caract = null)
        {
            this.Codigo = cod;
            this.Fecha_Comienzo = fecha;
            this.Nombre = nomb;
            this.Empresa = emp;
            this.Descripcion = desc;
            this.Caracteristicas = caract;
        }

        //Metodos de inicializacion y modificación 
        public void addListaCaracteristicas(CompetenciaEvaluada comp, Ponderacion pond)
        {
            Caracteristica elemento;
            elemento.dato1 = comp;
            elemento.dato2 = pond;
            caracteristicas.Add(elemento);
        }

        //Metodos de retorno
        public List<Caracteristica> getCaracteristicas() { return caracteristicas; }

    }
}
