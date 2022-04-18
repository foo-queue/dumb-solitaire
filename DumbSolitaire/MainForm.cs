namespace DumbSolitaire;

using System.Drawing;
using System.Windows.Forms;

public partial class MainForm : Form
{
    private float _scale = 1.0f;

    public DumbSolitaireGame Game { get; } = new();
    public int WinCount { get; private set; }
    public int LossCount { get; private set; }

    public MainForm() => InitializeComponent();

    private void UpdateGameCountPanel() => sbpGameCountPanel.Text = $"Won {WinCount} / Lost {LossCount}";
    private void SetStatus(string text) => sbpStatus.Text = text;

    private void NextCard()
    {
        if (Game.Gameover)
        {
            Game.Reset();
            SetStatus("");
            return;
        }

        Game.Play();

        if (Game.Gameover)
        {
            if (Game.Won)
            {
                WinCount++;
                SetStatus("YOU WON!!!");
            }
            else
            {
                LossCount++;
                SetStatus("YOU LOSE!!!");
            }

            UpdateGameCountPanel();
        }
    }

    private void OnLoad(object _, EventArgs e)
    {
        _scale = CreateGraphics().DpiX / 100f;

        //Put the deck at the top left below the menuStrip...
        Game.Deck.Location = ClientRectangle.Location + new Size(10, (int)(menuStrip.Height / _scale) + 10);
        //Put the hand on top of the deck...
        Game.Hands[0].Location = Game.Deck[^1].Location;
        //Put the pile below the deck...
        Game.Pile.CardLayout = Cards.CardLayout.HorzFaceUp;
        Game.Pile.Location = new(Game.Deck.Rectangle.Left, Game.Deck.Rectangle.Bottom + 20);

        foreach (var c in Game.Deck)
        {
            c.PositionChanged += Card_PositionChanged;
        }

        Game.Reset();
        LossCount = 0;
        WinCount = 0;
        SetStatus("");
        UpdateGameCountPanel();
    }

    private void NewGame()
    {
        if (!Game.Gameover)
        {
            ++LossCount; //forfeit
        }

        Game.Reset();
        SetStatus("");
        UpdateGameCountPanel();
    }

    private void Hit()
    {
        if (!autoPlay.Checked && !Game.Gameover)
        {
            NextCard();
        }
    }

    private void ToggleAutoPlay()
    {
        if (autoPlay.Checked)
        {
            autoPlay.Checked = false;
            return;
        }

        autoPlay.Checked = true;
        newGame.Enabled = false;
        hit.Enabled = false;

        do
        {
            NextCard();
            Application.DoEvents();
        } while (!Game.Won && autoPlay.Checked);

        autoPlay.Checked = false;
        newGame.Enabled = true;
        hit.Enabled = true;
    }

    private void CancelAutoPlay()
    {
        autoPlay.Checked = false;
    }

    private void Card_PositionChanged(Cards.Card card, Rectangle oldRect, Rectangle newRect)
    {
        var newR = new Rectangle((int)(newRect.X * _scale), (int)(newRect.Y * _scale), (int)((newRect.Width + 1) * _scale), (int)((newRect.Height + 1) * _scale));
        Invalidate(newR, false);

        // dont erase cards at the bottom of the deck (reduces flicker)
        if (oldRect != Game.Deck.FirstOrDefault()?.Rect)
        {
            var oldR = new Rectangle((int)(oldRect.X * _scale), (int)(oldRect.Y * _scale), (int)((oldRect.Width + 1) * _scale), (int)((oldRect.Height + 1) * _scale));
            Invalidate(oldR, false);
        }
    }

    private void Form1_Paint(object _, PaintEventArgs e)
    {
        try
        {
            e.Graphics.ScaleTransform(_scale, _scale);

            //Draw the deck (upto 4 cards)...
            var count = Math.Min(4, Game.Deck.Count);
            for (var i = Game.Deck.Count - count; i < Game.Deck.Count; ++i)
            {
                Game.Deck[i].DrawBack(e.Graphics, Cards.DeckImage.MOONFLOWER);
            }

            //Draw the hand on top of the deck...
            if (e.Graphics.VisibleClipBounds.IntersectsWith(Game.Hands[0].Rectangle))
            {
                foreach (var c in Game.Hands[0])
                {
                    c.DrawFace(e.Graphics);
                }
            }

            //Draw the pile below the deck...
            if (e.Graphics.VisibleClipBounds.IntersectsWith(Game.Pile.Rectangle))
            {
                foreach (var c in Game.Pile)
                {
                    c.DrawFace(e.Graphics);
                }
            }
        }
        catch (Exception ex)
        {
            var ptTable = ClientRectangle.Location;
            if (menuStrip.Visible)
            {
                ptTable.Y += menuStrip.Height;
            }

            var rc = new Rectangle(ptTable, ClientSize);
            if (statusBar.Visible)
            {
                rc.Height -= statusBar.Height;
            }

            e.Graphics.ResetTransform();
            e.Graphics.FillRectangle(Brushes.Blue, rc);
            e.Graphics.DrawString(ex.Message, Font, Brushes.White, rc);
        }
    }

    private void Form_Closing(object _, FormClosingEventArgs e) => CancelAutoPlay();
    private void Form_DpiChanged(object _, DpiChangedEventArgs e) => _scale = e.DeviceDpiNew / 100f;
    private void Form_MouseUp(object _, MouseEventArgs e) => Hit();
    private void NewGame_Click(object _, EventArgs e) => NewGame();
    private void AutoPlay_Click(object _, EventArgs e) => ToggleAutoPlay();
    private void Exit_Click(object _, EventArgs e) => Close();
    private void Hit_Click(object _, EventArgs e) => Hit();
    private void Form_KeyPress(object _, KeyPressEventArgs e)
    {
        if (e.KeyChar == ' ')
        {
            Hit();
        }
    }
}
