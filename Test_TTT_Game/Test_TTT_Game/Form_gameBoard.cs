using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using System.IO;

namespace Test_TTT_Game
{
    public partial class Form_gameBoard : Form
    {
        //string a, b, c, d;
        bool turn = false; //true = X false = O
        int turnCount = 0;
        bool isWinner = false;
        int[,] result = new int[6, 6]; //matrix contains moves of 2 players
        int[,] SubResult1 = new int[4, 4]; //case 1
        int[,] SubResult2 = new int[4, 4]; //case 1
        int[,] SubResult3 = new int[4, 4]; //case 1
        int[,] SubResult4 = new int[4, 4]; //case 1
        int[,] SubResult5 = new int[4, 4];
        int[,] SubResult6 = new int[4, 4];
        int[,] SubResult7 = new int[4, 4];
        int[,] SubResult8 = new int[4, 4];
        int[,] SubResult9 = new int[4, 4];

        int player1Points = 0;
        int player2Points = 0;

        String[,] names = new String[6, 6] {{"A1","B1","C1","D1","E1","F1"},
                                            {"A2","B2","C2","D2","E2","F2"},
                                            {"A3","B3","C3","D3","E3","F3"},
                                            {"A4","B4","C4","D4","E4","F4"},
                                            {"A5","B5","C5","D5","E5","F5"},
                                            {"A6","B6","C6","D6","E6","F6"}};


        /*STAR UP*/
        private void Form_gameBoard_Load(object sender, EventArgs e)
        {
            fillMatrix();
            //button2.Enabled = false;
            foreach (Control c in panel_gameBoard.Controls)
            {
                Button b = (Button)c;
                b.Visible = false;
                //MessageBox.Show(b.Name);
            }
        }

        private void fillMatrix()
        {
            //filling the matrix by default : 2 for empty, 1 and 0 for players
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    result[i, j] = random.Next(2, 3);
                }

            }
        }

        // To count the points after every play
        private void checkBoard()
        {

            // Resets points to zero so they are not added multiple times
            player1Points = 0;
            player2Points = 0;

            // All the different scoring possibilities are traversed through while adding to each players' score
            CountSubResultsAll(SubResult1);           
            countPointsOfHoro(SubResult2);       
            countPointsOfHoro(SubResult3);          
            countPointsOfPartialHoro(SubResult7);           
            countPointsOfPartialHoro(SubResult8);           
            countPointsOfPartialHoro(SubResult9);
            countPointsOfVert(SubResult4);
            countPointsOfVert(SubResult7);  
            countPointsOfPartialVert(SubResult3);
            countPointsOfPartialVert(SubResult6);
            countPointsOfPartialVert(SubResult9);
            countPointsOfDiagonal(SubResult2);
            countPointsOfDiagonal(SubResult3);
            countPointsOfDiagonal(SubResult4);
            countPointsOfDiagonal(SubResult5);
            countPointsOfDiagonal(SubResult6);
            countPointsOfDiagonal(SubResult7);
            countPointsOfDiagonal(SubResult8);
            countPointsOfDiagonal(SubResult9);
            
        }


        public Form_gameBoard()
        {
            InitializeComponent();
        }

        private void label_boardLetters_Click(object sender, EventArgs e)
        {

        }

        private void button_A1_Click(object sender, EventArgs e)
        {

        }

        private void label_boardLetterF_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_scoreboardP2_sixLabel_Click(object sender, EventArgs e)
        {

        }

        // Main Menu button to go back to main menu
        private void button_backToMenuFrmBoard_Click(object sender, EventArgs e)
        {
            Form_mainMenu frm_mM = new Form_mainMenu();
            frm_mM.Show();
            this.Hide();
        }

        private void button_playAgain_Click(object sender, EventArgs e)
        {
            /*Form_gameBoard frm_gB = new Form_gameBoard();
            frm_gB.Show();
            this.Hide();*/
            /*foreach (Control c in panel_gameBoard.Controls)
            {
                Button b = (Button)c;
                b.Visible = true;
                //MessageBox.Show(b.Name);
            }*/
            fillMatrix(); //initialize a new matrix which hold the value of steps from players--filled up with random number in the beginning.
            //button3.Enabled = true; // make optional 'player 2 goes first avalable'
            //button2.Enabled = true;
            isWinner = false;
            turnCount = 0;  // make the player 1 goes first as default.
            //GetWinRatio();
            try
            {
                turn = false;
                foreach (Control c in panel_gameBoard.Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }


        // This function is assigning a 1(one) or 0(zero) to the overall board called result, which is 6X6
        // This gets called the moment a player presses a button.
        private void CompareMatrix(string name, int value)
        {

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (name == names[i, j])
                        result[i, j] = value;
                }
            }
            //Test to see the value of value
            //MessageBox.Show(value.ToString());
        }

        // This function is taking the values in the 6x6 board called result and placing them in the 9 4x4 boards called
        // SubResult1 through SubResult9. 
        private void CopyResults()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i == 0 && j == 0)
                        SubResult1[i, j] = result[i, j];
                    else if (i == 0 && j == 1)
                    {
						SubResult1[i,j] = result[i,j];
                        SubResult2[i,j-1] = result[i,j];
                    }
                    else if (i == 0 && j == 2)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
                    }
					else if (i == 0 && j == 3)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
                    }
					else if (i == 0 && j == 4)
                    {
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
                    }
					else if (i == 0 && j == 5)
                    {
						SubResult3[i,j-2] = result[i,j];
                    }
						// new row
					else if (i == 1 && j == 0)
                    {
                        SubResult1[i, j] = result[i, j];
						SubResult4[i-1, j] = result[i, j];
                    }
                    else if (i == 1 && j == 1)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
                    }
					else if (i == 1 && j == 2)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
                    }
					else if (i == 1 && j == 3)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
                    }
					else if (i == 1 && j == 4)
                    {
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
                    }
					else if (i == 1 && j == 5)
                    {
						SubResult3[i,j-2] = result[i,j];
						SubResult6[i-1, j-2] = result[i,j];
                    }
				// 3rd Row
					else if (i == 2 && j == 0)
                    {
                        SubResult1[i, j] = result[i, j];
						SubResult4[i-1, j] = result[i, j];
						SubResult7[i-2, j] = result[i,j];
                    }
                    else if (i == 2 && j == 1)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
                    }
					else if (i == 2 && j == 2)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 2 && j == 3)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 2 && j == 4)
                    {
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 2 && j == 5)
                    {
						SubResult3[i,j-2] = result[i,j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
				// 4thRow
					else if (i == 3 && j == 0)
                    {
                        SubResult1[i, j] = result[i, j];
						SubResult4[i-1, j] = result[i, j];
						SubResult7[i-2, j] = result[i,j];
                    }
                    else if (i == 3 && j == 1)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
                    }
					else if (i == 3 && j == 2)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 3 && j == 3)
                    {
						SubResult1[i,j] = result[i,j];
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 3 && j == 4)
                    {
						SubResult2[i,j-1] = result[i,j];
						SubResult3[i,j-2] = result[i,j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 3 && j == 5)
                    {
						SubResult3[i,j-2] = result[i,j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
				// 5th Row
					else if (i == 4 && j == 0)
                    {
						SubResult4[i-1, j] = result[i, j];
						SubResult7[i-2, j] = result[i,j];
                    }
                    else if (i == 4 && j == 1)
                    {
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
                    }
					else if (i == 4 && j == 2)
                    {
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 4 && j == 3)
                    {
						SubResult4[i-1, j] = result[i, j];
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 4 && j == 4)
                    {
						SubResult5[i-1, j-1] = result[i, j];
						SubResult6[i-1, j-2] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 4 && j == 5)
                    {
						SubResult6[i-1, j-2] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
				// 6th and last row
					else if (i == 5 && j == 0)
                    {
						SubResult7[i-2, j] = result[i,j];
                    }
                    else if (i == 5 && j == 1)
                    {
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
                    }
					else if (i == 5 && j == 2)
                    {
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 5 && j == 3)
                    {
						SubResult7[i-2, j] = result[i,j];
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 5 && j == 4)
                    {
						SubResult8[i-2, j-1] = result[i,j];
						SubResult9[i-2, j-2] = result[i,j];
                    }
					else if (i == 5 && j == 5)
                    {
                        SubResult9[i - 2, j - 2] = result[i, j];
                    }
                    else
                    {}
                    // This message box is used to check if each value is correct on board after each selection, takes time.
                   // MessageBox.Show(result[i, j].ToString());
                }
               
            }
        } // end copy results

        private void button_click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;

            //set associativity when button is pressed
            if (turn) //true
            {
                b.ForeColor = Color.Green;
                b.Text = "X"; //player 2
                CompareMatrix(b.Name, 1);
                CopyResults();
               
                
            }
            else
            {
                b.Text = "O"; //player 1
                b.ForeColor = Color.Red;
                CompareMatrix(b.Name, 0);
                CopyResults();
                
            }
            turn = !turn;
            b.Enabled = false;

            turnCount++;
            // checkboard will check if every place on the board is selected, and then run an endgame counter
            checkBoard();
            // Will update the scores of the two players
            adjustScore();
            // Check for winner function finds 4 in a row and selects winner
            //Check_For_Winner();
        }

        private void DisableButtons()
        {
            try
            {
                foreach (Control c in panel_gameBoard.Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;

                }
            }
            catch { }
        }//end disable button

        private void CountSubResultsAll(int[,] temp)
        {
            if (temp[0, 0] == temp[0, 1] && temp[0, 1] == temp[0, 2] && temp[0, 2] == temp[0, 3])
            {
                if (temp[0,0] == 0)
                {
                    player1Points++;
                }
                else if (temp[0,0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[1, 0] == temp[1, 1] && temp[1, 1] == temp[1, 2] && temp[1, 2] == temp[1, 3])
            {
                if (temp[1,0] == 0)
                {
                    player1Points++;
                }
                else if (temp[1,0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[2, 0] == temp[2, 1] && temp[2, 1] == temp[2, 2] && temp[2, 2] == temp[2, 3])
            {
                if (temp[2,0] == 0)
                {
                    player1Points++;
                }
                else if (temp[2,0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[3, 0] == temp[3, 1] && temp[3, 1] == temp[3, 2] && temp[3, 2] == temp[3, 3])
            {
                if (temp[3,0] == 0)
                {
                    player1Points++;
                }
                else if (temp[3,0] == 1)
                {
                    player2Points++;
                }
            }
            //vertical line equal
            if (temp[0, 0] == temp[1, 0] && temp[1, 0] == temp[2, 0] && temp[2, 0] == temp[3, 0])
            {
                if (temp[0,0] == 0)
                {
                    player1Points++;
                }
                else if (temp[0,0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[0, 1] == temp[1, 1] && temp[1, 1] == temp[2, 1] && temp[2, 1] == temp[3, 1])
            {
                if (temp[0,1] == 0)
                {
                    player1Points++;
                }
                else if (temp[0,1] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[0, 2] == temp[1, 2] && temp[1, 2] == temp[2, 2] && temp[2, 2] == temp[3, 2])
                {
                if (temp[0,2] == 0)
                {
                    player1Points++;
                }
                else if (temp[0,2] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[0, 3] == temp[1, 3] && temp[1, 3] == temp[2, 3] && temp[2, 3] == temp[3, 3])
                {
                if (temp[0,3] == 0)
                {
                    player1Points++;
                }
                else if (temp[0,3] == 1)
                {
                    player2Points++;
                }
            }
            //diagonal line
            if (temp[0, 0] == temp[1, 1] && temp[1, 1] == temp[2, 2] && temp[2, 2] == temp[3, 3])
                {
                if (temp[0,0] == 0)
                {
                    player1Points++;
                }
                else if (temp[0,0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[3, 0] == temp[2, 1] && temp[2, 1] == temp[1, 2] && temp[1, 2] == temp[0, 3])
            {
                if (temp[3,0] == 0)
                {
                    player1Points++;
                }
                else if (temp[3, 0] == 1)
                {
                    player2Points++;
                }
            }
        }

        //for counting SubResults 4 and 7
        private void countPointsOfHoro(int[,] temp)
        {
            if (temp[0, 0] == temp[0, 1] && temp[0, 1] == temp[0, 2] && temp[0, 2] == temp[0, 3])
            {
                if (temp[0, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[0, 0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[1, 0] == temp[1, 1] && temp[1, 1] == temp[1, 2] && temp[1, 2] == temp[1, 3])
            {
                if (temp[1, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[1, 0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[2, 0] == temp[2, 1] && temp[2, 1] == temp[2, 2] && temp[2, 2] == temp[2, 3])
            {
                if (temp[2, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[2, 0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[3, 0] == temp[3, 1] && temp[3, 1] == temp[3, 2] && temp[3, 2] == temp[3, 3])
            {
                if (temp[3, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[3, 0] == 1)
                {
                    player2Points++;
                }
            }
        }

        //for counting parts of 3,6, and 9
        private void countPointsOfPartialHoro(int[,] temp)
        {
            if (temp[2, 0] == temp[2, 1] && temp[2, 1] == temp[2, 2] && temp[2, 2] == temp[2, 3])
            {
                if (temp[2, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[2, 0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[3, 0] == temp[3, 1] && temp[3, 1] == temp[3, 2] && temp[3, 2] == temp[3, 3])
            {
                if (temp[3, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[3, 0] == 1)
                {
                    player2Points++;
                }
            }
        }

        private void countPointsOfVert(int[,] temp)
        {
            if (temp[0, 0] == temp[1, 0] && temp[1, 0] == temp[2, 0] && temp[2, 0] == temp[3, 0])
            {
                if (temp[0, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[0, 0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[0, 1] == temp[1, 1] && temp[1, 1] == temp[2, 1] && temp[2, 1] == temp[3, 1])
            {
                if (temp[0, 1] == 0)
                {
                    player1Points++;
                }
                else if (temp[0, 1] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[0, 2] == temp[1, 2] && temp[1, 2] == temp[2, 2] && temp[2, 2] == temp[3, 2])
            {
                if (temp[0, 2] == 0)
                {
                    player1Points++;
                }
                else if (temp[0, 2] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[0, 3] == temp[1, 3] && temp[1, 3] == temp[2, 3] && temp[2, 3] == temp[3, 3])
            {
                if (temp[0, 3] == 0)
                {
                    player1Points++;
                }
                else if (temp[0, 3] == 1)
                {
                    player2Points++;
                }
            }
        }

        private void countPointsOfPartialVert(int[,] temp)
        {
            if (temp[0, 2] == temp[1, 2] && temp[1, 2] == temp[2, 2] && temp[2, 2] == temp[3, 2])
            {
                if (temp[0, 2] == 0)
                {
                    player1Points++;
                }
                else if (temp[0, 2] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[0, 3] == temp[1, 3] && temp[1, 3] == temp[2, 3] && temp[2, 3] == temp[3, 3])
            {
                if (temp[0, 3] == 0)
                {
                    player1Points++;
                }
                else if (temp[0, 3] == 1)
                {
                    player2Points++;
                }
            }
        }

        private void countPointsOfDiagonal(int[,] temp)
        {
            if (temp[0, 0] == temp[1, 1] && temp[1, 1] == temp[2, 2] && temp[2, 2] == temp[3, 3])
            {
                if (temp[0, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[0, 0] == 1)
                {
                    player2Points++;
                }
            }
            if (temp[3, 0] == temp[2, 1] && temp[2, 1] == temp[1, 2] && temp[1, 2] == temp[0, 3])
            {
                if (temp[3, 0] == 0)
                {
                    player1Points++;
                }
                else if (temp[3, 0] == 1)
                {
                    player2Points++;
                }
            }
        }

        private void adjustScore()
        {
            label_scoreboardP1_totalLabel.Text = "Total Points = " + player1Points;
            label_scoreboardP2_totalLabel.Text = "Total Points = " + player2Points;
        }

    }
}
