using CleanArchMvc.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Vasculha o assembly e aplica as configurações de todas as classes que herdam da entidade especificada
            // Ou seja, ele aplica todas as Configurations que criar na pasta EntitiesConfiguration, de forma automática
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Se tivesse que fazer na mão (para todos os configurations):
            // builder.ApplyConfiguration(new CategoryInformation());
        }
    }
}
