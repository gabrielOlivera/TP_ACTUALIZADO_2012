using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Entidades
{
    public struct Caracteristica //como es una estructura generica hay que tener cuidado al usarla
    { 
        public Object dato1; 
        public Object dato2;
    }

    public class Puesto
    {
        //Atributos de la clase Puesto
        private string codigo;
        private string nombre;
        private string empresa;
        private string descripcion;
        private List<Caracteristica> caracteristicas;

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
        public Puesto(string cod, string nomb, string emp, string desc = null)
        {
            codigo = cod; //el codigo es seteado unicamente al iniciar el Puesto.
            Nombre = nomb;
            Empresa = emp;
            Descripcion = desc;
            caracteristicas = new List<Caracteristica>();
        }

        //Constructor de clases ya existentes en BD
        public Puesto(string cod, string nomb, string emp, List<Caracteristica> caract, string desc = null)
        {
            Codigo = cod; //el codigo es seteado unicamente al iniciar el Puesto.
            Nombre  = nomb;
            Empresa = emp;
            Descripcion = desc;
            caracteristicas = caract;
        }


        
        public void addListaCaracteristicas(Competencia comp, Ponderacion pond)
        {
            Caracteristica elemento;
            elemento.dato1 = comp;
            elemento.dato2 = pond;
            caracteristicas.Add(elemento);
        }


    }

}
