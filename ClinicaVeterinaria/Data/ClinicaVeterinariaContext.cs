using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Models
{
    public class ClinicaVeterinariaContext : DbContext
    {
        public ClinicaVeterinariaContext (DbContextOptions<ClinicaVeterinariaContext> options)
            : base(options)
        {
        }

        public DbSet<Veterinario> Veterinario { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<ConsultaPagar> ConsultaPagar { get; set; }



    }
}
