using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace ApiJuioCesar.Modelo
{
    public class TPALABRASREPETIDAS
    {

        [Key]
        public int id_palabra { get; set; }

        public string mensaje { get; set; }

        public string fecha { get; set; }

        public string estado { get; set; }

        static int contarPalabra(string cadena, string palabra)
        {
            int repeticiones = 0;
            cadena = cadena.ToLower();
            string cadenaLimpia = Regex.Replace(cadena, @"[^\w\s.!@$%^&*()\-\/]+", "");
            List<string> cadenaSeparada = new List<string>();
            cadenaSeparada = cadenaLimpia.Split(' ').ToList();
            for(int i = 0; i < cadenaSeparada.Count; i++)
            {
                if (cadenaSeparada[i].Equals(palabra))
                {
                    repeticiones++;
                }
            }
            return repeticiones;

        }
        static void guardarArchivoLog(string mensaje, string fecha, string estado)
        {
            string informacion = "mensaje: " + mensaje + "; fecha:" + fecha + "; estado:" + estado + "\n";
            System.IO.File.AppendAllText("../ApiJuioCesar/Logs/LogEjercicio4.txt", informacion);
        }

        public TPALABRASREPETIDAS obtenerInformacion(string cadena,string palabra)
        {
            //error estado = 0
            //informativo estado = 1
            TPALABRASREPETIDAS datosGuardar = new TPALABRASREPETIDAS();
            string mensaje = "";
            string fecha = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            string estado = "1";
            try
            {
             mensaje = "se repite "+contarPalabra(cadena,palabra)+" veces" ;
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
