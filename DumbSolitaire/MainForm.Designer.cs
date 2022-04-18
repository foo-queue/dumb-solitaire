namespace DumbSolitaire;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.sbpStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbpGameCountPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hit = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbpStatus,
            this.sbpGameCountPanel});
            this.statusBar.Location = new System.Drawing.Point(0, 843);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(2118, 63);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // sbpStatus
            // 
            this.sbpStatus.Name = "sbpStatus";
            this.sbpStatus.Size = new System.Drawing.Size(1961, 48);
            this.sbpStatus.Spring = true;
            this.sbpStatus.Text = "Status";
            this.sbpStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // sbpGameCountPanel
            // 
            this.sbpGameCountPanel.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.sbpGameCountPanel.Name = "sbpGameCountPanel";
            this.sbpGameCountPanel.Size = new System.Drawing.Size(142, 48);
            this.sbpGameCountPanel.Text = "Game 0";
            this.sbpGameCountPanel.ToolTipText = "Game count";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(2118, 56);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGame,
            this.toolStripSeparator2,
            this.hit,
            this.autoPlay,
            this.toolStripSeparator1,
            this.exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(141, 52);
            this.fileToolStripMenuItem.Text = "&Game";
            // 
            // newGame
            // 
            this.newGame.Image = global::DumbSolitaire.Properties.Resources.New;
            this.newGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newGame.Name = "newGame";
            this.newGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGame.Size = new System.Drawing.Size(521, 66);
            this.newGame.Text = "&New Game";
            this.newGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(518, 6);
            // 
            // hit
            // 
            this.hit.Name = "hit";
            this.hit.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.hit.Size = new System.Drawing.Size(521, 66);
            this.hit.Text = "&Hit";
            this.hit.Click += new System.EventHandler(this.Hit_Click);
            // 
            // autoPlay
            // 
            this.autoPlay.Image = global::DumbSolitaire.Properties.Resources.Repeat;
            this.autoPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoPlay.Name = "autoPlay";
            this.autoPlay.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.autoPlay.Size = new System.Drawing.Size(521, 66);
            this.autoPlay.Text = "&Auto Play";
            this.autoPlay.Click += new System.EventHandler(this.AutoPlay_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(518, 6);
            // 
            // exit
            // 
            this.exit.Image = global::DumbSolitaire.Properties.Resources.Quit;
            this.exit.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(521, 66);
            this.exit.Text = "E&xit";
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(2118, 906);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Dumb Solitaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form_DpiChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private StatusStrip statusBar;
    private ToolStripStatusLabel sbpStatus;
    private ToolStripStatusLabel sbpGameCountPanel;
    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newGame;
    private ToolStripMenuItem autoPlay;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem exit;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem hit;
}
