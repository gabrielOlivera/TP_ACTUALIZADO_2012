﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Gestores;

namespace TpDiseñoCSharp
{
    public partial class Completar_Cuestionario : Form
    {
        private Bloque bloque_A_mostrar;
        private List<Caracteristica> opciones_A_preguntas;

        public Completar_Cuestionario(Bloque bloqueAsociado, Form pantalla_Anterior)
        {
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.DayOfWeek.ToString();
            this.mostrarPreguntas(bloqueAsociado);
            this.bloque_A_mostrar = bloqueAsociado;

            pantalla_Anterior.Close();
        }

        /*
         * El metodo mostrarPreguntas hace la construccion en pantalla del bloque con las preguntas que se deberan responder
         */
        public void mostrarPreguntas(Bloque bloqueAsociado)
        {
            int cadena_pregunta_mas_larga = 0;
            int cadena_opcion_mas_larga = 0;
            int tamanio_especioPregunta_anterior = 0;
            CheckBox checks_mas_opciones = new CheckBox();
            this.opciones_A_preguntas = new List<Caracteristica>();
            
            for (int k = 0; k < bloqueAsociado.ListaPreguntasEv.Count; k++)
            {
                if (cadena_pregunta_mas_larga < bloqueAsociado.ListaPreguntasEv[k].Pregunta.Length)
                {
                    cadena_pregunta_mas_larga = bloqueAsociado.ListaPreguntasEv[k].Pregunta.Length;
                }

            }

            for (int i = 0; i < bloqueAsociado.ListaPreguntasEv.Count; i++)
            {
                PreguntaEvaluada pregunta_A_mostrar = bloqueAsociado.ListaPreguntasEv[i];
                
                for (int k = 0; k < pregunta_A_mostrar.ListaOpcionesEv.Count; k++)
                {
                    if (cadena_opcion_mas_larga < pregunta_A_mostrar.ListaOpcionesEv[k].Nombre.Length)
                    {
                        cadena_opcion_mas_larga = pregunta_A_mostrar.ListaOpcionesEv[k].Nombre.Length;
                    }
                }

                GroupBox espacioPregunta = new GroupBox();
                espacioPregunta.Width = cadena_pregunta_mas_larga * 8;
                espacioPregunta.Location = new Point(60 , (tamanio_especioPregunta_anterior + 10));
                espacioPregunta.Text = pregunta_A_mostrar.Pregunta;
                espacioPregunta.Anchor = AnchorStyles.Top;

                int ordenVisualizacionOpcion = 1;
                for (int j = 0; j < pregunta_A_mostrar.ListaOpcionesEv.Count; j++)
                {
                    string opcion = "";
                    for (int indice = 0; indice < pregunta_A_mostrar.ListaOpcionesEv.Count; indice++)
                    {
                        if (ordenVisualizacionOpcion == pregunta_A_mostrar.ListaOpcionesEv[indice].OrdenDeVisualizacion)
                        {
                            ordenVisualizacionOpcion = pregunta_A_mostrar.ListaOpcionesEv[indice].OrdenDeVisualizacion;

                            opcion = pregunta_A_mostrar.ListaOpcionesEv[indice].Nombre;
                        }
                    }
                    
                    checks_mas_opciones = this.ubicarOpcion(espacioPregunta, opcion, ordenVisualizacionOpcion, cadena_opcion_mas_larga + 5);
                    //Agrego el elemento a la lista de opciones_ para luego evaluar las respuestas
                    Caracteristica elementos = new Caracteristica();
                    elementos.dato1 = pregunta_A_mostrar;
                    elementos.dato2 = checks_mas_opciones;
                    this.opciones_A_preguntas.Add(elementos);

                    ordenVisualizacionOpcion++;
                }

                espacioPregunta.AutoSize = true;
                panel_pregunta.Controls.Add(espacioPregunta);
                tamanio_especioPregunta_anterior = espacioPregunta.Bottom;
            }
        }

        /*
         * Metodo ubicarOpcion: es complemetentario al mostrarPreguntas, su finalidad es ubicar en la pantalla los groupBox
         * que agruparan las opciones de respuestas posibles para una pregunta, añadiendoles un checkBox para señalar la respuesta
         * seleccionada por el usuario o candidato
         */
        private CheckBox ubicarOpcion(GroupBox espacioPreguntas, string opcion, int ordenVisualizacion, int distanciaMaxima)
        {
            CheckBox checkPregunta = new CheckBox();

            if (opcion != "")
            {
                int selecionDeParidad = (ordenVisualizacion % 2);

                switch (selecionDeParidad == 0)
                {
                    case true://Ubicacion mas a la derecha
                        {
                            ordenVisualizacion--;
                            checkPregunta.Text = opcion;
                            checkPregunta.Location = new Point((espacioPreguntas.Height + distanciaMaxima) + 180, (ordenVisualizacion * 20));

                            espacioPreguntas.Controls.Add(checkPregunta);
                        }
                        break;
                    case false://Ubicacion mas a la izquierda
                        {
                            checkPregunta.Text = opcion;
                            checkPregunta.Location = new Point(espacioPreguntas.Height, (ordenVisualizacion * 20));

                            espacioPreguntas.Controls.Add(checkPregunta);
                        }
                        break;
                }
            }
            return checkPregunta;
        }

        /* 
         * Secuencia del caso de uso a seguir luego de presionar el boton "Siguiente" (o finalizar de ser el caso)
         */
        private void Siguiente_Click(object sender, EventArgs e)
        {
            AdministradorBD admiBD = new AdministradorBD();
            GestorCuestionario gestorCuestionario = new GestorCuestionario();

            int bloque_completo = 0;
            List<Caracteristica> respuestaUsuario = new List<Caracteristica>();
            string nombre_opcion;

            for (int i = 0; i < this.opciones_A_preguntas.Count; i++)
            {
                CheckBox checks_Mas_opciones = (CheckBox)this.opciones_A_preguntas[i].dato2;
                if (Equals(checks_Mas_opciones.Checked, true) == true)
                {
                    bloque_completo++;
                    PreguntaEvaluada pregunta = (PreguntaEvaluada)opciones_A_preguntas[i].dato1;
                    nombre_opcion = checks_Mas_opciones.Text;
                    int j = 0;
                    while (j < pregunta.ListaOpcionesEv.Count)
                    {
                        if (nombre_opcion == pregunta.ListaOpcionesEv[j].Nombre)
                        {
                            Caracteristica respuestas = new Caracteristica();
                            respuestas.dato1 = pregunta;
                            respuestas.dato2 = pregunta.ListaOpcionesEv[j];

                            respuestaUsuario.Add(respuestas);

                            j = pregunta.ListaOpcionesEv.Count;
                        }
                        else
                            j++;
                    }
                }
            }

            //ESTO ME INDICA SI LA CANTIDAD DE OPCIONES SELECCIONADAS ES IGUAL A LA CANTIDAD DE PREGUNTAS DEL BLOQUE
            if (bloque_completo != this.bloque_A_mostrar.ListaPreguntasEv.Count)
            {
                MessageBox.Show("Hay preguntas que no poseen una respuesta\n\nComplete TODAS las preguntas y luego presiones 'SIGUIENTE'\n");
            }

            else
            {
                bool resguardoRealizado = gestorCuestionario.guardarRespuestas(bloque_A_mostrar.CuestAsociado, respuestaUsuario, bloque_A_mostrar.NroBloque);

                if (this.Siguiente.Text != "Finalizar")
                {
                    if (resguardoRealizado == true)
                    {
                        //UNA VEZ RESGURDADAS LAS RESPUESTAS
                        Bloque proximoBloque = gestorCuestionario.proximoBloque(this.bloque_A_mostrar);
                        Completar_Cuestionario siguienteBloque = new Completar_Cuestionario(proximoBloque, this);

                        if (proximoBloque.EsUltimoNloque == true)
                            siguienteBloque.Siguiente.Text = "Finalizar";

                        siguienteBloque.Show();
                    }
                    else
                        MessageBox.Show("! OCURRIO UN ERROR AL RESGUARDAR SUS RESPUESTA\n\n\tPor favor reinicie su sesión");

                }
                else
                {
                    if (resguardoRealizado == true)
                    {
                        gestorCuestionario.cambiarEstado("COMPLETO", bloque_A_mostrar.CuestAsociado);
                        MessageBox.Show("TERMINO LA EVALUACION");
                    }
                    else
                        MessageBox.Show("! OCURRIO UN ERROR AL RESGUARDAR SUS RESPUESTA\n\n\tPor favor reinicie su sesión");

                    this.Close();
                }
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cerrando su evaluacion.\n\nLos datos de sus respuesta actuales no serán guardados\n\nPresione 'Cancelar' y 'Siguiente' para guardarlos datos\n\nDe lo contrario presiones 'Aceptar'");
            this.Close();
        }
    }
}
