using DiogoMachadoGlobalGames.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DiogoMachadoGlobalGames.Dados
{
    public class DataContext : DbContext
    {

        public DbSet<Servicos> Servicos { get; set; }

        public DbSet<Inscricoes> Incricoes { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
