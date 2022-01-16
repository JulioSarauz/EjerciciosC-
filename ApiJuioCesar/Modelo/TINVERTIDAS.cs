using System.ComponentModel.DataAnnotations;
using System;

namespace ApiJuioCesar.Modelo
{
    public class TINVERTIDAS
    {

        [Key]
        public int id_invertida { get; set; }

        public string mensaje { get; set; }

        public string fecha { get; set; }

        public string estado { get; set; }

        static string invertirPalabra(string cadena)
        {
            string palabraInvertida = "";
            for (int i = cadena.Length-1; i > -1; i--)
            {
               palabraInvertida += cadena[i];
            }
            return palabraInvertida;

        }
        static void guardarArchivoLog(string mensaje, string fecha, string estado)
        {
            string informacion = "mensaje: " + mensaje + "; fecha:" + fecha + "; estado:" + estado + "\n";
            System.IO.File.AppendAllText("../ApiJuioCesar/Logs/LogEjercicio5.txt", informacion);
        }

        public TINVERTIDAS obtenerInformacion(string cadena)
        {
            //error estado = 0
            //informativo estado = 1
            TINVERTIDAS datosGuardar = new TINVERTIDAS();
            string mensaje = "";
            string fecha = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            string estado = "1";
            try
            {
                
                mensaje = invertirPalabra(cadena);

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
