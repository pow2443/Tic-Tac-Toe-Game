using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
* 
* 1:  get tic tac toe line to win 
* 2:  block user's tic tac toe 
* 3:  open for corner space
* 4:  take open space
* 
*/
namespace tictactoe
{
    public partial class tictactoe : Form
    {
        bool turn = true;
        int turnCount = 0;
        bool computerMode = false;


        public tictactoe()
        {
            InitializeComponent();
        }
        // about message
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Edgar","Tic Tac Toe About");
        }
        //exit the game 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //when button is clicked, the mark will be changed
        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (turn)
            {
                //mark X
                button.Text = "X";
            }
            else
            {
                //mark O
                button.Text = "O";
            }

            turn = !turn;
            button.Enabled = false;
            //count for draw
            turnCount = turnCount + 1;
            
            checkWinner();

            //calling computer mode 
            if ((!turn) && (computerMode))
            {

                computerExcute();
            }

        }
        //computer mode 
        private void computerExcute()
        {

            Button move = null;

            //check win oppertunity
            move = lookForWinOrBlock("O");
            if (move == null)
            {
                //check block oppertunity
                move = lookForWinOrBlock("X");
                if (move == null)
                {
                    move = moveLookForCorner();
                    if (move == null)
                    {
                        move = lookForOpenSpace();
                    }
                }

            }

            move.PerformClick();

        }
        //checking open spaces
        private Button lookForOpenSpace()
        {
            
            Button button = null;
            foreach (Control c in Controls)
            {
                button = c as Button;
                if (button != null)
                {
                    if (button.Text == "")
                        return button;
                }
            }

            return null;

        }
        //picking up corner space 
        private Button moveLookForCorner()
        {

            
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;

        }
        //checking block oppertunity 
        private Button lookForWinOrBlock(string mark)
        {
            Console.WriteLine("Looking for win or Block : " + mark);
            //horizontal
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
            {
                return A3;
            }
            else if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
            {
                return A1;
            }
            else if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
            {
                return A2;
            }
            else if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
            {
                return B3;
            }
            else if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
            {
                return B1;
            }
            else if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
            {
                return B2;
            }
            else if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
            {
                return C3;
            }
            else if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
            {
                return C1;
            }
            else if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
            {
                return C2;
            }

            //vrtical
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
            {
                return C1;
            }
            else if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
            {
                return A1;
            }
            else if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
            {
                return B1;
            }
            else if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
            {
                return C2;
            }
            else if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
            {
                return A2;
            }
            else if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
            {
                return B2;
            }
            else if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
            {
                return C3;
            }
            else if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
            {
                return A3;
            }
            else if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
            {
                return B3;
            }

            //diagonal
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
            {
                return C3;
            }
            else if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
            {
                return A1;
            }
            else if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
            {
                return B2;
            }
            else if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
            {
                return C1;
            }
            else if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
            {
                return A3;
            }
            else if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
            {
                return B2;
            }

            return null;

        }

        //checking who winner is 
        private void checkWinner()
        {
            bool winner = false;
            //horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
            {

                winner = true;

            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {

                winner = true;

            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {

                winner = true;

            }

            //vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {

                winner = true;

            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {

                winner = true;

            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {

                winner = true;

            }

            //diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {

                winner = true;

            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {

                winner = true;

            }
            



            if (winner == true)
            {
                disableButton();
                string winnerChar = "";

                if (turn)
                {
                    winnerChar = "O";
                    oWin.Text = (Int32.Parse(oWin.Text)+1).ToString();
                }
                else
                {
                    winnerChar = "X";
                    xWin.Text = (Int32.Parse(xWin.Text) + 1).ToString();
                }

                MessageBox.Show(winnerChar + "wins!");

            }
            else
            {
                if (turnCount == 9)
                {
                    draw.Text = (Int32.Parse(draw.Text) + 1).ToString();
                    MessageBox.Show("Draw!");

                }

            }

        }

        //making disable buttons to avoid duplication
        private void disableButton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button button = (Button)c;
                    button.Enabled = false;


                }
            }
            catch{ }

        }
        // new game
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            turn = false;
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button button = (Button)c;
                        button.Enabled = true;
                        button.Text = "";
                    }
                    catch { }

                }
            }
            catch { }

        }
        //reset game
        private void resetWinNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oWin.Text = "";
            xWin.Text = "";
            draw.Text = "";
        }
        // computermode 
        private void p2_TextChanged(object sender, EventArgs e)
        {
            if (p2.Text.ToUpper() == "COMPUTER")
            {
                computerMode = true;
            }
            else
            {
                computerMode = false;

            }

        }
        //set default mode 
        private void setPlayersDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.Text = "Edgar";
            p2.Text = "Computer";
        }

        //loading default mode 
        private void tictactoe_Load(object sender, EventArgs e)
        {
            setPlayersDefaultToolStripMenuItem.PerformClick();
        }
    }
}
