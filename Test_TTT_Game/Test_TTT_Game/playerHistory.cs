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
    public partial class Form_playerHistory : Form
    {
        public Form_playerHistory()
        {
            InitializeComponent();
        }

        private void Form_playerHistory_Load(object sender, EventArgs e)
        {
            richTextBox_history_playerInfo.Text = "";
        }

        private void button_backToMenuFrmHistory_Click(object sender, EventArgs e)
        {
            Form_mainMenu frm_mM = new Form_mainMenu();
            frm_mM.Show();
            this.Hide();
        }

        private void textBox_historySearch_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_historySearch_search_Click_1(object sender, EventArgs e)
        {
            richTextBox_history_playerInfo.Text = "";

            string player = "";
            double win1, loss1, tie1, total1;
            bool found = false;
            XmlDocument xml = new XmlDocument();
            xml.Load("playerDatabase.xml");

            XmlNodeList xnlist = xml.SelectNodes("/Users/User");

            if (textBox_historySearch_name.Text != "")
            {
                player = textBox_historySearch_name.Text;
                foreach (XmlNode xn in xnlist)
                {
                    if (player == xn["Name"].InnerText)
                    {
                        richTextBox_history_playerInfo.AppendText("Player : " + player + "\n");
                        richTextBox_history_playerInfo.AppendText("Won   : " + xn["Win"].InnerText.ToString() + "\n");
                        richTextBox_history_playerInfo.AppendText("Loss   : " + xn["Loss"].InnerText.ToString() + "\n");
                        richTextBox_history_playerInfo.AppendText("Draw  : " + xn["Tie"].InnerText.ToString() + "\n");
                        win1 = System.Convert.ToDouble(xn["Win"].InnerText.ToString());
                        loss1 = System.Convert.ToDouble(xn["Loss"].InnerText.ToString());
                        tie1 = System.Convert.ToDouble(xn["Tie"].InnerText.ToString());

                        total1 = (win1 / (win1 + loss1 + tie1)) * 100;
                        richTextBox_history_playerInfo.AppendText("Ratio  : " + Math.Round(total1, 2) + "%\n");
                        richTextBox_history_playerInfo.AppendText("------------------------------------------------\n");
                        found = true;
                    }

                }
                if (found == false)
                    MessageBox.Show("Can not find " + textBox_historySearch_name.Text);
                textBox_historySearch_name.Text = "";

            }
            else
                MessageBox.Show("Please enter a name!", "Validation");

        }

        private void button_historySearch_viewAll_Click_1(object sender, EventArgs e)
        {
            double win1, loss1, tie1, total1;
            XmlDocument xml = new XmlDocument();
            xml.Load("playerDatabase.xml");
            //MessageBox.Show(name);
            XmlNodeList xnlist = xml.SelectNodes("/Users/User");
            foreach (XmlNode xn in xnlist)
            {
                if (xn["Name"].InnerText != "")
                {
                    richTextBox_history_playerInfo.AppendText("Player : " + xn["Name"].InnerText + "\n");
                    richTextBox_history_playerInfo.AppendText("Won   : " + xn["Win"].InnerText.ToString() + "\n");
                    richTextBox_history_playerInfo.AppendText("Loss   : " + xn["Loss"].InnerText.ToString() + "\n");
                    richTextBox_history_playerInfo.AppendText("Draw  : " + xn["Tie"].InnerText.ToString() + "\n");
                    win1 = System.Convert.ToDouble(xn["Win"].InnerText.ToString());
                    loss1 = System.Convert.ToDouble(xn["Loss"].InnerText.ToString());
                    tie1 = System.Convert.ToDouble(xn["Tie"].InnerText.ToString());

                    total1 = (win1 / (win1 + loss1 + tie1)) * 100;
                    richTextBox_history_playerInfo.AppendText("Ratio  : " + Math.Round(total1, 2) + "%\n");
                    richTextBox_history_playerInfo.AppendText("------------------------------------------------\n");

                }

            }
        }
    }
}
