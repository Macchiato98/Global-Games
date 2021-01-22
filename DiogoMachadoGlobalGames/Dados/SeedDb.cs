namespace DiogoMachadoGlobalGames.Dados
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entidades;
    using DiogoMachadoGlobalGames.Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("diogo.machado18@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Diogo",
                    LastName = "Machado",
                    Email = "diogo.machado18@gmail.com",
                    UserName = "diogo.machado18@gmail.com",
                    PhoneNumber = "956872641",
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

            }


            if (!this.context.Incricoes.Any())
            {
                this.AddInscricoes("Mehdi Taremi", user);
                this.AddInscricoes("Jesús Corona", user);
                this.AddInscricoes("Otávio Monteiro", user);
                this.AddInscricoes("Agustín Marchesín", user);
                this.AddInscricoes("Moussa Marega", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddInscricoes(string name, User user)
        {
            this.context.Incricoes.Add(new Inscricoes
            {
                Nome = name,
                Apelido = name,
                CC = this.random.Next(30000000),
                User = user,
            });
        }
    }
}
