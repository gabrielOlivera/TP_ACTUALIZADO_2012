using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;

namespace Entidades
{
    //el codigo del administrador no esta bien implementado. Ver Implementacion de BD
    public class AdministradorBD
    {
        private MySqlConnection ObjConexion = new MySqlConnection();
        private String connectionString;

        private bool iniciarConexion()
        {
            try
            {
                connectionString = "Server=127.0.0.1; Database=tp base de datos; Uid=root; Pwd=root;";
                ObjConexion.ConnectionString = connectionString;

                ObjConexion.Open();

                return true;

            }

            catch
            {
                return false;

            }
        }

        private void terminarConexion()
        {
            if (ObjConexion.State == ConnectionState.Open)
                ObjConexion.Close();
        }
        //genera un comando (con la consulta que se pasa de parametro) para realizar una transaccion
        private MySql.Data.MySqlClient.MySqlCommand crearComando(string consultaSql)
        {
            MySql.Data.MySqlClient.MySqlCommand comando = new MySqlCommand();

            comando.Connection = ObjConexion;
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 0;
            comando.CommandText = consultaSql;

            return comando;
        }
        
        /*
        * ===================================================
        * FUNCION ENCARGADA DE RECUPERAR LOS PUESTOS
        * ==================================================
        */
        public ArrayList recuperarPuestos(string codigo = null, string nombreDePuesto = null, string empresa = null)
        {
            bool conexionExitosa;
       
            string consultaSql = "SELECT * FROM puesto WHERE `codigo` = '" +codigo+ "' AND `nombreDePuesto` = '"
                +nombreDePuesto+ "' AND `empresa` = '" +empresa+ "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            ArrayList listaDePuestos = new ArrayList();

            while (reader.Read())
            {
                string cod =reader["codigo"].ToString();
                string nomPuesto = reader["nombreDePuesto"].ToString();
                string emp = reader["empresa"].ToString();

                Puesto objPuesto = new Puesto(cod, nomPuesto, emp);
                listaDePuestos.Add(objPuesto);
            }
            terminarConexion();
            return listaDePuestos;
        }

        //recupera un candidato puntual 
        public ArrayList recuperarCandidato(string TipoDoc, string NroDoc)
        {
            bool conexionExitosa;
            ArrayList listaCandidatos = new ArrayList();

            string consultaSql = "SELECT * FROM candidato WHERE  `nro documento` = '" + NroDoc + "' AND `tipo documento` = '"
                + TipoDoc + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaCandidatos.Add("Fallo la conexion con la base de datos");
                return listaCandidatos;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                listaCandidatos.Add("No se encontro un candidato solicitado ");
                return listaCandidatos;
            }
            while (reader.Read())
            {
                string nom = reader["nombre"].ToString();
                string ape = reader["apellido"].ToString();
                string tipoDoc = reader["tipo documento"].ToString();
                string nroDoc = reader["nro documento"].ToString();

                int nroCandidato;
                if (reader["nroCandidato"].ToString() == "")
                    nroCandidato = 0;
                else
                    nroCandidato = Int32.Parse(reader["nroCandidato"].ToString());

                int nroEmpleado;
                if (reader["nroEmpleado"].ToString() == "")
                    nroEmpleado = 0;
                else
                    nroEmpleado = Int32.Parse(reader["nroEmpleado"].ToString());

                Candidato objCandidato = new Candidato(nom, ape, tipoDoc, nroDoc, nroCandidato, nroEmpleado);
                listaCandidatos.Add(objCandidato);
            }

            terminarConexion();

            //-------------------------------------------

            return listaCandidatos;
        }

        //Recupera una lista de candidatos con ningún, uno o mas parametros
        public ArrayList recuperarCandidatos(string TipoDoc = null, string NroDoc = null, string nombre = null, string apellido = null, int nroEmp = 0, int nroCand = 0)
        {
            bool conexionExitosa;
            ArrayList listaCandidatos = new ArrayList();
            List<string> listaConsultas = new List<string>();
            string consultaSql;
            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return null;

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            //si todo es por defecto devolver TODOs los candidatos
            if (TipoDoc == null && NroDoc == null && nombre == null && apellido == null && nroEmp == 0 && nroCand == 0)
            {
                consultaSql = "SELECT * FROM candidato";

                comando.CommandText = consultaSql;

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string nom = reader["nombre"].ToString();
                    string ape = reader["apellido"].ToString();
                    string tipoDoc = reader["tipo documento"].ToString();
                    string nroDoc = reader["nro documento"].ToString();

                    int nroCandidato;
                    if (reader["nroCandidato"].ToString() == "")
                        nroCandidato = 0;
                    else
                        nroCandidato = Int32.Parse(reader["nroCandidato"].ToString());

                    int nroEmpleado;
                    if (reader["nroEmpleado"].ToString() == "")
                        nroEmpleado = 0;
                    else
                        nroEmpleado = Int32.Parse(reader["nroEmpleado"].ToString());

                    Candidato objCandidato = new Candidato(nom, ape, tipoDoc, nroDoc, nroCandidato, nroEmpleado);
                    listaCandidatos.Add(objCandidato);
                }

            }//fin de if(TODO ES NULL)

            else
            {
                if (TipoDoc != null)
                    listaConsultas.Add("`tipo documento` = '" + TipoDoc + "' ");
                if (NroDoc != null)
                    listaConsultas.Add("`nro documento` = '" + NroDoc + "' ");
                if (nombre != null)
                    listaConsultas.Add("`nombre` = '" + nombre + "' ");
                if (apellido != null)
                    listaConsultas.Add("`apellido` = '" + apellido + "' ");
                if (nroEmp != 0)
                    listaConsultas.Add("`nroEmpleado` = '" + nroEmp + "' ");
                if (nroCand != 0)
                    listaConsultas.Add("`nroCandidato` = '" + nroCand + "' ");

                consultaSql = "SELECT * FROM `candidato` WHERE ";

                for (int i = 0; i != (listaConsultas.Count - 1); i++)
                {
                    consultaSql += listaConsultas[i] + "AND ";
                }

                consultaSql += listaConsultas[(listaConsultas.Count - 1)] + ";";

                comando.CommandText = consultaSql;

                MySqlDataReader reader = comando.ExecuteReader();

                if (!reader.HasRows)
                { //si el reader esta vacio, es qe no encontro a ese candidato
                    listaCandidatos.Add("No se encontro un candidato solicitado ");
                    return listaCandidatos;
                }

                while (reader.Read())
                {
                    string nom = reader["nombre"].ToString();
                    string ape = reader["apellido"].ToString();
                    string tipoDoc = reader["tipo documento"].ToString();
                    string nroDoc = reader["nro documento"].ToString();

                    int nroCandidato;
                    if (reader["nroCandidato"].ToString() == "")
                        nroCandidato = 0;
                    else
                        nroCandidato = Int32.Parse(reader["nroCandidato"].ToString());

                    int nroEmpleado;
                    if (reader["nroEmpleado"].ToString() == "")
                        nroEmpleado = 0;
                    else
                        nroEmpleado = Int32.Parse(reader["nroEmpleado"].ToString());

                    Candidato objCandidato = new Candidato(nom, ape, tipoDoc, nroDoc, nroCandidato, nroEmpleado);
                    listaCandidatos.Add(objCandidato);
                }
            }

            terminarConexion();
            return listaCandidatos;
        }

        public ArrayList recuperarCuestionarioActivo(Candidato candidato)
        {
            bool conexionExitosa;
            ArrayList listaCuestionariosAsociados = new ArrayList();

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaCuestionariosAsociados.Add("Fallo la conexion con la base de datos");
                return listaCuestionariosAsociados;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            //La siguiente consulta deberia arrojarme los datos de los cuestionarios que posee el candidato
            string consultaSql = "SELECT DISTINCT `clave`, `Puesto Evaluado_idPuesto Evaluado` ,`nroaccesos` ";
            consultaSql += "FROM `cuestionario` cuest ";
            consultaSql += "JOIN `candidato` cand on (cand.`nro documento` = '"+ candidato.NroDoc +"' AND cand.idCandidato = cuest.Candidato_idCandidato) ";
            consultaSql += "JOIN `cuestionario_estado` c_est on (cuest.idCuestionario = c_est.Cuestionario_idCuestionario);";
            
            //"SELECT * FROM `candidato`,`cuestionario`  WHERE  `candidato`.idCandidato = `cuestionario`.Candidato_idCandidato AND `nro documento` = '" + candidato.NroDoc + "';";

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                listaCuestionariosAsociados.Add("No se encontro ningun cuestionario asociado");
                return listaCuestionariosAsociados;
            }

            List<Cuestionario> preSeleccionCuestionarios = new List<Cuestionario>();
            List<int> listaIdPuestos = new List<int>();
            while (reader.Read())
            {
                string clave = reader["clave"].ToString();
                int accesos = Int32.Parse(reader["nroAccesos"].ToString());
                int idPuestoEv = Int32.Parse(reader["Puesto Evaluado_idPuesto Evaluado"].ToString());

                Cuestionario cuesAsociado = new Cuestionario(candidato, clave, null, accesos);
                preSeleccionCuestionarios.Add(cuesAsociado);
                listaIdPuestos.Add(idPuestoEv);
            }
            terminarConexion();

            ArrayList listaPuestosEv = new ArrayList();
            for (int i = 0; i < listaIdPuestos.Count; i++)
            {
                listaPuestosEv = this.recuperarPuestoEvaluado(listaIdPuestos[i]);

                if ((listaPuestosEv[0] is string) == false)
                {
                    PuestoEvaluado puestoEv = (PuestoEvaluado)listaPuestosEv[0];

                    ArrayList listEstado = this.recuperarUltimoEstado(preSeleccionCuestionarios[i]);
                    Estado estadoCuest = (Estado)listEstado[0];

                    if (estadoCuest.Estado_ == "ACTIVO" || estadoCuest.Estado_ == "EN PROCESO")
                    {
                        preSeleccionCuestionarios[i].Estado = estadoCuest;
                        listaCuestionariosAsociados.Add(preSeleccionCuestionarios[i]);
                    }

                }
                else
                    listaCuestionariosAsociados.Add(listaPuestosEv[0]);
            }

            return listaCuestionariosAsociados;
        }

        public ArrayList recuperarUltimoEstado(Cuestionario cuestAsociado)
        {
            bool conexionExitosa;
            ArrayList listaEstado = new ArrayList();

            string consultaSql = "SELECT `Estado_idEstado`,`fecha` FROM `cuestionario` , `cuestionario_estado` WHERE `clave` = '"+ cuestAsociado.Clave +"' AND `idCuestionario` = `Cuestionario_idCuestionario`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaEstado.Add("Fallo la conexion con la base de datos");
                return listaEstado;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                listaEstado.Add("No se encontro el estado para el cuestionario");
                return listaEstado;
            }

            List<Caracteristica> lista_fechaYid_Estado = new List<Caracteristica>();
            
            while (reader.Read())
            {
                DateTime fecha = DateTime.Parse(reader["fecha"].ToString());
                int idEstado = Int32.Parse(reader["Estado_idEstado"].ToString());

                Caracteristica elementoLista;
                elementoLista.dato1 = fecha;
                elementoLista.dato2 = idEstado;

                lista_fechaYid_Estado.Add(elementoLista);
                
            }

            terminarConexion();

            DateTime ultimaFecha = DateTime.Parse("1900-01-01");//Seteado en esa fecha para hacer las comparaciones desde un punto fijo pero no posible
            int indice = 0;
            for (int i = 0; i < lista_fechaYid_Estado.Count; i++)
            {
                DateTime fechaLista = (DateTime)lista_fechaYid_Estado[i].dato1;
                if (DateTime.Compare(ultimaFecha, fechaLista) == -1)
                {
                    ultimaFecha = fechaLista;
                    indice = i;
                }
            }

            string estado = this.recuperarEstado((int)lista_fechaYid_Estado[indice].dato2);

            Estado objEstado = new Estado(cuestAsociado, estado, ultimaFecha);

            listaEstado.Add(objEstado);

            return listaEstado;
        }

        private string recuperarEstado(int id_Estado)
        {
            bool conexionExitosa;

            string consultaSql = "SELECT `estado` FROM `estado` WHERE `idEstado` = '" + id_Estado + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return "Fallo la conexion con la base de datos";

            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                return "No se encontro un candidato solicitado ";
            }

            string nombreEstado = null;

            while (reader.Read())
                nombreEstado = reader["estado"].ToString();

            terminarConexion();

            return nombreEstado;
        }

        public ArrayList recuperarPuestoEvaluado(int idPuestoEv)
        {
            bool conexionExitosa;
            ArrayList listaPuestos = new ArrayList();

            string consultaSql = "SELECT * FROM `puesto evaluado` WHERE `idPuesto Evaluado` = " + idPuestoEv + " ;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaPuestos.Add("Fallo la conexion con la base de datos");
                terminarConexion();
                return listaPuestos;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                listaPuestos.Add("No se encontro un candidato solicitado ");
                terminarConexion();
                return listaPuestos;
            }
            while (reader.Read())
            {
                if (reader["eliminado"].ToString() == "")
                {
                    string codigo = reader["codigo"].ToString();
                    string nombrePuestoEv = reader["nombre"].ToString();
                    string empresa = reader["empresa"].ToString();

                    PuestoEvaluado objPuesto = new PuestoEvaluado(codigo, nombrePuestoEv, empresa);
                    listaPuestos.Add(objPuesto);
                }
                else
                {
                    listaPuestos.Add("El puesto se a eliminado");
                    terminarConexion();
                    return listaPuestos;
                }
            }

            terminarConexion();
            return listaPuestos;
        }

        public ArrayList recuperarCompetencias()
        {
            bool conexionExitosa;

            string consultaSql = "SELECT * FROM competencia;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return null;


            MySql.Data.MySqlClient.MySqlCommand comando;
            
            comando = ObjConexion.CreateCommand();
            
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            
            ArrayList listaDeCompetencias = new ArrayList();

            while (reader.Read())
            {
                
                string cod = reader["codigo"].ToString();
                string nomComp = reader["nombre"].ToString();
                string descrip = reader["descripcion"].ToString();

                Competencia elemento = new Competencia(cod, nomComp, descrip);
                listaDeCompetencias.Add(elemento);    

            }
            
            return listaDeCompetencias;
        }

        public List<Caracteristica> recuperarCaracteristicasPuesto(PuestoEvaluado puestoEvAsociado)
        {
            bool conexionExitosa;

            List<Caracteristica> listaCaracteristicas = new List<Caracteristica>();
            Caracteristica elementoLista = new Caracteristica();
            //La consulta selecciona las competencias asociadas al puesto pasado como parametro con su correspondiente ponderacion
            string consultaSql = "SELECT `Competencia Evaluada_idCompetencia Evaluada`, `ponderacion` ";
            consultaSql += "FROM `puesto evaluado_competencia evaluada` ponderaciones ";
            consultaSql += "JOIN `tp base de datos`.`puesto evaluado` p on (p.`codigo` = '" + puestoEvAsociado.Codigo + "') ";
            consultaSql += "WHERE p.`idPuesto Evaluado` = ponderaciones.`Puesto Evaluado_idPuesto Evaluado`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                elementoLista.dato1 = "No se realizo la conexion con la base de datos";
                listaCaracteristicas.Add(elementoLista);
                terminarConexion();
                return listaCaracteristicas;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                elementoLista.dato1 = "El puesto no posee competencias para ser evaluado";
                listaCaracteristicas.Add(elementoLista);
                terminarConexion();
                return listaCaracteristicas;
            }

            List<Caracteristica> listaRetorno = new List<Caracteristica>();
            while (reader.Read())
            {
                int idCompetenciaEv = Int32.Parse(reader["Competencia Evaluada_idCompetencia Evaluada"].ToString());
                int ponderacion = Int32.Parse(reader["ponderacion"].ToString());

                elementoLista.dato1 = idCompetenciaEv;
                elementoLista.dato2 = ponderacion;
                listaRetorno.Add(elementoLista);
            }
            terminarConexion();

            //ArrayList listaCompetenciasAsociadas = new ArrayList();
            for (int i = 0; i < listaRetorno.Count; i++)
            {
                ArrayList competenciaAs = recuperarCompetenciasEvaluadas((int)listaRetorno[i].dato1);
                if ((competenciaAs[0] is string) == false)
                {
                    Ponderacion pondeAs = new Ponderacion((int)listaRetorno[i].dato2);
                    elementoLista.dato1 = competenciaAs[0];
                    elementoLista.dato2 = pondeAs;
                    listaCaracteristicas.Add(elementoLista);
                }
            }

            return listaCaracteristicas;
        }

        public ArrayList recuperarCompetenciasEvaluadas(int idCompetenciaEv)
        {
            bool conexionExitosa;
            ArrayList listaDeCompetencias = new ArrayList();

            string consultaSql = "SELECT * FROM `competencia evaluada` WHERE `competencia evaluada`.`idCompetencia Evaluada` ='" + idCompetenciaEv + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaDeCompetencias.Add("No se realizo la conexion con la base de datos");
                terminarConexion();
                return listaDeCompetencias;
            }


            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                listaDeCompetencias.Add("El puesto no posee competencias para ser evaluado");
                terminarConexion();
                return listaDeCompetencias;
            }

            while (reader.Read())
            {
                string cod = reader["codigo"].ToString();
                string nomComp = reader["nombre"].ToString();
                string descrip = reader["descripcion"].ToString();

                CompetenciaEvaluada competenciaEv = new CompetenciaEvaluada(cod, nomComp, descrip);
                listaDeCompetencias.Add(competenciaEv);
            }
            terminarConexion();
            
            //Agregamos la lista de Factores para cada una de las competencias encontradas
            for (int i = 0; i < listaDeCompetencias.Count ; i++)
            {
                ArrayList factoresList = recuperarFactoresEvaluados((CompetenciaEvaluada)listaDeCompetencias[i]);

                for (int j = 0; j < factoresList.Count; j++)
                {
                    CompetenciaEvaluada compT = (CompetenciaEvaluada)listaDeCompetencias[j];
                    compT.addFactor((FactorEvaluado)factoresList[j]);
                }
            }

            return listaDeCompetencias;
        }

        public ArrayList recuperarFactoresEvaluados(CompetenciaEvaluada competenciaAsociada)
        {
            bool conexionExitosa;
            ArrayList listaDeFactores = new ArrayList();

            string consultaSql = "SELECT `factor evaluado`.nombre ,`factor evaluado`.codigo ,nroOrden " +
            "FROM `factor evaluado` " +
            "JOIN `competencia evaluada` comEv on (comEv.`codigo` = '"+ competenciaAsociada.Codigo +"') " +
            "WHERE `factor evaluado`.`Competencia Evaluada_idCompetencia Evaluada` = comEv.`idCompetencia Evaluada`;";
            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaDeFactores.Add("No se realizo la conexion con la base de datos");
                terminarConexion();
                return listaDeFactores;
            }


            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                listaDeFactores.Add("El puesto no posee competencias para ser evaluado");
                terminarConexion();
                return listaDeFactores;
            }

            while (reader.Read())
            {
                string cod = reader["`factor evaluado`.codigo"].ToString();
                string nomFactor = reader["`factor evaluado`.nombre"].ToString();
                int nrOrden = Int32.Parse(reader["nroOrden"].ToString());

                FactorEvaluado factorEv = new FactorEvaluado(cod, nomFactor, competenciaAsociada, nrOrden); 
                listaDeFactores.Add(factorEv);
            }
            terminarConexion();

            //Agregamos la lista de Factores para cada una de las competencias encontradas
            for (int i = 0; i < listaDeFactores.Count; i++)
            {
                ArrayList factoresList = recuperarPreguntasEvaluados((FactorEvaluado)listaDeFactores[i]);

                for (int j = 0; j < factoresList.Count; j++)
                {
                    FactorEvaluado factoR = (FactorEvaluado)listaDeFactores[j];
                    factoR.addPregunta((PreguntaEvaluada)factoresList[j]);
                }
            }
            
            return listaDeFactores;
        }

        public ArrayList recuperarPreguntasEvaluados(FactorEvaluado factorAsociado)
        {
            bool conexionExitosa;
            ArrayList listaDePreguntas = new ArrayList();

            string consultaSql = "SELECT `pregunta evaluada`.nombre ,`pregunta evaluada`.codigo, `pregunta evaluada`.pregunta, `pregunta evaluada`.`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada` "
            + "FROM `pregunta evaluada` "
            + "JOIN `factor evaluado` fac on (fac.`codigo` = '"+ factorAsociado.Codigo +"') "
            + "WHERE `pregunta evaluada`.`Factor Evaluado_idFactor Evaluado` = fac.`idFactor Evaluado`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaDePreguntas.Add("No se realizo la conexion con la base de datos");
                terminarConexion();
                return listaDePreguntas;
            }


            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                listaDePreguntas.Add("El puesto no posee competencias para ser evaluado");
                terminarConexion();
                return listaDePreguntas;
            }

            List<int> listaIdOpRespuesta = new List<int>();
            while (reader.Read())
            {
                string cod = reader["`pregunta evaluada`.codigo"].ToString();
                string nomPreg = reader["`pregunta evaluada`.nombre"].ToString();
                string preg = reader["`pregunta evaluada`.pregunta"].ToString();
                int idOpRespuesta = Int32.Parse(reader["`pregunta evaluada`.`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada`"].ToString());

                PreguntaEvaluada preguntaEv = new PreguntaEvaluada(preg, nomPreg, factorAsociado);
                listaDePreguntas.Add(preguntaEv);
                listaIdOpRespuesta.Add(idOpRespuesta);
            }
            terminarConexion();

            //Agregamos la listas de Opciones de respuesta y las opciones para cada una de las preguntas encontradas
            for (int i = 0; i < listaDePreguntas.Count; i++)
            {
                ArrayList opcionesRespuesta = recuperarOpcionRespuestaEvaluada(listaIdOpRespuesta[i]);
                List<OpcionesEvaluadas> opciones = recuperarOpcionesEvaluadas((PreguntaEvaluada)listaDePreguntas[i]);
                for (int j = 0; j < opcionesRespuesta.Count; j++)
                {
                    OpciondeRespuestaEvaluada opcRespuestaEv = (OpciondeRespuestaEvaluada)opcionesRespuesta[j];
                    opcRespuestaEv.ListaOpcionesEv = opciones; //Realizo la asignacion de la lista de opciones evaluadas en las opciones de respuesta

                    //Realizo la asignacion de las opciones de respuestas y las opciones corespondientes para la pregunta
                    PreguntaEvaluada preguntaEv = (PreguntaEvaluada)listaDePreguntas[j];
                    preguntaEv.Op_respuestaEv = opcRespuestaEv;
                    preguntaEv.ListaOpcionesEv = opciones;
                }
            }

            return listaDePreguntas;
        }

        public List<OpcionesEvaluadas> recuperarOpcionesEvaluadas(PreguntaEvaluada pregAsociada) 
        {
            bool conexionExitosa;
            List<OpcionesEvaluadas> listaDeOpciones = new List<OpcionesEvaluadas>();

            string consultaSql = "SELECT DISTINCT opc.nombre, opR_opc.ordenDeVisualizacion, pr_opc.ponderacion" +
            "FROM `opcion evaluada` opc " +
            "JOIN `opcion de respuesta evaluada_opcion evaluada` opR_opc on (opR_opc.`Opcion Evaluada_idOpcion` = opc.`idOpcion`) " +
            "JOIN `pregunta evaluada` pr on (pr.`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada` = opR_opc.`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada`) " +
            "JOIN `pregunta evaluada_opcion evaluada` pr_opc on (pr_opc.`Pregunta Evaluada_idPregunta Evaluada` = pr.`idPregunta Evaluada`) " +
            "WHERE pr.codigo = '" + pregAsociada.Codigo + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaDeOpciones.Add(null);
                terminarConexion();
                return listaDeOpciones;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                listaDeOpciones.Add(null);
                terminarConexion();
                return listaDeOpciones;
            }

            while (reader.Read())
            {
                //opc.nombre, opR_opc.ordenDeVisualizacion, pr.`idPregunta Evaluada`
                string nomOpcion = reader["opc.nombre"].ToString();
                int ponderacion = Int32.Parse(reader["pr_opc.ponderacion"].ToString());
                int idOpcion = Int32.Parse(reader["opR_opc.ordenDeVisualizacion"].ToString());

                OpcionesEvaluadas preguntaEv = new OpcionesEvaluadas(nomOpcion, ponderacion);
                listaDeOpciones.Add(preguntaEv);
            }
            terminarConexion();

            return listaDeOpciones;
        }

        public ArrayList recuperarOpcionRespuestaEvaluada(int idOpcionDeRespuesta)
        {
            bool conexionExitosa;
            ArrayList listaDeOpRespuesta = new ArrayList();

            string consultaSql = "SELECT * FROM `opcion de respuesta evaluada` opcRes WHERE opcRes.`idOpcion de Respuesta Evaluada` = '" + idOpcionDeRespuesta + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                listaDeOpRespuesta.Add("No se pudo realizar la conexion con la base de datos");
                terminarConexion();
                return listaDeOpRespuesta;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a esa opcion de respuesta evaluada
                listaDeOpRespuesta.Add("No se encontro la opcion de respuesta solicitada");
                terminarConexion();
                return listaDeOpRespuesta;
            }

            while (reader.Read())
            {
                string nomOpcionResp = reader["nombre"].ToString();
                string codigo = reader["codigo"].ToString();
                
                OpciondeRespuestaEvaluada OpcionResp = new OpciondeRespuestaEvaluada(nomOpcionResp, codigo);
                listaDeOpRespuesta.Add(OpcionResp);
            }
            terminarConexion();

            return listaDeOpRespuesta; 
        }

        public bool reconstruirRelaciones(Cuestionario cuestionarioAsociado)
        {
            bool seRealizoConExito = false;
            PuestoEvaluado puestoEvAsociado = cuestionarioAsociado.PuestoEvaluado;

            if (puestoEvAsociado.Caracteristicas == null)
            {
                List<Caracteristica> caracteristicasPuesto = recuperarCaracteristicasPuesto(puestoEvAsociado);
                puestoEvAsociado.Caracteristicas = caracteristicasPuesto;
                seRealizoConExito = true;
            }

            return seRealizoConExito;

        }

        //Metodos de resguardo de clases
        public void guardarPuesto(Puesto puesto) { }
        public void guardarRespuesta(Respuestas respuesta) { }
        public void guardarEstado(Estado estado) { }
        public void guardarBloque(Bloque nuevoBloque) { }

        //Metodos de consulta de existencia de clases
        public bool existePuesto(string codigo = null, string nombre = null)
        {
            bool seConecto;

            seConecto = iniciarConexion();

            //aca va la magia del metodo

            terminarConexion();


            return seConecto; //retorno de prueba

            
        }

        public int preguntasPorBloque()
        {
            bool conexionExitosa;
            int pregPorBloque = -2;

            string consultaSql = "SELECT preguntasPorBloque FROM `instrucciones de sistema`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return -1; //Error de conexion

            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)//si el reader esta vacio, no se encontro el parametro buscado
                return -2;

            while (reader.Read())
            {
                pregPorBloque = Int32.Parse(reader["preguntasPorBloque"].ToString());
            }

            terminarConexion();

            return pregPorBloque;
        }

        public ArrayList retornarProximoBloque(Cuestionario cuest, int nroProxBloque)
        {
            ArrayList retornoBD = new ArrayList();
            return retornoBD;
        }

        /*retorna el tiempo en dias (entero) para realizar la evaluaciones,
         se tomara este valor de la tabla 'Instrucciones de Sistema' de la BD*/
        public int darTiempoEvaluacion()
        {
            int tiempoEvaluacion = 15; //ejemplo hasta hacer la implementacion real
            return tiempoEvaluacion;
        }

        public int darAccesosMaximos()
        {
            bool conexionExitosa;
            int AccesosMaximos = -2;

            string consultaSql = "SELECT maximosAccesos FROM `instrucciones de sistema`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return -1; //Error de conexion
            
            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)//si el reader esta vacio, no se encontro el parametro buscado
                return -2;
            
            while (reader.Read())
            {
                AccesosMaximos = Int32.Parse(reader["maximosAccesos"].ToString());
            }

            terminarConexion();

            return AccesosMaximos;

        }

        /*retorna el tiempo en dias (entero) para completar el cuestionario desde que se inicia,
         se tomara este valor de la tabla 'Instrucciones de Sistema' de la BD*/
        public int darTiempoActivo()
        {
            bool conexionExitosa;
            int tiempoActivo = -2;

            string consultaSql = "SELECT tiempoEstadoActivo FROM `instrucciones de sistema`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return -1; //Error de conexion

            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)//si el reader esta vacio, no se encontro el parametro buscado
                return -2;

            while (reader.Read())
            {
                tiempoActivo = Int32.Parse(reader["tiempoEstadoActivo"].ToString());
            }

            terminarConexion();

            return tiempoActivo;
        }

        public string retornarInstruccionesDelcuestionario()
        {
            bool conexionExitosa;
            string instrucciones = null;

            string consultaSql = "SELECT instruccionesDelcuestionario FROM `instrucciones de sistema`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return "No se realizo la conexion con la base de datos"; //Error de conexion

            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)//si el reader esta vacio, no se encontro el parametro buscado
                return "No se encontraron las instrucciones del cuestionario";

            while (reader.Read())
            {
                instrucciones = reader["instruccionesDelcuestionario"].ToString();
            }

            terminarConexion();

            return instrucciones;

        }

        /*
        public List<Factor> recuperarFactores(string codigoDeCompetencia)
        {
            bool conexionExitosa;

            string consultaSql = "SELECT * FROM factor WHERE `Competencia_codigo` = '" + codigoDeCompetencia + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return null;


            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            List<Factor> listaDeFactores;

            while (reader.Read())
            {
                int codigo;
                string nombre;
                string descripcion;
                int nro_orden;
                private List<Pregunta> listaPreguntas;

            }

            return listaDeFactores;
        }*/


        /*
        public List<Pregunta> recuperarPreguntas()
        {

        }
        */
        /*
        public List<Opciones> recuperarOpciones()
        {
            bool conexionExitosa;

            string consultaSql1 = "SELECT * FROM opciones;";
            string consultaSql2 = "SELECT * FROM pregunta_opciones WHERE `ponderacion`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return null;


            MySql.Data.MySqlClient.MySqlCommand comando1;
            MySql.Data.MySqlClient.MySqlCommand comando2;

            comando1 = ObjConexion.CreateCommand();
            comando2 = ObjConexion.CreateCommand();

            comando1.CommandText = consultaSql1;
            comando2.CommandText = consultaSql2;

            List<Opciones> listaDeOpciones = new List<Opciones>();
            MySqlDataReader reader1 = comando1.ExecuteReader();
            ArrayList nombreDeOpciones = new ArrayList();
            while (reader1.Read())
            {
                string nom = reader1["nombre"].ToString();
                nombreDeOpciones.Add(nom);
            }

            MySqlDataReader reader2 = comando1.ExecuteReader();
            while (reader2.Read())
            {
                string pond = reader2["ponderacion"].ToString();*/

    }
}
