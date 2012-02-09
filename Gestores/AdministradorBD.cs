using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using Entidades;


namespace Gestores
{
    public class AdministradorBD
    {
        /*
         * - El ADMINISTRADOR DE BASE DE DATOS para nosotros en una interfaz entre los que es el Sistema y la Base de Datos.
         * - La mayoria de los metodos van a retornar un lista de objetos (List<ClaseOjetoRetorno>);
         *      pero si bien, desde aqui, vamos a tener conocimiento de las clases ENTIDAD, 
         *      quienes van a estar acargo instanciar dichas clases 
         *      son los GESTORES con el metodo correspondiente para ello.
         */

        /*
         * ===================
         * VARIABLES GLOBALES
         * ===================
         * ObjConexion -> es un objeto el tipo MySqlConnection que se utilizara para las operaciones con BD
         * connectionString -> es un string donde se pondran las directivas de busqueda de la BD
         */
        private MySqlConnection ObjConexion = new MySqlConnection();
        private String connectionString;

        /*
         * El siguiente metodo se encarga de iniciar la conexion con la base de datos
         * Retorna un bolea que indica:
         *              - true = conexion realizada
         *              - false = conexion fallida
         */
        private bool iniciarConexion()
        {
            try
            {
                //connectionString establece la IP del servidor, la base de datos a la que se va a conectar 
                //y el usuario y password de la cuenta
                connectionString = "Server=127.0.0.1; Database=tp base de datos; Uid=root; Pwd=root;";
                //El ObjConexion.ConnectionString almacena la directiva anterior para luego en el OPEN hacer el enlace
                ObjConexion.ConnectionString = connectionString;

                ObjConexion.Open();
                //Si la llamada anterior es exitosa retornara "true"
                return true;

            }

            catch
            {
                //Si en la llamada ObjConexion.Open() sucede un error se retorna "false" 
                return false;

            }
        }

        /*
         * Este metodo simplemente finaliza cualquier conexion que este activa con el motor de la base de datos
         */
        private void terminarConexion()
        {
            //Primero se verifica que exista en el ObjConexion.State una conexion activa para cerrarla
            if (ObjConexion.State == ConnectionState.Open)
                ObjConexion.Close();
        }

        /*
         * Genera un comando (con la consulta que se pasa de parametro) para realizar una transaccion
         */
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
         * ====================================
         * METODOS DE RECUPERACION DE ENTIDADES
         * ====================================
         *      - Tiene la finalidad de recuperar los datos de la BASE DE DATOS segun algún criterio de busqueda
         *      - Retornaran una lista de objetos que se obtuvieron de dicha busqueda (si los hubiere)
         *      - De no encontrar un datos o de no poderse realizar la conexion se expondra error y se retornara 'NULL'
         */

        /*
         * - RecuperarPuestos tiene la misión de recuperar los datos de los puestos según un criterion de busqueda
         */
        /*
       * ===========================================================================
       * FUNCION QUE SE ENCARGA DE RECUPERAR LOS DATOS DE LOS PUESTOS QUE CONCUERDEN
       * CON LOS FILTROS DE BUSQUEDA Y NO SE ENCUENTREN ELIMINADOS
       * ===========================================================================
       */
        public List<Puesto> recuperarPuestos(string codigo = null, string nombreDePuesto = null, string empresa = null)
        {
            bool conexionExitosa;
            GestorPuesto gestorPuestos = new GestorPuesto();
            List<Puesto> listaDePuestos = new List<Puesto>(); //para el retorno de datos

            string consultaSql = "SELECT * " +
                                 "FROM puesto " +
                                 "WHERE `codigo` LIKE '%" + codigo + "%'" +
                                 " AND `nombre` LIKE '%" + nombreDePuesto + "%'" +
                                 " AND `empresa` LIKE '%" + empresa + "%';";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("No se pudo realizar la conexión con la Base de Datos");
                terminarConexion();
                return null;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos mas arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            //En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql
            comando.CommandText = consultaSql; 

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { 
                //si el reader esta vacio, es que no se encontraron datos para la consulta realizada
                MessageBox.Show("No se encontro ningún puesto");
                terminarConexion();
                return null;
            }
            
            //Si el reader contiene datos, se realiza la lectura de todos los ellos.
            while (reader.Read())
            {
                Puesto objPuesto;
                
                if (reader["eliminado"].ToString() == "")
                {
                    string cod = reader["codigo"].ToString();
                    string nomPuesto = reader["nombre"].ToString();
                    string emp = reader["empresa"].ToString();

                    //Llamamos al gestor de puestos para instanciar el puesto que se obtuvo de la base de datos
                    objPuesto = gestorPuestos.instanciarPuesto(cod, nomPuesto, emp);
                    //El retorno del metodo del gestor es introducido en la lista de puestos    
                    listaDePuestos.Add(objPuesto);
                }
                    
            }

            terminarConexion();
            return listaDePuestos;
        }

        /*
         * RecuperarPuesto tiene la misión de recuperar los datos de un puesto puntual
         */
        public Puesto recuperarPuesto(string codigo)
        {
            bool conexionExitosa;
            GestorPuesto gestorPuestos = new GestorPuesto();

            string consultaSql = "SELECT * " +
                                 "FROM puesto " +
                                 "WHERE `codigo` = '" + codigo + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return null;

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();
            Puesto objPuesto;

            if (reader.Read())
            {
                if ((reader["eliminado"].ToString()) == "")
                {
                string cod = reader["codigo"].ToString();
                string nomPuesto = reader["nombre"].ToString();
                string emp = reader["empresa"].ToString();
                string desc = reader["descripcion"].ToString();

                objPuesto = gestorPuestos.instanciarPuesto(cod, nomPuesto, emp, desc);
                }
                 else
                     objPuesto = gestorPuestos.instanciarPuesto("ELIMINADO", null, null);

               
            }
            else
                objPuesto = gestorPuestos.instanciarPuesto(null, null, null);
            terminarConexion();
            return objPuesto;
        }

        /*
         * - RecuperarCandidato tiene la misión de recuperar los datos de un candidato puntual
         */
        public List<Candidato> recuperarCandidato(string TipoDoc, string NroDoc)
        {
            bool conexionExitosa;
            GestorCandidatos gestorCandidatos = new GestorCandidatos();
            List<Candidato> listaCandidatos = new List<Candidato>();//para el retorno de datos
            
            string consultaSql = "SELECT * FROM candidato WHERE  `nro documento` = '" + NroDoc + "' AND `tipo documento` = '"
                + TipoDoc + "';";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos mas arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;//En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                //si el reader esta vacio, es que no se encontraron datos para la consulta realizada
                MessageBox.Show("El tipo y número de documento no corresponden a un candidato registrado");
                terminarConexion();
                return null;
            }

            //Si el reader contiene datos, se realiza la lectura de todos los ellos.
            while (reader.Read())
            {
                string nom = reader["nombre"].ToString();
                string ape = reader["apellido"].ToString();
                string tipoDoc = reader["tipo documento"].ToString();
                string nroDoc = reader["nro documento"].ToString();

                int nroCandidato;
                if (reader["nroCandidato"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                    nroCandidato = 0;
                else
                    nroCandidato = Int32.Parse(reader["nroCandidato"].ToString());//Se lo transforma a un numero entero

                int nroEmpleado;
                if (reader["nroEmpleado"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                    nroEmpleado = 0;
                else
                    nroEmpleado = Int32.Parse(reader["nroEmpleado"].ToString());//Se lo transforma a un numero entero

                //Llamamos al gestor de candidatos para instanciar el candidato que se obtuvo de la base de datos
                Candidato objCandidato = gestorCandidatos.instanciarCandidato(nom, ape, tipoDoc, nroDoc, nroCandidato, nroEmpleado);
                //El retorno del metodo del gestor es introducido en la lista de candidatos
                listaCandidatos.Add(objCandidato);
            }

            terminarConexion();
            return listaCandidatos;
        }

        /*
         * - RecuperarCandidatos tiene la misión de recuperar los datos de uno o varios candidatos
         */
        public List<Candidato> recuperarCandidatos(string TipoDoc = null, string NroDoc = null, string nombre = null, string apellido = null, int nroEmp = 0, int nroCand = 0)
        {
            bool conexionExitosa;
            GestorCandidatos gestorCandidatos = new GestorCandidatos();

            List<string> listaConsultas = new List<string>(); //Para componer la consultaSql
            List<Candidato> listaCandidatos = new List<Candidato>();//Para el retorno de datos

            string consultaSql;
            //Llamamos al metodo "iniciarConexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("No se pudo realizar la conexión con la Base de Datos");
                terminarConexion();
                return null;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos mas arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            //Si todo es por defecto NULL se buscan y retornan TODOS los candidatos que haya en la Base de Datos
            if (TipoDoc == null && NroDoc == null && nombre == null && apellido == null && nroEmp == 0 && nroCand == 0)
            {
                consultaSql = "SELECT * FROM candidato";
                comando.CommandText = consultaSql;//En el adaptador comando le hacemos un asignacion en su atributo CommandText de la consultaSql

                //Se hace la ejecucion del comando con el metodo ExecuterReader 
                //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
                MySqlDataReader reader = comando.ExecuteReader();

                if (!reader.HasRows)
                {
                    //si el reader esta vacio, es que no se encontraron datos para la consulta realizada
                    MessageBox.Show("No se encontro ningún candidato en la Base de Datos");
                    terminarConexion();
                    return null;
                }

                //Si el reader contiene datos, se realiza la lectura de todos los ellos.
                while (reader.Read())
                {
                    string nom = reader["nombre"].ToString();
                    string ape = reader["apellido"].ToString();
                    string tipoDoc = reader["tipo documento"].ToString();
                    string nroDoc = reader["nro documento"].ToString();

                    int nroCandidato;
                    if (reader["nroCandidato"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                        nroCandidato = 0;
                    else
                        nroCandidato = Int32.Parse(reader["nroCandidato"].ToString());//Se lo transforma a un numero entero

                    
                    int nroEmpleado;
                    if (reader["nroEmpleado"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                        nroEmpleado = 0;
                    else
                        nroEmpleado = Int32.Parse(reader["nroEmpleado"].ToString());//Se lo transforma a un numero entero

                    //Llamamos al gestor de candidatos para instanciar el candidato que se obtuvo de la base de datos
                    Candidato objCandidato = gestorCandidatos.instanciarCandidato(nom, ape, tipoDoc, nroDoc, nroCandidato, nroEmpleado);
                    //El retorno del metodo del gestor es introducido en la lista de candidatos
                    listaCandidatos.Add(objCandidato);
                }

            }//fin de if(TODO ES NULL), osea si no se pusieron parametros de busqueda

            
            //En caso de haber algún parametro diferente de NULL. Se compondra la consulta para la base de datos
            else
            {
                consultaSql = "SELECT * FROM `candidato` WHERE ";//Cabecera de la consulta sql

                //A continuacion se contemplan todas las posibilidades en fragmentos de consulta
                if (TipoDoc != null)
                    listaConsultas.Add("`tipo documento` LIKE '%" + TipoDoc + "%'");
                if (NroDoc != null)
                    listaConsultas.Add("`nro documento` LIKE '%" + NroDoc + "%'");
                if (nombre != null)
                    listaConsultas.Add("`nombre` LIKE '%" + nombre + "%'");
                if (apellido != null)
                    listaConsultas.Add("`apellido` LIKE '%" + apellido + "%'");
                if (nroEmp != 0)
                    listaConsultas.Add("`nroEmpleado` LIKE '%" + nroEmp + "%'");
                if (nroCand != 0)
                    listaConsultas.Add("`nroCandidato` LIKE '%" + nroCand + "%'");

                //Se agregan los fragmentos de consulta a la variable "consultaSql"
                for (int i = 0; i != (listaConsultas.Count - 1); i++)
                {
                    consultaSql += listaConsultas[i] + " AND ";
                }
                //Se concluye la declaracion de la consulta
                consultaSql += listaConsultas[(listaConsultas.Count - 1)] + ";";

                comando.CommandText = consultaSql;  //asignamos la consulta recien creada a el atributo CommandText (donde se guarda la consulta de un obj de tipo comando)

                //Se hace la ejecucion del comando con el metodo ExecuterReader 
                //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
                MySqlDataReader reader = comando.ExecuteReader();

                if (!reader.HasRows)
                { 
                    //si el reader esta vacio, es qe no encontro a ese candidato
                    MessageBox.Show("No se encontro un candidato solicitado");
                    terminarConexion();
                    return null;
                }

                //Si el reader contiene datos, se realiza la lectura de todos los ellos.
                while (reader.Read())
                {
                    string nom = reader["nombre"].ToString();
                    string ape = reader["apellido"].ToString();
                    string tipoDoc = reader["tipo documento"].ToString();
                    string nroDoc = reader["nro documento"].ToString();

                    int nroCandidato;
                    if (reader["nroCandidato"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                        nroCandidato = 0;
                    else
                        nroCandidato = Int32.Parse(reader["nroCandidato"].ToString());//Se lo transforma a un numero entero

                    int nroEmpleado;
                    if (reader["nroEmpleado"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                        nroEmpleado = 0;
                    else
                        nroEmpleado = Int32.Parse(reader["nroEmpleado"].ToString());//Se lo transforma a un numero entero

                    //Llamamos al gestor de candidatos para instanciar el candidato que se obtuvo de la base de datos
                    Candidato objCandidato = gestorCandidatos.instanciarCandidato(nom, ape, tipoDoc, nroDoc, nroCandidato, nroEmpleado);
                    //El retorno del metodo del gestor es introducido en la lista de candidatos
                    listaCandidatos.Add(objCandidato);
                }
            }

            terminarConexion();
            return listaCandidatos;
        }

        /*
         * - RecuperarCuestionarioActivo tiene la misión de recuperar los datos del cuestionario activo (o en proceso) para un candidato
         */
        public List<Cuestionario> recuperarCuestionarioActivo(Candidato candidato)
        {
            bool conexionExitosa;
            GestorCuestionario gestorCuestionarios = new GestorCuestionario();
            List<Cuestionario> listaCuestionariosAsociados = new List<Cuestionario>(); //Esta es la lista que devuelve el metodo como resultado

            //Declaramos una lista de cuestionarios auxiliar para obtener el historial de cuestionarios del candidato
            List<Cuestionario> preSeleccionCuestionarios = new List<Cuestionario>();

            //Declaramos una lista auxiliar de enteros para almacenar los ID de PUESTOS EVALUADOS 
            //con el fin de reconstruir las relaciones minimas en la instanciacion del cuestionario
            List<int> listaIdPuestos = new List<int>();
            
            //Otra lista auxiliar para guardar los números de bloque
            List<int> listaNroBloque = new List<int>();


            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos abajo
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            //La siguiente consulta arroja los datos de los cuestionarios que posee el candidato
            //__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++
            //ME PARECE QUE ESTO NO ANDA __--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++
            //__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++
            /*
             * PARA LA PREGUNTA DE JOSE: "de donde sale cuest? no habria que sacarlo afuera de las comillas dobles?"
             * LA RESPUESTA ES NO -> XQ: cuest es un apodo que se puede poner a las tablas, no se si se acuerdan de gestion de datos,
             * pero, a las tablas se las podia renobran con un "seudonimo" para hacer una consulta y no tener que estar utilizando el
             * nombre completo de la tabla.
             * LA CONSULTA SI FUNCIONA PORQUE LA PROBE EN EL WORKBENCH. SE LAS DEJO ACA PARA QUE LA PUEDAN EJECUTAR
             * 
               SELECT DISTINCT `clave`, `Puesto Evaluado_idPuesto Evaluado` ,`nroaccesos`, `ultimoBloque`
               FROM `tp base de datos`.`cuestionario` cuest 
               JOIN `tp base de datos`.`candidato` cand on (cand.`nro documento` = 32376056 AND cand.idCandidato = cuest.Candidato_idCandidato)
               JOIN `tp base de datos`.`cuestionario_estado` c_est on (cuest.idCuestionario = c_est.Cuestionario_idCuestionario);
             * 
             * PERO SI HAY UNA FORMA MAS FACIL DE HACER ESTA CONSULTA BIENVENIDA SEA...
             */
            //__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++__--++
            
            string consultaSql = "SELECT DISTINCT `clave`, `Puesto Evaluado_idPuesto Evaluado` ,`nroaccesos`, `ultimoBloque` ";
            consultaSql += "FROM `cuestionario` cuest "; //de donde sale cuest? no habria que sacarlo afuera de las comillas dobles?
            consultaSql += "JOIN `candidato` cand on (cand.`nro documento` = '" + candidato.NroDoc + "' AND cand.idCandidato = cuest.Candidato_idCandidato) ";
            consultaSql += "JOIN `cuestionario_estado` c_est on (cuest.idCuestionario = c_est.Cuestionario_idCuestionario);";
            
            //En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql
            comando.CommandText = consultaSql;

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { 
                //si el reader esta vacio, es qe no encontro a ese candidato
                terminarConexion();
                Cuestionario cues = gestorCuestionarios.instanciarCuestionario(candidato, "NO POSEE", null, 0);
                listaCuestionariosAsociados.Add(cues);
                return listaCuestionariosAsociados;
            }

            //Si el reader contiene datos, se realiza la lectura de todos los ellos.
            while (reader.Read())
            {
                string clave = reader["clave"].ToString();
                int accesos = Int32.Parse(reader["nroAccesos"].ToString());
                int idPuestoEv = Int32.Parse(reader["Puesto Evaluado_idPuesto Evaluado"].ToString());
                int nroBloque;

                if (reader["ultimoBloque"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                    nroBloque = 0;//IMPLICA QUE EL CUESTIONARIO ESTA ACTIVO
                else
                    nroBloque = Int32.Parse(reader["ultimoBloque"].ToString());//IMPLICA QUE EL CUESTIONARIO ESTA EN PROCESO

                //Llamamos al gestor de cuestionarios para instanciar el cuestionario que se obtuvo de la base de datos
                Cuestionario cuesAsociado = gestorCuestionarios.instanciarCuestionario(candidato, clave, null, accesos);
                //Cargamos el cuestionario creado a la lista de preSeleccionados
                preSeleccionCuestionarios.Add(cuesAsociado);
                //Cargamos el ID del Puesto Evaludos para luego buscarlo en la base de datos
                listaIdPuestos.Add(idPuestoEv);
                //Cargamos el nroDeBloque
                listaNroBloque.Add(nroBloque);
            }

            /*
             * Como vamos a hacer una llamada a otro metodo que ejecuta una consulta sobre la base de datos
             * Terminamos la conexión antes de seguir adelante
            */
            terminarConexion();

            PuestoEvaluado PuestoEv;
            for (int i = 0; i < listaIdPuestos.Count; i++)
            {
                PuestoEv = this.recuperarPuestoEvaluado(listaIdPuestos[i]);

                if (Equals(PuestoEv.Codigo, "ELIMINADO") == false)
                {
                    List<Estado> listEstado = this.recuperarUltimoEstado(preSeleccionCuestionarios[i]);
                    Estado estadoCuest = listEstado[0];

                    if (estadoCuest.Estado_ == "ACTIVO" || estadoCuest.Estado_ == "EN PROCESO")
                    {
                        //Agrego el puesto evaluado al cuestionario
                        preSeleccionCuestionarios[i].PuestoEvaluado = PuestoEv;
                        //Agrego el estado al cuestionario
                        preSeleccionCuestionarios[i].Estado = estadoCuest;

                        if (listaNroBloque[i] != 0)//ESTA EN PROCESO
                        {
                            //Agrego el bloque al cuestionario
                            preSeleccionCuestionarios[i].UltimoBloque = this.retornarBloque(preSeleccionCuestionarios[i], listaNroBloque[i]);
                        }
                        //Luego de agregar el Estado, el bloque y el Puesto Evaluado, agregamos el cuestionario a la lista de retorno
                        listaCuestionariosAsociados.Add(preSeleccionCuestionarios[i]);
                    }
                    else
                    {
                        //Agrego el puesto evaluado al cuestionario
                        preSeleccionCuestionarios[i].PuestoEvaluado = PuestoEv;
                        //Agrego el estado al cuestionario
                        preSeleccionCuestionarios[i].Estado = estadoCuest;
                        listaCuestionariosAsociados.Add(preSeleccionCuestionarios[i]);//Agregamos el error para controlarlo
                    }
                }
                else
                {
                    preSeleccionCuestionarios[i].PuestoEvaluado = PuestoEv;
                    listaCuestionariosAsociados.Add(preSeleccionCuestionarios[i]);//Agregamos el error para controlarlo
                }
            }

            return listaCuestionariosAsociados;
        }

        /*
         * - RecuperarUltimoEstado tiene la misión de recuperar los datos del ultimo Estado de un cuestionario puntual
         */
        public List<Estado> recuperarUltimoEstado(Cuestionario cuestAsociado)
        {
            bool conexionExitosa;
            GestorCuestionario gestorCuestionario = new GestorCuestionario();
            List<Estado> listaEstado = new List<Estado>();//Para el retorno de datos

            string consultaSql = "SELECT `Estado_idEstado`,`fecha` FROM `cuestionario` , `cuestionario_estado` WHERE `clave` = '" + cuestAsociado.Clave + "' AND `idCuestionario` = `Cuestionario_idCuestionario`;";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            //En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql
            comando.CommandText = consultaSql;

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { 
                //Si el reader esta vacio, es que no encontro el cuestionario
                MessageBox.Show("No se encontro el estado para el cuestionario");
                terminarConexion();
                return null;
            }

            //Lista de caracteristicas auxiliar para contener la fecha y el ID ESTADO del estado que luego seran utilizados para 
            //definir el ultimo estado del cuestionario
            List<Caracteristica> lista_fechaYid_Estado = new List<Caracteristica>();

            while (reader.Read())
            {
                DateTime fecha = DateTime.Parse(reader["fecha"].ToString());
                int idEstado = Int32.Parse(reader["Estado_idEstado"].ToString());

                //Creamos un elemento del tipo caracteristica e inicializamos sus partes
                Caracteristica elementoLista;
                elementoLista.dato1 = fecha;
                elementoLista.dato2 = idEstado;
                //Agregamos el elemento a la lista
                lista_fechaYid_Estado.Add(elementoLista);

            }
            terminarConexion();

            //Seteado en esa fecha para hacer las comparaciones desde un punto fijo pero no posible
            DateTime ultimaFecha = DateTime.Parse("1900-01-01");
            int indice = 0; //Se utilizara para ubicar en la lista de las fechas y ID ESTADO al estado correspondiente
            
            for (int i = 0; i < lista_fechaYid_Estado.Count; i++)
            {
                //Casteamos de la lista el dato1 que contiene la fecha
                DateTime fechaLista = (DateTime)lista_fechaYid_Estado[i].dato1;
                if (DateTime.Compare(ultimaFecha, fechaLista) == -1)
                {
                    ultimaFecha = fechaLista;//actualizamos la variable como la ultima fecha
                    indice = i;//establecemos el indice donde se encuentra este ultimo estado
                }
            }

            //Recuperamos los datos de Estado pasandole el id_estado que se encuentra en la lista
            string estado = this.recuperarEstado((int)lista_fechaYid_Estado[indice].dato2);
            //Instanciamos el estado de cuestionario
            Estado objEstado = gestorCuestionario.instanciarEstado(cuestAsociado, estado, ultimaFecha);

            listaEstado.Add(objEstado);

            return listaEstado;
        }

        /*
         * - RecuperarEstado tiene la misión de recuperar el nombre del Estado según su id
         */
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
            { 
                //si el reader esta vacio, es qe no encontro a ese candidato
                return "No se encontro un candidato solicitado ";
            }

            string nombreEstado = null;

            while (reader.Read())
                nombreEstado = reader["estado"].ToString();

            terminarConexion();

            return nombreEstado;
        }

        /*
         * - RecuperarPuestoEvaluado tiene la misión de recuperar un puesto evaluado puntual 
         *   según su id de la tabla de la base de datos
         */
        public PuestoEvaluado recuperarPuestoEvaluado(int idPuestoEv)
        {
            bool conexionExitosa;
            GestorEvaluacion gestorEvaluados = new GestorEvaluacion();
            PuestoEvaluado objPuesto = null;

            DateTime fecha_evaluacion = this.recuperarFechadeComienzoEvaluacion(idPuestoEv);

            string consultaSql = "SELECT * FROM `puesto evaluado` WHERE `idPuesto Evaluado` = " + idPuestoEv + " ;";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                //Si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("No se encontro un candidato solicitado ");
                terminarConexion();
                return null;
            }
            else
            {
                while (reader.Read())
                {
                    if (reader["eliminado"].ToString() == "")
                    {
                        string codigo = reader["codigo"].ToString();
                        string nombrePuestoEv = reader["nombre"].ToString();
                        string empresa = reader["empresa"].ToString();
                        //Usamos el gestor de evaluacion para instanciar el puesto evaludado con los datos encontrados en la base de datos
                        objPuesto = gestorEvaluados.instanciarPuestoEvaluado(codigo, nombrePuestoEv, empresa);
                        objPuesto.Fecha_Comienzo = fecha_evaluacion;
                    }
                    else
                    {
                        //Si el puesto evaludado fue eliminado se instanciara un puesto cuyo codigo sera "ELIMINADO"
                        objPuesto = gestorEvaluados.instanciarPuestoEvaluado("ELIMINADO", " ", " ");
                    }
                }
            }
            terminarConexion();
            return objPuesto;
        }

        public List<PuestoEvaluado> recuperarPuestos_ev(string codigo)
        {
            bool conexionExitosa;
            GestorEvaluacion gestorPuestos = new GestorEvaluacion();
            List<PuestoEvaluado> listaDePuestos_ev = new List<PuestoEvaluado>(); //para el retorno de datos
            List<Int32> lista_de_ID_Puesto_ev = new List<Int32>();

            string consultaSql = "SELECT DISTINCT `idPuesto Evaluado`, codigo, nombre, empresa, fecha " +
                "FROM `puesto evaluado` pu_ev " +
                "JOIN cuestionario cuest on (pu_ev.codigo = '" + codigo + "' AND pu_ev.`idPuesto evaluado` = cuest.`Puesto Evaluado_idPuesto Evaluado`) " +
                "JOIN `cuestionario_estado` c_est on (cuest.idCuestionario = c_est.Cuestionario_idCuestionario) " +
                "WHERE Estado_idEstado = 1 "+
                "GROUP BY `idPuesto Evaluado`";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("No se pudo realizar la conexión con la Base de Datos");
                terminarConexion();
                return null;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos mas arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            //En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql
            comando.CommandText = consultaSql;

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                //si el reader esta vacio, es que no se encontraron datos para la consulta realizada
                MessageBox.Show("No se encontro ningún puesto");
                terminarConexion();
                return null;
            }

            //Si el reader contiene datos, se realiza la lectura de todos los ellos.
            while (reader.Read())
            {
                PuestoEvaluado objPuestoEv;
                string id_puesto_ev = reader[0].ToString();
                string cod = reader["codigo"].ToString();
                string nomPuesto = reader["nombre"].ToString();
                string emp = reader["empresa"].ToString();
                DateTime fecha = (DateTime) reader["fecha"] ;

                //Llamamos al gestor de puestos para instanciar el puesto que se obtuvo de la base de datos
                objPuestoEv = gestorPuestos.instanciarPuestoEvaluado(cod, nomPuesto, emp);
                
                objPuestoEv.Fecha_Comienzo = fecha;

                //El retorno del metodo del gestor es introducido en la lista de puestos    
                listaDePuestos_ev.Add(objPuestoEv);
            }

            terminarConexion();


            return listaDePuestos_ev;
        }

        /*
         * - RecuperarCompetencias tiene la misión de recuperar todas las competencias que estan activas (no eliminadas)
         *   de la base de datos
         */
        public List<Competencia> recuperarCompetencias()
        {
            bool conexionExitosa;
            GestorCompetencias gestorCompetencias = new GestorCompetencias();
            List<Competencia> listaDeCompetencias = new List<Competencia>();//Para el retorno de datos

            string consultaSql = "SELECT * FROM competencia;";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                //Si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("No se encontro un candidato solicitado ");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                Competencia nuevaCompetencia;

                //Contemplamos la posibilidad de que este eliminada la competencia
                if (reader["eliminado"].ToString() == "")
                {
                    string cod = reader["codigo"].ToString();
                    string nomComp = reader["nombre"].ToString();
                    string descrip = reader["descripcion"].ToString();

                    //Si esta en condiciones de ser usada, se instancia una nueva competencia con los datos
                    nuevaCompetencia = gestorCompetencias.instanciarCompetencia(cod, nomComp, descrip, null);
                }
                else//Si fue eliminada se instancia una competencia con el codigo indicando esta situación
                    nuevaCompetencia = gestorCompetencias.instanciarCompetencia("ELIMINADA", null, null, null);
                
                listaDeCompetencias.Add(nuevaCompetencia);
            }

            return listaDeCompetencias;
        }

        /*
         * =======================================
         * FUNCION QUE SE ENCARGA DE RECUPERAR LAS   
         * CARACTERISTICAS ASOCIADAS A UN PUESTO
         * =======================================
         */
        public List<Caracteristica> recuperarCaracteristicasPuesto(string codigo)
        {
            bool conexionExitosa;
            List<Caracteristica> listaDeCaracteristicas = new List<Caracteristica>();
            
            string consultaSql = "SELECT DISTINCT c.nombre, p_c.ponderacion " +
                                    "FROM puesto " +
                                    "JOIN puesto_competencia AS p_c " +
                                    "ON '"+codigo+"'=p_c.Puesto_codigo " +
                                    "JOIN competencia AS c ON p_c.Competencia_codigo=c.codigo;";

           
            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                //Si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("No se encontraron competencias asociadas");
                terminarConexion();
                return null;
            }

            
            
            while (reader.Read())
            {
                Caracteristica caracteristica;
                string nombre = reader["nombre"].ToString();
                string ponderacion = reader["ponderacion"].ToString();

                caracteristica.dato1 = nombre;
                caracteristica.dato2 = ponderacion;


                listaDeCaracteristicas.Add(caracteristica);
                
            }
            terminarConexion();
            return listaDeCaracteristicas;
        }

        /*
         * - RecuperarCaracteristicasPuesto tiene la misión de recuperar todas las competencias que estan activas (no eliminadas)
         *   y ponederaciones asociades a un puesto puntual de la base de datos
         */
        public List<Caracteristica> recuperarCaracteristicasPuestoEv(PuestoEvaluado puestoEvAsociado)
        {
            bool conexionExitosa;
            //Lista que se retornara con los datos finales de la busqueda
            List<Caracteristica> listaCaracteristicas = new List<Caracteristica>();
            //Lista de caracteristicas auxiliar para realizar la busqueda (almacena los ID de las competencias y ponderaciones)
            List<Caracteristica> listaRetornoBD = new List<Caracteristica>();
            
            Caracteristica elementoLista = new Caracteristica();

            //La consulta selecciona las competencias asociadas al puesto pasado como parametro con su correspondiente ponderacion
            string consultaSql = "SELECT `Competencia Evaluada_idCompetencia Evaluada`, `ponderacion` ";
            consultaSql += "FROM `puesto evaluado_competencia evaluada` ponderaciones ";
            consultaSql += "JOIN `tp base de datos`.`puesto evaluado` p on (p.`codigo` = '" + puestoEvAsociado.Codigo + "') ";
            consultaSql += "WHERE p.`idPuesto Evaluado` = ponderaciones.`Puesto Evaluado_idPuesto Evaluado`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                elementoLista.dato1 = "No se realizo la conexion con la base de datos";//Se informa el error
                listaCaracteristicas.Add(elementoLista);
                terminarConexion();
                return listaCaracteristicas;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos mas arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            //En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql
            comando.CommandText = consultaSql;

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                elementoLista.dato1 = "El puesto no posee competencias para ser evaluado";
                listaCaracteristicas.Add(elementoLista);
                terminarConexion();
                return listaCaracteristicas;
            }

            while (reader.Read())
            {
                //Se recuperan los ID's de las competencias y los números correspondientes a las ponderaciones 
                int idCompetenciaEv = Int32.Parse(reader["Competencia Evaluada_idCompetencia Evaluada"].ToString());
                int ponderacion = Int32.Parse(reader["ponderacion"].ToString());

                //Los datos obtenidos se almacena en un elemento de la lista
                elementoLista.dato1 = idCompetenciaEv;
                elementoLista.dato2 = ponderacion;
                listaRetornoBD.Add(elementoLista);//Agregamos el elemento a la lista
            }
            //Termanamos la conexion con la base de datos para evitar futuros conflictos con otras consultas
            terminarConexion();

            for (int i = 0; i < listaRetornoBD.Count; i++)
            {
                //Realizamos la busqueda de las competencias evaluadas por su ID (QUE ES UNICO)
                List<CompetenciaEvaluada> competenciaAs = recuperarCompetenciasEvaluadas((int)listaRetornoBD[i].dato1);
                if (competenciaAs[0] != null)
                {
                    //Si hubo algun retorno, instanciamos un objeto del tipo ponderacion
                    Ponderacion pondeAs = new Ponderacion((int)listaRetornoBD[i].dato2);
                    //Agregamos la competencia y la poneración a un elemento de la lista
                    elementoLista.dato1 = competenciaAs[0];
                    elementoLista.dato2 = pondeAs;
                    listaCaracteristicas.Add(elementoLista);//Agregamos el elemento a la lista de caracteristicas del puesto evaluado
                }
            }

            return listaCaracteristicas;
        }

        /*
         * - RecuperarCompetenciasEvaludas tiene la misión de recuperar una competencia evaluada según su ID
         *   que corresponde a la BASE DE DATOS
         */
        public List<CompetenciaEvaluada> recuperarCompetenciasEvaluadas(int idCompetenciaEv)
        {
            bool conexionExitosa;
            GestorEvaluacion gestorEvaluacion = new GestorEvaluacion();
            List<CompetenciaEvaluada> listaDeCompetencias = new List<CompetenciaEvaluada>();//Para el retorno de datos

            string consultaSql = "SELECT * FROM `competencia evaluada` WHERE `competencia evaluada`.`idCompetencia Evaluada` ='" + idCompetenciaEv + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("No se realizo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("El puesto no posee competencias para ser evaluado");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                //Verificamos que la competencia no este eliminada
                CompetenciaEvaluada competenciaEv;

                if (reader["eliminado"].ToString() == "")
                {
                    string cod = reader["codigo"].ToString();
                    string nomComp = reader["nombre"].ToString();
                    string descrip = reader["descripcion"].ToString();

                    //Si no fue eliminada, la instaciamos con el gestor de evaluacion con los datos obtenidos
                    competenciaEv = gestorEvaluacion.instanciarCompetenciaEvaluda(cod, nomComp, descrip);
                }
                else//Si fue eliminada, instanciamos una competencia con el atrubuto 'codigo' inicializado en ELIMINADA
                    competenciaEv = gestorEvaluacion.instanciarCompetenciaEvaluda("ELIMINADA", null, null);

                listaDeCompetencias.Add(competenciaEv);
            }

            terminarConexion();

            //Agregamos la lista de Factores para cada una de las competencias encontradas
            for (int i = 0; i < listaDeCompetencias.Count; i++)
            {
                //Recuperamos los factores asociados a la competencia
                List<FactorEvaluado> factoresList = recuperarFactoresEvaluados(listaDeCompetencias[i]);

                for (int j = 0; j < factoresList.Count; j++)
                {
                    //Para la competencia Evaluada que esta resguardada en la posición i 
                    //le agregamos a su lista de factores, el factor evaluado que se encentre en la posición j
                    listaDeCompetencias[i].addFactor(factoresList[j]);
                }
            }

            return listaDeCompetencias;
        }

        /*
         * - RecuperarFactoresEvaludos tiene la misión de recuperar los factores evaluados para una competencia puntual
         *   de a la BASE DE DATOS
         */
        public List<FactorEvaluado> recuperarFactoresEvaluados(CompetenciaEvaluada competenciaAsociada)
        {
            bool conexionExitosa;
            GestorEvaluacion gestorEvaluacion = new GestorEvaluacion();
            List<FactorEvaluado> listaDeFactores = new List<FactorEvaluado>();//Para el retorno de datos

            string consultaSql = "SELECT `factor evaluado`.nombre ,`factor evaluado`.codigo ,nroOrden " +
            "FROM `factor evaluado` " +
            "JOIN `competencia evaluada` comEv on (comEv.`codigo` = '" + competenciaAsociada.Codigo + "') " +
            "WHERE `factor evaluado`.`Competencia Evaluada_idCompetencia Evaluada` = comEv.`idCompetencia Evaluada`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("No se realizo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("El puesto no posee competencias para ser evaluado");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {   
                string cod = reader["codigo"].ToString();
                string nomFactor = reader["nombre"].ToString();
                int nrOrden = Int32.Parse(reader["nroOrden"].ToString());
                //Ahora vamos a crear una instancia del objeto factor, a través del gestor de factores 
                FactorEvaluado factorEv = gestorEvaluacion.instanciarFactorEvaluado(cod, nomFactor, competenciaAsociada, nrOrden);
                listaDeFactores.Add(factorEv);
            }
            terminarConexion();
    
            //Agregamos la lista de Factores para cada una de las competencias encontradas
            for (int i = 0; i < listaDeFactores.Count; i++)
            {
                List<PreguntaEvaluada> preguntasList = recuperarPreguntasEvaluadas(listaDeFactores[i]);
                if (preguntasList[i] != null)
                {
                    for (int j = 0; j < preguntasList.Count; j++)
                    {
                        listaDeFactores[i].addPregunta(preguntasList[j]);
                    }
                }
                /*else
                    listaDeFactores.Add(preguntasList[i]);*/
            }

            return listaDeFactores;
        }

        /*
         * - RecuperarPreguntas evaluadas tiene la misión de recuperar Las preguntas evaluadas para Un factor puntual
         *   de a la BASE DE DATOS
         */
        public List<PreguntaEvaluada> recuperarPreguntasEvaluadas(FactorEvaluado factorAsociado)
        {
            bool conexionExitosa;
            GestorEvaluacion gestorEvaluacion = new GestorEvaluacion();
            List<PreguntaEvaluada> listaDePreguntas = new List<PreguntaEvaluada>();

            string consultaSql = "SELECT `pregunta evaluada`.nombre ,`pregunta evaluada`.codigo, `pregunta evaluada`.pregunta, `pregunta evaluada`.`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada` "
            + "FROM `pregunta evaluada` "
            + "JOIN `factor evaluado` fac on (fac.`codigo` = '" + factorAsociado.Codigo + "') "
            + "WHERE `pregunta evaluada`.`Factor Evaluado_idFactor Evaluado` = fac.`idFactor Evaluado`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("No se realizo la conexion con la base de datos");
                terminarConexion();
                return null;
            }


            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("El factor no posee preguntas para ser evaluado");
                terminarConexion();
                return null;
            }

            List<int> listaIdOpRespuesta = new List<int>();
            while (reader.Read())
            {
                string cod = reader["codigo"].ToString();
                string nomPreg = reader["nombre"].ToString();
                string preg = reader["pregunta"].ToString();
                int idOpRespuesta = Int32.Parse(reader["Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada"].ToString());

                PreguntaEvaluada preguntaEv = gestorEvaluacion.instanciarPreguntaEvaluda(cod, preg, nomPreg, factorAsociado);
                listaDePreguntas.Add(preguntaEv);
                listaIdOpRespuesta.Add(idOpRespuesta);
            }
            terminarConexion();

            //Agregamos la listas de Opciones de respuesta y las opciones para cada una de las preguntas encontradas
            for (int i = 0; i < listaDePreguntas.Count; i++)
            {
                //Se recuperan la opcion de respuesta de la pregunta
                List<OpciondeRespuestaEvaluada> opcionesRespuesta = recuperarOpcionRespuestaEvaluada(listaIdOpRespuesta[i]);
                if (opcionesRespuesta[0] != null)
                {
                    //Recuperamos la opcion que contiene la poneracion para esa pregunta
                    List<OpcionesEvaluadas> opciones = recuperarOpcionesEvaluadas(listaDePreguntas[i]);
                    //Completamos el objeto Opciones_de_respuestas_evaludas con la lista de opciones
                    opcionesRespuesta[0].ListaOpcionesEv = opciones;
                    
                    //Realizamos la asignacion de la opcion de respuesta y las opciones corespondientes para la pregunta
                    listaDePreguntas[i].Op_respuestaEv = opcionesRespuesta[0];
                    listaDePreguntas[i].ListaOpcionesEv = opciones;
                }
            }

            return listaDePreguntas;
        }
        
        /*
         * - RecuperarOpcionesEvaludas tiene la misión de recuperar las opciones evaluadas para una pregunta puntual
         *   de a la BASE DE DATOS
         */
        public List<OpcionesEvaluadas> recuperarOpcionesEvaluadas(PreguntaEvaluada pregAsociada)
        {
            bool conexionExitosa;
            GestorEvaluacion gestionEvaluacion = new GestorEvaluacion();
            List<OpcionesEvaluadas> listaDeOpciones = new List<OpcionesEvaluadas>();//Para el retorno de datos 

            string consultaSql = "SELECT op.nombre, pr_op.ponderacion, opr_op.ordenDeVisualizacion "
            + "FROM `tp base de datos`.`pregunta evaluada_opcion evaluada` pr_op "
            + "JOIN `tp base de datos`.`pregunta evaluada` pr on (pr_op.`Pregunta Evaluada_idPregunta Evaluada` = pr.`idPregunta Evaluada` AND pr.codigo = '" + pregAsociada.Codigo + "') "
            + "JOIN `tp base de datos`.`opcion evaluada` op on (pr_op.`Opcion Evaluada_idOpcion` = op.idOpcion) "
            + "JOIN `tp base de datos`.`opcion de respuesta evaluada_opcion evaluada` opr_op on (pr_op.`Opcion Evaluada_idOpcion` = opr_op.`Opcion Evaluada_idOpcion`) "
            + "GROUP BY nombre, ponderacion, ordenDeVisualizacion;";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("No se entraron opciones para la pregunta solicitada");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                //opc.nombre, opR_opc.ordenDeVisualizacion, pr.`idPregunta Evaluada`
                string nomOpcion = reader["nombre"].ToString();
                int ponderacion = Int32.Parse(reader["ponderacion"].ToString());
                int ordenVisualizacion = Int32.Parse(reader["ordenDeVisualizacion"].ToString());

                OpcionesEvaluadas preguntaEv = gestionEvaluacion.instanciarOpcionEv(nomOpcion, ponderacion, ordenVisualizacion);
                listaDeOpciones.Add(preguntaEv);
            }

            terminarConexion();
            
            return listaDeOpciones;
        }

        /*
         * - RecuperarOpcionRespuestaEvaluda tiene la misión de recuperar las opciones evaluadas para una pregunta puntual
         *   de a la BASE DE DATOS
         */
        public List<OpciondeRespuestaEvaluada> recuperarOpcionRespuestaEvaluada(int idOpcionDeRespuesta)
        {
            bool conexionExitosa;
            GestorEvaluacion gestorEvaluacion = new GestorEvaluacion();
            List<OpciondeRespuestaEvaluada> listaDeOpRespuesta = new List<OpciondeRespuestaEvaluada>();//Para el retorno de datos

            string consultaSql = "SELECT * FROM `opcion de respuesta evaluada` opcRes WHERE opcRes.`idOpcion de Respuesta Evaluada` = '" + idOpcionDeRespuesta + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("No se pudo realizar la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a esa opcion de respuesta evaluada
                MessageBox.Show("No se encontro la opcion de respuesta solicitada");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                string nomOpcionResp = reader["nombre"].ToString();
                string codigo = reader["codigo"].ToString();

                OpciondeRespuestaEvaluada OpcionResp = gestorEvaluacion.instanciarOpRespuestaEv(nomOpcionResp, codigo);
                listaDeOpRespuesta.Add(OpcionResp);
            }
            terminarConexion();
            
            return listaDeOpRespuesta;
        }

        /*
         * retornarProximoBloque tiene la misión de recuperar el proximo bloque de un cuestionario a travez de su numero de bloque
         */
        public Bloque retornarBloque(Cuestionario cuestAsociado, int nroBloque)
        {
            GestorCuestionario gestorCuestionario = new GestorCuestionario();
            GestorEvaluacion gestorEvaluacion = new GestorEvaluacion();

            if (cuestAsociado.PuestoEvaluado.Caracteristicas == null)
            {
                //Re-armamos las relaciones del cuestionario para tener todos los objetos en memoria
                bool re_construido = this.reconstruirRelaciones(cuestAsociado);
                if (!re_construido)
                {
                    MessageBox.Show("No se pudo recuperar Todos los datos requeridos");
                    return null;
                }
            }

            bool conexionExitosa;
            List<PreguntaEvaluada> ListapregAsociadas = new List<PreguntaEvaluada>();

            string consultaSql = "SELECT codigo " //Recupero el codigo de las preguntas evaluadas
                + "FROM item_bloque it_Bloq " //Desde la tabla de ITEM_BLOQUE de la base de datos
                //CONDICIONO CON UN JOIN que el id que se encuentra en la tabla de `pregunta evaluada` sea igual al id de la tabla `item_bloque`
                + "JOIN `pregunta evaluada` pEv on (pEv.`idPregunta Evaluada` = it_Bloq.PreguntaEvaluada_idPreguntaEv) "
                //CON UN SEGUNDO JOIN pido que me busque los datos del bloque que condice con el "nroBloque"
                + "JOIN bloque bq on (bq.nroBloque = " + nroBloque + ") "
                //TERCER JOIN pido que me busque entre los cuestionarios los datos del que coincida con el cuestionario que le paso como parametro 
                + "JOIN cuestionario cuest on (cuest.clave = '" + cuestAsociado.Clave + "') "
                //Con el WHERE restrinjo que de los datos obtenidos:
                //El id del bloque que se encuentra en la tabla `item_bloque` sea el mismo al del bloque seleccionado en el JOIN
                + "WHERE it_Bloq.Bloque_idBloque = bq.idBloque "
                //Y que el id del cuestionario que esta en la tabla de `bloques` sea el mismo al obtenido del JOIN con la tabla cuestionario
                + "AND bq.Cuestionario_idCuestrionario = cuest.idCuestionario;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return null; //Error de conexion

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)//si el reader esta vacio, no se encontro el parametro buscado
                return null;

            while (reader.Read())
            {
                string codigo = reader["codigo"].ToString();

                ListapregAsociadas.Add(gestorEvaluacion.retornarPreguntaDeLaRelacion(cuestAsociado.PuestoEvaluado, codigo));
            }

            terminarConexion();

            bool esUltimoBloque = esUltimimoBloque(cuestAsociado, nroBloque);
            Bloque bloque_R = gestorCuestionario.instanciarBloque(nroBloque, cuestAsociado);
            bloque_R.EsUltimoNloque = esUltimoBloque;
            bloque_R.ListaPreguntasEv = ListapregAsociadas;

            terminarConexion();

            return bloque_R;
        }

        private bool esUltimimoBloque(Cuestionario cuestAsociado, int nroBloque)
        {
            bool esUltimoBloque_ = false;//POR DEFECTO ES FALSO
            bool conexionExitosa;

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return false; //Error de conexion

            string consultaSql = "SELECT bloq.esUltimoBloque "
                + "FROM bloque bloq "
                + "JOIN cuestionario cuest on (bloq.Cuestionario_idCuestrionario = cuest.idCuestionario) "
                + "WHERE cuest.clave = '" + cuestAsociado.Clave + "' AND bloq.nroBloque = " + nroBloque + ";";

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {//si el reader esta vacio, no se encontro el parametro buscado
                MessageBox.Show("algo salio mal en el bloque ... ");
                return false;
            }

            while (reader.Read())
            {
                if (reader["esUltimoBloque"].ToString() != "")
                    esUltimoBloque_ = Boolean.Parse(reader["esUltimoBloque"].ToString());
            }

            return esUltimoBloque_;
        }

        /*
         * =======================================
         * METODOS DE RECONSTRUCCION DE RELACIONES
         * =======================================
         *      - Tiene la finalidad de re-establecer los objetos asociados del diagrama de clases
         */
        public bool reconstruirRelaciones(Cuestionario cuestionarioAsociado)
        {
            bool seRealizoConExito = true;
            PuestoEvaluado puestoEvAsociado = cuestionarioAsociado.PuestoEvaluado;

            if (Equals(puestoEvAsociado.Caracteristicas, null) == true)
            {
                List<Caracteristica> caracteristicasPuesto = recuperarCaracteristicasPuestoEv(puestoEvAsociado);
                puestoEvAsociado.Caracteristicas = caracteristicasPuesto;
                if (Equals(caracteristicasPuesto[0].dato1.GetType(), "stringEJEMPLO".GetType()) == false)
                    seRealizoConExito = true;
                else
                    seRealizoConExito = false;
            }
            return seRealizoConExito;
        }

        /*
         * ====================
         * METODOS DE RESGUARDO 
         * ====================
         *      - Tiene la finalidad de guardar los datos de una entidad
         */
        public bool guardarPuesto(Puesto puesto)
        {
            //codigo, nombreDePuesto, empresa, descripcion
            string consultaSql1 = "INSERT INTO puesto (codigo,nombre,empresa,descripcion) " +
                "VALUES ('" + puesto.Codigo + "','" + puesto.Nombre + "','" + puesto.Empresa + "','" + puesto.Descripcion + "');";


            MySql.Data.MySqlClient.MySqlTransaction transaccion;

            bool conexionExitosa;
            int cantDeFilasAfectadas = 0;

            conexionExitosa = iniciarConexion();

            MySql.Data.MySqlClient.MySqlCommand comando1 = new MySqlCommand(), comando2 = new MySqlCommand();


            comando1.Connection = ObjConexion;
            comando1.CommandType = CommandType.Text;
            comando1.CommandTimeout = 0;
            comando1.CommandText = consultaSql1;

            comando2.Connection = ObjConexion;
            comando2.CommandType = CommandType.Text;
            comando2.CommandTimeout = 0;

            transaccion = ObjConexion.BeginTransaction();

            try
            {
                if (!conexionExitosa)
                    return false;

                comando1.Transaction = transaccion;
                comando2.Transaction = transaccion;

                cantDeFilasAfectadas += comando1.ExecuteNonQuery();

                for (int i = 0; i < puesto.Caracteristicas.Count; i++)
                {
                    Competencia competencia1 = (Competencia)puesto.Caracteristicas[i].dato1;
                    Ponderacion ponderacion1 = (Ponderacion)puesto.Caracteristicas[i].dato2;

                    string consultaSql2 = "INSERT INTO puesto_competencia (Puesto_codigo,Competencia_codigo,ponderacion) " +
                       "VALUES ('" + puesto.Codigo + "','" + competencia1.Codigo + "','" + ponderacion1.Valor + "');";


                    comando2.CommandText = consultaSql2;

                    cantDeFilasAfectadas += comando2.ExecuteNonQuery();
                }

                transaccion.Commit();
                terminarConexion();

            }

            catch (MySqlException MysqlEx)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("La transaccion no se pudo realizar: " + MysqlEx.Message);


            }
            catch (DataException Ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("La transaccion no se pudo realizar: " + Ex.Message);

            }

            if (cantDeFilasAfectadas >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool modificarPuesto(Puesto puesto)
        {
            //codigo, nombreDePuesto, empresa, descripcion
            string consultaSql1 = "UPDATE `puesto` " +
                "SET nombre='"+ puesto.Nombre +"', descripcion='"+ puesto.Descripcion +"', empresa='"+ puesto.Empresa +"' "+
                "WHERE codigo='"+ puesto.Codigo +"';";

            string consultaSqlDelete = "DELETE FROM `puesto_competencia` " +
                                       "WHERE Puesto_codigo='" + puesto.Codigo + "';";

            MySql.Data.MySqlClient.MySqlTransaction transaccion;

            bool conexionExitosa;
            int cantDeFilasAfectadas = 0;

            conexionExitosa = iniciarConexion();

            MySql.Data.MySqlClient.MySqlCommand comando1 = new MySqlCommand(), comando2 = new MySqlCommand(), comandoDelete = new MySqlCommand();

            comandoDelete.Connection = ObjConexion;
            comandoDelete.CommandType = CommandType.Text;
            comandoDelete.CommandTimeout = 0;
            comandoDelete.CommandText = consultaSqlDelete;

            comando1.Connection = ObjConexion;
            comando1.CommandType = CommandType.Text;
            comando1.CommandTimeout = 0;
            comando1.CommandText = consultaSql1;

            comando2.Connection = ObjConexion;
            comando2.CommandType = CommandType.Text;
            comando2.CommandTimeout = 0;

            transaccion = ObjConexion.BeginTransaction();

            try
            {
                if (!conexionExitosa)
                    return false;

                comando1.Transaction = transaccion;
                comandoDelete.Transaction = transaccion;
                comando2.Transaction = transaccion;

                cantDeFilasAfectadas += comando1.ExecuteNonQuery();
                comandoDelete.ExecuteNonQuery();
                for (int i = 0; i < puesto.Caracteristicas.Count; i++)
                {
                    Competencia competencia1 = (Competencia)puesto.Caracteristicas[i].dato1;
                    Ponderacion ponderacion1 = (Ponderacion)puesto.Caracteristicas[i].dato2;

                    string consultaSql2 = "INSERT INTO puesto_competencia (Puesto_codigo,Competencia_codigo,ponderacion) " +
                       "VALUES ('" + puesto.Codigo + "','" + competencia1.Codigo + "','" + ponderacion1.Valor + "');";

                    comando2.CommandText = consultaSql2;

                    cantDeFilasAfectadas += comando2.ExecuteNonQuery();
                }

                transaccion.Commit();
                terminarConexion();

            }

            catch (MySqlException MysqlEx)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("La transaccion no se pudo realizar: " + MysqlEx.Message);


            }
            catch (DataException Ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("La transaccion no se pudo realizar: " + Ex.Message);

            }
            terminarConexion();
            if (cantDeFilasAfectadas >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * ====================================================
         * FUNCION QUE SE ENCARGA DE VERIFICAR SI EL PUESTO QUE     
         * SE QUIERE ELIMINAR TIENE EVALUACIONES ASOCIADAS
         * ====================================================
         */
        public bool tieneElPuestoEvaluacionesAsociadas(string codigo)
        {
            bool conexionExitosa;

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return false; //Error de conexion

            string consultaSql = "SELECT DISTINCT `idPuesto Evaluado` "
                + "FROM puesto "
                + "JOIN `puesto evaluado` p "
                + "ON '" + codigo + "'=p.codigo;";

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();
            if (!reader.HasRows)
            {
                terminarConexion();
                //Si el reader está vacio significa que el puesto no tiene evaluaciones asociadas y puede ser eliminado
                return false;
            }
            else
            {
                terminarConexion();
                return true;
            }
        }

        public bool eliminarPuesto(string codigo)
        {
            bool conexionExitosa, bandera;

            conexionExitosa = iniciarConexion();

            MySql.Data.MySqlClient.MySqlTransaction transaccion;


            string consultaSql = "UPDATE `puesto` " +
                                 "SET eliminado='"+ 1 +"' "+
                                 "WHERE codigo='"+ codigo +"';";

            MySql.Data.MySqlClient.MySqlCommand comando= new MySqlCommand();

            comando.Connection = ObjConexion;
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 0;
            comando.CommandText = consultaSql;

            transaccion = ObjConexion.BeginTransaction();
            

             try
            {
                if (!conexionExitosa)
                    return false;

                comando.Transaction = transaccion;
                comando.ExecuteNonQuery();

                transaccion.Commit();
                terminarConexion();
                bandera = true;
            }
             catch (MySqlException MysqlEx)
             {
                 // si algo fallo deshacemos todo
                 transaccion.Rollback();
                 // mostramos el mensaje del error
                 MessageBox.Show("La transaccion no se pudo realizar: " + MysqlEx.Message);
                 bandera = false;

             }
             catch (DataException Ex)
             {
                 // si algo fallo deshacemos todo
                 transaccion.Rollback();
                 // mostramos el mensaje del error
                 MessageBox.Show("La transaccion no se pudo realizar: " + Ex.Message);
                 bandera = false;
             }
             return bandera;
        }

        public bool guardarRespuesta(Respuestas respuesta, int nroBloque)
        {
            MySql.Data.MySqlClient.MySqlTransaction transaccion;

            bool conexionExitosa;
            int cantDeFilasAfectadas = 0;

            conexionExitosa = iniciarConexion();

            MySql.Data.MySqlClient.MySqlCommand comando = new MySqlCommand();

            comando.Connection = ObjConexion;
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 0;

            transaccion = ObjConexion.BeginTransaction();

            try
            {
                if (!conexionExitosa)
                    return false;

                for (int i = 0; i < respuesta.PreguntasMasOpciones.Count; i++)
                {
                    PreguntaEvaluada pregAsociada = (PreguntaEvaluada)respuesta.PreguntasMasOpciones[i].dato1;
                    OpcionesEvaluadas opcionAsociada = (OpcionesEvaluadas)respuesta.PreguntasMasOpciones[i].dato2;

                    //CONSULTA QUE ACTUALIZA LA TABLA ITEM_BLOQUE PARA RESGUARDAR LAS RESPUESTAS
                    string consultaSql = "UPDATE item_bloque "
                                         + "SET `Opcion Evaluada_idOpcion_seleccionada` = "
                                         + "(SELECT idOpcion FROM `opcion evaluada` WHERE nombre = '" + opcionAsociada.Nombre + "')"
                                         + "WHERE (Bloque_idBloque = ( SELECT idBloque FROM `tp base de datos`.bloque AS bloq "
                                         + "JOIN cuestionario AS cuest "
                                         + "ON (cuest.clave = '" + respuesta.CuestionarioAsociado.Clave + "' AND cuest.idCuestionario = bloq.Cuestionario_idCuestrionario)  "
                                         + "WHERE bloq.nroBloque = " + nroBloque + ")) "
                                         + "AND (PreguntaEvaluada_idPreguntaEv = (SELECT `idPregunta Evaluada` "
                                         + "FROM `pregunta evaluada` "
                                         + "WHERE codigo = '" + pregAsociada.Codigo + "'));";


                    comando.CommandText = consultaSql;

                    cantDeFilasAfectadas += comando.ExecuteNonQuery();
                }

                transaccion.Commit();
                terminarConexion();

            }

            catch (MySqlException MysqlEx)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("RESGUARDO DE RESPUESTAS: La transaccion no se pudo realizar: " + MysqlEx.Message);


            }

            catch (DataException Ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("RESGUARDO DE RESPUESTAS: La transaccion no se pudo realizar: " + Ex.Message);

            }

            if (cantDeFilasAfectadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool guardarEstado(Estado nuevoEstado_) 
        {
            MySql.Data.MySqlClient.MySqlTransaction transaccion;

            bool conexionExitosa;
            int cantDeFilasAfectadas = 0;

            conexionExitosa = iniciarConexion();

            MySql.Data.MySqlClient.MySqlCommand comando = new MySqlCommand();

            comando.Connection = ObjConexion;
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 0;

            transaccion = ObjConexion.BeginTransaction();


            try
            {
                if (!conexionExitosa)
                    return false;
                else
                {
                    string fecha = nuevoEstado_.Fecha_hora.Year + "-" + nuevoEstado_.Fecha_hora.Month + "-" + nuevoEstado_.Fecha_hora.Day + " " + nuevoEstado_.Fecha_hora.Hour + ":" + nuevoEstado_.Fecha_hora.Minute + ":" + nuevoEstado_.Fecha_hora.Second;
                    //CONSULTA QUE ACTUALIZA LA TABLA CUESTIONARIO_ESTADO PARA RESGUARDAR EL ESTADO 
                    string consultaSql = "INSERT INTO cuestionario_estado (Cuestionario_idCuestionario,Estado_idEstado,fecha) "
                        + "VALUES ((SELECT idCuestionario FROM cuestionario WHERE clave = '" + nuevoEstado_.Cuestionario.Clave + "'),"
                        + "(SELECT idEstado FROM estado WHERE estado = '" + nuevoEstado_.Estado_ + "'), "
                        + " '" + fecha + "');";

                    comando.CommandText = consultaSql;

                    cantDeFilasAfectadas += comando.ExecuteNonQuery();
                }

                transaccion.Commit();
                terminarConexion();

            }

            catch (MySqlException MysqlEx)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("RESGUARDO DE ESTADO: La transaccion no se pudo realizar: " + MysqlEx.Message);
            }

            catch (DataException Ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("RESGUARDO DE ESTADO: La transaccion no se pudo realizar: " + Ex.Message);
            }

            if (cantDeFilasAfectadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool guardarBloque(Bloque nuevoBloque)
        {
            //CONSULTA QUE ACTUALIZA LA TABLA DE BLOQUES CON UNA NUEVA FILA
            string consultaSql1 = "INSERT INTO `bloque` (`nroBloque`,`Cuestionario_idCuestrionario`,`esUltimoBloque`) ";
            if (nuevoBloque.EsUltimoNloque == false)
                consultaSql1 += "VALUES (" + nuevoBloque.NroBloque + ",(SELECT idCuestionario FROM cuestionario WHERE clave = '" + nuevoBloque.CuestAsociado.Clave + "'),null);";
            else
                consultaSql1 += "VALUES (" + nuevoBloque.NroBloque + ",(SELECT idCuestionario FROM cuestionario WHERE clave = '" + nuevoBloque.CuestAsociado.Clave + "')," + nuevoBloque.EsUltimoNloque + ");";

            MySql.Data.MySqlClient.MySqlTransaction transaccion;

            bool conexionExitosa;
            int cantDeFilasAfectadas = 0;

            conexionExitosa = iniciarConexion();

            MySql.Data.MySqlClient.MySqlCommand comando1 = new MySqlCommand(), comando2 = new MySqlCommand();


            comando1.Connection = ObjConexion;
            comando1.CommandType = CommandType.Text;
            comando1.CommandTimeout = 0;
            comando1.CommandText = consultaSql1;

            comando2.Connection = ObjConexion;
            comando2.CommandType = CommandType.Text;
            comando2.CommandTimeout = 0;

            transaccion = ObjConexion.BeginTransaction();

            try
            {
                if (!conexionExitosa)
                    return false;

                comando1.Transaction = transaccion;
                comando2.Transaction = transaccion;

                cantDeFilasAfectadas += comando1.ExecuteNonQuery();

                for (int i = 0; i < nuevoBloque.ListaPreguntasEv.Count; i++)
                {
                    PreguntaEvaluada preguntaAsociada = nuevoBloque.ListaPreguntasEv[i];
                    //CONSULTA QUE ACTUALIZA LA TABLA DE ITEM_BLOQUE CON NUEVAS FILAS PARA ASOCIAR LAS PREGUNTAS A LOS BLOQUES
                    string consultaSql2 = "INSERT INTO item_bloque (`Bloque_idBloque`,`PreguntaEvaluada_idPreguntaEv`,`Opcion Evaluada_idOpcion_seleccionada`) "
                        + "VALUES ((SELECT idBloque FROM bloque AS b "
                        + "JOIN cuestionario AS c ON (b.Cuestionario_idCuestrionario = c.idCuestionario AND c.clave = '" + nuevoBloque.CuestAsociado.Clave + "') "
                        + "WHERE b.nroBloque = " + nuevoBloque.NroBloque + "),"
                        + "(SELECT `idPregunta Evaluada` FROM `pregunta evaluada` AS p_ev "
                        + "JOIN `factor evaluado` AS f_ev ON (f_ev.`idFactor Evaluado` = p_ev.`Factor Evaluado_idFactor Evaluado`) "
                        + "JOIN `opcion de respuesta evaluada` AS opR ON (opR.`idOpcion de Respuesta Evaluada` = p_ev.`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada`) "
                        + "WHERE p_ev.codigo = '" + preguntaAsociada.Codigo + "'),null);";

                    comando2.CommandText = consultaSql2;

                    cantDeFilasAfectadas += comando2.ExecuteNonQuery();
                }

                transaccion.Commit();
                terminarConexion();

            }

            catch (MySqlException MysqlEx)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("RESGUARDO DE BLOQUES: La transaccion no se pudo realizar: " + MysqlEx.Message);


            }
            catch (DataException Ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("RESGUARDO DE BLOQUES: La transaccion no se pudo realizar: " + Ex.Message);

            }

            if (cantDeFilasAfectadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool guardarAtrubutosCuestionario(Cuestionario cuest_)
        {
            MySql.Data.MySqlClient.MySqlTransaction transaccion;

            bool conexionExitosa;
            int cantDeFilasAfectadas = 0;

            conexionExitosa = iniciarConexion();

            MySql.Data.MySqlClient.MySqlCommand comando = new MySqlCommand();

            comando.Connection = ObjConexion;
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 0;

            transaccion = ObjConexion.BeginTransaction();

            try
            {
                if (!conexionExitosa)
                    return false;

                else
                {
                    //CONSULTA QUE ACTUALIZA LA TABLA ITEM_BLOQUE PARA RESGUARDAR LAS RESPUESTAS
                    string consultaSql = "UPDATE `cuestionario` SET `nroAccesos`=" + cuest_.NroAccesos + ", `ultimoBloque`=" + cuest_.UltimoBloque.NroBloque + " "
                        + "WHERE clave='" + cuest_.Clave + "';";


                    comando.CommandText = consultaSql;

                    cantDeFilasAfectadas += comando.ExecuteNonQuery();
                }

                transaccion.Commit();
                terminarConexion();

            }

            catch (MySqlException MysqlEx)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("RESGUARDO DE DATOS CUESTIONARIO: La transaccion no se pudo realizar: " + MysqlEx.Message);


            }

            catch (DataException Ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                // mostramos el mensaje del error
                MessageBox.Show("RESGUARDO DE DATOS CUESTIONARIO: La transaccion no se pudo realizar: " + Ex.Message);

            }

            if (cantDeFilasAfectadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * ====================================
         * METODOS DE RETORNO DE DATOS PUNTALES 
         * ====================================
         *      - Tiene la finalidad de BUSCAR y RETORNAR datos de la fuente según algun criterio
         */
        public Puesto existePuesto(string codigo = null, string nombreDePuesto = null)
        {
            bool conexionExitosa;
            bool bandera = false;
            Puesto objPuesto;
            GestorPuesto gestorPuesto = new GestorPuesto();
            string consultaSql = "SELECT * FROM puesto WHERE `codigo` = '" + codigo + "' OR `nombre` = '"
                + nombreDePuesto + "';";


            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
                return null;


            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();
            objPuesto = gestorPuesto.instanciarPuesto(null, null, null);

            while (reader.Read() && !bandera)
            {
                string cod = reader["codigo"].ToString();
                string nomPuesto = reader["nombre"].ToString();

                if ((codigo == cod) || (nombreDePuesto == nomPuesto))
                {
                    objPuesto = gestorPuesto.instanciarPuesto(cod, nomPuesto, null);
                }
                else
                    objPuesto = gestorPuesto.instanciarPuesto(null, null, null);
            }

            terminarConexion();
            return objPuesto;
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

        /*retorna el tiempo en dias (entero) para realizar la evaluaciones,
         se tomara este valor de la tabla 'Instrucciones de Sistema' de la BD*/
        public int darTiempoEvaluacion()
        {
            int tiempoEvaluacion = -2;
            bool conexionExitosa;

            string consultaSql = "SELECT tiempoParaContestarCuestionario FROM `instrucciones de sistema`;";

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
                tiempoEvaluacion = Int32.Parse(reader["tiempoParaContestarCuestionario"].ToString());
            }

            terminarConexion();

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

        public DateTime recuperarFechadeComienzoEvaluacion(int idPuestoEV)
        {
            bool conexionExitosa;
            DateTime fechaComienzo = new DateTime();

            string consultaSql = "SELECT DISTINCT `fecha` FROM `cuestionario_estado` cu_est " +
                "JOIN `puesto evaluado` p on (p.`idPuesto Evaluado` = '" + idPuestoEV + "') " +
                "JOIN `cuestionario` cuest on (cuest.`Puesto Evaluado_idPuesto Evaluado` = p.`idPuesto Evaluado`) " +
                "WHERE cu_est.Cuestionario_idCuestionario = cuest.idCuestionario AND Estado_idEstado = 1;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("ERROR DE CONEXION CON LA BASE DE DATOS");
                return fechaComienzo.AddDays(0); //Error de conexion
            }
            MySql.Data.MySqlClient.MySqlCommand comando;

            comando = ObjConexion.CreateCommand();

            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)//si el reader esta vacio, no se encontro el parametro buscado
            {
                MessageBox.Show("DATOS DE LA FECHA DEL PUESTO NO ENCONTRADOS");
                return fechaComienzo.AddDays(0);
            }

            while (reader.Read())
                fechaComienzo = DateTime.Parse(reader["fecha"].ToString());

            terminarConexion();

            return fechaComienzo;
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

        public List<Object> listarCandidatosPorEvaluacion(DateTime fecha_ev, string codigo_ev, int estado)
        {
            bool conexionExitosa;
            List<Candidato> listaCandidatos = new List<Candidato>();
            List<int> listaAccesos = new List<int>();
            List<Object> listaRetorno = new List<object>();
            GestorCandidatos gestorCandidatos = new GestorCandidatos();
            
            string fecha_formateada = this.formatear_fecha(fecha_ev);
            
            string consultaSql = "SELECT `tipo documento`, `nro documento`,  nombre, apellido, nroCandidato, nroEmpleado, nroAccesos" +
                " FROM cuestionario_estado cuest_est "+
                " JOIN cuestionario cuest on (idCuestionario = Cuestionario_idCuestionario) "+
                " JOIN candidato cand on ( idCandidato = Candidato_idCandidato) "+
                " WHERE Estado_idEstado = " + estado + " AND `Puesto Evaluado_idPuesto Evaluado` = (SELECT DISTINCT `idPuesto Evaluado` " +
                " FROM candidato cand " +
                " JOIN cuestionario cuest on (idCandidato = Candidato_idCandidato) " +
                " JOIN cuestionario_estado cuest_estado on (idCuestionario = Cuestionario_idCuestionario) " +
                " JOIN `puesto evaluado` puesto_ev on (`idPuesto Evaluado` =`Puesto Evaluado_idPuesto Evaluado`) " +
                " WHERE puesto_ev.codigo =  '"+ codigo_ev +"' AND fecha = '"+ fecha_formateada +"');";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos mas arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;//En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                //si el reader esta vacio, es que no se encontraron datos para la consulta realizada
                MessageBox.Show("No existen candidatos que hayan participado de esta evaluacion[Imposible!]");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                string tipoDoc = reader["tipo documento"].ToString();
                string nroDoc = reader["nro documento"].ToString();
                string nombre = reader["nombre"].ToString();
                string apellido = reader["apellido"].ToString();
                int nroAccesos = Int32.Parse(reader["nroAccesos"].ToString());
                int nroCandidato;
                if (reader["nroCandidato"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                    nroCandidato = 0;
                else
                    nroCandidato = Int32.Parse(reader["nroCandidato"].ToString());//Se lo transforma a un numero entero

                int nroEmpleado;
                if (reader["nroEmpleado"].ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                    nroEmpleado = 0;
                else
                    nroEmpleado = Int32.Parse(reader["nroEmpleado"].ToString());//Se lo transforma a un numero entero

                listaAccesos.Add(nroAccesos);

                //Llamamos al gestor de candidatos para instanciar el candidato que se obtuvo de la base de datos
                Candidato objCandidato = gestorCandidatos.instanciarCandidato(nombre, apellido, tipoDoc, nroDoc, nroCandidato, nroEmpleado);
                //El retorno del metodo del gestor es introducido en la lista de candidatos
                listaCandidatos.Add(objCandidato);
            }
            listaRetorno.Add(listaCandidatos);
            listaRetorno.Add(listaAccesos);
            terminarConexion();
            return listaRetorno;
        }

        public string formatear_fecha(DateTime fecha) 
        {
            string fecha_formateada;
            
            string mes = fecha.Month.ToString();
            string dia = fecha.Day.ToString();
            string hora = fecha.Hour.ToString();
            string minutos = fecha.Minute.ToString();
            string segundos = fecha.Second.ToString();

            if (Int32.Parse(fecha.Month.ToString()) < 10)
                mes = "0" + mes;

            if (Int32.Parse(fecha.Day.ToString()) < 10)
                dia = "0" + dia;

            if (Int32.Parse(fecha.Hour.ToString()) < 10)
                hora = "0" + hora;
            
            if (Int32.Parse(fecha.Minute.ToString()) < 10)
                minutos = "0" + minutos;
            
            if (Int32.Parse(fecha.Second.ToString()) < 10)
                segundos = "0" + segundos;

            fecha_formateada = fecha.Year + "-" + mes + "-" + dia + " " + hora + ":" + minutos + ":" + segundos;
            
            return fecha_formateada;
        }
        public List<CompetenciaEvaluada> competencias_segun_puesto(DateTime fecha_ev, string codigo_ev, int estado)
        {
            bool conexionExitosa;
            GestorEvaluacion gestor_de_Evaluacion = new GestorEvaluacion();
            List<CompetenciaEvaluada> listaCompetenciasEvaluadas= new List<CompetenciaEvaluada>();
            string fecha_formateada = this.formatear_fecha(fecha_ev);

            string consultaSql = "SELECT ponderacion , codigo, nombre " +
                    " FROM `puesto evaluado_competencia evaluada` pe_ce " +
                    " JOIN `competencia evaluada` comp_ev on (`idCompetencia Evaluada` = `Competencia Evaluada_idCompetencia Evaluada`) " +
                    " WHERE `Puesto Evaluado_idPuesto Evaluado` = (SELECT `idPuesto Evaluado` " +
                    " FROM candidato cand " +
                    " JOIN cuestionario cuest on (idCandidato = Candidato_idCandidato) " +
                    " JOIN cuestionario_estado cuest_estado on (idCuestionario = Cuestionario_idCuestionario) " +
                    " JOIN `puesto evaluado` puesto_ev on (`idPuesto Evaluado` =`Puesto Evaluado_idPuesto Evaluado`) " +
                    " WHERE puesto_ev.codigo =  '" + codigo_ev + "' AND fecha = '" + fecha_formateada + "');";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos mas arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;//En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                //si el reader esta vacio, es que no se encontraron datos para la consulta realizada
                MessageBox.Show("No existen competencias asociadas a esta evaluacion[Imposible!]");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                
                string codigo = reader["codigo"].ToString();
                string nombre = reader["nombre"].ToString();
                
                int ponderacion = Int32.Parse(reader["ponderacion"].ToString());

                CompetenciaEvaluada competencia_ev = gestor_de_Evaluacion.instanciarCompetenciaEvaluda(codigo, nombre);
                competencia_ev.Ponderacion = ponderacion;

                listaCompetenciasEvaluadas.Add(competencia_ev);
            }

            terminarConexion();
            return listaCompetenciasEvaluadas;

        }

        public int cantidad_De_Preguntas_Por_Competencia(string codigo_de_competencia, DateTime fecha_ev, string codigo_ev, int estado)
        {
            bool conexionExitosa;
            GestorEvaluacion gestor_de_Evaluacion = new GestorEvaluacion();
            List<CompetenciaEvaluada> listaCompetenciasEvaluadas = new List<CompetenciaEvaluada>();
            string fecha_formateada = this.formatear_fecha(fecha_ev);
            int cantidad_preguntas = -1; 

            string consultaSql = "SELECT COUNT(*) " +
                " FROM `factor evaluado` fa " +
                " JOIN `pregunta evaluada` pe on( `Factor Evaluado_idFactor Evaluado` = `idFactor Evaluado`) " +
                " WHERE `Competencia Evaluada_idCompetencia Evaluada` = (SELECT `idCompetencia Evaluada` " +
                " FROM `puesto evaluado_competencia evaluada` pe_ce " +
                " JOIN `competencia evaluada` comp_ev on (codigo = '" + codigo_de_competencia + 
                "' AND `Competencia Evaluada_idCompetencia Evaluada` = `idCompetencia Evaluada`) " +
                " WHERE `Puesto Evaluado_idPuesto Evaluado` = (SELECT `idPuesto Evaluado` " +
                " FROM candidato cand " +
                " JOIN cuestionario cuest on (idCandidato = Candidato_idCandidato) " +
                " JOIN cuestionario_estado cuest_estado on (idCuestionario = Cuestionario_idCuestionario) " +
                " JOIN `puesto evaluado` puesto_ev on (`idPuesto Evaluado` =`Puesto Evaluado_idPuesto Evaluado`)" +
                " WHERE puesto_ev.codigo =  '" + codigo_ev + "' AND fecha = '" + fecha_formateada + "');";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return -1;
            }

            //Creamos un adaptador llamado "comando" para realizar la consultaSql que definimos mas arriba
            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;//En el adaptador comando hacemos un asignacion en su atributo CommandText de la consultaSql

            //Se hace la ejecucion del comando con el metodo ExecuterReader 
            //y se lo asigna a una variable reader que contendra los resultados de la busqueda en la base de datos
            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                //si el reader esta vacio, es que no se encontraron datos para la consulta realizada
                MessageBox.Show("No existen preguntas asociadas a esta competencia de esta evaluacion[Imposible!]");
                terminarConexion();
                return -1;
            }

            while (reader.Read())
            {
                cantidad_preguntas = Int32.Parse(reader["COUNT(*)"].ToString());

            }

            terminarConexion();
            return cantidad_preguntas;

        }


         /*
         * - RecuperarCompetenciasEvaludas tiene la misión de recuperar una competencia evaluada según su ID
         *   que corresponde a la BASE DE DATOS
         */
        public List<Competencia> recuperarCompetencias(string codigoCompetencia)
        {
            bool conexionExitosa;
            GestorCompetencias gestorCompetencias = new GestorCompetencias();
            List<Competencia> listaDeCompetencias = new List<Competencia>();//Para el retorno de datos

            string consultaSql = "SELECT * FROM `competencia` AS comp"
                + "WHERE comp.codigo ='" + codigoCompetencia + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("No se realizo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("El puesto no posee competencias para ser evaluado");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                //Verificamos que la competencia no este eliminada
                Competencia competenciaEv;

                if (reader["eliminado"].ToString() == "")
                {
                    string cod = reader["codigo"].ToString();
                    string nomComp = reader["nombre"].ToString();
                    string descrip = reader["descripcion"].ToString();

                    //Si no fue eliminada, la instaciamos con el gestor de evaluacion con los datos obtenidos
                    competenciaEv = gestorCompetencias.instanciarCompetencia(cod, nomComp, descrip);
                }
                else//Si fue eliminada, instanciamos una competencia con el atrubuto 'codigo' inicializado en ELIMINADA
                    competenciaEv = gestorCompetencias.instanciarCompetencia("ELIMINADA", null, null);

                listaDeCompetencias.Add(competenciaEv);
            }

            terminarConexion();

            //Agregamos la lista de Factores para cada una de las competencias encontradas
            for (int i = 0; i < listaDeCompetencias.Count; i++)
            {
                //Recuperamos los factores asociados a la competencia
                List<Factor> factoresList = recuperarFactores(listaDeCompetencias[i]);

                for (int j = 0; j < factoresList.Count; j++)
                {
                    //Para la competencia Evaluada que esta resguardada en la posición i 
                    //le agregamos a su lista de factores, el factor evaluado que se encentre en la posición j
                    listaDeCompetencias[i].addFactor(factoresList[j]);
                }
            }

            return listaDeCompetencias;
        }

        /*
         * - RecuperarFactoresEvaludos tiene la misión de recuperar los factores evaluados para una competencia puntual
         *   de a la BASE DE DATOS
         */
        public List<Factor> recuperarFactores(Competencia competenciaAsociada)
        {
            bool conexionExitosa;
            GestorFactores gestorFactores = new GestorFactores();
            List<Factor> listaDeFactores = new List<Factor>();//Para el retorno de datos

            string consultaSql = "SELECT `factor evaluado`.nombre ,`factor evaluado`.codigo ,nroOrden " +
            "FROM `factor evaluado` " +
            "JOIN `competencia evaluada` comEv on (comEv.`codigo` = '" + competenciaAsociada.Codigo + "') " +
            "WHERE `factor evaluado`.`Competencia Evaluada_idCompetencia Evaluada` = comEv.`idCompetencia Evaluada`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("No se realizo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("El puesto no posee competencias para ser evaluado");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {   
                string cod = reader["codigo"].ToString();
                string nomFactor = reader["nombre"].ToString();
                int nrOrden = Int32.Parse(reader["nroOrden"].ToString());
                //Ahora vamos a crear una instancia del objeto factor, a través del gestor de factores 
                Factor factorEv = gestorFactores.instanciarFactor(cod, nomFactor, competenciaAsociada, null, nrOrden);
                listaDeFactores.Add(factorEv);
            }
            terminarConexion();
    
            //Agregamos la lista de Factores para cada una de las competencias encontradas
            for (int i = 0; i < listaDeFactores.Count; i++)
            {
                List<Pregunta> preguntasList = recuperarPreguntas(listaDeFactores[i]);
                if (preguntasList[i] != null)
                {
                    for (int j = 0; j < preguntasList.Count; j++)
                    {
                        listaDeFactores[i].addPregunta(preguntasList[j]);
                    }
                }
                /*else
                    listaDeFactores.Add(preguntasList[i]);*/
            }

            return listaDeFactores;
        }

        /*
         * - RecuperarPreguntas evaluadas tiene la misión de recuperar Las preguntas evaluadas para Un factor puntual
         *   de a la BASE DE DATOS
         */
        public List<Pregunta> recuperarPreguntas(Factor factorAsociado)
        {
            bool conexionExitosa;
            GestorPreguntas gestorPreguntas = new GestorPreguntas();
            List<Pregunta> listaDePreguntas = new List<Pregunta>();

            string consultaSql = "SELECT `pregunta evaluada`.nombre ,`pregunta evaluada`.codigo, `pregunta evaluada`.pregunta, `pregunta evaluada`.`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada` "
            + "FROM `pregunta evaluada` "
            + "JOIN `factor evaluado` fac on (fac.`codigo` = '" + factorAsociado.Codigo + "') "
            + "WHERE `pregunta evaluada`.`Factor Evaluado_idFactor Evaluado` = fac.`idFactor Evaluado`;";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("No se realizo la conexion con la base de datos");
                terminarConexion();
                return null;
            }


            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("El factor no posee preguntas para ser evaluado");
                terminarConexion();
                return null;
            }

            List<int> listaIdOpRespuesta = new List<int>();
            while (reader.Read())
            {
                string cod = reader["codigo"].ToString();
                string nomPreg = reader["nombre"].ToString();
                string preg = reader["pregunta"].ToString();
                int idOpRespuesta = Int32.Parse(reader["Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada"].ToString());

                Pregunta pregunta = gestorPreguntas.instanciarPregunta(preg, nomPreg, factorAsociado);
                listaDePreguntas.Add(pregunta);
                listaIdOpRespuesta.Add(idOpRespuesta);
            }
            terminarConexion();

            //Agregamos la listas de Opciones de respuesta y las opciones para cada una de las preguntas encontradas
            for (int i = 0; i < listaDePreguntas.Count; i++)
            {
                //Se recuperan la opcion de respuesta de la pregunta
                List<OpciondeRespuesta> opcionesRespuesta = recuperarOpcionRespuesta(listaIdOpRespuesta[i]);
                if (opcionesRespuesta[0] != null)
                {
                    //Recuperamos la opcion que contiene la poneracion para esa pregunta
                    List<Opciones> opciones = recuperarOpciones(listaDePreguntas[i]);
                    //Completamos el objeto Opciones_de_respuestas_evaludas con la lista de opciones
                    opcionesRespuesta[0].ListaOpciones = opciones;
                    
                    //Realizamos la asignacion de la opcion de respuesta y las opciones corespondientes para la pregunta
                    listaDePreguntas[i].OpcionRespuesta_Asociada = opcionesRespuesta[0];
                    listaDePreguntas[i].ListaOpciones = opciones;
                }
            }

            return listaDePreguntas;
        }
        
        /*
         * - RecuperarOpcionesEvaludas tiene la misión de recuperar las opciones evaluadas para una pregunta puntual
         *   de a la BASE DE DATOS
         */
        public List<Opciones> recuperarOpciones(Pregunta pregAsociada)
        {
            bool conexionExitosa;
            GestorOpRespuesta gestionOpciones = new GestorOpRespuesta();
            List<Opciones> listaDeOpciones = new List<Opciones>();//Para el retorno de datos 

            string consultaSql = "SELECT op.nombre, pr_op.ponderacion, opr_op.ordenDeVisualizacion "
            + "FROM `tp base de datos`.`pregunta evaluada_opcion evaluada` pr_op "
            + "JOIN `tp base de datos`.`pregunta evaluada` pr on (pr_op.`Pregunta Evaluada_idPregunta Evaluada` = pr.`idPregunta Evaluada` AND pr.codigo = '" + pregAsociada.Nombre + "') "
            + "JOIN `tp base de datos`.`opcion evaluada` op on (pr_op.`Opcion Evaluada_idOpcion` = op.idOpcion) "
            + "JOIN `tp base de datos`.`opcion de respuesta evaluada_opcion evaluada` opr_op on (pr_op.`Opcion Evaluada_idOpcion` = opr_op.`Opcion Evaluada_idOpcion`) "
            + "GROUP BY nombre, ponderacion, ordenDeVisualizacion;";

            //llamamos al metodo "iniciar conexion"
            conexionExitosa = iniciarConexion();

            //Evaluamos si la conexion se realizo con exito
            if (!conexionExitosa)
            {
                MessageBox.Show("Fallo la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a ese candidato
                MessageBox.Show("No se entraron opciones para la pregunta solicitada");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                //opc.nombre, opR_opc.ordenDeVisualizacion, pr.`idPregunta Evaluada`
                string nomOpcion = reader["nombre"].ToString();
                int ponderacion = Int32.Parse(reader["ponderacion"].ToString());
                int ordenVisualizacion = Int32.Parse(reader["ordenDeVisualizacion"].ToString());

                Opciones preguntaEv = gestionOpciones.instanciarOpcion(nomOpcion, ponderacion, ordenVisualizacion);
                listaDeOpciones.Add(preguntaEv);
            }

            terminarConexion();
            
            return listaDeOpciones;
        }

        /*
         * - RecuperarOpcionRespuestaEvaluda tiene la misión de recuperar las opciones evaluadas para una pregunta puntual
         *   de a la BASE DE DATOS
         */
        public List<OpciondeRespuesta> recuperarOpcionRespuesta(int idOpcionDeRespuesta)
        {
            bool conexionExitosa;
            GestorOpRespuesta gestorOpcionResp = new GestorOpRespuesta();
            List<OpciondeRespuesta> listaDeOpRespuesta = new List<OpciondeRespuesta>();//Para el retorno de datos

            string consultaSql = "SELECT * FROM `opcion de respuesta evaluada` opcRes WHERE opcRes.`idOpcion de Respuesta Evaluada` = '" + idOpcionDeRespuesta + "';";

            conexionExitosa = iniciarConexion();

            if (!conexionExitosa)
            {
                MessageBox.Show("No se pudo realizar la conexion con la base de datos");
                terminarConexion();
                return null;
            }

            MySql.Data.MySqlClient.MySqlCommand comando;
            comando = ObjConexion.CreateCommand();
            comando.CommandText = consultaSql;

            MySqlDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            { //si el reader esta vacio, es qe no encontro a esa opcion de respuesta evaluada
                MessageBox.Show("No se encontro la opcion de respuesta solicitada");
                terminarConexion();
                return null;
            }

            while (reader.Read())
            {
                string nomOpcionResp = reader["nombre"].ToString();
                string codigo = reader["codigo"].ToString();

                OpciondeRespuesta OpcionResp = gestorOpcionResp.instanciarOpcionDeRespuesta(nomOpcionResp, codigo);
                listaDeOpRespuesta.Add(OpcionResp);
            }
            terminarConexion();
            
            return listaDeOpRespuesta;
        }           
        
        }
}
