using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiJuioCesar.Modelo;

namespace ApiJuioCesar.Data
{
    public class ApiJulioCesarContext : DbContext
    {
        public ApiJulioCesarContext (DbContextOptions<ApiJulioCesarContext> options)
            : base(options)
        {
        }

        public DbSet<ApiJuioCesar.Modelo.TPALINDROMOS> TPALINDROMOS { get; set; }
    }
}
