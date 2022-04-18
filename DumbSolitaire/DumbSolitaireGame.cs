namespace DumbSolitaire;

public class DumbSolitaireGame : Cards.Game
{
    public DumbSolitaireGame() : base(new Cards.PokerDeck(), 1)
    {
    }

    public override void Reset()
    {
        base.Reset();
        Won = Lost = false;
        Deal(4, true);
    }

    public bool Won { get; private set; }
    public bool Lost { get; private set; }
    public override bool Gameover => Won || Lost || Hands[0].Count < 4;

    public override void Play()
    {
        if (Gameover)
        {
            throw new ApplicationException("Game over, man!");
        }

        //check for discards...
        var matched = false;
        var hand = Hands[0];
        if (hand[^1].Rank == hand[^4].Rank)
        {
            //discard all four cards
            hand.Discard(hand.Count - 4, 4, Pile);
            matched = true;
        }
        else if (hand[^1].Suit == hand[^4].Suit)
        {
            //discard the middle (second & third) cards
            hand.Discard(hand.Count - 3, 2, Pile);
            matched = true;
        }

        //figure out how many cards need to be dealt
        var cardsToDeal = 0;
        if (!matched)
        {
            cardsToDeal = 1;
        }
        else if (hand.Count < 4)
        {
            cardsToDeal = 4 - hand.Count;
        }

        //are we done?
        Won = Deck.IsEmpty && hand.IsEmpty;
        Lost = !Won && Deck.Count < cardsToDeal;

        if (!Won && !Lost)
        {
            Deal(cardsToDeal, true);

            //Check for losing condition...
            if (Deck.IsEmpty)
            {
                Lost = hand[^1].Rank != hand[^4].Rank &&
                         hand[^1].Suit != hand[^4].Suit;
            }
        }
    }
}
