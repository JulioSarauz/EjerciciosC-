using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ApiJuioCesar.Modelo
{
    public class TNUMEROSMAYORES
    {
        [Key]
        public int id_numeromayor { get; set; }

        public string mensaje { get; set; }

        public string fecha { get; set; }

        public string estado { get; set; }

        static int obtenerMayor(int[] numeros)
        {
            int mayor = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                if(mayor < numeros[i])
                {
                    mayor = numeros[i];
                }
            }
            return mayor;

        }
        static void guardarArchivoLog(string mensaje, string fecha, string estado)
        {
            string informacion = "mensaje: " + mensaje + "; fecha:" + fecha + "; estado:" + estado + "\n";
            System.IO.File.AppendAllText("../ApiJuioCesar/Logs/LogEjercicio3.txt", informacion);
        }

        static int[] cadenaVector(string numeros)
        {
            List<string> vectorNumerosCadena = new List<string>();
            vectorNumerosCadena = numeros.Split(',').ToList();
            int[] vectorNumeros = new int[vectorNumerosCadena.Count];
            for (int i = 0; i < vectorNumerosCadena.Count; i++)
            {
                vectorNumeros[i] = Int32.Parse(vectorNumerosCadena[i]);
            }
            return vectorNumeros;
        }

        public TNUMEROSMAYORES obtenerInformacion(string numeros)
        {
            //error estado = 0
            //informativo estado = 1
            TNUMEROSMAYORES datosGuardar = new TNUMEROSMAYORES();
            string mensaje = "";
            string fecha = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            string estado = "1";
            try
            {  
               mensaje = "El mayor es: " + obtenerMayor(cadenaVector(numeros)); 
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
