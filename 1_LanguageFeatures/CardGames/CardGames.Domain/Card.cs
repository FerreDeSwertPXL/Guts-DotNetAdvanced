namespace CardGames.Domain;

public readonly struct Card : ICard
{
    public CardSuit Suit { get; }
    public CardRank Rank { get; }

    public Card(CardSuit suit, CardRank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}