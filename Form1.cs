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
        }

        private void MoveTheBall()
        {
            Ball.Top += verVelocity;
            Ball.Left += horVelocity;
        }

        private void InitializeField()
        {
            verVelocity = speed;
            horVelocity = speed;
            this.BackColor = Color.SkyBlue;
        }
    }
}
