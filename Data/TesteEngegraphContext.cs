using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteEngegraph.Models;

namespace TesteEngegraph.Data
{
    public class TesteEngegraphContext : DbContext
    {
        public TesteEngegraphContext (DbContextOptions<TesteEngegraphContext> options)
            : base(options)
        {
        }

        public DbSet<TesteEngegraph.Models.Pessoa>? Pessoa { get; set; }

        public DbSet<TesteEngegraph.Models.Tipo_Pessoa>? Tipo_Pessoa { get; set; }
    }
}
