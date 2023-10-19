using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowDvd
{
    public partial class DvdLogo : Form
    {
        bool RunBool = false;

        public DvdLogo()
        {
            InitializeComponent();
        }

        public void ChangePosThread()
        {
            int ScreenW = Screen.PrimaryScreen.Bounds.Width - Width;
            int ScreenH = Screen.PrimaryScreen.Bounds.Height - Height;
            int speedX = 1;
            int speedY = 1;
            bool collision = false;
            this.Controls.Remove(PosLabel);
            while (true)
            {
                // PosLabel.Text = $"({Top}; {Left})";
                if (RunBool)
                {
                    if (Left >= ScreenW || Left <= 0)
                    {
                        speedX = -speedX;
                        BackColor = Color.Red;
                        collision = true;
                    }
                    if (Top >= ScreenH || Top <= 0)
                    {
                        speedY = -speedY;
                        if (collision) { BackColor = Color.Green; }
                        else { BackColor = Color.Blue; }
                    }
                    collision = false;
                    Left += speedX;
                    Top += speedY;
                }
            }
        }

        public async void DvdLogo_Load(object sender, EventArgs e)
        {
            await Task.Run(() => ChangePosThread());
        }

        private void DvdLogo_Click(object sender, EventArgs e)
        {
            RunBool = !RunBool;
        }
    }
}
