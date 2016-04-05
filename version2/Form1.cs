using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace version2
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();

        }

        //Player vs Player Checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            PvCCheckbox.Select();
        }

        private void PvCCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
