namespace WinApp.View
{
    partial class AppForm
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
            this.StopFileCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonClearFilter = new System.Windows.Forms.Button();
            this.DirectoriesRadioButton = new System.Windows.Forms.RadioButton();
            this.AllRadioButton = new System.Windows.Forms.RadioButton();
            this.NameFileRadioButton = new System.Windows.Forms.RadioButton();
            this.StopAfterFilterTextBox = new System.Windows.Forms.TextBox();
            this.SearchStringTextBox = new System.Windows.Forms.TextBox();
            this.PathButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.LogElementsListBox = new System.Windows.Forms.ListBox();
            this.TreeElementsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StopFileCheckBox
            // 
            this.StopFileCheckBox.AutoSize = true;
            this.StopFileCheckBox.Location = new System.Drawing.Point(14, 89);
            this.StopFileCheckBox.Name = "StopFileCheckBox";
            this.StopFileCheckBox.Size = new System.Drawing.Size(256, 28);
            this.StopFileCheckBox.TabIndex = 21;
            this.StopFileCheckBox.Text = "Stop after( File or Directory)";
            this.StopFileCheckBox.UseVisualStyleBackColor = true;
            this.StopFileCheckBox.CheckedChanged += new System.EventHandler(this.StopFileCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ButtonClearFilter);
            this.groupBox2.Controls.Add(this.DirectoriesRadioButton);
            this.groupBox2.Controls.Add(this.AllRadioButton);
            this.groupBox2.Controls.Add(this.NameFileRadioButton);
            this.groupBox2.Controls.Add(this.StopFileCheckBox);
            this.groupBox2.Controls.Add(this.StopAfterFilterTextBox);
            this.groupBox2.Controls.Add(this.SearchStringTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 296);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Filter text:";
            // 
            // ButtonClearFilter
            // 
            this.ButtonClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonClearFilter.Location = new System.Drawing.Point(9, 259);
            this.ButtonClearFilter.Name = "ButtonClearFilter";
            this.ButtonClearFilter.Size = new System.Drawing.Size(298, 30);
            this.ButtonClearFilter.TabIndex = 13;
            this.ButtonClearFilter.Text = "Clear filters";
            this.ButtonClearFilter.UseVisualStyleBackColor = true;
            this.ButtonClearFilter.Click += new System.EventHandler(this.ButtonClearFilter_Click);
            // 
            // DirectoriesRadioButton
            // 
            this.DirectoriesRadioButton.AutoSize = true;
            this.DirectoriesRadioButton.Location = new System.Drawing.Point(14, 191);
            this.DirectoriesRadioButton.Name = "DirectoriesRadioButton";
            this.DirectoriesRadioButton.Size = new System.Drawing.Size(208, 28);
            this.DirectoriesRadioButton.TabIndex = 11;
            this.DirectoriesRadioButton.Text = "Show only directories";
            this.DirectoriesRadioButton.UseVisualStyleBackColor = true;
            this.DirectoriesRadioButton.CheckedChanged += new System.EventHandler(this.SelectResult_Update);
            // 
            // AllRadioButton
            // 
            this.AllRadioButton.AutoSize = true;
            this.AllRadioButton.Location = new System.Drawing.Point(14, 158);
            this.AllRadioButton.Name = "AllRadioButton";
            this.AllRadioButton.Size = new System.Drawing.Size(99, 28);
            this.AllRadioButton.TabIndex = 12;
            this.AllRadioButton.Text = "Show all";
            this.AllRadioButton.UseVisualStyleBackColor = true;
            this.AllRadioButton.CheckedChanged += new System.EventHandler(this.SelectResult_Update);
            // 
            // NameFileRadioButton
            // 
            this.NameFileRadioButton.AutoSize = true;
            this.NameFileRadioButton.Location = new System.Drawing.Point(14, 225);
            this.NameFileRadioButton.Name = "NameFileRadioButton";
            this.NameFileRadioButton.Size = new System.Drawing.Size(153, 28);
            this.NameFileRadioButton.TabIndex = 12;
            this.NameFileRadioButton.Text = "Show only files";
            this.NameFileRadioButton.UseVisualStyleBackColor = true;
            this.NameFileRadioButton.CheckedChanged += new System.EventHandler(this.SelectResult_Update);
            // 
            // StopAfterFilterTextBox
            // 
            this.StopAfterFilterTextBox.Location = new System.Drawing.Point(14, 123);
            this.StopAfterFilterTextBox.Name = "StopAfterFilterTextBox";
            this.StopAfterFilterTextBox.Size = new System.Drawing.Size(290, 29);
            this.StopAfterFilterTextBox.TabIndex = 17;
            this.StopAfterFilterTextBox.TextChanged += new System.EventHandler(this.StopAfterFilterTextBox_TextChanged);
            // 
            // SearchStringTextBox
            // 
            this.SearchStringTextBox.Location = new System.Drawing.Point(14, 52);
            this.SearchStringTextBox.Name = "SearchStringTextBox";
            this.SearchStringTextBox.Size = new System.Drawing.Size(290, 29);
            this.SearchStringTextBox.TabIndex = 17;
            this.SearchStringTextBox.TextChanged += new System.EventHandler(this.SearchStringTextBox_TextChanged);
            // 
            // PathButton
            // 
            this.PathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PathButton.Location = new System.Drawing.Point(275, 26);
            this.PathButton.Margin = new System.Windows.Forms.Padding(1);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(29, 28);
            this.PathButton.TabIndex = 19;
            this.PathButton.Text = "...";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathTextBox.Location = new System.Drawing.Point(6, 28);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(265, 26);
            this.pathTextBox.TabIndex = 18;
            this.pathTextBox.TextChanged += new System.EventHandler(this.PathTextBox_TextChanged);
            // 
            // FilterButton
            // 
            this.FilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilterButton.Location = new System.Drawing.Point(12, 382);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(313, 39);
            this.FilterButton.TabIndex = 16;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // LogElementsListBox
            // 
            this.LogElementsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogElementsListBox.FormattingEnabled = true;
            this.LogElementsListBox.HorizontalScrollbar = true;
            this.LogElementsListBox.Location = new System.Drawing.Point(6, 6);
            this.LogElementsListBox.Name = "LogElementsListBox";
            this.LogElementsListBox.Size = new System.Drawing.Size(638, 342);
            this.LogElementsListBox.TabIndex = 13;
            // 
            // TreeElementsListBox
            // 
            this.TreeElementsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TreeElementsListBox.FormattingEnabled = true;
            this.TreeElementsListBox.HorizontalScrollbar = true;
            this.TreeElementsListBox.Location = new System.Drawing.Point(6, 6);
            this.TreeElementsListBox.Name = "TreeElementsListBox";
            this.TreeElementsListBox.Size = new System.Drawing.Size(638, 342);
            this.TreeElementsListBox.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pathTextBox);
            this.groupBox1.Controls.Add(this.PathButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 60);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directories";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(331, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(658, 396);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TreeElementsListBox);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(650, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tree directories";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LogElementsListBox);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(650, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logging";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 428);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.FilterButton);
            this.Name = "AppForm";
            this.Text = "AppForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox StopFileCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonClearFilter;
        private System.Windows.Forms.RadioButton NameFileRadioButton;
        private System.Windows.Forms.RadioButton DirectoriesRadioButton;
        private System.Windows.Forms.Button PathButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox SearchStringTextBox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.ListBox LogElementsListBox;
        private System.Windows.Forms.ListBox TreeElementsListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox StopAfterFilterTextBox;
        private System.Windows.Forms.RadioButton AllRadioButton;
    }
}

