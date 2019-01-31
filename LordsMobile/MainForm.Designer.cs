namespace LordsMobile
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstMEmuProfiles = new System.Windows.Forms.ListView();
            this.lvhUse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvhName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvhID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtYCoord = new System.Windows.Forms.TextBox();
            this.txtXCoord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKCoord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGuildName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNoInstances = new System.Windows.Forms.Label();
            this.txtNoInstances = new System.Windows.Forms.TextBox();
            this.txtTimeOnAccount = new System.Windows.Forms.TextBox();
            this.lblTimeOnAccount = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstProfiles = new System.Windows.Forms.ListBox();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.ttpInstances = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrunts = new System.Windows.Forms.TextBox();
            this.txtArchers = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCataphracts = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBallistas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstMEmuProfiles);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MEmu Instances";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstMEmuProfiles
            // 
            this.lstMEmuProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvhUse,
            this.lvhName,
            this.lvhID});
            this.lstMEmuProfiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstMEmuProfiles.Location = new System.Drawing.Point(6, 6);
            this.lstMEmuProfiles.Name = "lstMEmuProfiles";
            this.lstMEmuProfiles.Size = new System.Drawing.Size(720, 468);
            this.lstMEmuProfiles.TabIndex = 0;
            this.lstMEmuProfiles.UseCompatibleStateImageBehavior = false;
            // 
            // lvhUse
            // 
            this.lvhUse.Text = "Use?";
            this.lvhUse.Width = -2;
            // 
            // lvhName
            // 
            this.lvhName.DisplayIndex = 2;
            this.lvhName.Text = "Instance Name";
            this.lvhName.Width = -2;
            // 
            // lvhID
            // 
            this.lvhID.DisplayIndex = 1;
            this.lvhID.Text = "GUID";
            this.lvhID.Width = -2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(14, 8);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(740, 506);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtYCoord);
            this.groupBox2.Controls.Add(this.txtXCoord);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtKCoord);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtAccountName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtGuildName);
            this.groupBox2.Location = new System.Drawing.Point(6, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 119);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Settings";
            // 
            // txtYCoord
            // 
            this.txtYCoord.Location = new System.Drawing.Point(206, 93);
            this.txtYCoord.Name = "txtYCoord";
            this.txtYCoord.Size = new System.Drawing.Size(34, 20);
            this.txtYCoord.TabIndex = 11;
            this.txtYCoord.Text = "198";
            // 
            // txtXCoord
            // 
            this.txtXCoord.Location = new System.Drawing.Point(169, 93);
            this.txtXCoord.Name = "txtXCoord";
            this.txtXCoord.Size = new System.Drawing.Size(34, 20);
            this.txtXCoord.TabIndex = 10;
            this.txtXCoord.Text = "268";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hive Coordinates";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKCoord
            // 
            this.txtKCoord.Location = new System.Drawing.Point(132, 93);
            this.txtKCoord.Name = "txtKCoord";
            this.txtKCoord.Size = new System.Drawing.Size(34, 20);
            this.txtKCoord.TabIndex = 8;
            this.txtKCoord.Text = "436";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name Prefix";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(132, 19);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(108, 20);
            this.txtAccountName.TabIndex = 4;
            this.txtAccountName.Text = "mgt";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Guild Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGuildName
            // 
            this.txtGuildName.Location = new System.Drawing.Point(132, 44);
            this.txtGuildName.Name = "txtGuildName";
            this.txtGuildName.Size = new System.Drawing.Size(108, 20);
            this.txtGuildName.TabIndex = 6;
            this.txtGuildName.Text = "Maggots";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNoInstances);
            this.groupBox1.Controls.Add(this.txtNoInstances);
            this.groupBox1.Controls.Add(this.txtTimeOnAccount);
            this.groupBox1.Controls.Add(this.lblTimeOnAccount);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 72);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instance Settings";
            // 
            // lblNoInstances
            // 
            this.lblNoInstances.Location = new System.Drawing.Point(6, 16);
            this.lblNoInstances.Name = "lblNoInstances";
            this.lblNoInstances.Size = new System.Drawing.Size(120, 20);
            this.lblNoInstances.TabIndex = 1;
            this.lblNoInstances.Text = "# of Instances";
            this.lblNoInstances.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoInstances
            // 
            this.txtNoInstances.Location = new System.Drawing.Point(132, 16);
            this.txtNoInstances.Name = "txtNoInstances";
            this.txtNoInstances.Size = new System.Drawing.Size(108, 20);
            this.txtNoInstances.TabIndex = 0;
            this.txtNoInstances.Text = "4";
            // 
            // txtTimeOnAccount
            // 
            this.txtTimeOnAccount.Location = new System.Drawing.Point(132, 41);
            this.txtTimeOnAccount.Name = "txtTimeOnAccount";
            this.txtTimeOnAccount.Size = new System.Drawing.Size(108, 20);
            this.txtTimeOnAccount.TabIndex = 2;
            this.txtTimeOnAccount.Text = "10";
            // 
            // lblTimeOnAccount
            // 
            this.lblTimeOnAccount.Location = new System.Drawing.Point(6, 41);
            this.lblTimeOnAccount.Name = "lblTimeOnAccount";
            this.lblTimeOnAccount.Size = new System.Drawing.Size(120, 20);
            this.lblTimeOnAccount.TabIndex = 3;
            this.lblTimeOnAccount.Text = "Time Per Account";
            this.lblTimeOnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(544, 333);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Escape";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(625, 69);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Turf?s";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(510, 155);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "Down";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(596, 120);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "Right";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(420, 120);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Left";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(510, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Up";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(437, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Test Match";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Take SS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 441);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstProfiles);
            this.tabPage3.Controls.Add(this.pnlProfile);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(732, 470);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Profiles";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstProfiles
            // 
            this.lstProfiles.FormattingEnabled = true;
            this.lstProfiles.Location = new System.Drawing.Point(3, 4);
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.Size = new System.Drawing.Size(228, 459);
            this.lstProfiles.TabIndex = 1;
            this.lstProfiles.SelectedIndexChanged += new System.EventHandler(this.lstProfiles_SelectedIndexChanged);
            // 
            // pnlProfile
            // 
            this.pnlProfile.Location = new System.Drawing.Point(237, 4);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(492, 459);
            this.pnlProfile.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(131, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "K";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(168, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(205, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "Y";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBallistas);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCataphracts);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtArchers);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtGrunts);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(6, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 65);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Max Troop Settings";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Grunt";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGrunts
            // 
            this.txtGrunts.Location = new System.Drawing.Point(9, 37);
            this.txtGrunts.Name = "txtGrunts";
            this.txtGrunts.Size = new System.Drawing.Size(51, 20);
            this.txtGrunts.TabIndex = 1;
            this.txtGrunts.Text = "1000";
            // 
            // txtArchers
            // 
            this.txtArchers.Location = new System.Drawing.Point(69, 37);
            this.txtArchers.Name = "txtArchers";
            this.txtArchers.Size = new System.Drawing.Size(51, 20);
            this.txtArchers.TabIndex = 3;
            this.txtArchers.Text = "1000";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(69, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "Archer";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCataphracts
            // 
            this.txtCataphracts.Location = new System.Drawing.Point(129, 37);
            this.txtCataphracts.Name = "txtCataphracts";
            this.txtCataphracts.Size = new System.Drawing.Size(51, 20);
            this.txtCataphracts.TabIndex = 5;
            this.txtCataphracts.Text = "1000";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(129, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 14);
            this.label9.TabIndex = 4;
            this.label9.Text = "Cataph...";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBallistas
            // 
            this.txtBallistas.Location = new System.Drawing.Point(189, 37);
            this.txtBallistas.Name = "txtBallistas";
            this.txtBallistas.Size = new System.Drawing.Size(51, 20);
            this.txtBallistas.TabIndex = 7;
            this.txtBallistas.Text = "1000";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(189, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 14);
            this.label10.TabIndex = 6;
            this.label10.Text = "Ballista";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 530);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MaggotBot";
            this.tabPage2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lstMEmuProfiles;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ColumnHeader lvhUse;
        private System.Windows.Forms.ColumnHeader lvhID;
        private System.Windows.Forms.ColumnHeader lvhName;
        private System.Windows.Forms.Label lblNoInstances;
        private System.Windows.Forms.TextBox txtNoInstances;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lstProfiles;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.ToolTip ttpInstances;
        private System.Windows.Forms.Label lblTimeOnAccount;
        private System.Windows.Forms.TextBox txtTimeOnAccount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGuildName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtYCoord;
        private System.Windows.Forms.TextBox txtXCoord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKCoord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBallistas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCataphracts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtArchers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGrunts;
        private System.Windows.Forms.Label label7;
    }
}

