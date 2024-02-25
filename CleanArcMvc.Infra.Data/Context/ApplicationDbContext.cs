using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
            
        }

        /*
            O entity Framework vai verificar esses DbSet, com base nessas ifnormações serão gerado as tabelas no SGBD
            Toda string é gerado automaticamente como nvarchar(max) e nullable true no SGBD
            Um tipo decimal sempre sera mapeado para decimal(18,2)
            A Fluent Api irá auxiliar na configuração das propriedades
        */


        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        //Necessário pra utilizar o FluentApi
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Reflection para aplicar a configuração em todas as entitidades que implementar IEntityTypeConfiguration
            //Sem utilizar o Apply, seria necessário configurar manualmente cada uma das configurações dos entities aqui.
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
