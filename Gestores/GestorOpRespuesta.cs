using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Gestores
{
    public class GestorOpRespuesta
    {
        /*
         * La mision que justifica la existencia de los gestores es hacer de "interfaz" entre las ENTIDADES y el resto del sistema
         * Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
         */
        public OpciondeRespuesta instanciarOpcionDeRespuesta(string nombre, string descripcion = null)
        {
            OpciondeRespuesta nuevaOpcionResp = new OpciondeRespuesta(nombre, descripcion);
            return nuevaOpcionResp;
        }

        public Opciones instanciarOpcion(string nombre, int valor, int ordenVisual)
        {
            Opciones nuevaOpcion = new Opciones(nombre, valor, ordenVisual);
            return nuevaOpcion;
        }
    }
}
