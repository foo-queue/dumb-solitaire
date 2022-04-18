namespace Cards;

using System.Collections.Concurrent;
using System.Drawing;

public class Card : IComparable<Card>, ICloneable
{
    private static readonly ConcurrentDictionary<string, Bitmap> _imageCache;
    private Point _location;

    public static int CardOrdinal(Suit suit, Rank rank) => CardOrdinal(rank, suit);
    public static int CardOrdinal(Rank rank, Suit suit) => (suit, rank) switch
    {
        (Suit.Joker, Rank.Joker1 or Rank.Joker2) => 52 + (int)rank - (int)Rank.Joker1,
        (Suit.Joker, _) or (_, Rank.Joker1 or Rank.Joker2) => throw new ApplicationException("Invalid suit/rank combination."),
        _ => (int)rank * 4 + (int)suit
    };
    public static Suit SuitFromOrdinal(int ordinal) => ordinal switch
    {
        >= 0 and < 52 => (Suit)(ordinal % 4),
        52 or 53 => Suit.Joker,
        _ => throw new ApplicationException("Invalid card ordinal.")
    };
    public static Rank RankFromOrdinal(int ordinal) => ordinal switch
    {
        >= 0 and < 52 => (Rank)(ordinal / 4),
        52 => Rank.Joker1,
        53 => Rank.Joker2,
        _ => throw new ApplicationException("Invalid card ordinal.")
    };

    static Card()
    {
        _imageCache = new();
        var bmp = Bitmap("CardMask");
        var gu = GraphicsUnit.Pixel;
        Size = bmp.GetBounds(ref gu).Size.ToSize();
    }

    public Card(int ordinal)
    {
        Ordinal = ordinal;
        _location = Point.Empty;
    }
    public Card(Rank rank, Suit suit) : this(CardOrdinal(rank, suit)) { }
    public Card(Suit suit, Rank rank) : this(CardOrdinal(rank, suit)) { }


    public int Ordinal { get; }
    public Rank Rank => RankFromOrdinal(Ordinal);
    public Suit Suit => SuitFromOrdinal(Ordinal);

    public static Size Size { get; private set; }
    public Rectangle Rect => new(Location, Size);
    public virtual Point Location
    {
        get => _location;
        set
        {
            if (_location == value)
            {
                return;
            }

            var rcOld = Rect;
            _location = value;
            PositionChanged?.Invoke(this, rcOld, Rect);
        }
    }

    public event Action<Card, Rectangle, Rectangle>? PositionChanged;

    public virtual void DrawFace(Graphics g)
    {
        var r = Rect;
        if (g.VisibleClipBounds.IntersectsWith(r))
        {
            g.DrawImage(Bitmap(ToString()), r);
        }
    }
    public virtual void DrawBack(Graphics g, DeckImage backType)
    {
        var r = Rect;
        if (g.VisibleClipBounds.IntersectsWith(r))
        {
            g.DrawImage(Bitmap(backType.ToString()), r);
        }
    }

    public static Bitmap Bitmap(string name)
    {
        return _imageCache.GetOrAdd(name, name =>
        {
            var image = (Bitmap)(Resource.ResourceManager.GetObject(name, null) ?? throw new ApplicationException("Resource not found."));
            image.MakeTransparent(image.GetPixel(0, 0));
            return image;
        });
    }

    #region Object Overrides
    public override string ToString() => Suit == Suit.Joker ? Rank.ToString() : $"{Rank}_of_{Suit}";
    public override bool Equals(object? obj) => obj is Card card && CompareTo(card) == 0;
    public override int GetHashCode() => Ordinal.GetHashCode();
    #endregion

    #region ICloneable Members
    public object Clone() => new Card(Ordinal)
    {
        _location = _location
    };
    #endregion

    #region IComparable<> Members
    public int CompareTo(Card? other) => other is null ? 1 : Ordinal.CompareTo(other.Ordinal);
    #endregion
}
