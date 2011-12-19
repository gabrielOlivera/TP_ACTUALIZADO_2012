using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;
using System.Windows.Forms;

namespace Gestores
{
    public class GestorCandidatos
    {
        //Declaracion de una instancia de gestores para poder hacerles consultas
        Entidades.AdministradorBD admBD = new AdministradorBD();
        GestorCuestionario gestorCuestionario = new GestorCuestionario();

        public List<Candidato> listarCandidatos(string apellido, string nombre, int nroEmpleado = 0, int nroCandidato = 0)
        {
            ArrayList retornoBD = admBD.recuperarCandidatos(null, null, nombre, apellido, nroEmpleado, nroCandidato);
            List<Candidato> listaCandidatos = new List<Candidato>();

            for (int i = 0; i < retornoBD.Count; i++)
            {
                Candidato cand = (Candidato)retornoBD[i];
                listaCandidatos.Add(cand);
            }

            return listaCandidatos;
        }
        
        public Candidato retornarCandidato(string TipoDoc, string NroDoc)
        {
            ArrayList retornoBD = admBD.recuperarCandidato(TipoDoc, NroDoc);
            Candidato cand = (Candidato)retornoBD[0];

            return cand;
        }

        public bool validarCandidato(string TipoDoc, string NroDoc, string clave)
        {
            bool esValido = false;
            ArrayList retornoBD = admBD.recuperarCandidato(TipoDoc, NroDoc);

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
