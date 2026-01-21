
namespace CardGames.Domain;

public class CardDeck : ICardDeck
{
    private static readonly Random Random = new();
    private readonly IList<ICard> _cards;


    public int RemainingCards => _cards.Count;


    public CardDeck()
    {
        _cards = new List<ICard>();
        foreach (CardSuit suit in Enum.GetValues<CardSuit>())
            foreach (CardRank rank in Enum.GetValues<CardRank>())
                _cards.Add(new Card(suit, rank));
    }


    private CardDeck(IEnumerable<ICard> cards)
    {
        _cards = new List<ICard>(cards);
    }


    public void Shuffle()
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = Random.Next(i + 1);
            var temp = _cards[i];
            _cards[i] = _cards[j];
            _cards[j] = temp;
        }
    }


    public ICard DealCard()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException();


        var card = _cards[^1];
        _cards.RemoveAt(_cards.Count - 1);
        return card;
    }


    public ICardDeck WithoutCardsRankingLowerThan(CardRank minimumRank)
    => new CardDeck(_cards.Where(c => c.Rank >= minimumRank));


    [Obsolete]
    public IList<CardDeck> SplitBySuit()
    => _cards
    .GroupBy(c => c.Suit)
    .Select(g => new CardDeck(g))
    .ToList();
}