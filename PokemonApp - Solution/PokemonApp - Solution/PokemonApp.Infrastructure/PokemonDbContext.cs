using Microsoft.EntityFrameworkCore;
using PokemonApp.Domain;

namespace PokemonApp.Infrastructure;

public class PokemonDbContext : DbContext
{
    public DbSet<Pokemon> Pokemons { get; set; } = null!;

    public PokemonDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pokemon>().HasData(GetPokemonsToSeed());
    }

    private IEnumerable<Pokemon> GetPokemonsToSeed()
    {
        var pokemons = new List<Pokemon>
        {
            new Pokemon { Id = 1, Name = "Pikachu", Type = "Electric", Level = 15},
            new Pokemon { Id = 2, Name = "Charmander", Type = "Fire", Level = 20 },
            new Pokemon { Id = 3, Name = "Squirtle", Type = "Water", Level = 8 },
            new Pokemon { Id = 4, Name = "Bulbasaur", Type = "Grass", Level = 8 },
            new Pokemon { Id = 5, Name = "Jigglypuff", Type = "Fairy", Level = 5 },
            new Pokemon { Id = 6, Name = "Snorlax", Type = "Normal", Level = 20 }
        };
        return pokemons;
    }
}