namespace LuxuryHomeMarketing
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
            this.startBbutton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.infoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.membersGridView = new System.Windows.Forms.DataGridView();
            this.queueGroupBox = new System.Windows.Forms.GroupBox();
            this.logGgroupBox = new System.Windows.Forms.GroupBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.statusStrip1.SuspendLayout();
            this.membersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersGridView)).BeginInit();
            this.logGgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // startBbutton
            // 
            this.startBbutton.Location = new System.Drawing.Point(12, 398);
            this.startBbutton.Name = "startBbutton";
            this.startBbutton.Size = new System.Drawing.Size(75, 23);
            this.startBbutton.TabIndex = 0;
            this.startBbutton.Text = "Start";
            this.startBbutton.UseVisualStyleBackColor = true;
            this.startBbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1010, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // infoStatusLabel
            // 
            this.infoStatusLabel.Name = "infoStatusLabel";
            this.infoStatusLabel.Size = new System.Drawing.Size(69, 17);
            this.infoStatusLabel.Text = "Members: 0";
            // 
            // membersGroupBox
            // 
            this.membersGroupBox.Controls.Add(this.membersGridView);
            this.membersGroupBox.Location = new System.Drawing.Point(12, 12);
            this.membersGroupBox.Name = "membersGroupBox";
            this.membersGroupBox.Size = new System.Drawing.Size(493, 380);
            this.membersGroupBox.TabIndex = 3;
            this.membersGroupBox.TabStop = false;
            this.membersGroupBox.Text = "Members";
            // 
            // membersGridView
            // 
            this.membersGridView.AllowUserToAddRows = false;
            this.membersGridView.AllowUserToDeleteRows = false;
            this.membersGridView.BackgroundColor = System.Drawing.Color.White;
            this.membersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.membersGridView.Location = new System.Drawing.Point(3, 16);
            this.membersGridView.Name = "membersGridView";
            this.membersGridView.ReadOnly = true;
            this.membersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.membersGridView.Size = new System.Drawing.Size(487, 361);
            this.membersGridView.TabIndex = 0;
            // 
            // queueGroupBox
            // 
            this.queueGroupBox.Location = new System.Drawing.Point(511, 12);
            this.queueGroupBox.Name = "queueGroupBox";
            this.queueGroupBox.Size = new System.Drawing.Size(487, 199);
            this.queueGroupBox.TabIndex = 4;
            this.queueGroupBox.TabStop = false;
            this.queueGroupBox.Text = "Queue";
            // 
            // logGgroupBox
            // 
            this.logGgroupBox.Controls.Add(this.logRichTextBox);
            this.logGgroupBox.Location = new System.Drawing.Point(511, 217);
            this.logGgroupBox.Name = "logGgroupBox";
            this.logGgroupBox.Size = new System.Drawing.Size(486, 204);
            this.logGgroupBox.TabIndex = 5;
            this.logGgroupBox.TabStop = false;
            this.logGgroupBox.Text = "Log";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(255, 398);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // resumeButton
            // 
            this.resumeButton.Location = new System.Drawing.Point(93, 398);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(75, 23);
            this.resumeButton.TabIndex = 7;
            this.resumeButton.Text = "Resume";
            this.resumeButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(174, 398);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 8;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(336, 398);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logRichTextBox.Location = new System.Drawing.Point(3, 16);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(480, 185);
            this.logRichTextBox.TabIndex = 0;
            this.logRichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 451);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.logGgroupBox);
            this.Controls.Add(this.queueGroupBox);
            this.Controls.Add(this.membersGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startBbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parser Luxury Home Marketing";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.membersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.membersGridView)).EndInit();
            this.logGgroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBbutton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel infoStatusLabel;
        private System.Windows.Forms.GroupBox membersGroupBox;
        private System.Windows.Forms.GroupBox queueGroupBox;
        private System.Windows.Forms.GroupBox logGgroupBox;
        private System.Windows.Forms.DataGridView membersGridView;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RichTextBox logRichTextBox;
    }
}

