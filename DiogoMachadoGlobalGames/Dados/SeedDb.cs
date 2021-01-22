using DiogoMachadoGlobalGames.Dados.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiogoMachadoGlobalGames.Dados
{
    public class SeedDb
    {
        private readonly DataContext context;

        private readonly Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;

            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Incricoes.Any())
            {
                this.AddInscricoes("Mehdi Taremi");
                this.AddInscricoes("Jesús Corona");
                this.AddInscricoes("Otávio Monteiro");
                this.AddInscricoes("Agustín Marchesín");
                this.AddInscricoes("Moussa Marega");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddInscricoes(string name)
        {
            this.context.Incricoes.Add(new Inscricoes
            {
                Nome = name,
                Apelido = name,
                CC = this.random.Next(30000000),
            });
        }
    }
}
