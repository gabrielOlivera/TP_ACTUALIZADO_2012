﻿using System;
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
        public Cuestionario instanciarCuestionario(Candidato canditoAsociado, string claveCuestionario, PuestoEvaluado puestoEvAsociado, int accesos = 0)
        {
            int maxAccesos = admBD.darAccesosMaximos();
            Cuestionario nuevoCuestionario = new Cuestionario(canditoAsociado, claveCuestionario, puestoEvAsociado, maxAccesos, accesos, null);
            return nuevoCuestionario;
        }

        public Bloque instanciarBloque(int nro_Bloq, Cuestionario cuest)
        {
            Bloque nuevoBloque = new Bloque(nro_Bloq, cuest);
            return nuevoBloque;
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
            List<Cuestionario> nCuestionario = admBD.recuperarCuestionarioActivo(candidatoAsociado);
            Cuestionario nuevoCuest = null;

            if (nCuestionario != null)
            {
                if (nCuestionario[0].Clave != "NO POSEE")
                {
                    if (nCuestionario[0].PuestoEvaluado.Codigo != "ELIMINADO")
                    {
                        if (nCuestionario[0].Estado.Estado_ == "ACTIVO" || nCuestionario[0].Estado.Estado_ == "EN PROCESO")
                        {//Transforma el retorno de la base de datos en un objeto del tipo cuestionario
                            nuevoCuest = nCuestionario[0];
                        }
                        else
                            return this.instanciarCuestionario(null, "LOS TIEMPOS VENCIERON PARA REALIZAR LA EVALUACIÓN", null, 0);
                    }
                    else
                        return this.instanciarCuestionario(null, "EL PUESTO DE EVALUACION FUE ELIMINADO", null, 0);
                }
                else
                    return this.instanciarCuestionario(null, "NO POSEE UN CUESTIONARIO PARA SER EVALUADO", null, 0);
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

        private int determinarCantidad_DeDiasPasados(DateTime fecha_cuestionario)
        {
            int diasPasados = -1, añosPasados;
            DateTime fecha_de_Actual = DateTime.Now;

            añosPasados = this.derterminarAño(fecha_cuestionario);
            if (añosPasados != -1)
            {
                if (añosPasados == 0)//SON FECHAS DEL MISMO AÑO
                {
                    switch (fecha_de_Actual.CompareTo(fecha_cuestionario))
                    {
                        case 1://La fecha del cuestionario es anterior 
                            diasPasados = fecha_de_Actual.DayOfYear - fecha_cuestionario.DayOfYear;
                            break;
                        case 0://La fecha del cuestionario es igual
                            diasPasados = 0;
                            break;
                        case -1://La fecha del cuestionario es posterior -> error: ninguna fecha puede ser mayor a la actual
                            diasPasados = -1;
                            break;
                    }
                }

                else //DIFERENTES AÑOS
                {
                    if ((fecha_de_Actual.CompareTo(fecha_cuestionario)) == 1)//La fecha del cuestionario es anterior
                    {
                        int aux;
                        aux = fecha_cuestionario.DayOfYear - fecha_de_Actual.DayOfYear;
                        diasPasados = (añosPasados * 365) - aux;
                    }
                    else //La fecha del cuestionario es igual. La fecha del cuestionario es posterior -> error: ninguna fecha puede ser mayor a la actual
                        diasPasados = -1;
                }
            }

            return diasPasados;
        }

        private int derterminarAño(DateTime fecha_cuestionario)
        {
            int añosPasados = 0;
            DateTime fecha_de_actual = DateTime.Now;

            switch (fecha_de_actual.Year.CompareTo(fecha_cuestionario.Year))
            {
                case 1://El año del cuestionario es anterior
                    añosPasados = fecha_de_actual.Year - fecha_cuestionario.Year;
                    break;
                case 0://El año de cuestionario es igual
                    añosPasados = 0;
                    break;
                case -1://El año del cuestionario es posterior -> error el año no puede ser mayor que el de la fecha actual
                    añosPasados = -1;
                    break;
            }

            return añosPasados;
        }

        //Toma la decicion de que acción realizar para el cuestionario validado
        public ArrayList crearCuestionario(Cuestionario nCuestionario)
        {
            ArrayList procesoFinalizado = new ArrayList();
            
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
                    int tiempoActual = this.determinarCantidad_DeDiasPasados(fechaComienzoEvaluacion);
                    
                    switch (tiempoActual <= tiempoSist)
                    {
                        case true:
                            //tiempo maximo es el tiempo maximo para realizar el cuestionario desde que se comienza
                            int tiempoMax = admBD.darTiempoActivo();
                            DateTime fechaCuestionario = nCuestionario.obtenerFechaEstado();
                            //tiempo activo es el tiempo que transcurrio desde que se comenzo a realizar el cuestionario
                            int tiempoActivo = this.determinarCantidad_DeDiasPasados(fechaCuestionario);
                            
                            switch (tiempoActivo <= tiempoMax)
                            {
                                case true:
                                    {
                                        if (Equals(estadoCuestionario, "EN PROCESO") == true)
                                        {
                                            Bloque bloq_retorno = this.levantarCuestionario(nCuestionario);
                                            procesoFinalizado.Add(bloq_retorno);
                                        }
                                        else if (Equals(estadoCuestionario, "ACTIVO") == true)
                                        {
                                            procesoFinalizado.Add("instrucciones"); //va al objeto interfaz
                                            break;
                                        }
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
            if (listaPreguntas.Count != 0)
            {
                ordenarListaAleatorio(listaPreguntas);
                int pregXbloque = admBD.preguntasPorBloque();
                if (pregXbloque != -1 && pregXbloque != -2)
                {
                    bool bloques_Creados = this.crearBloque(listaPreguntas, pregXbloque, cuestionario);
                    if (bloques_Creados)
                    {
                        this.cambiarEstado("EN PROCESO", cuestionario);
                        cuestionario.aumentarAcceso();
                        Bloque bloq_ = cuestionario.UltimoBloque;
                        return bloq_;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public Bloque levantarCuestionario(Cuestionario cuestionario) 
        {
            cuestionario.aumentarAcceso();
            Bloque bloq_ = cuestionario.UltimoBloque;
            return bloq_;
        }

        public void cerrarCuestionario(Cuestionario cuestionario, string estado)
        {
            switch (estado)
            {
                case "ACTIVO":
                    this.cambiarEstado("SIN CONTESTAR", cuestionario);
                    break;
                case "EN PROCESO":
                    this.cambiarEstado("INCOMPLETO", cuestionario);
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
            Bloque proxBloque = admBD.retornarBloque(cuestAsociado, nroProxBloque);
            cuestAsociado.UltimoBloque = proxBloque; //seteo el ultimo bloque
            return proxBloque;
        }

        private bool crearBloque(List<PreguntaEvaluada> listaPreguntas, int pregXbloque, Cuestionario cuest)
        {
            AdministradorBD admBD = new AdministradorBD();  //intanciacion del administrador base de datos

            bool operacionRealizadaConExito = false;

            int numBloq = 1, contadorDeBloqueCreados = 0;
            int cantidadBloques = (listaPreguntas.Count / pregXbloque);

            for (int i = 0; i <= listaPreguntas.Count; i++)
            {
                Bloque nuevoBloque = new Bloque(numBloq, cuest);
                for (int j = 0; j <= pregXbloque; j++)
                {
                    nuevoBloque.addPreguntaEv(listaPreguntas[j]);
                }

                contadorDeBloqueCreados += 1;
                if (numBloq == 1)
                {
                    cuest.UltimoBloque = nuevoBloque;
                }
                numBloq++;
                i += pregXbloque;

                switch (contadorDeBloqueCreados == cantidadBloques)
                {
                    case true:
                        {
                            nuevoBloque.marcarUltimobloque();
                            bool echo = admBD.guardarBloque(nuevoBloque); // mensaje se envia al Adm de BD
                            if (echo)
                                operacionRealizadaConExito = true;
                            else
                            {
                                MessageBox.Show("No se pudieron resguardar los datos de su evaluación\nComuniquese con su evaluador");
                                operacionRealizadaConExito = false;
                            }
                        }
                        break;
                    default:
                        {
                            bool echo = admBD.guardarBloque(nuevoBloque); // mensaje se envia al Adm de BD
                            if (echo)
                                operacionRealizadaConExito = true;
                            else
                            {
                                MessageBox.Show("No se pudieron resguardar los datos de su evaluación\nComuniquese con su evaluador");
                                operacionRealizadaConExito = false;
                            }
                        }
                        break;
                }
            }
            return operacionRealizadaConExito;
        }

        private void cambiarEstado(string alEstado, Cuestionario cuest)
        {
            AdministradorBD admBD = new AdministradorBD();  //intanciacion del administrador base de datos

            Estado nuevoEstado = new Estado(cuest, alEstado);
            cuest.Estado = nuevoEstado;
            admBD.guardarEstado(cuest.Estado); //se lo envia al Adm BD
        }

        private void ordenarListaAleatorio(List<PreguntaEvaluada> listaPreguntas) 
        {
            listaPreguntas.Sort();
        } //establecer una forma de ordenamiento aleatorio... MIRAR
    }
}
