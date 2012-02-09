using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Gestores
{
    public class GestorFactores
    {
        /*
         * La mision que justifica la existencia de los gestores es hacer de "interfaz" entre las ENTIDADES y el resto del sistema
         * Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
         */
        public Factor instanciarFactor(string codigo, string nombre, Competencia competenciaAsociada, string descripcion = null, int nrOrden = 0)
        {
            Factor nuevoFactor = new Factor(codigo, nombre, competenciaAsociada, descripcion, nrOrden);
            return nuevoFactor;
        }
    }
}
