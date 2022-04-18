namespace Cards;

public abstract class Game
{
    public Game(Deck deck, int players)
    {
        ArgumentNullException.ThrowIfNull(deck);
        Deck = deck;
        Pile = CreatePile();
        Hands = Enumerable.Range(0, players).Select(i => CreateHand(i)).ToArray();
    }

    public Deck Deck { get; }
    public Hand[] Hands { get; }
    public CardCollection Pile { get; }

    public abstract void Play();
    public abstract bool Gameover { get; }

    public virtual void Reset()
    {
        Pile.Fold(Deck);
        foreach (var h in Hands)
        {
            h.Fold(Deck);
        }

        Deck.Shuffle();
    }

    public virtual bool Deal(int NumberOfCards, bool AllowPartial)
    {
        if (NumberOfCards < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(NumberOfCards), NumberOfCards, "Invalid value.");
        }

        if (!AllowPartial && NumberOfCards * Hands.Length > Deck.Count)
        {
            return false;
        }

        for (var i = 0; i < NumberOfCards; ++i)
        {
            foreach (var h in Hands)
            {
                if (Deck.IsEmpty)
                {
                    return false;
                }

                h.AddCard(Deck.Next());
            }
        }
        return true;
    }

    protected virtual CardCollection CreatePile()
    {
        return new CardCollection();
    }

    protected virtual Hand CreateHand(int player)
    {
        return new Hand();
    }
}
