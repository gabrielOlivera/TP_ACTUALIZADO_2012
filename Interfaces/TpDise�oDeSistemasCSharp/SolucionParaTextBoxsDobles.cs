using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TpDiseñoCSharp
{
    public partial class SolucionParaTextBoxsDobles : Form
    {
        public int i = 0;
        public struct Caracteristicas
        {
            public Object Competencia;
            public Object Ponderacion;
        }
        List<Caracteristicas> CaractPuesto = new List<Caracteristicas>();

        public SolucionParaTextBoxsDobles()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            agregarTextBox(i);
            i++;
                
        }

        //Agrega los textBoxs de competencia y ponderacion y además agrega los mismos en la lista de puestos
        private void agregarTextBox(int i)
        {
            Caracteristicas Elemento;

            //Generate labels and text boxes
            //Create a new label and text box
            TextBox Comp = new TextBox();
            TextBox Pond = new TextBox();
            Elemento.Competencia = Comp;
            Elemento.Ponderacion = Pond;
            CaractPuesto.Add(Elemento);
            //Inicializa las propiedades de textBoxes 
            Comp.Location = new Point(30, (i * 30));
            Pond.Location = new Point(Comp.Width + 50, Comp.Top);

            //Add the labels and text box to the form
            panel3.Controls.Add((TextBox)Elemento.Competencia);
            panel3.Controls.Add((TextBox)Elemento.Ponderacion);
        }
        private void eliminarTextBox()
        {
            panel3.Controls.Remove((TextBox)CaractPuesto[i - 1].Competencia);
            panel3.Controls.Remove((TextBox)CaractPuesto[i - 1].Ponderacion);
            CaractPuesto.Remove(CaractPuesto[i - 1]);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (i > 0)
            {
                eliminarTextBox();
                i--;
            }
        }
    }
}
