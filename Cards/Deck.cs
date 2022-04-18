namespace Cards
{
    public class Deck : CardCollection
    {
        protected virtual Card CreateCard(int ordinal)
        {
            return new Card(ordinal);
        }

        public Deck(bool IncludeJokers = false)
        {
            int count = (IncludeJokers ? 54 : 52);
            _cardLayout = CardLayout.Deck;
            _cards.AddRange(Enumerable.Range(0, count).Select(ordinal => CreateCard(ordinal)));
            UpdateCardLayout();
        }

        public virtual void Shuffle()
        {
            Randomize();
        }
        public virtual void Randomize()
        {
            //See http://www.codinghorror.com/blog/archives/001015.html
            for (var i = Count - 1; i > 0; i--)
            {
                var x = Random.Shared.Next(i + 1);
                (_cards[x], _cards[i]) = (_cards[i], _cards[x]);
            }
            UpdateCardLayout();
        }

        public override string ToString() { return "Generic Deck"; }
    }
}