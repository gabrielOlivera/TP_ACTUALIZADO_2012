using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;
using System.Windows.Forms;

namespace Gestores
{
    public class GestorCuestionario
    {
        AdministradorBD admBD = new AdministradorBD();
        GestorEvaluacion gestorEvaluacion = new GestorEvaluacion();

        //recupera el cuestionario activo, si lo tuviere, para el candidato pasado como parametro
        public Cuestionario cuestionarioAsociado(Candidato candidatoAsociado)
        {
            ArrayList retornoBD = admBD.recuperarCuestionarioActivo(candidatoAsociado);//solicita a la base de datos el retorno del cuest
            Cuestionario nuevoCuest = (Cuestionario)retornoBD[0];//Transforma el retorno de la base de datos en un objeto del tipo cuestionario

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
            ArrayList retornoBD = admBD.recuperarCuestionarioActivo(candidatoAsociado);
            Cuestionario nCuestionario = (Cuestionario)retornoBD[0];
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
            cuestionario.crearBloque(listaPreguntas, pregXbloque);
            cuestionario.cambiarEstado("En proceso");
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
                    cuestionario.cambiarEstado("Sin contestar");
                    break;
                case "En proceso":
                    cuestionario.cambiarEstado("Imcompleto");
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
        
        public Bloque proximoBloque(Bloque bloque)
        {
            Cuestionario cuestAsociado = bloque.CuestAsociado;
            Bloque nuevoBloque = cuestAsociado.proximoBloque(bloque);
            return nuevoBloque;
        }

        internal void ordenarListaAleatorio(List<PreguntaEvaluada> listaPreguntas) 
        {
            listaPreguntas.Sort();
        } //establecer una forma de ordenamiento aleatorio... MIRAR
    }
}
