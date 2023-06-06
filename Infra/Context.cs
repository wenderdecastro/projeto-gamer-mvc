using Microsoft.EntityFrameworkCore;
using projeto_gamer.Models;

namespace projeto_gamer.Infra
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source = NOTE16-S14; initial catalog = ProjetoGamerManha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true");

            //string de conexão com o banco
            //Data Source = nome do servidor do gerenciador do banco de dados
            //initial catalog = nome do db
            //Integrated Security =  true - autenticação pelo windows

            //autenticação pelo sqlserver

            //UserId = "id do user"
            //Password = "senha"

        }

        public DbSet<Player> Player {get; set;}
        public DbSet<Team> Team {get; set;}
        public DbSet<Login> Login {get; set;}
            
}
}