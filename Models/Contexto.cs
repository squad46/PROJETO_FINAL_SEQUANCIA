using Microsoft.EntityFrameworkCore;
using Andor.Models;
using Pomelo.EntityFrameworkCore.MySql;

namespace Andor.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Formacao> Formacoes { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Moradia> Moradias { get; set; }
        public DbSet<Imagem> Imagens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // conexao local
            // optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-VV6TL78;Database=DBANDOR_Img;Integrated Security=True");

            // conexao azure
            optionsBuilder.UseSqlServer(connectionString: @"Data Source = andorserver.database.windows.net; Initial Catalog = BETE_DBANDOR; User ID = squad46; Password =#RecodePro;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
           
        }
    }        
}
