namespace CardGames.Domain;

public interface ICardDeck
{
    int RemainingCards { get; }
    void Shuffle();
    ICard DealCard();
    ICardDeck WithoutCardsRankingLowerThan(CardRank minimumRank);
    [Obsolete("This method will be removed.")]
    IList<CardDeck> SplitBySuit();

}