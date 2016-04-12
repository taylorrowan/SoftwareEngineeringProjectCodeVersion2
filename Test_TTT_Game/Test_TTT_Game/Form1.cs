using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_TTT_Game
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_PvP.Checked)
            {
                checkBox_player2Guest.Enabled = true;
                comboBox2.Enabled = true;
                checkBox_PvC.Checked = false;
            }
            else
            {
                checkBox_player2Guest.Enabled = false;
                comboBox2.Enabled = false;
                checkBox_PvC.Checked = true;
            }
        }

        private void checkBox_PvC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_PvC.Checked)
            {
                checkBox_player2Guest.Enabled = false;
                comboBox2.Enabled = false;
                checkBox_PvP.Checked = false;
            }
            else
            {
                checkBox_player2Guest.Enabled = true;
                comboBox2.Enabled = true;
                checkBox_PvP.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox_player1Guest.Checked)
            {
                comboBox1.Enabled = false;
                comboBox1.Text = "";
            }
            else 
            {
                comboBox1.Enabled = true;
            }
        }

        private void checkBox_player2Guest_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player2Guest.Checked)
            {
                comboBox2.Enabled = false;
                comboBox2.Text = "";
            }
            else
            {
                comboBox2.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            checkBox_PvC.Checked = true;
            checkBox_player1GoesFirst.Checked = true;
            checkBox_diffEasy.Checked = true;
            comboBox2.Enabled = false;
            checkBox_player2Guest.Enabled = false;
            comboBox3.Text = "Blue";
            comboBox4.Text = "Red";
        }

        private void checkBox_player1GoesFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player1GoesFirst.Checked)
            {
                checkBox_player2GoesFirst.Checked = false;
            }
            else
            {
                checkBox_player2GoesFirst.Checked = true;
            }
        }

        private void checkBox_player2GoesFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player2GoesFirst.Checked)
            {
                checkBox_player1GoesFirst.Checked = false;
            }
            else
            {
                checkBox_player1GoesFirst.Checked = true;
            }
        }

        private void button_startGame_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == comboBox4.Text)
            {
                MessageBox.Show("Please select different color stones");
            }
            else if (!(checkBox_diffHard.Checked || checkBox_diffMedium.Checked || checkBox_diffEasy.Checked))
            {
                MessageBox.Show("Please select a difficulty");
            }
        }

        private void groupBox_step4_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox_diffEasy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_diffEasy.Checked)
            {
                //checkBox_diffEasy.Checked = true;
                checkBox_diffMedium.Checked = false;
                checkBox_diffHard.Checked = false;
            }
        }

        private void checkBox_diffMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_diffMedium.Checked)
            {
                // checkBox_diffMedium.Checked = true;
                checkBox_diffEasy.Checked = false;
                checkBox_diffHard.Checked = false;
            }
        }

        private void checkBox_diffHard_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_diffHard.Checked)
            {
                // checkBox_diffHard.Checked = true;
                checkBox_diffEasy.Checked = false;
                checkBox_diffMedium.Checked = false;
            }
        }

        

        
    }
}
