namespace version2
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Player1Label = new System.Windows.Forms.Label();
            this.PvPCheckbox = new System.Windows.Forms.CheckBox();
            this.Player2Label = new System.Windows.Forms.Label();
            this.PvCCheckbox = new System.Windows.Forms.CheckBox();
            this.Player1NameComboBox = new System.Windows.Forms.ComboBox();
            this.Player2NameComboBox = new System.Windows.Forms.ComboBox();
            this.Player1GuestCheckBox = new System.Windows.Forms.CheckBox();
            this.Player2GuestCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(26, 393);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(45, 13);
            this.Player1Label.TabIndex = 0;
            this.Player1Label.Text = "Player 1";
            // 
            // PvPCheckbox
            // 
            this.PvPCheckbox.AutoSize = true;
            this.PvPCheckbox.Location = new System.Drawing.Point(87, 279);
            this.PvPCheckbox.Name = "PvPCheckbox";
            this.PvPCheckbox.Size = new System.Drawing.Size(104, 17);
            this.PvPCheckbox.TabIndex = 1;
            this.PvPCheckbox.Text = "Player vs. Player";
            this.PvPCheckbox.UseVisualStyleBackColor = true;
            this.PvPCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(26, 450);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(45, 13);
            this.Player2Label.TabIndex = 0;
            this.Player2Label.Text = "Player 2";
            // 
            // PvCCheckbox
            // 
            this.PvCCheckbox.AutoSize = true;
            this.PvCCheckbox.Location = new System.Drawing.Point(87, 232);
            this.PvCCheckbox.Name = "PvCCheckbox";
            this.PvCCheckbox.Size = new System.Drawing.Size(120, 17);
            this.PvCCheckbox.TabIndex = 2;
            this.PvCCheckbox.Text = "Player vs. Computer";
            this.PvCCheckbox.UseVisualStyleBackColor = true;
            this.PvCCheckbox.CheckedChanged += new System.EventHandler(this.PvCCheckbox_CheckedChanged);
            // 
            // Player1NameComboBox
            // 
            this.Player1NameComboBox.FormattingEnabled = true;
            this.Player1NameComboBox.Location = new System.Drawing.Point(86, 390);
            this.Player1NameComboBox.Name = "Player1NameComboBox";
            this.Player1NameComboBox.Size = new System.Drawing.Size(121, 21);
            this.Player1NameComboBox.TabIndex = 3;
            // 
            // Player2NameComboBox
            // 
            this.Player2NameComboBox.FormattingEnabled = true;
            this.Player2NameComboBox.Location = new System.Drawing.Point(86, 447);
            this.Player2NameComboBox.Name = "Player2NameComboBox";
            this.Player2NameComboBox.Size = new System.Drawing.Size(121, 21);
            this.Player2NameComboBox.TabIndex = 4;
            // 
            // Player1GuestCheckBox
            // 
            this.Player1GuestCheckBox.AutoSize = true;
            this.Player1GuestCheckBox.Location = new System.Drawing.Point(243, 393);
            this.Player1GuestCheckBox.Name = "Player1GuestCheckBox";
            this.Player1GuestCheckBox.Size = new System.Drawing.Size(95, 17);
            this.Player1GuestCheckBox.TabIndex = 5;
            this.Player1GuestCheckBox.Text = "Player 1 Guest";
            this.Player1GuestCheckBox.UseVisualStyleBackColor = true;
            // 
            // Player2GuestCheckBox
            // 
            this.Player2GuestCheckBox.AutoSize = true;
            this.Player2GuestCheckBox.Location = new System.Drawing.Point(243, 445);
            this.Player2GuestCheckBox.Name = "Player2GuestCheckBox";
            this.Player2GuestCheckBox.Size = new System.Drawing.Size(95, 17);
            this.Player2GuestCheckBox.TabIndex = 6;
            this.Player2GuestCheckBox.Text = "Player 2 Guest";
            this.Player2GuestCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(877, 613);
            this.Controls.Add(this.Player2GuestCheckBox);
            this.Controls.Add(this.Player1GuestCheckBox);
            this.Controls.Add(this.Player2NameComboBox);
            this.Controls.Add(this.Player1NameComboBox);
            this.Controls.Add(this.PvCCheckbox);
            this.Controls.Add(this.PvPCheckbox);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.Player2Label);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DITZY";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.CheckBox PvPCheckbox;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.CheckBox PvCCheckbox;
        private System.Windows.Forms.ComboBox Player1NameComboBox;
        private System.Windows.Forms.ComboBox Player2NameComboBox;
        private System.Windows.Forms.CheckBox Player1GuestCheckBox;
        private System.Windows.Forms.CheckBox Player2GuestCheckBox;
    }
}

