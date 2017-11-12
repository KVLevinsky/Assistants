namespace ExchangeLogAnalyzer
{
    partial class FormELA
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
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lvData = new System.Windows.Forms.ListView();
            this.tTabs = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tpStatistics = new System.Windows.Forms.TabPage();
            this.msMain.SuspendLayout();
            this.tTabs.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssMain
            // 
            this.ssMain.Location = new System.Drawing.Point(0, 540);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(784, 22);
            this.ssMain.TabIndex = 0;
            this.ssMain.Text = "statusStrip1";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(784, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeyDisplayString = "";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "E&xit";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "&Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(152, 22);
            this.tsmiAbout.Text = "&About";
            // 
            // lvData
            // 
            this.lvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvData.FullRowSelect = true;
            this.lvData.GridLines = true;
            this.lvData.Location = new System.Drawing.Point(3, 3);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(770, 484);
            this.lvData.TabIndex = 2;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // tTabs
            // 
            this.tTabs.Controls.Add(this.tpMain);
            this.tTabs.Controls.Add(this.tpStatistics);
            this.tTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tTabs.Location = new System.Drawing.Point(0, 24);
            this.tTabs.Name = "tTabs";
            this.tTabs.SelectedIndex = 0;
            this.tTabs.Size = new System.Drawing.Size(784, 516);
            this.tTabs.TabIndex = 3;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.lvData);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(776, 490);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Журнал";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // tpStatistics
            // 
            this.tpStatistics.Location = new System.Drawing.Point(4, 22);
            this.tpStatistics.Name = "tpStatistics";
            this.tpStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatistics.Size = new System.Drawing.Size(776, 490);
            this.tpStatistics.TabIndex = 1;
            this.tpStatistics.Text = "Статистика";
            this.tpStatistics.UseVisualStyleBackColor = true;
            // 
            // FormELA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tTabs);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.msMain);
            this.Icon = global::ExchangeLogAnalyzer.Properties.Resources.Magnifier;
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormELA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange Log Analyzer";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tTabs.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.TabControl tTabs;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage tpStatistics;
    }
}

