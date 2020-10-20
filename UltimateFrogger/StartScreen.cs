using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateFrogger
{
    public partial class StartScreen : UserControl
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(gs);
            gs.Focus();
        }
    }
}
