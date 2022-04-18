namespace Cards;

public class Hand : CardCollection
{
    public Hand()
    {
        CardLayout = CardLayout.HorzFaceUp;
    }

    public void Discard(int index, CardCollection pile)
    {
        Discard(index, 1, pile);
    }
    public void Discard(int index, int count, CardCollection pile)
    {
        ArgumentNullException.ThrowIfNull(pile);
        pile.AddCards(GetRange(index, count));
        RemoveRange(index, count);
    }
}

