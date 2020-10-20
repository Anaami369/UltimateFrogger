namespace UltimateFrogger
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.mountain = new System.Windows.Forms.Label();
            this.scoreKeeper = new System.Windows.Forms.Label();
            this.waitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // mountain
            // 
            this.mountain.AutoSize = true;
            this.mountain.Image = global::UltimateFrogger.Properties.Resources.mountainFinal1;
            this.mountain.Location = new System.Drawing.Point(199, 223);
            this.mountain.Name = "mountain";
            this.mountain.Size = new System.Drawing.Size(0, 13);
            this.mountain.TabIndex = 1;
            // 
            // scoreKeeper
            // 
            this.scoreKeeper.BackColor = System.Drawing.Color.Transparent;
            this.scoreKeeper.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.scoreKeeper.ForeColor = System.Drawing.Color.White;
            this.scoreKeeper.Location = new System.Drawing.Point(3, 0);
            this.scoreKeeper.Name = "scoreKeeper";
            this.scoreKeeper.Size = new System.Drawing.Size(100, 23);
            this.scoreKeeper.TabIndex = 2;
            // 
            // waitLabel
            // 
            this.waitLabel.BackColor = System.Drawing.Color.Black;
            this.waitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.waitLabel.ForeColor = System.Drawing.Color.Transparent;
            this.waitLabel.Location = new System.Drawing.Point(0, 0);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(1000, 700);
            this.waitLabel.TabIndex = 3;
            this.waitLabel.Text = "The game will start soon";
            this.waitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::UltimateFrogger.Properties.Resources.space;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.waitLabel);
            this.Controls.Add(this.scoreKeeper);
            this.Controls.Add(this.mountain);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label mountain;
        private System.Windows.Forms.Label scoreKeeper;
        private System.Windows.Forms.Label waitLabel;
    }
}
