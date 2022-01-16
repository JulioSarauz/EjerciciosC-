using System.ComponentModel.DataAnnotations;
using System;

namespace ApiJuioCesar.Modelo
{
    public class TPRIMOS
    {

        [Key]
        public int id_primo { get; set; }

        public string mensaje { get; set; }

        public string fecha { get; set; }

        public string estado { get; set; }

        static bool esPrimo(int numero)
        {
            bool primo = true;
            for (int i = 2; i < numero; i++)
            {
                if ((numero % i) == 0)
                {
                    primo = false;
                }
            }
            return primo;

        }
        static void guardarArchivoLog(string mensaje, string fecha, string estado)
        {
            string informacion = "mensaje: "+mensaje + "; fecha:" + fecha + "; estado:" + estado+"\n";
            System.IO.File.AppendAllText("../ApiJuioCesar/Logs/LogEjercicio1.txt", informacion);
        }

        public TPRIMOS obtenerInformacion(int numero)
        {
            //error estado = 0
            //informativo estado = 1
            TPRIMOS datosGuardar = new TPRIMOS();
            string mensaje = "No es primo:"+numero;
            string fecha = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            string estado = "1";
            try
            {
                if (esPrimo(numero))
                {
                    mensaje = "Es primo: "+numero;
                }
            }
            catch(Exception e)
            {
                mensaje = "ERROR: "+e;
                estado = "0";
            }
           

            datosGuardar.mensaje = mensaje;
            datosGuardar.fecha = fecha;
            datosGuardar.estado = estado;
            guardarArchivoLog(mensaje,fecha,estado);
            return datosGuardar;
        }

      

    }
}
