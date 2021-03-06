﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Validacion
{
    public class FuncionesVarias
    {
        public static bool isAlphanum(char c)
        {
            return ((c >= 'a' && c <= 'z') ||
                    (c >= '0' && c <= '9') ||
                    (c >= 'A' && c <= 'Z') ||
                    (c==' '));
        }
        public static bool isAlpha(char c)
        {
            return ((c >= 'a' && c <= 'z') ||
                    (c >= 'A' && c <= 'Z') ||
                    (c==' '));
        }

        public static bool isNumeric(char c)
        {
            return (c >= '0' && c <= '9');
        }


        public static bool validarCamposAlfanum(object sender)
        {
            string campo;
            int longitud, i;
            bool bandera = false;
            campo = sender.ToString();
            longitud = campo.Length;

            for (i = 0; i < longitud && !bandera; i++)
            {
                if (!(isAlphanum(campo[i])))
                {
                    bandera = true;
                }
            }
            return bandera;
        }

        public static bool validarCamposAlfa(object sender)
        {
            string campo;
            int longitud, i;
            bool bandera = false;
            campo = sender.ToString();
            longitud = campo.Length;

            for (i = 0; i < longitud && !bandera; i++)
            {
                if (!(isAlpha(campo[i])))
                {
                    bandera = true;
                }
            }
            return bandera;
        }

        public static bool validarCamposNumericos(object sender)
        {
            string campo;
            int longitud, i;
            bool bandera = false;
            campo = sender.ToString();
            longitud = campo.Length;

            for (i = 0; i < longitud && !bandera; i++)
            {
                if (!(isNumeric(campo[i])))
                {
                    bandera = true;
                }
            }
            return bandera;
        }




        // Declaramos nuestro metodo que hara la limpieza de los textbox
        public static void limpiarBoxesFormulario(Form formulario)
        {
            // hace un chequeo por todos los textbox del formulario
            foreach (Control controlDeFormulario in formulario.Controls)
            {
                if (controlDeFormulario is GroupBox)
                {
                    foreach (Control controlBox in controlDeFormulario.Controls)
                    {
                        if (controlBox is TextBox)
                        {
                            controlBox.Text = null;
                        }
                        else if (controlBox is Panel)
                        {
                            foreach (Control controlComboBox in controlBox.Controls)
                            {
                                if (controlComboBox is ComboBox)
                                {
                                    controlComboBox.Text = null;
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
