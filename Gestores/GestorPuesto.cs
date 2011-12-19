using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;

namespace Gestores
{
    public class GestorPuesto
    {
        //Declaracion de una instancia del administrador para poder hacerle consultas
        AdministradorBD admBD = new AdministradorBD(); 

        public List<Puesto> listarPuestos(string codigo = null, string nombreDePuesto = null, string empresa = null)
        {
            ArrayList retornoBD = admBD.recuperarPuestos(codigo, nombreDePuesto, empresa);
            List<Puesto> listaPuestos = new List<Puesto>();

            for (int i = 0; i <= retornoBD.Count ; i++)
            {
                Puesto nuevoPuesto = (Puesto)retornoBD[i];
                listaPuestos.Add(nuevoPuesto);
            }

            return listaPuestos;
        }

        public void altaPuesto(string codigo, string nombreDePuesto, string empresa, List<Caracteristica> caract, string descripcion = null)
        {
            Puesto nuevoPuesto = new Puesto(codigo, nombreDePuesto, empresa, descripcion);
            inicializarCaracteristicas(nuevoPuesto, caract);
            admBD.guardarPuesto(nuevoPuesto);
        }

        private void inicializarCaracteristicas(Puesto puesto, List<Caracteristica> listaCaract)
        { 
            for(int i = 0; i < listaCaract.LongCount(); i++)
            {
                Ponderacion pond = new Ponderacion((int)listaCaract[i].dato2);
                puesto.addListaCaracteristicas((Competencia)listaCaract[i].dato1, pond);
            }
        }

        public bool buscarPuesto(string codigo = null, string nombreDePuesto = null)
        {
            bool retornoBD = admBD.existePuesto(codigo, nombreDePuesto);
            return retornoBD;
        }
    }
}
