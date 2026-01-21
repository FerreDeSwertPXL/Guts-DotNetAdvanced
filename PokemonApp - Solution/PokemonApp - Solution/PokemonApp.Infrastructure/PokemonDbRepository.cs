using PokemonApp.AppLogic;
using PokemonApp.Domain;

namespace PokemonApp.Infrastructure
{
    public class PokemonDbRepository : IPokemonRepository
    {
        private readonly PokemonDbContext _context;

        public PokemonDbRepository(PokemonDbContext context)
        {
            _context = context;
        }

        public IList<Pokemon> GetAll()
        {
            return _context.Pokemons.ToList();
        }
    }
}
