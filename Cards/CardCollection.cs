namespace Cards;

using System.Collections;
using System.Drawing;

public class CardCollection : IEnumerable<Card>
{
    protected readonly List<Card> _cards = new();
    protected Rectangle _rectangle = new(Point.Empty, Card.Size);
    protected CardLayout _cardLayout = CardLayout.StackedFaceDown;

    public int Count => _cards.Count;
    public bool IsEmpty => Count == 0;
    public Rectangle Rectangle => _rectangle;
    public virtual Point Location
    {
        get => _rectangle.Location;
        set { _rectangle.Location = value; UpdateCardLayout(); }
    }
    public virtual CardLayout CardLayout
    {
        get => _cardLayout;
        set { _cardLayout = value; UpdateCardLayout(); }
    }

    public Card Peek() => GetAt(0);
    public Card Next()
    {
        var c = GetAt(0);
        RemoveAt(0);
        return c;
    }
    public IEnumerable<Card> Next(int count)
    {
        var cc = GetRange(0, count);
        RemoveRange(0, count);
        return cc;
    }

    public void AddCard(Card card)
    {
        ArgumentNullException.ThrowIfNull(card);
        _cards.Add(card);
        UpdateCardLayout();
    }
    public void AddCards(IEnumerable<Card> cards)
    {
        ArgumentNullException.ThrowIfNull(cards);
        _cards.AddRange(cards.Select(c => c ?? throw new ArgumentException("Cannot add null card.")));
        UpdateCardLayout();
    }

    public Card GetAt(int index) => _cards[index];
    public IEnumerable<Card> GetRange(int index, int count) => _cards.GetRange(index, count);
    public IEnumerable<Card> GetAll() => _cards.GetRange(0, Count);
    public Card this[int index] => _cards[index];

    public void RemoveAt(int index) => RemoveRange(index, 1);
    public void RemoveAll() => RemoveRange(0, Count);
    public void RemoveRange(int index, int count)
    {
        _cards.RemoveRange(index, count);
        UpdateCardLayout();
    }

    public void Fold(CardCollection pile)
    {
        ArgumentNullException.ThrowIfNull(pile);
        var cc = GetAll();
        RemoveAll();
        pile.AddCards(cc);
    }

    public virtual void Sort()
    {
        _cards.Sort();
        UpdateCardLayout();
    }

    public virtual void UpdateCardLayout()
    {
        _rectangle.Size = Card.Size;
        var pos = _rectangle.Location;

        var index = 0;
        var cardOfst = 11;
        foreach (var c in _cards)
        {
            var location = pos;
            switch (_cardLayout)
            {
                case CardLayout.Deck:
                    if (index + 4 == _cards.Count)
                    {
                        location.Offset(2, 2);
                    }
                    else if (index + 3 == _cards.Count)
                    {
                        location.Offset(4, 4);
                    }
                    else if (index + 2 == _cards.Count)
                    {
                        location.Offset(6, 6);
                    }
                    else if (index + 1 == _cards.Count)
                    {
                        location.Offset(8, 8);
                    }

                    break;
                case CardLayout.HorzFaceUp:
                    pos.Offset(cardOfst, 0); break;
                case CardLayout.HorzFaceDown:
                    pos.Offset(2, 0); break;
                case CardLayout.VertFaceUp:
                    pos.Offset(0, cardOfst); break;
                case CardLayout.VertFaceDown:
                    pos.Offset(0, 2); break;
                case CardLayout.TiledFaceUp:
                    pos.Offset(cardOfst, cardOfst); break;
                case CardLayout.TiledFaceDown:
                    pos.Offset(2, 2); break;

                case CardLayout.StackedFaceUp:
                case CardLayout.StackedFaceDown:
                    break;
            }

            c.Location = location;
            _rectangle = Rectangle.Union(_rectangle, c.Rect);
            ++index;
        }
    }

    #region IEnumerable Members
    public IEnumerator<Card> GetEnumerator() => _cards.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _cards.GetEnumerator();
    #endregion
}
