using projectTic_tic_toegame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectTic_tic_toegame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enPlayer playTurn = enPlayer.play1;
        StGameStatus GameStatus;
        enum enPlayer
        {
            play1,play2

        }
      
        enum enWinner
        {
            play1,play2,draw,GameInProgress
        }
        struct StGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayerCount;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color black = Color.White;
            Pen Pen = new Pen(black);
            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            e.Graphics.DrawLine(Pen, 700, 100, 700, 700);
            e.Graphics.DrawLine(Pen, 900, 100, 900, 700);

            e.Graphics.DrawLine(Pen, 450, 300, 1100, 300);
            e.Graphics.DrawLine(Pen, 450, 500, 1100, 500);
        }
        void EndGame()
        {
            lbTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.play1:
                    lpWin.Text = "play1";
                    break;
                case enWinner.play2:
                    lpWin.Text = "play2";
                    break;
                default:
                    lpWin.Text = "Drow";
                    break;
            }
            MessageBox.Show("Game Over","Game Over",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       bool HowIsWin(Button btn1,Button btn2,Button btn3)
        {
            if (btn1.Tag.ToString() != "?" &&btn1.Tag.ToString() == btn2.Tag.ToString() && btn3.Tag.ToString() == btn1.Tag.ToString())
            {
                btn1.BackColor = Color.Green;
                btn2.BackColor = Color.Green;
                btn3.BackColor = Color.Green;

                if (btn1.Tag.ToString() == "X") {
                    GameStatus.Winner = enWinner.play1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.play2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

               
               
            }
            GameStatus.GameOver = false;
            return false;
        }

       public void checkWinnr()
        {
            if (HowIsWin(btn1, btn2, btn3))
            {
                return;
            }else if(HowIsWin(btn4, btn5, btn6))
            {
                return;
            }
            else if (HowIsWin(btn7, btn8, btn9))
            {
                return;
            }
            else if (HowIsWin(btn1, btn4, btn7))
            {
                return;
            }
            else if (HowIsWin(btn2, btn5, btn8))
            {
                return;
            }
            else if (HowIsWin(btn3, btn6, btn9))
            {
                return;
            }
            else if (HowIsWin(btn1, btn5, btn9))
            {
                return;
            }
            else if (HowIsWin(btn3, btn5, btn7))
            {
                return;
            }

        }

     public void playgame(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (playTurn)
                {
                    case enPlayer.play1:

                        btn.Image = Resources.X;
                        playTurn = enPlayer.play2;
                        lbTurn.Text = "Play2";
                        btn.Tag = "X";
                        GameStatus.PlayerCount++;
                        checkWinnr();
                        break;
                    case enPlayer.play2:
                        btn.Image = Resources.O;
                        playTurn = enPlayer.play1;
                        lbTurn.Text = "Play1";
                        btn.Tag = "O";
                        GameStatus.PlayerCount++;
                        checkWinnr();
                        break;
                }

            }
            else
            {
                MessageBox.Show("wrong cheice", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (GameStatus.PlayerCount == 9)
            {
                GameStatus.GameOver= true;
                GameStatus.Winner = enWinner.draw;
                EndGame();
            }
        }
        private void RestartButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }
        
        private void RestartGame()
        {
           
            RestartButton(btn1);
            RestartButton(btn2);
            RestartButton(btn3);
            RestartButton(btn4);
            RestartButton(btn5);
            RestartButton(btn6);
            RestartButton(btn7);
            RestartButton(btn8);
            RestartButton(btn9);
            playTurn= enPlayer.play1;
            lbTurn.Text= "play1";
            GameStatus.PlayerCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lpWin.Text = "In Progress";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            playgame((Button)sender);
        }
       

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
 