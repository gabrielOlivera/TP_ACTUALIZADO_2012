using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Gestores
{
    public class GestorPreguntas
    {
        /*
         * La mision que justifica la existencia de los gestores es hacer de "interfaz" entre las ENTIDADES y el resto del sistema
         * Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
         */
        public Pregunta instanciarPregunta(string pregunta_, string nombre, Factor factorAsociado, OpciondeRespuesta opcionRes_Asociada = null, string descripcion = null)
        {
            Pregunta nuevoPregunta = new Pregunta(pregunta_, nombre, factorAsociado, opcionRes_Asociada, descripcion);
            return nuevoPregunta;
        }
    }
}
