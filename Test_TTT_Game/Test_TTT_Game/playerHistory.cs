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
    public partial class Form_playerHistory : Form
    {
        public Form_playerHistory()
        {
            InitializeComponent();
        }

        private void button_backToMenuFrmHistory_Click(object sender, EventArgs e)
        {
            Form_mainMenu frm_mM = new Form_mainMenu();
            frm_mM.Show();
            this.Hide();
        }
    }
}
