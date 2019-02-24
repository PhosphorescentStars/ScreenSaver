using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static ScreenSaver.DirectionHelper;

namespace ScreenSaver
{
    public partial class ScreensaverForm : Form
    {
        Direction direction;
        int DISPLACEMENT = 10;
        bool CloseForReal = false;

        public ScreensaverForm() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.Picture;
            lblInputKey.Visible = false;
            FullScreen();
            CenterToScreen();
            timerImageMovement.Start();
        }

        private void FullScreen()
        {
            Width = Screen.FromControl(this).Bounds.Width;
            Height = Screen.FromControl(this).Bounds.Height;
        }

        private void timerImageMovement_Tick(object sender, EventArgs e) => MoveImage(pictureBox);

        private void MoveImage(PictureBox pictureBox)
        {
            direction = GetNewDirection(pictureBox, direction);
            Point point = GetPointBasedOnDirectionAndDisplacement(direction, DISPLACEMENT);
            pictureBox.Location = new Point(pictureBox.Location.X + point.X, pictureBox.Location.Y + point.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            lblInputKey.Text = e.KeyCode.ToString() + ' ';
            if (e.KeyCode == Keys.Space)
            {
                CloseForReal = true;
                Close();
            }
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !CloseForReal;

    }
}
