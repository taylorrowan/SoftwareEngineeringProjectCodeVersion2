namespace Test_TTT_Game
{
    partial class Form_playerHistory
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
            this.groupBox_historySearch = new System.Windows.Forms.GroupBox();
            this.button_historySearch_viewAll = new System.Windows.Forms.Button();
            this.button_historySearch_search = new System.Windows.Forms.Button();
            this.textBox_historySearch_name = new System.Windows.Forms.TextBox();
            this.label_historySearch_name = new System.Windows.Forms.Label();
            this.button_backToMenuFrmHistory = new System.Windows.Forms.Button();
            this.groupBox_history_playerInfo = new System.Windows.Forms.GroupBox();
            this.richTextBox_history_playerInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox_historySearch.SuspendLayout();
            this.groupBox_history_playerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_historySearch
            // 
            this.groupBox_historySearch.Controls.Add(this.button_historySearch_viewAll);
            this.groupBox_historySearch.Controls.Add(this.button_historySearch_search);
            this.groupBox_historySearch.Controls.Add(this.textBox_historySearch_name);
            this.groupBox_historySearch.Controls.Add(this.label_historySearch_name);
            this.groupBox_historySearch.Location = new System.Drawing.Point(12, 12);
            this.groupBox_historySearch.Name = "groupBox_historySearch";
            this.groupBox_historySearch.Size = new System.Drawing.Size(430, 56);
            this.groupBox_historySearch.TabIndex = 0;
            this.groupBox_historySearch.TabStop = false;
            this.groupBox_historySearch.Text = "Search Player";
            // 
            // button_historySearch_viewAll
            // 
            this.button_historySearch_viewAll.Location = new System.Drawing.Point(341, 21);
            this.button_historySearch_viewAll.Name = "button_historySearch_viewAll";
            this.button_historySearch_viewAll.Size = new System.Drawing.Size(75, 23);
            this.button_historySearch_viewAll.TabIndex = 3;
            this.button_historySearch_viewAll.Text = "View All";
            this.button_historySearch_viewAll.UseVisualStyleBackColor = true;
            // 
            // button_historySearch_search
            // 
            this.button_historySearch_search.Location = new System.Drawing.Point(260, 21);
            this.button_historySearch_search.Name = "button_historySearch_search";
            this.button_historySearch_search.Size = new System.Drawing.Size(75, 23);
            this.button_historySearch_search.TabIndex = 2;
            this.button_historySearch_search.Text = "Search";
            this.button_historySearch_search.UseVisualStyleBackColor = true;
            // 
            // textBox_historySearch_name
            // 
            this.textBox_historySearch_name.Location = new System.Drawing.Point(85, 23);
            this.textBox_historySearch_name.Name = "textBox_historySearch_name";
            this.textBox_historySearch_name.Size = new System.Drawing.Size(159, 20);
            this.textBox_historySearch_name.TabIndex = 1;
            // 
            // label_historySearch_name
            // 
            this.label_historySearch_name.AutoSize = true;
            this.label_historySearch_name.Location = new System.Drawing.Point(16, 26);
            this.label_historySearch_name.Name = "label_historySearch_name";
            this.label_historySearch_name.Size = new System.Drawing.Size(63, 13);
            this.label_historySearch_name.TabIndex = 0;
            this.label_historySearch_name.Text = "Enter Name";
            // 
            // button_backToMenuFrmHistory
            // 
            this.button_backToMenuFrmHistory.Location = new System.Drawing.Point(166, 512);
            this.button_backToMenuFrmHistory.Name = "button_backToMenuFrmHistory";
            this.button_backToMenuFrmHistory.Size = new System.Drawing.Size(126, 23);
            this.button_backToMenuFrmHistory.TabIndex = 4;
            this.button_backToMenuFrmHistory.Text = "Back to Main Menu";
            this.button_backToMenuFrmHistory.UseVisualStyleBackColor = true;
            this.button_backToMenuFrmHistory.Click += new System.EventHandler(this.button_backToMenuFrmHistory_Click);
            // 
            // groupBox_history_playerInfo
            // 
            this.groupBox_history_playerInfo.Controls.Add(this.richTextBox_history_playerInfo);
            this.groupBox_history_playerInfo.Location = new System.Drawing.Point(12, 89);
            this.groupBox_history_playerInfo.Name = "groupBox_history_playerInfo";
            this.groupBox_history_playerInfo.Size = new System.Drawing.Size(430, 406);
            this.groupBox_history_playerInfo.TabIndex = 1;
            this.groupBox_history_playerInfo.TabStop = false;
            this.groupBox_history_playerInfo.Text = "Player Information";
            // 
            // richTextBox_history_playerInfo
            // 
            this.richTextBox_history_playerInfo.Location = new System.Drawing.Point(6, 19);
            this.richTextBox_history_playerInfo.Name = "richTextBox_history_playerInfo";
            this.richTextBox_history_playerInfo.Size = new System.Drawing.Size(418, 382);
            this.richTextBox_history_playerInfo.TabIndex = 0;
            this.richTextBox_history_playerInfo.Text = "";
            // 
            // Form_playerHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 547);
            this.Controls.Add(this.button_backToMenuFrmHistory);
            this.Controls.Add(this.groupBox_history_playerInfo);
            this.Controls.Add(this.groupBox_historySearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_playerHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DITZY PLAYER HISTORY";
            this.groupBox_historySearch.ResumeLayout(false);
            this.groupBox_historySearch.PerformLayout();
            this.groupBox_history_playerInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_historySearch;
        private System.Windows.Forms.Label label_historySearch_name;
        private System.Windows.Forms.TextBox textBox_historySearch_name;
        private System.Windows.Forms.Button button_backToMenuFrmHistory;
        private System.Windows.Forms.Button button_historySearch_viewAll;
        private System.Windows.Forms.Button button_historySearch_search;
        private System.Windows.Forms.GroupBox groupBox_history_playerInfo;
        private System.Windows.Forms.RichTextBox richTextBox_history_playerInfo;
    }
}