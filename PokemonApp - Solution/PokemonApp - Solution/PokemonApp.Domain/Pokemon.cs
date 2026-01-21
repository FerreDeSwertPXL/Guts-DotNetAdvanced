namespace PokemonApp.Domain
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public string Type { get; set; } = string.Empty;
    }

}
