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
    public partial class GenerarTextBoxsDinamicos : Form
    {
        private List<TextBox> inputTextBoxes;
        public GenerarTextBoxsDinamicos()
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.AutoSize = true;
            this.Padding = new Padding(0, 0, 20, 20);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Get the number of input text boxes to generate
            int inputNumber = Int32.Parse(textBoxInput.Text);

            //Initialize list of input text boxes
            inputTextBoxes = new List<TextBox>();

            //Generate labels and text boxes
            for (int i = 1; i <= inputNumber; i++)
            {
                //Create a new label and text box
                Label labelInput = new Label();
                TextBox textBoxNewInput = new TextBox();

                //Initialize label's property
                labelInput.Text = "Input " + i;
                labelInput.Location = new Point(30, textBoxInput.Bottom + (i * 30));
                labelInput.AutoSize = true;

                //Initialize textBoxes Property
                textBoxNewInput.Location = new Point(labelInput.Width, labelInput.Top - 3);

                //Add the newly created text box to the list of input text boxes
                inputTextBoxes.Add(textBoxNewInput);

                //Add the labels and text box to the form
                this.Controls.Add(labelInput);
                this.Controls.Add(textBoxNewInput);
            }

            //Create an Add button
            Button buttonAdd = new Button();
            //Initialize Properties
            buttonAdd.Text = "Add";
            //Make the button show up in the middle of the form and right below the last input box
            buttonAdd.Location = new Point(this.Width / 2 - buttonAdd.Width / 2,
                inputTextBoxes[inputTextBoxes.Count - 1].Bottom + 20);
            //Add an event handler to the button's click event
            buttonAdd.Click += new EventHandler(buttonAdd_Click);

            //Add the button to the form
            this.Controls.Add(buttonAdd);

            //Center the form to the screen
            this.CenterToScreen();
        }


        void buttonAdd_Click(object sender, EventArgs e)
        {
            int sum = 0;

            foreach (TextBox inputBox in inputTextBoxes)
            {
                if (inputBox.Text == String.Empty)
                {
                    MessageBox.Show("Plaese fill in all the text boxes.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    sum += Int32.Parse(inputBox.Text);
                }
            }
            MessageBox.Show("The Sum is " + sum);
        }


    }
}
