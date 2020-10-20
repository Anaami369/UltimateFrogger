using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace UltimateFrogger
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.White);

        //a list to hold a column of boxes  
        List<Box> top3 = new List<Box>();
        List<Box> top2 = new List<Box>();
        List<Box> top1 = new List<Box>();
        List<Box> middle = new List<Box>();
        List<Box> bottom1 = new List<Box>();
        List<Box> bottom2 = new List<Box>();
        List<Box> bottom3 = new List<Box>();

        int leftX = 10;
        int gap = 100;

        //assign frog box
        Box frog;
        int frogSpeed = 20;
        int frogSize = 20;

        //score keeper
        int score = 5;

        //end buttons
        bool yes = false;
        bool no = false;

        Random randNum = new Random();
        #endregion 

        public GameScreen()
        {
            InitializeComponent();
            OnStart();

            waitLabel.Visible = true;
        }

        public void MakeRightBox()
        {

            Box newBox = new Box(0, leftX + gap, 20, Color.DarkOrange);
            top1.Add(newBox);

            Box newBox3 = new Box(0, leftX + (3 * gap), 20, Color.Orange);
            top3.Add(newBox3);

            Box newBox5 = new Box(0, leftX + (5 * gap), 20, Color.OrangeRed);
            bottom1.Add(newBox5);

            Box newBox7 = new Box(0, leftX + (7 * gap), 20, Color.MintCream);
            bottom3.Add(newBox7);
        }

        public void MakeLeftBox()
        {
            Box newBox2 = new Box(1000, leftX + (2 * gap), 20, Color.Silver);
            top2.Add(newBox2);

            Box newBox4 = new Box(1000, leftX + (4 * gap), 20, Color.SteelBlue);
            middle.Add(newBox4);

            Box newBox6 = new Box(1000, leftX + (6 * gap), 20, Color.SandyBrown);
            bottom2.Add(newBox6);
        }
        public void OnStart()
        {
            scoreKeeper.Text = "Lives: " + score;

            MakeLeftBox();
            MakeRightBox();

            frog = new Box(this.Width / 2 - frogSize / 2, 650, frogSize);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            #region update position of boxes (moving right)
            foreach (Box b in top3)
            {
                b.Move(5);
            }

            foreach (Box b in top2)
            {
                b.LeftMove(5);
            }

            foreach (Box b in top1)
            {
                b.Move(5);
            }

            foreach (Box b in middle)
            {
                b.LeftMove(5);
            }

            foreach (Box b in bottom1)
            {
                b.Move(5);
            }

            foreach (Box b in bottom2)
            {
                b.LeftMove(5);
            }

            foreach (Box b in bottom3)
            {
                b.Move(5);
            }
            #endregion

            #region remove a box if it is time
            foreach (Box b in top1)
            {
                if (b.x > 975)
                {
                    top1.Remove(b);
                    break;
                }
            }

            foreach (Box b in top2)
            {
                if (b.x < 0)
                {
                    top2.Remove(b);
                    break;
                }
            }

            foreach (Box b in top3)
            {
                if (b.x > 975)
                {
                    top3.Remove(b);
                    break;
                }
            }

            foreach (Box b in middle)
            {
                if (b.x < 0)
                {
                    middle.Remove(b);
                    break;
                }
            }

            foreach (Box b in bottom3)
            {
                if (b.x > 975)
                {
                    bottom3.Remove(b);
                    break;
                }
            }

            foreach (Box b in bottom2)
            {
                if (b.x < 0)
                {
                    bottom2.Remove(b);
                    break;
                }
            }

            foreach (Box b in bottom1)
            {
                if (b.x > 975)
                {
                    bottom1.Remove(b);
                    break;
                }
            }
            #endregion

            #region add new box if it is time
            if (top1[top1.Count - 1].x > 80)
            {
                MakeRightBox();
            }
            else if (top2[top2.Count - 1].x < 900)
            {
                MakeLeftBox();
            }

            #endregion

            #region move hero
            if (leftArrowDown == true)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.jumpSound);
                player.Play();

                frog.Move(frogSpeed, "left");
            }
            else if (rightArrowDown == true)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.jumpSound);
                player.Play();

                frog.Move(frogSpeed, "right");
            }
            else if (upArrowDown == true)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.jumpSound);
                player.Play();

                frog.Move(frogSpeed, "up");
            }
            else if (downArrowDown == true)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.jumpSound);
                player.Play();

                frog.Move(frogSpeed, "down");
            }
            #endregion

            #region check for collision
            Rectangle frogRec = new Rectangle(frog.x, frog.y, frog.size, frog.size);

            if (bottom2.Count >= 9)
            {
                waitLabel.Visible = false;

                // check all boxes
                for (int i = 0; i < 9; i++)
                {
                    Rectangle top2Rec = new Rectangle(top2[i].x, top2[i].y, top2[i].size, top2[i].size);
                    Rectangle middleRec = new Rectangle(middle[i].x, middle[i].y, middle[i].size, middle[i].size);
                    Rectangle bottom2Rec = new Rectangle(bottom2[i].x, bottom2[i].y, bottom2[i].size, bottom2[i].size);

                    if (top2Rec.IntersectsWith(frogRec) || middleRec.IntersectsWith(frogRec) || bottom2Rec.IntersectsWith(frogRec))
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.lifeLost);
                        player.Play();

                        score--;
                        scoreKeeper.Text = "";
                        scoreKeeper.Text = "Lives: " + score;

                        OnStart();
                    }
                }
            }

            if (bottom1.Count >= 12)
            {
                waitLabel.Visible = false;

                for (int i = 0; i < 12; i++)
                {
                    Rectangle top1Rec = new Rectangle(top1[i].x, top1[i].y, top1[i].size, top1[i].size);
                    Rectangle top3Rec = new Rectangle(top3[i].x, top3[i].y, top3[i].size, top3[i].size);
                    Rectangle bottom1Rec = new Rectangle(bottom1[i].x, bottom1[i].y, bottom1[i].size, bottom1[i].size);
                    Rectangle bottom3Rec = new Rectangle(bottom3[i].x, bottom3[i].y, bottom3[i].size, bottom3[i].size);

                    if (top1Rec.IntersectsWith(frogRec) || top3Rec.IntersectsWith(frogRec) || bottom1Rec.IntersectsWith(frogRec) || bottom3Rec.IntersectsWith(frogRec))
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.lifeLost);
                        player.Play();

                        score--;
                        scoreKeeper.Text = "";
                        scoreKeeper.Text = "Lives: " + score;

                        OnStart();
                    }
                }

            }
            #endregion

            #region if top line crossed
            if (frog.y <= 60)
            {
                OnStart();
            }
            #endregion

            #region game over
            if (score == 0)
            {

                SoundPlayer player = new SoundPlayer(Properties.Resources.gameOver);
                player.Play();

                GameOver();
            }
            #endregion

            Refresh();
        }

        public void GameOver()
        {
            gameLoop.Enabled = false;

            Form form = this.FindForm();
            EndScreen es = new EndScreen();

            //es.Location = new Point((form.Width - es.Width) / 2, (form.Height - es.Height) / 2);

            form.Controls.Add(es);
            form.Controls.Remove(this);
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            #region draw boxes to screen
            foreach (Box b in top3)
            {
                boxBrush.Color = b.color;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            foreach (Box b in top2)
            {
                boxBrush.Color = b.color;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            foreach (Box b in top1)
            {
                boxBrush.Color = b.color;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            foreach (Box b in middle)
            {
                boxBrush.Color = b.color;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            foreach (Box b in bottom1)
            {
                boxBrush.Color = b.color;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            foreach (Box b in bottom2)
            {
                boxBrush.Color = b.color;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            foreach (Box b in bottom3)
            {
                boxBrush.Color = b.color;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }
            #endregion

            #region draw hero character
            boxBrush.Color = Color.GreenYellow;
            e.Graphics.FillRectangle(boxBrush, frog.x, frog.y, frog.size, frog.size);

            #endregion
        }
    }
}
