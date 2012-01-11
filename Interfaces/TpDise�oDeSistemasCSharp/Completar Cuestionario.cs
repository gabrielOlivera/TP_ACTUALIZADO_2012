using System;
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

        public Completar_Cuestionario(Bloque bloqueAsociado)
        {
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.DayOfWeek.ToString();
            this.mostrarPreguntas(bloqueAsociado);
            this.bloque_A_mostrar = bloqueAsociado;
        }

        public void mostrarPreguntas(Bloque bloqueAsociado)
        {
            int cadena_pregunta_mas_larga = 0;
            int cadena_opcion_mas_larga = 0;
            int tamanio_especioPregunta_anterior = 0;
            List<Caracteristica> listaChecks = new List<Caracteristica>();
            
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
                    Label opcion = new Label();
                    for (int indice = 0; indice < pregunta_A_mostrar.ListaOpcionesEv.Count; indice++)
                    {
                        if (ordenVisualizacionOpcion == pregunta_A_mostrar.ListaOpcionesEv[indice].OrdenDeVisualizacion)
                        {
                            ordenVisualizacionOpcion = pregunta_A_mostrar.ListaOpcionesEv[indice].OrdenDeVisualizacion;

                            opcion.Text = pregunta_A_mostrar.ListaOpcionesEv[indice].Nombre;
                        }
                    }

                    this.ubicarOpcion(espacioPregunta, opcion, ordenVisualizacionOpcion, cadena_opcion_mas_larga + 5);
                    ordenVisualizacionOpcion++;
                }

                espacioPregunta.AutoSize = true;
                panel_pregunta.Controls.Add(espacioPregunta);
                tamanio_especioPregunta_anterior = espacioPregunta.Bottom;
            }
        }

        private void ubicarOpcion(GroupBox espacioPreguntas, Label opcion, int ordenVisualizacion, int distanciaMaxima)
        {

            Caracteristica elementos;
            CheckBox checkPregunta = new CheckBox();

            if (opcion.Text != "")
            {
                int selecionDeParidad = (ordenVisualizacion % 2);

                switch (selecionDeParidad == 0)
                {
                    case true://Ubicacion mas a la derecha
                        {
                            ordenVisualizacion--;
                            opcion.Location = new Point((espacioPreguntas.Height + distanciaMaxima) + 200, (ordenVisualizacion * 20) + 5);
                            checkPregunta.Location = new Point((espacioPreguntas.Height + distanciaMaxima) + 180, (ordenVisualizacion * 20));

                            elementos.dato1 = opcion;
                            elementos.dato2 = checkPregunta;

                            espacioPreguntas.Controls.Add((Label)elementos.dato1);
                            espacioPreguntas.Controls.Add((CheckBox)elementos.dato2);
                        }
                        break;
                    case false://Ubicacion mas a la izquierda
                        {
                            opcion.Location = new Point(espacioPreguntas.Height + 20, (ordenVisualizacion * 20) + 5);
                            checkPregunta.Location = new Point(espacioPreguntas.Height, (ordenVisualizacion * 20));

                            elementos.dato1 = opcion;
                            elementos.dato2 = checkPregunta;

                            espacioPreguntas.Controls.Add((Label)elementos.dato1);
                            espacioPreguntas.Controls.Add((CheckBox)elementos.dato2);
                        }
                        break;
                }
            }
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            if (this.Siguiente.Text != "Finalizar")
            {
                GestorCuestionario gestorCuestionario = new GestorCuestionario();
                Bloque proximoBloque = gestorCuestionario.proximoBloque(this.bloque_A_mostrar);
                MessageBox.Show(proximoBloque.EsUltimoNloque.ToString());
                Completar_Cuestionario siguienteBloque = new Completar_Cuestionario(proximoBloque);

                if (proximoBloque.EsUltimoNloque == true)
                    siguienteBloque.Siguiente.Text = "Finalizar";

                siguienteBloque.ShowDialog();

            }
            else
            {
                MessageBox.Show("TERMINO LA EVALUACION");
                this.Close();
            }
        }
    }
}
