using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;
using Gestores;
using System.Windows.Forms;

namespace Gestores
{
    public class GestorCandidatos
    {
        //Declaracion de una instancia de gestores para poder hacerles consultas
        AdministradorBD admBD = new AdministradorBD();
        GestorCuestionario gestorCuestionario = new GestorCuestionario();

        /*
         * La mision que justifica la existencia de los gestores es hacer de "interfaz" entre las ENTIDADES y el resto del sistema
         * Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
         */
        public Candidato instanciarCandidato(string nombre, string apellido, string tipo, string nroDocumento, int nroCandidato = 0, int nroEmpleado = 0)
        {
            Candidato nuevoCandidato = new Candidato(nombre, apellido, tipo, nroDocumento, nroCandidato, nroEmpleado);
            return nuevoCandidato;
        }

        /*
         * Listar candidatos tiene como objetivo encontrar a todos los candidatos que fueron buscados segun algun criterio de BUSQUEDA
         * Para eso le pedimos al Administrador de la base de datos que nos retorne los candidatos buscados 
         * Y retornara una lista de objetos CANDIDATOS
         */
        public List<Candidato> listarCandidatos(string apellido = null, string nombre = null, int nroEmpleado = 0, int nroCandidato = 0)
        {
            //Se pide al administrador Base de datos que retorne los candidatos y se asignan a un ArrayList
            //ArrayList retornoBD = admBD.recuperarCandidatos(null, null, nombre, apellido, nroEmpleado, nroCandidato);
            List<Candidato> listaCandidatos = new List<Candidato>();

            /*for (int i = 0; i < retornoBD.Count; i++)
            {
                Candidato cand = (Candidato)retornoBD[i];
                listaCandidatos.Add(cand);
            }
            */
            return listaCandidatos;
        }
        
        public Candidato retornarCandidato(string TipoDoc, string NroDoc)
        {
            ArrayList retornoBD = null;//admBD.recuperarCandidato(TipoDoc, NroDoc);
            Candidato cand = (Candidato)retornoBD[0];

            return cand;
        }

        public bool validarCandidato(string TipoDoc, string NroDoc, string clave)
        {
            bool esValido = false;
            ArrayList retornoBD = null;//admBD.recuperarCandidato(TipoDoc, NroDoc);

            if (retornoBD[0] is string)
            {
                MessageBox.Show(retornoBD[0].ToString());
                return esValido; //que aca es falso
            }

            Candidato nuevoCandidato = (Candidato)retornoBD[0];

            Cuestionario cuestAsociado = gestorCuestionario.cuestionarioAsociado(nuevoCandidato);
            if (cuestAsociado is Cuestionario)
            {
                bool accesoValido = gestorCuestionario.validarAcceso(cuestAsociado, clave);
                if (accesoValido != false)
                {
                    esValido = true;
                }
                else
                    MessageBox.Show("La clave ingresada no es valida para este candidato. \nIntente nuevamente");
            }
            else
                MessageBox.Show("El candidato no Poseé un cuestionario para ser evaluado");

            return esValido;
        }
    }
}
