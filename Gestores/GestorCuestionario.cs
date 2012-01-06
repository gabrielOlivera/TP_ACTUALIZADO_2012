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
    public class GestorCuestionario
    {
        AdministradorBD admBD = new AdministradorBD();
        GestorEvaluacion gestorEvaluacion = new GestorEvaluacion();

        /*
         * La mision que justifica la existencia de los gestores es hacer de "interfaz" entre las ENTIDADES y el resto del sistema
         * Por esto el gestor debe tener la responsabilidad de instanciar la/s que le corresponde gestionar
         */
        public Cuestionario instanciarCuestionario(Candidato canditoAsociado, string claveCuestionario, PuestoEvaluado puestoEvAsociado, int maxAccesos = 0, int accesos = 0, Bloque bloqueAsociado = null)
        {
            Cuestionario nuevoCuestionario = new Cuestionario(canditoAsociado, claveCuestionario, puestoEvAsociado, maxAccesos, accesos, bloqueAsociado);
            return nuevoCuestionario;
        }

        public Estado instanciarEstado(Cuestionario cuestAsociado, string _estado, DateTime fecha)
        {
            Estado nuevoEstado = new Estado(cuestAsociado, _estado, fecha);
            return nuevoEstado;
        }

        //recupera el cuestionario activo, si lo tuviere, para el candidato pasado como parametro
        public Cuestionario cuestionarioAsociado(Candidato candidatoAsociado)
        {
            //Se solicita a la base de datos el retorno del cuestionario activo para el candidato que se pasa como parametro
            List<Cuestionario> retornoBD_cuestionario = admBD.recuperarCuestionarioActivo(candidatoAsociado);
            Cuestionario nuevoCuest = null;

            if (retornoBD_cuestionario != null)
            {
                if (retornoBD_cuestionario[0].Clave != "NO POSEE")
                {
                    if (retornoBD_cuestionario[0].PuestoEvaluado.Codigo != "ELIMINADO")
                    {
                        if (retornoBD_cuestionario[0].Estado.Estado_ == "ACTIVO" || retornoBD_cuestionario[0].Estado.Estado_ == "EN PROCESO")
                        {//Transforma el retorno de la base de datos en un objeto del tipo cuestionario
                            nuevoCuest = retornoBD_cuestionario[0];
                        }
                        else
                            return this.instanciarCuestionario(null, "LOS TIEMPOS VENCIERON PARA REALIZAR LA EVALUACIÓN", null);
                    }
                    else
                        return this.instanciarCuestionario(null, "EL PUESTO DE EVALUACION FUE ELIMINADO", null);
                }
                else
                    return this.instanciarCuestionario(null, "NO POSEE UN CUESTIONARIO PARA SER EVALUADO", null);
            }

            return nuevoCuest;
        }

        //valida que el candidato poseea un cuestionario en algun estado valido
        public bool validarAcceso(Cuestionario cuest, string claveUs)
        {
            bool retorno = false; //por defecto se lo dejo como falso.. MIRAR DESPUES
            string estado = cuest.obtenerEstado();
            switch(estado)
            {
                case "ACTIVO":
                    switch (Equals(cuest.Clave, claveUs))//se fija si la clave guardada en el cuestionario sea = a la pasada como parametro
                    {
                        case true: 
                            retorno = true;
                            break;
                        case false:
                            MessageBox.Show("La clave ingresada no es valida"); //a la interfaz
                            retorno = false;
                            break;
                    }
                    break;
                case "EN PROCESO":
                    switch (Equals(cuest.Clave, claveUs))//idem anterior ... FIJARSE SI NO HAY UNA MEJOR FORMA DE HACER ESTOS SWITCH EN GRAL
                    {
                        case true: 
                            retorno = true;
                            break;
                        case false:
                            MessageBox.Show("La clave ingresada no es valida");
                            retorno = false;
                            break;
                    }
                    break;
                default:
                    MessageBox.Show("El candidato no posee un cuestionario 'En proceso' o 'Activo'");
                    retorno = false;
                    break;
            }
            return retorno;
        }

        public ArrayList crearCuestionario(Candidato candidatoAsociado)
        {
            ArrayList procesoFinalizado = new ArrayList();
            //Vamos a buscar primero el cuestionario Activo asociado al candidato si lo tubiere
            List<Cuestionario> retornoBD_cuestionario = admBD.recuperarCuestionarioActivo(candidatoAsociado);
            Cuestionario nCuestionario = retornoBD_cuestionario[0];//Asignamos el retorno para usar la variable
            
            //Re-armamos las relaciones del cuestionario para tener todos los objetos en memoria
            bool re_construido = admBD.reconstruirRelaciones(nCuestionario);

            if (!re_construido)
            {
                procesoFinalizado.Add("No se pudo recuperar Todos los datos requeridos");
                return procesoFinalizado;
            }
            int accesos = nCuestionario.NroAccesos;
            int maxAccesos = nCuestionario.MaxAccesos;
            string estadoCuestionario = nCuestionario.obtenerEstado();

            switch (accesos <= maxAccesos)
            {
                case true:
                    PuestoEvaluado puestoEv = nCuestionario.PuestoEvaluado;
                    DateTime fechaComienzoEvaluacion = gestorEvaluacion.obtenerFechaEvaluacion(puestoEv);
                    //tiempo del sistema es el tiempo en dias que se prevee para la evaluación
                    int tiempoSist = admBD.darTiempoEvaluacion();

                    //tiempo actual es el tiempo transcurrido en dias desde el se inicio de la evaluacion
                    int tiempoActual = DateTime.Now.DayOfYear - fechaComienzoEvaluacion.DayOfYear;

                    switch (tiempoActual <= tiempoSist)
                    {
                        case true:
                            //tiempo maximo es el tiempo maximo para realizar el cuestionario desde que se comienza
                            int tiempoMax = admBD.darTiempoActivo();
                            DateTime fechaCuestionario = nCuestionario.obtenerFechaEstado();
                            //tiempo activo es el tiempo que transcurrio desde que se comenzo a realizar el cuestionario
                            int tiempoActivo = DateTime.Now.DayOfYear - fechaCuestionario.DayOfYear;
                            MessageBox.Show("tiempo activo: " + tiempoActivo.ToString() + " tiempo max: " + tiempoMax.ToString()+" fecha cuestionario:"+ fechaCuestionario.ToString());

                            switch (tiempoActivo <= tiempoMax)
                            {
                                case true:
                                    switch (estadoCuestionario)
                                    {
                                        case "En proceso":
                                            Bloque bloq_retorno = levantarCuestionario(nCuestionario);
                                            procesoFinalizado.Add(bloq_retorno);
                                            break;
                                        case "Activo":
                                            procesoFinalizado.Add("instrucciones"); //va al objeto interfaz
                                            break;
                                    }
                                    break;
                                case false:
                                    cerrarCuestionario(nCuestionario, estadoCuestionario);
                                    procesoFinalizado.Add("Se supero el tiempo para estar Activo establecido para completar el cuestionario");
                                    break;
                            }
                            break;
                        case false:
                            cerrarCuestionario(nCuestionario, estadoCuestionario);
                            procesoFinalizado.Add("Supero el tiempo maximo permitido para completar el cuestionario");
                            break;
                    }
                    break;
                case false:
                    cerrarCuestionario(nCuestionario, estadoCuestionario);
                    procesoFinalizado.Add("Supero la cantidad maxima de accesos permitida para completar el cuestionario");
                    break;
            }
            return procesoFinalizado;
        }

        public Bloque inicializarCuestionario(Cuestionario cuestionario)
        {
            PuestoEvaluado pEv = cuestionario.PuestoEvaluado;
            List<PreguntaEvaluada> listaPreguntas = gestorEvaluacion.listarPreguntas(pEv);
            ordenarListaAleatorio(listaPreguntas);
            int pregXbloque = admBD.preguntasPorBloque();
            this.crearBloque(listaPreguntas, pregXbloque, cuestionario);
            this.cambiarEstado("En proceso", cuestionario);
            cuestionario.aumentarAcceso();
            Bloque bloq_ = cuestionario.UltimoBloque;
            return bloq_;
        }

        public Bloque levantarCuestionario(Cuestionario cuestionario) 
        {
            cuestionario.aumentarAcceso();
            //HAY QUE MIRAR SI ESTA INSTANCIADO EL BLOQUE Q VAMOS A TRAER !!!
            Bloque bloq_ = cuestionario.UltimoBloque;
            return bloq_;
        }

        public void cerrarCuestionario(Cuestionario cuestionario, string estado)
        {
            switch (estado)
            {
                case "Activo":
                    this.cambiarEstado("Sin contestar", cuestionario);
                    break;
                case "En proceso":
                    this.cambiarEstado("Imcompleto", cuestionario);
                    break;
            }
        }
        
        public void guardarRespuestas(Cuestionario cuestAsociado, List<Caracteristica> respuestaUsuario)
        {
            Respuestas Respuesta = new Respuestas(cuestAsociado);
            for (int i = 0; i < respuestaUsuario.LongCount(); i++)
            {
                Respuesta.addRespueta((PreguntaEvaluada)respuestaUsuario[i].dato1, (OpcionesEvaluadas)respuestaUsuario[i].dato2);
            }
            admBD.guardarRespuesta(Respuesta);
        }
        
        public Bloque proximoBloque(Bloque bloqAnterior)
        {
            AdministradorBD admBD = new AdministradorBD();  //intanciacion del administrador base de datos
            Cuestionario cuestAsociado = bloqAnterior.CuestAsociado;

            int nroProxBloque = bloqAnterior.NroBloque;
            nroProxBloque += 1;
            List<Bloque> retornoBD_Bloque = admBD.retornarProximoBloque(cuestAsociado, nroProxBloque);
            Bloque proxBloque = retornoBD_Bloque[0];
            cuestAsociado.UltimoBloque = proxBloque; //seteo el ultimo bloque
            return proxBloque;
        }

        public void crearBloque(List<PreguntaEvaluada> listaPreguntas, int pregXbloque, Cuestionario cuest)
        {
            int numBloq = 0, j, contadorDeBloqueCreados = 0;
            int cantidadBloques = (listaPreguntas.Count / pregXbloque);

            for (int i = 0; i <= listaPreguntas.Count; i++)
            {
                AdministradorBD admBD = new AdministradorBD();  //intanciacion del administrador base de datos

                Bloque nuevoBloque = new Bloque(numBloq++, cuest);
                PreguntaEvaluada preg;
                for (j = 0; j <= pregXbloque; j++)
                {
                    preg = listaPreguntas[j];
                    nuevoBloque.addPreguntaEv(preg);
                }
                contadorDeBloqueCreados += 1;
                i += j;
                switch (contadorDeBloqueCreados == cantidadBloques)
                {
                    case true:
                        {
                            nuevoBloque.marcarUltimobloque();
                            admBD.guardarBloque(nuevoBloque); // mensaje se envia al Adm de BD
                        }
                        break;
                    default:
                        admBD.guardarBloque(nuevoBloque); // mensaje se envia al Adm de BD
                        break;
                }
            }
        }

        public void cambiarEstado(string alEstado, Cuestionario cuest)
        {
            AdministradorBD admBD = new AdministradorBD();  //intanciacion del administrador base de datos

            Estado nuevoEstado = new Estado(cuest, alEstado);
            cuest.Estado = nuevoEstado;
            admBD.guardarEstado(cuest.Estado); //se lo envia al Adm BD
        }

        internal void ordenarListaAleatorio(List<PreguntaEvaluada> listaPreguntas) 
        {
            listaPreguntas.Sort();
        } //establecer una forma de ordenamiento aleatorio... MIRAR
    }
}
