using System.ComponentModel.DataAnnotations;
using System;

namespace ApiJuioCesar.Modelo
{
    public class TPALINDROMOS
    {
        [Key]
        public int id_palindromo { get; set; }

        public string mensaje { get; set; }

        public string fecha { get; set; }

        public string estado { get; set; }

        static bool esPalindromo(string palabra)
        {
            bool palindromo = false;

            int tamanio = palabra.Length;
            string aux = palabra.Substring(0, tamanio / 2);
            char[] cadena = palabra.ToCharArray();
            Array.Reverse(cadena);
            string temp = new string(cadena);
            string original = temp.Substring(0, temp.Length / 2);
            if (aux.Equals(original))
            {
                palindromo = true;
            }


            return palindromo;

        }
        static void guardarArchivoLog(string mensaje, string fecha, string estado)
        {
            string informacion = "mensaje: " + mensaje + "; fecha:" + fecha + "; estado:" + estado + "\n";
            System.IO.File.AppendAllText("../ApiJuioCesar/Logs/LogEjercicio2.txt", informacion);
        }

        public TPALINDROMOS obtenerInformacion(string palabra)
        {
            //error estado = 0
            //informativo estado = 1
            TPALINDROMOS datosGuardar = new TPALINDROMOS();
            string mensaje = "No es palindroma:" + palabra;
            string fecha = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            string estado = "1";
            try
            {
                if (esPalindromo(palabra))
                {
                    mensaje = "Es palindroma:" + palabra;
                }
            }
            catch (Exception e)
            {
                mensaje = "ERROR: " + e;
                estado = "0";
            }


            datosGuardar.mensaje = mensaje;
            datosGuardar.fecha = fecha;
            datosGuardar.estado = estado;
            guardarArchivoLog(mensaje, fecha, estado);
            return datosGuardar;
        }

    }
}
