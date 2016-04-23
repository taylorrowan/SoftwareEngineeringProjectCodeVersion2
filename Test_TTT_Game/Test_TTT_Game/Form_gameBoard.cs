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


        String[,] names = new String[6, 6] {{"A1","B1","C1","D1","E1","F1"},
                                            {"A2","B2","C2","D2","E2","F2"},
                                            {"A3","B3","C3","D3","E3","F3"},
                                            {"A4","B4","C4","D4","E4","F4"},
                                            {"A5","B5","C5","D5","E5","F5"},
                                            {"A6","B6","C6","D6","E6","F6"}};



        /// <summary>
        /// this section reserved for all possiblities where this is a winner
        /// </summary>
        //case 1
        int[,] result1 = new int[4, 4] {{1,1,1,1},
                                        {0,0,0,0},
                                        {0,0,0,0},
                                        {0,0,0,0}};
        //case 2
        int[,] result2 = new int[4, 4] {{0,0,0,0},
                                        {1,1,1,1},
                                        {0,0,0,0},
                                        {0,0,0,0}};
        //case 3
        int[,] result3 = new int[4, 4] {{0,0,0,0},
                                        {0,0,0,0},
                                        {1,1,1,1},
                                        {0,0,0,0}};
        //case 4
        int[,] result4 = new int[4, 4] {{0,0,0,0},
                                        {0,0,0,0},
                                        {0,0,0,0},
                                        {1,1,1,1}};
        //case 5
        int[,] result5 = new int[4, 4] {{1,0,0,0},
                                        {0,1,0,0},
                                        {0,0,1,0},
                                        {0,0,0,1}};
        //case 6
        int[,] result6 = new int[4, 4] {{1,0,0,0},
                                        {1,0,0,0},
                                        {1,0,0,0},
                                        {1,0,0,0}};
        //case 7
        int[,] result7 = new int[4, 4] {{0,1,0,0},
                                        {0,1,0,0},
                                        {0,1,0,0},
                                        {0,1,0,0}};
        //case 8
        int[,] result8 = new int[4, 4] {{0,0,1,0},
                                        {0,0,1,0},
                                        {0,0,1,0},
                                        {0,0,1,0}};
        //case 9
        int[,] result9 = new int[4, 4] {{0,0,0,1},
                                        {0,0,0,1},
                                        {0,0,0,1},
                                        {0,0,0,1}};
        //case 10
        int[,] result10 = new int[4, 4] {{0,0,0,1},
                                         {0,0,1,0},
                                         {0,1,0,0},
                                         {1,0,0,0}};




        private void fillMatrix()
        {
            //filling the matrix by default : 2 for empty, 1 and 0 for players
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    result[i, j] = random.Next(2, 100000);
                }

            }
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
            Check_For_Winner();
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

        private void CheckSubResults1(int[,] temp)
        {
            //horizontal line equal
            if (temp[0, 0] == temp[0, 1] && temp[0, 1] == temp[0, 2] && temp[0, 2] == temp[0, 3] && (!A1.Enabled))

                isWinner = true;

            else if (temp[1, 0] == temp[1, 1] && temp[1, 1] == temp[1, 2] && temp[1, 2] == temp[1, 3] && (!A2.Enabled))
                isWinner = true;
            else if (temp[2, 0] == temp[2, 1] && temp[2, 1] == temp[2, 2] && temp[2, 2] == temp[2, 3] && (!A3.Enabled))
                isWinner = true;
            else if (temp[3, 0] == temp[3, 1] && temp[3, 1] == temp[3, 2] && temp[3, 2] == temp[3, 3] && (!A4.Enabled))
                isWinner = true;
            //vertical line equal
            if (temp[0, 0] == temp[1, 0] && temp[1, 1] == temp[2, 0] && temp[2, 0] == temp[3, 0] && (!A1.Enabled))
                isWinner = true;
            else if (temp[0, 1] == temp[1, 1] && temp[1, 1] == temp[2, 1] && temp[2, 1] == temp[3, 1] && (!B1.Enabled))
                isWinner = true;
            else if (temp[0, 2] == temp[1, 2] && temp[1, 2] == temp[2, 2] && temp[2, 2] == temp[3, 2] && (!C1.Enabled))
                isWinner = true;
            else if (temp[0, 3] == temp[1, 3] && temp[1, 3] == temp[2, 3] && temp[2, 3] == temp[3, 3] && (!D1.Enabled))
                isWinner = true;

            //diagonal line
            if (temp[0, 0] == temp[1, 1] && temp[1, 1] == temp[2, 2] && temp[2, 2] == temp[3, 3] && (!A1.Enabled))
                isWinner = true;
            else if (temp[3, 0] == temp[2, 1] && temp[2, 1] == temp[1, 2] && temp[1, 2] == temp[0, 3] && (!A4.Enabled))
                isWinner = true;
        }//end check sub results.

        private void CheckSubResults2(int[,] temp)
        {
            //horizontal line equal
            if (temp[0, 0] == temp[0, 1] && temp[0, 1] == temp[0, 2] && temp[0, 2] == temp[0, 3] && (!B1.Enabled))
                isWinner = true;
            else if (temp[1, 0] == temp[1, 1] && temp[1, 1] == temp[1, 2] && temp[1, 2] == temp[1, 3] && (!B2.Enabled))
                isWinner = true;
            else if (temp[2, 0] == temp[2, 1] && temp[2, 1] == temp[2, 2] && temp[2, 2] == temp[2, 3] && (!B3.Enabled))
                isWinner = true;
            else if (temp[3, 0] == temp[3, 1] && temp[3, 1] == temp[3, 2] && temp[3, 2] == temp[3, 3] && (!B4.Enabled))
                isWinner = true;

            //vertical line equal
            if (temp[0, 0] == temp[1, 0] && temp[1, 1] == temp[2, 0] && temp[2, 0] == temp[3, 0] && (!B1.Enabled))
                isWinner = true;
            else if (temp[0, 1] == temp[1, 1] && temp[1, 1] == temp[2, 1] && temp[2, 1] == temp[3, 1] && (!C1.Enabled))
                isWinner = true;
            else if (temp[0, 2] == temp[1, 2] && temp[1, 2] == temp[2, 2] && temp[2, 2] == temp[3, 2] && (!D1.Enabled))
                isWinner = true;
            else if (temp[0, 3] == temp[1, 3] && temp[1, 3] == temp[2, 3] && temp[2, 3] == temp[3, 3] && (!E1.Enabled))
                isWinner = true;

            //diagonal line
            if (temp[0, 0] == temp[1, 1] && temp[1, 1] == temp[2, 2] && temp[2, 2] == temp[3, 3] && (!B1.Enabled))
                isWinner = true;
            else if (temp[3, 0] == temp[2, 1] && temp[2, 1] == temp[1, 2] && temp[1, 2] == temp[0, 3] && (!B4.Enabled))
                isWinner = true;
        }//end check sub results.

        private void CheckSubResults3(int[,] temp)
        {
            //horizontal line equal
            if (temp[0, 0] == temp[0, 1] && temp[0, 1] == temp[0, 2] && temp[0, 2] == temp[0, 3] && (!A2.Enabled))
                isWinner = true;
            else if (temp[1, 0] == temp[1, 1] && temp[1, 1] == temp[1, 2] && temp[1, 2] == temp[1, 3] && (!A3.Enabled))
                isWinner = true;
            else if (temp[2, 0] == temp[2, 1] && temp[2, 1] == temp[2, 2] && temp[2, 2] == temp[2, 3] && (!A4.Enabled))
                isWinner = true;
            else if (temp[3, 0] == temp[3, 1] && temp[3, 1] == temp[3, 2] && temp[3, 2] == temp[3, 3] && (!A5.Enabled))
                isWinner = true;

            //vertical line equal
            if (temp[0, 0] == temp[1, 0] && temp[1, 1] == temp[2, 0] && temp[2, 0] == temp[3, 0] && (!A2.Enabled))
                isWinner = true;
            else if (temp[0, 1] == temp[1, 1] && temp[1, 1] == temp[2, 1] && temp[2, 1] == temp[3, 1] && (!B2.Enabled))
                isWinner = true;
            else if (temp[0, 2] == temp[1, 2] && temp[1, 2] == temp[2, 2] && temp[2, 2] == temp[3, 2] && (!C2.Enabled))
                isWinner = true;
            else if (temp[0, 3] == temp[1, 3] && temp[1, 3] == temp[2, 3] && temp[2, 3] == temp[3, 3] && (!D2.Enabled))
                isWinner = true;

            //diagonal line
            if (temp[0, 0] == temp[1, 1] && temp[1, 1] == temp[2, 2] && temp[2, 2] == temp[3, 3] && (!A2.Enabled))
                isWinner = true;
            else if (temp[3, 0] == temp[2, 1] && temp[2, 1] == temp[1, 2] && temp[1, 2] == temp[0, 3] && (!A5.Enabled))
                isWinner = true;
        }//end check sub results.

        private void CheckSubResults4(int[,] temp)
        {
            //horizontal line equal
            if (temp[0, 0] == temp[0, 1] && temp[0, 1] == temp[0, 2] && temp[0, 2] == temp[0, 3] && (!B2.Enabled))
                isWinner = true;
            else if (temp[1, 0] == temp[1, 1] && temp[1, 1] == temp[1, 2] && temp[1, 2] == temp[1, 3] && (!B3.Enabled))
                isWinner = true;
            else if (temp[2, 0] == temp[2, 1] && temp[2, 1] == temp[2, 2] && temp[2, 2] == temp[2, 3] && (!B4.Enabled))
                isWinner = true;
            else if (temp[3, 0] == temp[3, 1] && temp[3, 1] == temp[3, 2] && temp[3, 2] == temp[3, 3] && (!C5.Enabled))
                isWinner = true;

            //vertical line equal
            if (temp[0, 0] == temp[1, 0] && temp[1, 1] == temp[2, 0] && temp[2, 0] == temp[3, 0] && (!B2.Enabled))
                isWinner = true;
            else if (temp[0, 1] == temp[1, 1] && temp[1, 1] == temp[2, 1] && temp[2, 1] == temp[3, 1] && (!C2.Enabled))
                isWinner = true;
            else if (temp[0, 2] == temp[1, 2] && temp[1, 2] == temp[2, 2] && temp[2, 2] == temp[3, 2] && (!D2.Enabled))
                isWinner = true;
            else if (temp[0, 3] == temp[1, 3] && temp[1, 3] == temp[2, 3] && temp[2, 3] == temp[3, 3] && (!E2.Enabled))
                isWinner = true;

            //diagonal line
            if (temp[0, 0] == temp[1, 1] && temp[1, 1] == temp[2, 2] && temp[2, 2] == temp[3, 3] && (!B2.Enabled))
                isWinner = true;
            else if (temp[3, 0] == temp[2, 1] && temp[2, 1] == temp[1, 2] && temp[1, 2] == temp[0, 3] && (!B5.Enabled))
                isWinner = true;
        }

        private void Check_For_Winner()
        {
            //bool isWinner = false;

            //check winner logistic in this  <==========NEED HELP========================>


            CheckSubResults1(SubResult1);
            CheckSubResults2(SubResult2);
            CheckSubResults3(SubResult3);
            CheckSubResults4(SubResult4);
           // CheckSubResults5(SubResult5);
            //CheckSubResults6(SubResult6);
            //CheckSubResults7(SubResult7);
            //CheckSubResults8(SubResult8);
            //CheckSubResults9(SubResult9);
            //check winner logistic in this   <==========NEED HELP========================>

            if (isWinner)
            {
                DisableButtons();
                //String winner = "";
                if (turn)
                {
                    /*winner = label13.Text;
                    label17.Text = (Int32.Parse(label17.Text) + 1).ToString();
                    label21.Text = (Int32.Parse(label21.Text) + 1).ToString();*/
                    MessageBox.Show(/*winner + */" ABC Wins!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //UpdateWinLoss(label13.Text, label15.Text, false);
                }
                else
                {
                    /*winner = label15.Text;
                    label18.Text = (Int32.Parse(label18.Text) + 1).ToString();
                    label20.Text = (Int32.Parse(label20.Text) + 1).ToString();*/
                    MessageBox.Show(/*winner + */" 123 Wins!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //UpdateWinLoss(label15.Text, label13.Text, false);
                }
            }
            else
            {
                if (turnCount == 25)
                {
                    //update draw game result
                    /*label19.Text = (Int32.Parse(label19.Text) + 1).ToString();
                    label22.Text = (Int32.Parse(label22.Text) + 1).ToString();*/
                    MessageBox.Show("Draw game!", "No Result");
                    //UpdateWinLoss(label13.Text, label15.Text, true);
                }
            }
        }//end Check_For_Winner

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

    }
}
