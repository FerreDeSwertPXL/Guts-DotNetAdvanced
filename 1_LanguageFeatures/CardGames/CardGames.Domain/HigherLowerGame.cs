namespace CardGames.Domain;

public class HigherLowerGame
{
    private readonly ICardDeck _deck;


    public ICard CurrentCard { get; private set; }
    public ICard? PreviousCard { get; private set; }


    public int NumberOfCorrectGuesses { get; private set; }
    public bool HasWon => NumberOfCorrectGuesses >= _requiredCorrectGuesses;
    public string? Motivation { get; private set; }


    private readonly int _requiredCorrectGuesses;


    public HigherLowerGame(ICardDeck deck, int requiredCorrectGuesses, CardRank minimumRank = CardRank.Ace)
    {
        _requiredCorrectGuesses = requiredCorrectGuesses;
        _deck = deck.WithoutCardsRankingLowerThan(minimumRank);
        _deck.Shuffle();
        CurrentCard = _deck.DealCard();
    }


    public void MakeGuess(bool higher)
    {
        var next = _deck.DealCard();
        PreviousCard = CurrentCard;


        bool correct = higher
        ? next.Rank >= CurrentCard.Rank
        : next.Rank <= CurrentCard.Rank;


        if (correct)
        {
            NumberOfCorrectGuesses++;
            int remaining = _requiredCorrectGuesses - NumberOfCorrectGuesses;


            Motivation = remaining > 0 && remaining <= 3
            ? $"Only {remaining} more to go!"
            : null;
        }
        else
        {
            NumberOfCorrectGuesses = 0;
            Motivation = null;
        }


        CurrentCard = next;
    }
}
