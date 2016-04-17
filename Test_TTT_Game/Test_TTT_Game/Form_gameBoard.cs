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
            Form_gameBoard frm_gB = new Form_gameBoard();
            frm_gB.Show();
            this.Hide();
        }
    }
}
