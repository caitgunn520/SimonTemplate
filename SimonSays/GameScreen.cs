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
                        greenButton.BackColor = Color.GreenYellow;
                        Refresh();
                        Thread.Sleep(500);
                        greenButton.BackColor = Color.ForestGreen;
                        break;
                    case 1:
                        redButton.BackColor = Color.Red;
                        Refresh();
                        Thread.Sleep(500);
                        redButton.BackColor = Color.DarkRed;
                        break;
                    case 2:
                        blueButton.BackColor = Color.Blue;
                        Refresh();
                        Thread.Sleep(500);
                        blueButton.BackColor = Color.DarkBlue;
                        break;
                    default:
                        yellowButton.BackColor = Color.Yellow;
                        Refresh();
                        Thread.Sleep(500);
                        yellowButton.BackColor = Color.Goldenrod;
                        break;
                }
            }

            //TODO: get guess index value back to 0
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //TODO: close this screen and open the GameOverScreen

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value at current guess index equal to a green. If so:
                // light up button, play sound, and pause
                // set button colour back to original
                // add one to the guess index
                // check to see if we are at the end of the pattern. If so:
                    // call ComputerTurn() method
                // else call GameOver method
        }
    }
}
