using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class Field : Form
    {
        private int verVelocity = 0;
        private int horVelocity = 0;
        private int speed = 3;

        private Timer mainTimer = null;


        public Field()
        {
            InitializeComponent();
            InitializeField();
            InitializeMainTimer();
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Tick += new EventHandler(MainTimer_tick);
            mainTimer.Interval = 10;
            mainTimer.Start();
        }

        private void MainTimer_tick(object sender, EventArgs e)
        {
            MoveTheBall();
            BallBorderCollision();
        }

        private void MoveTheBall()
        {
            Ball.Top += verVelocity;
            Ball.Left += horVelocity;
            Ball.BackColor = Color.Transparent;
        }

        private void InitializeField()
        {
            verVelocity = speed;
            horVelocity = speed;
            this.BackColor = Color.SkyBlue;
            this.KeyDown += new KeyEventHandler(Field_KeyDown);

            //human.Newemail += new EmailEventHandler(HumanHandlesEmail);
        }

        private void BallBorderCollision()
        {
            if (Ball.Top + Ball.Height > ClientRectangle.Height)
            {
                verVelocity = -speed;
            }
            else if (Ball.Top < 0)
            {
                verVelocity = speed;
            }
            if (Ball.Left + Ball.Width > ClientRectangle.Width)
            {
                horVelocity = -speed;
            }
            else if (Ball.Left < 0)
            {
                horVelocity = speed;
            }
        }

        private void Field_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.X)
            {
                speed += 1; //speed++
                UpdateSpeedLabel();
            }
            else if(e.KeyCode == Keys.Z)
            {
                if(speed > 1)
                {
                    speed -= 1; //speed--
                    UpdateSpeedLabel();
                }
            }
        }

        private void UpdateSpeedLabel()
        {
            SpeedLabel.Text = "DVD speed: " + speed;
        }
    }
}
