using System.ComponentModel.DataAnnotations;

namespace ApiJuioCesar.Modelo
{
    public class TPRIMOS
    {
        
        [Key]
        public int id_primo { get; set; }

        public string mensaje { get; set; }

        public string fecha { get; set; }

        public string estado { get; set; }

        public bool esPrimo(int numero)
        {
            bool primo = true;
            for (int i = 2; i < numero; i++)
            {
                if((numero % i) == 0)
                {
                    primo = false;
                }
            }
            return primo;

        }

    }
}
