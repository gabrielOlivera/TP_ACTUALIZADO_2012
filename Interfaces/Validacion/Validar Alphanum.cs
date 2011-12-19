using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Validacion
{
    public class validarAlphanum
    {
        public static bool isAlphanum(char c)
        {
            return ((c >= 'a' && c <= 'z') ||
                    (c >= '0' && c <= '9') ||
                    (c >= 'A' && c <= 'Z'));
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






      





    }
}
