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
            List<Candidato> listaCandidatos = admBD.recuperarCandidatos(null, null, nombre, apellido, nroEmpleado, nroCandidato);
            
            //VALIDAR RETORNO

            return listaCandidatos;
        }
        
        public Candidato retornarCandidato(string TipoDoc, string NroDoc)
        {
            List<Candidato> listaCadidatos = admBD.recuperarCandidato(TipoDoc, NroDoc);
            
            //VALIDAR RETORNO

            Candidato cand = listaCadidatos[0];
            return cand;
        }

        public object validarCandidato(string TipoDoc, string NroDoc, string clave)
        {
            bool esValido = false;
            List<Candidato> retornoBD_candidato = admBD.recuperarCandidato(TipoDoc, NroDoc);

            if (retornoBD_candidato == null)
            {
                return esValido; //que aca es falso
            }

            else
            {
                Candidato nuevoCandidato = retornoBD_candidato[0];
                Cuestionario cuestAsociado = gestorCuestionario.cuestionarioAsociado(nuevoCandidato);

                if (cuestAsociado != null)
                {
                    bool accesoValido = gestorCuestionario.validarAcceso(cuestAsociado, clave);

                    if (accesoValido != false)
                    {
                        esValido = true;
                        return cuestAsociado;
                    }

                    else
                        MessageBox.Show("La clave ingresada no es valida para este candidato. \n\nIntente nuevamente");
                }
                else
                    MessageBox.Show(cuestAsociado.Clave);//Muestra la naturaleza del error
            }
            return esValido;
        }
    }
}
