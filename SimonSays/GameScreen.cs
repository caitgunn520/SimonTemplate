using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //create guess variable to track what part of the pattern the user is at
        int guess;

        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.patternList.Clear();
            this.Refresh();
            Thread.Sleep(500);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            int randNum = randGen.Next(0, 4);
            Form1.patternList.Add(randNum);

            //create a for loop that shows each value in the pattern by lighting up appropriate button
            for (int i = 0; i < Form1.patternList.Count(); i++)
            {
                switch (Form1.patternList[i])
                {
                    case 0:
                        greenButton.BackColor = Color.Lime;
                        Refresh();
                        Thread.Sleep(500);
                        greenButton.BackColor = Color.ForestGreen;
                        Refresh();
                        Thread.Sleep(500);
                        break;
                    case 1:
                        redButton.BackColor = Color.Red;
                        Refresh();
                        Thread.Sleep(500);
                        redButton.BackColor = Color.DarkRed;
                        Refresh();
                        Thread.Sleep(500);
                        break;
                    case 2:
                        blueButton.BackColor = Color.Blue;
                        Refresh();
                        Thread.Sleep(500);
                        blueButton.BackColor = Color.DarkBlue;
                        Refresh();
                        Thread.Sleep(500);
                        break;
                    default:
                        yellowButton.BackColor = Color.Yellow;
                        Refresh();
                        Thread.Sleep(500);
                        yellowButton.BackColor = Color.Goldenrod;
                        Refresh();
                        Thread.Sleep(500);
                        break;
                }
            }

            //get guess index value back to 0
            guess = 0;
        }

        public void GameOver()
        {
            //Play a game over sound
            SoundPlayer gameOverSound = new SoundPlayer(Properties.Resources.mistake);
            gameOverSound.Play();

            //TODO: close this screen and open the GameOverScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameOverScreen gso = new GameOverScreen();
            f.Controls.Add(gso);
        }

        //create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //is the value at current guess index equal to a green. If so:
                // light up button, play sound, and pause
                // set button colour back to original
                // add one to the guess index
                // check to see if we are at the end of the pattern. If so:
                    // call ComputerTurn() method
                // else call GameOver method
            if (Form1.patternList[guess] == 0)
            {
                greenButton.BackColor = Color.Lime;
                Refresh();
                SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);
                greenSound.Play();
                Thread.Sleep(500);

                greenButton.BackColor = Color.ForestGreen;
                Refresh();

                guess++;

                if (guess >= Form1.patternList.Count())
                {
                    ComputerTurn();
                }
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guess] == 1)
            {
                redButton.BackColor = Color.Red;
                Refresh();
                SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
                redSound.Play();
                Thread.Sleep(500);

                redButton.BackColor = Color.DarkRed;
                Refresh();

                guess++;

                if (guess >= Form1.patternList.Count())
                {
                    ComputerTurn();
                }
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guess] == 2)
            {
                blueButton.BackColor = Color.Blue;
                Refresh();
                SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);
                blueSound.Play();
                Thread.Sleep(500);

                blueButton.BackColor = Color.DarkBlue;
                Refresh();

                guess++;

                if (guess >= Form1.patternList.Count())
                {
                    ComputerTurn();
                }
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guess] == 3)
            {
                yellowButton.BackColor = Color.Yellow;
                Refresh();
                SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
                yellowSound.Play();
                Thread.Sleep(500);

                yellowButton.BackColor = Color.Goldenrod;
                Refresh();

                guess++;

                if (guess >= Form1.patternList.Count())
                {
                    ComputerTurn();
                }
            }
        }
    }
}
