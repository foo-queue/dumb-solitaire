namespace Cards;

public class PokerDeck : Deck
{
    public PokerDeck() : base(false) { }
    public override string ToString() { return "Poker Deck"; }
}

