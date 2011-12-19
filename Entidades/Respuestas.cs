using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Respuestas
    {
        private Cuestionario cuestionarioAsociado;
        private List<Caracteristica> preguntasMasOpciones;

        public Cuestionario CuestionarioAsociado
        {
            get { return cuestionarioAsociado; }
            set { cuestionarioAsociado = value; }

        }

        public List<Caracteristica> PreguntasMasOpciones
        {
            get { return preguntasMasOpciones; }
            set { preguntasMasOpciones = value; }

        }

        public Respuestas(Cuestionario cuestAsociado)
        {
            cuestionarioAsociado = cuestAsociado;
            preguntasMasOpciones = new List<Caracteristica>();
        }

        public void addRespueta(PreguntaEvaluada pregContestada, OpcionesEvaluadas opcionElegida)
        {
            Caracteristica elemento = new Caracteristica();
            elemento.dato1 = pregContestada;
            elemento.dato2 = opcionElegida;
            preguntasMasOpciones.Add(elemento);
        }
    }
}
