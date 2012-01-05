using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;
using Gestores;

namespace Gestores
{
    public class GestorCompetencias
    {
        //Declaracion de una instancia del administrador para poder hacerle consultas
        AdministradorBD admBD  = new AdministradorBD();

        /*
         * La mision que justifica la existencia de los gestores es hacer de "interfaz" entre las ENTIDADES y el resto del sistema
         * Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
         */
        public Competencia instanciarCompetencia(string codigo, string nombre, string descripcion = null, List<Factor> factoresAsociados = null)
        {
            Competencia nuevaCompetencia = new Competencia(codigo, nombre, descripcion, factoresAsociados);
            return nuevaCompetencia;
        }

        public List<Competencia> listarCompetencias(string codigo = null, string nombre = null, string empresa = null)
        {
            List<Competencia> listaCompetencias = admBD.recuperarCompetencias();
            
            for (int i = 0; i < listaCompetencias.Count; i++)
            {
                Competencia nuevaCompetencia = listaCompetencias[i];
                if(nuevaCompetencia.Codigo == "ELIMINADA")
                    listaCompetencias.Remove(nuevaCompetencia);
            }

            return listaCompetencias;
        }
    }
}
