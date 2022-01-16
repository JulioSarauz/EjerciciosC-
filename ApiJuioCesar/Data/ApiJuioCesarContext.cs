using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiJuioCesar.Modelo;

namespace ApiJuioCesar.Data
{
    public class ApiJuioCesarContext : DbContext
    {
        public ApiJuioCesarContext (DbContextOptions<ApiJuioCesarContext> options)
            : base(options)
        {
        }

        public DbSet<ApiJuioCesar.Modelo.TPRIMOS> TPRIMOS { get; set; }

        public DbSet<ApiJuioCesar.Modelo.TPALINDROMOS> TPALINDROMOS { get; set; }

        public DbSet<ApiJuioCesar.Modelo.TNUMEROSMAYORES> TNUMEROSMAYORES { get; set; }

        public DbSet<ApiJuioCesar.Modelo.TPALABRASREPETIDAS> TPALABRASREPETIDAS { get; set; }

        public DbSet<ApiJuioCesar.Modelo.TINVERTIDAS> TINVERTIDAS { get; set; }
    }
}
