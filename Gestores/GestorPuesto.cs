using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Gestores;
using Entidades;

namespace Gestores
{
    public class GestorPuesto
    {
        //Declaracion de una instancia del administrador para poder hacerle consultas
        AdministradorBD admBD = new AdministradorBD();

        /*
         * - La mision que justifica la existencia de los gestores es hacer de "interfaz" entre las ENTIDADES y el resto del sistema
         * - Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
        */
        public Puesto instanciarPuesto(string codigo, string nombre, string empresa, string descripcion = null)
        {
            Puesto nuevoPuesto = new Puesto(codigo, nombre, empresa, descripcion);
            return nuevoPuesto;
        }

        public List<Puesto> listarPuestos(string codigo = null, string nombreDePuesto = null, string empresa = null)
        {
            List<Puesto> listaPuestos = admBD.recuperarPuestos(codigo, nombreDePuesto, empresa);
            
            //VALIDAR RETORNO BD

            return listaPuestos;
        }

        public bool altaPuesto(string codigo, string nombreDePuesto, string empresa, List<Caracteristica> caract, string descripcion = null)
        {
            //COMPLETAR LOGICA DEL METODO

            Puesto nuevoPuesto = new Puesto(codigo, nombreDePuesto, empresa, descripcion);
            inicializarCaracteristicas(nuevoPuesto, caract);

            return admBD.guardarPuesto(nuevoPuesto);
        }

        public bool modificarPuesto(string codigo, string nombreDePuesto, string empresa, List<Caracteristica> caract, string descripcion = null)
        {
            Puesto nuevoPuesto = new Puesto(codigo, nombreDePuesto, empresa, descripcion);
            inicializarCaracteristicas(nuevoPuesto, caract);

            return admBD.modificarPuesto(nuevoPuesto);
        }

        private void inicializarCaracteristicas(Puesto puesto, List<Caracteristica> listaCaract)
        { 
            for(int i = 0; i < listaCaract.LongCount(); i++)
            {
                Ponderacion pond = new Ponderacion((int)listaCaract[i].dato2);
                puesto.addListaCaracteristicas((Competencia)listaCaract[i].dato1, pond);
            }
        }

        public Puesto buscarPuesto(string codigo = null, string nombreDePuesto = null)
        {
            Puesto retornoBD = admBD.existePuesto(codigo, nombreDePuesto);
            return retornoBD;
        }

        public Puesto recuperarUnPuesto(string codigo)
        {
            return admBD.recuperarPuesto(codigo);
        }
        public List<Caracteristica> recuperarCaracteristicas(string codigo)
        {
            return admBD.recuperarCaracteristicasPuesto(codigo);
        }

        public bool tieneElPuestoEvaluacionesAsociadas(string codigo)
        {
            bool valor=admBD.tieneElPuestoEvaluacionesAsociadas(codigo);
            return valor;
        }
        public bool eliminarPuesto(string codigo)
        {
            bool retornoBD = admBD.eliminarPuesto(codigo);
            return retornoBD;
        }
    }
}
