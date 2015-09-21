using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VideoPoker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Globals
        string location = Directory.GetCurrentDirectory() + "/Deck/";
        Image[] images = new Image[53];
        int[,] cardVal = new int[53, 2];
        Random rg = new Random();
        static int animCount = 2;
        static int cardCounter = 1;
        double win = 100;
        static int numOfClicks = 0;
        enum SUITS { CLUBS = 1, DIAMONDS, HEARTS, SPADES };

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            //Accidentally put here
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            int cardValue;
            for(int i = 0; i < 53; ++i)
            {
                images[i] = Image.FromFile(location + i.ToString() + ".bmp");
                if( i >= 1 && i <= 13) cardVal[i, 1] = (int) SUITS.CLUBS;
                else if( i >= 14 && i <= 26) cardVal[i, 1] = (int) SUITS.DIAMONDS;
                else if( i >= 27 && i <= 39) cardVal[i, 1] = (int) SUITS.HEARTS;
                else if( i >= 40 && i <= 52) cardVal[i, 1] = (int) SUITS.SPADES;

                cardValue = i % 13;
                if(cardValue == 0) cardValue = 13;
                else if (cardValue == 1) cardValue = 14;
                cardVal[i, 0] = cardValue;
            }

            cardVal[0,0] = 0;
            pic1.Image = pic2.Image = pic3.Image = pic4.Image = pic5.Image = images[0];
            chk1.Focus();
            ShuffleDeck();
            lblCredit.Text = win.ToString("C");
        }

        private void ShuffleDeck()
        {
            Image tmp;
            int r1, r2, temp;
            for(int i = 1; i < 53; ++i)
            {
                r1 = rg.Next(1, 53);
                r2 = rg.Next(1, 53);

                //Shuffle
                temp = cardVal[r1, 0];
                cardVal[r1, 0] = cardVal[r2, 0];
                cardVal[r2, 0] = temp;

                //Shuffle Suits
                temp = cardVal[r1, 1];
                cardVal[r1, 1] = cardVal[r2, 1];
                cardVal[r2, 1] = temp;

                //Shuffle Images
                tmp = images[r1];
                images[r1] = images[r2];
                images[r2] = tmp;

            }
        }

        private void Animate(PictureBox p, int w)
        {
            p.Width = p.Width + w;
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (numOfClicks < 2) tmr1.Enabled = true;
            tmr2.Enabled = tmr3.Enabled = tmr4.Enabled = tmr5.Enabled = false;
            numOfClicks++;
            if(numOfClicks <= 2)
            {
                if(!chk1.Checked)
                {
                    animCount = 0;
                    pic1.Image = images[cardCounter++];
                    pic1.Width = animCount;
                }

                if (!chk2.Checked)
                {
                    animCount = 0;
                    pic2.Image = images[cardCounter++];
                    pic2.Width = animCount;
                }

                if (!chk3.Checked)
                {
                    animCount = 0;
                    pic3.Image = images[cardCounter++];
                    pic3.Width = animCount;
                }

                if (!chk4.Checked)
                {
                    animCount = 0;
                    pic4.Image = images[cardCounter++];
                    pic4.Width = animCount;
                }

                if (!chk5.Checked)
                {
                    animCount = 0;
                    pic5.Image = images[cardCounter++];
                    pic5.Width = animCount;
                }
                win -= .25;
                lblCredit.Text = win.ToString();
            }
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            animCount = 2;
            animCount++;
            Animate(pic1, animCount);
            if(pic1.Width >= 114)
            {
                tmr1.Enabled = false;
                tmr2.Enabled = true;
            }
        }

        private void tmr2_Tick(object sender, EventArgs e)
        {
            animCount = 2;
            animCount++;
            Animate(pic2, animCount);
            if (pic2.Width >= 114)
            {
                tmr2.Enabled = false;
                tmr3.Enabled = true;
            }
        }

        private void tmr3_Tick(object sender, EventArgs e)
        {
            animCount = 2;
            animCount++;
            Animate(pic3, animCount);
            if (pic3.Width >= 114)
            {
                tmr3.Enabled = false;
                tmr4.Enabled = true;
            }
        }

        private void tmr4_Tick(object sender, EventArgs e)
        {
            animCount = 2;
            animCount++;
            Animate(pic4, animCount);
            if (pic4.Width >= 114)
            {
                tmr4.Enabled = false;
                tmr5.Enabled = true;
            }
        }

        private void tmr5_Tick(object sender, EventArgs e)
        {
            animCount = 2;
            animCount++;
            Animate(pic5, animCount);
            if (pic5.Width >= 114)
            {
                tmr5.Enabled = false;
            }
        }
    }
}

