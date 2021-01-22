namespace DiogoMachadoGlobalGames.Dados
{
    using Entidades;

    public class InscricoesRepository : GenericRepository<Inscricoes>, IInscricoesRepository
    {
        public InscricoesRepository(DataContext context) : base(context)
        {

        }
    }
}
