using PokemonApp.Domain;

namespace PokemonApp.AppLogic
{
    public interface IPokemonRepository
    {
        IList<Pokemon> GetAll();
    }
}
