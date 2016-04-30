﻿using System;
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
    public partial class Form_mainMenu : Form
    {
        public Form_mainMenu()
        {
            InitializeComponent();
        }

        // If player vs. player is checked
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

            if (checkBox_PvP.Checked)
            {
                checkBox_player2Guest.Enabled = true;
                comboBox_player2Name.Enabled = true;
                comboBox_player2Stone.Enabled = true;
                label_compStone.Enabled = false;
                checkBox_diffEasy.Enabled = false;
                checkBox_diffMedium.Enabled = false;
                checkBox_diffHard.Enabled = false;
                checkBox_PvC.Checked = false;
                comboBox_player1Name.SelectedIndex = -1;
                comboBox_player2Name.SelectedIndex = -1;
                comboBox_player2Stone.Text = "Royal Blue";
                
            }
            else
            {
                checkBox_player2Guest.Enabled = false;
                comboBox_player2Name.Enabled = false;
                comboBox_player2Stone.Text = "";
                comboBox_player2Stone.Enabled = false;
                label_compStone.Enabled = true;
                checkBox_diffEasy.Enabled = true;
                checkBox_diffMedium.Enabled = true;
                checkBox_diffHard.Enabled = true;
                checkBox_PvC.Checked = true;
                comboBox_player1Name.SelectedIndex = -1;
                comboBox_player2Name.SelectedIndex = 0;
                comboBox_player2Stone.SelectedIndex = -1;
            }
        }

        // If player vs. computer is checked...
        private void checkBox_PvC_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_player1Name.Text = "";
            comboBox_player2Name.Text = "";
            checkBox_player1Guest.Checked = false;
            checkBox_player2Guest.Checked = false;

            if (checkBox_PvC.Checked)
            {
                checkBox_player2Guest.Enabled = false;
                comboBox_player2Name.Enabled = false;
                checkBox_PvP.Checked = false;
                comboBox_player2Stone.SelectedIndex = -1;
            }
            else
            {
                checkBox_player2Guest.Enabled = true;
                comboBox_player2Name.Enabled = true;
                checkBox_PvP.Checked = true;
            }
        }

        // If player 1 guest is checked...
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox_player1Guest.Checked)
            {
                comboBox_player1Name.Enabled = false;
                comboBox_player1Name.Text = "Guest1";
      
            }
            else 
            {
                comboBox_player1Name.Enabled = true;
            }
        }

        // If player 2 guest is checked...
        private void checkBox_player2Guest_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player2Guest.Checked)
            {
                comboBox_player2Name.Enabled = false;
                comboBox_player2Name.Text = "Guest2";
            }
            else
            {
                comboBox_player2Name.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // Items that are enabled/disabled when main menu is loaded
        private void mainMenu_Load(object sender, EventArgs e)
        {
            checkBox_PvC.Checked = true;
            checkBox_player1GoesFirst.Checked = true;
            checkBox_diffEasy.Checked = true;
            comboBox_player2Name.Enabled = false;
            checkBox_player2Guest.Enabled = false;
            comboBox_player1Stone.Text = "Gold";
            comboBox_player2Stone.Text = "";
            comboBox_player2Stone.Enabled = false;
            
            getPlayer(); // Populate player combo boxes with registered player names
            
        }

        // If player 1 goes first is checked...
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

        // If player 2 goes first is checked...
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

        // To pass the Player1 Name to the game board
        public string getPlayer1Name
        {
            get { return comboBox_player1Name.Text; }
        }
        // To pass the Player2 Name to the game board
        public string getPlayer2Name
        {
            get { return comboBox_player2Name.Text; }
        }
        // To pass the who goes first to the game board
        public bool getWhoGoesFirst
        {
            get 
            {
                if (checkBox_player1GoesFirst.Checked)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            
            }
        }
        // To pass the Player1 Color to the game board
        public string getPlayer1Color
        {
            get { return comboBox_player1Stone.Text; }
        }
        // To pass the Player2 Color to the game board
        public string getPlayer2Color
        {
            get
            {
                if (checkBox_PvC.Checked)
                {
                    return "Black"; // AI color is black
                }
                else
                {
                    return comboBox_player2Stone.Text;
                }
            }
        }
        // To pass Difficulty
        public string getDifficulty
        {
            get
            {
                if (checkBox_diffEasy.Checked)
                {
                    return checkBox_diffEasy.Text;
                }
                else if (checkBox_diffMedium.Checked)
                {
                    return checkBox_diffMedium.Text;
                }
                else if (checkBox_diffHard.Checked)
                {
                    return checkBox_diffHard.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        // If start game is selected...
        private void button_startGame_Click(object sender, EventArgs e)
        {
            if (comboBox_player1Name.Text == comboBox_player2Name.Text || (comboBox_player1Name.Text == "..." && !(checkBox_player1Guest.Checked)) || (comboBox_player2Name.Text == "..t." && !(checkBox_player2Guest.Checked)))
            {
                MessageBox.Show("Please select a different player name");
            }
            else if (comboBox_player1Name.Text == "DITZY" || (checkBox_PvP.Checked && comboBox_player2Name.Text == "DITZY"))
            {
                MessageBox.Show("Please select a different player name, DITZY is the name of our AI");
            }
            else if (comboBox_player1Stone.Text == comboBox_player2Stone.Text || (comboBox_player2Stone.Text == "..." && checkBox_PvP.Checked))
            {
                MessageBox.Show("Please select a different stone color");
            }
            else if (!(checkBox_diffHard.Checked || checkBox_diffMedium.Checked || checkBox_diffEasy.Checked))
            {
                MessageBox.Show("Please select a difficulty");
            }
            else
            {
                Form_gameBoard frm_gB = new Form_gameBoard();
                frm_gB.player1NameGB = getPlayer1Name;
                frm_gB.player2NameGB = getPlayer2Name;
                frm_gB.player1ColorGB = getPlayer1Color;
                frm_gB.player2ColorGB = getPlayer2Color;
                frm_gB.whoseGoingFirst = getWhoGoesFirst;
                frm_gB.AIdifficulty = getDifficulty;
                frm_gB.Show();
                this.Hide();
            }
        }

        private void groupBox_step4_Enter(object sender, EventArgs e)
        {

        }

        // If Easy is checked...
        private void checkBox_diffEasy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_diffEasy.Checked)
            {
                checkBox_diffMedium.Checked = false;
                checkBox_diffHard.Checked = false;
            }
        }

        // If Medium is checked...
        private void checkBox_diffMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_diffMedium.Checked)
            {
                checkBox_diffEasy.Checked = false;
                checkBox_diffHard.Checked = false;
            }
        }

        // If Hard is checked...
        private void checkBox_diffHard_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_diffHard.Checked)
            {
                checkBox_diffEasy.Checked = false;
                checkBox_diffMedium.Checked = false;
            }
        }

        // If view player history is clicked...
        private void button_viewHistory_Click(object sender, EventArgs e)
        {
            Form_playerHistory frm_pH = new Form_playerHistory();
            frm_pH.Show();
            this.Hide();
        }

        // Insert new player name to xml database
        private void insertNode(string username)
        {
            // Create an instant of xml document and load content of xml file
            XmlDocument doc = new XmlDocument();
            doc.Load("playerDatabase.xml");

            // Add user info node
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "User", "");

            XmlNode nodeName = doc.CreateElement("Name");
            nodeName.InnerText = username;
            XmlNode nodeWin = doc.CreateElement("Win");
            nodeWin.InnerText = "0";
            XmlNode nodeLoss = doc.CreateElement("Loss");
            nodeLoss.InnerText = "0";
            XmlNode nodeTie = doc.CreateElement("Tie");
            nodeTie.InnerText = "0";

            node.AppendChild(nodeName);
            node.AppendChild(nodeWin);
            node.AppendChild(nodeLoss);
            node.AppendChild(nodeTie);
            doc.DocumentElement.AppendChild(node);

            doc.Save("playerDatabase.xml");
        }

        // If register button is clicked...
        private void button_regNewPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_playerName.Text != "")
                {
                    string name;
                    bool nameExist = false;

                    // Check if player already exist
                    XmlDocument xml = new XmlDocument();
                    xml.Load("playerDatabase.xml");

                    XmlNodeList xnlist = xml.SelectNodes("/Users/User");

                    foreach (XmlNode xn in xnlist)
                    {
                        name = xn["Name"].InnerText;
                        if (textBox_playerName.Text == name)
                        {
                            MessageBox.Show("\"" + textBox_playerName.Text + "\" is taken! Please choose another name.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox_playerName.Text = "";
                            nameExist = true;
                        }
                    }

                    if (nameExist == false)
                    {
                        insertNode(textBox_playerName.Text);

                        MessageBox.Show("\"" + textBox_playerName.Text + "\" is created sucessfully!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_playerName.Text = "";
                    }
                }
                else
                    MessageBox.Show("The name entered is unacceptable!  Please choose another name.", "Validation");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            getPlayer(); // Updates player 1 & 2 combo boxes
        }

        // To load registered players' names in player 1 & 2 combo boxes
        private void getPlayer() 
        {
            comboBox_player1Name.Items.Clear();
            comboBox_player2Name.Items.Clear();
            string name;

            //start checking if user exists
            XmlDocument xml = new XmlDocument();
            xml.Load("playerDatabase.xml");

            XmlNodeList xnlist = xml.SelectNodes("/Users/User");

            foreach (XmlNode xn in xnlist)
            {
                name = xn["Name"].InnerText;
                if (name != "" )

                    comboBox_player1Name.Items.Add(name);
            }
            foreach (XmlNode xn in xnlist)
            {
                name = xn["Name"].InnerText;
                if (name != "")

                    comboBox_player2Name.Items.Add(name);

            }

            comboBox_player2Name.SelectedIndex = 0;
        }

        private void comboBox_player1Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_player1Stone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
