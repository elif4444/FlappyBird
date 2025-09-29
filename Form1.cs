using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{





    public partial class Form1 : Form
    {

        int boruHızı = 8;
        int gravity = 10;
        int score = 0;
        Random random = new Random();
        bool boruAltScored = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            BoruAlt.Left -= boruHızı;
            BoruUst.Left -= boruHızı;
            scoreText.Text = "Score: " + score;

            // Sadece alt boru için skor kontrolü
            if (!boruAltScored && flappybird.Left > BoruAlt.Left + BoruAlt.Width)
            {
                score++;
                boruAltScored = true;
            }
            maya.Left -= 5;
            if (maya.Left < -100) { maya.Left =800; }
            if (BoruAlt.Left < -150)
            {
                BoruAlt.Left = 800;
                int randomHeightBottom = random.Next(80, 250);
                BoruAlt.Height = randomHeightBottom;
                BoruAlt.Top = zemin.Top - randomHeightBottom;
                boruAltScored = false;
            }

            if (BoruUst.Left < -180)
            {
                BoruUst.Left = 950;
                int randomHeightTop = random.Next(80, 200);
                BoruUst.Height = randomHeightTop;
            }

            BoruUst.Left = BoruAlt.Left;

            if (flappybird.Bounds.IntersectsWith(BoruAlt.Bounds) ||
               flappybird.Bounds.IntersectsWith(BoruUst.Bounds) ||
               flappybird.Bounds.IntersectsWith(zemin.Bounds))
            {
                endGame();
            }

            if (score > 10)
            {
                boruHızı = 15;
            }

            if (flappybird.Top < -25)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Score" + score;
            scoreText.Text = "Game Over!!! \n Score:"+score;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flappybird.BorderStyle = BorderStyle.None;
            // Oyun başlangıcında boruları rastgele yükseklikte ayarla
            int randomHeightBottom = random.Next(80, 250);
            int randomHeightTop = random.Next(80, 200);

            BoruAlt.Height = randomHeightBottom;
            BoruAlt.Top = zemin.Top - randomHeightBottom;

            BoruUst.Height = randomHeightTop;

            // Boruları aynı hizada başlat
            BoruUst.Left = BoruAlt.Left;
        }
    }
}