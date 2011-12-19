using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Estado
    {
        private string estado_;
        private DateTime fecha_hora;
        private Cuestionario cuestionario;

        public string Estado_
        {
            get { return estado_; }
            set { estado_ = value; }

        }

        public DateTime Fecha_hora
        {
            get { return  fecha_hora; }
            set {  fecha_hora = value; }

        }

        public Cuestionario Cuestionario
        {
            get { return  cuestionario; }
            set {  cuestionario = value; }

        }

        //Contructor de clase 1: se lo llamara si se esta instanciando un obj para la clase que ya exista en la BD
        public Estado(Cuestionario cuest, string est, DateTime fecha) 
        {
            cuestionario = cuest;
            estado_ = est;
            fecha_hora = fecha;
        }

        //Constructor de clase 2: se llamara si se esta instanciando un obj por primera vez.
        public Estado(Cuestionario cuest, string est)
        {
            cuestionario = cuest;
            estado_ = est;
            fecha_hora = DateTime.Now;
        }


    }
}
