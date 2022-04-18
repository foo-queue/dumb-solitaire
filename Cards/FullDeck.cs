namespace Cards;

public class FullDeck : Deck
{
    public FullDeck() : base(true) { }
    public override string ToString() { return "Full Deck"; }
}

