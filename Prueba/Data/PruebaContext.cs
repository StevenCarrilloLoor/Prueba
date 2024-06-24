using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Data
{
    public class PruebaContext : DbContext
    {
        public PruebaContext (DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public DbSet<Prueba.Models.Paciente> Paciente { get; set; } = default!;
        public DbSet<Prueba.Models.HistorialMedico> HistorialMedico { get; set; } = default!;
        public DbSet<Prueba.Models.Tratamiento> Tratamiento { get; set; } = default!;
        public DbSet<Prueba.Models.Alergia> Alergia { get; set; } = default!;
        public DbSet<Prueba.Models.Condicion> Condicion { get; set; } = default!;
        public DbSet<Prueba.Models.Medicacion> Medicacion { get; set; } = default!;
    }
}
