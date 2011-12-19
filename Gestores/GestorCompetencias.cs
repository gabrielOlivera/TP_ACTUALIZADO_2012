using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;

namespace Gestores
{
    public class GestorCompetencias
    {
        //Declaracion de una instancia del administrador para poder hacerle consultas
        AdministradorBD admBD  = new AdministradorBD(); 

        public List<Competencia> listarCompetencias(string codigo = null, string nombre = null, string empresa = null)
        {
            ArrayList retornoBD = admBD.recuperarCompetencias();
            List<Competencia> listaCompetencias = new List<Competencia>();

            for (int i = 0; i < retornoBD.Count; i++)
            {
                Competencia nuevaCompetencia = (Competencia)retornoBD[i]; 
                listaCompetencias.Add(nuevaCompetencia);
            }

            return listaCompetencias;
        }
    }
}
