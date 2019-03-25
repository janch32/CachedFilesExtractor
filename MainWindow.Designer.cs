namespace CachedFilesExtractor
{
    partial class MainWindow
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.ProfileSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Stats = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Stats)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatAppearance.BorderSize = 2;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Location = new System.Drawing.Point(196, 13);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 30);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Uložit";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // ProfileSelect
            // 
            this.ProfileSelect.BackColor = System.Drawing.Color.Gainsboro;
            this.ProfileSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfileSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileSelect.FormattingEnabled = true;
            this.ProfileSelect.ItemHeight = 17;
            this.ProfileSelect.Location = new System.Drawing.Point(12, 17);
            this.ProfileSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProfileSelect.Name = "ProfileSelect";
            this.ProfileSelect.Size = new System.Drawing.Size(172, 25);
            this.ProfileSelect.TabIndex = 3;
            this.ProfileSelect.SelectedValueChanged += new System.EventHandler(this.ProfileSelectChange);
            // 
            // label1
            // 
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.Text = "Připraveno";
            // 
            // Stats
            // 
            this.Stats.Location = new System.Drawing.Point(12, 73);
            this.Stats.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(271, 356);
            this.Stats.TabIndex = 6;
            this.Stats.TabStop = false;
            this.Stats.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawStats);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(295, 442);
            this.Controls.Add(this.Stats);
            this.Controls.Add(this.ProfileSelect);
            this.Controls.Add(this.SaveButton);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Cached Files Extractor";
            this.Load += new System.EventHandler(this.WindowLoad);
            ((System.ComponentModel.ISupportInitialize)(this.Stats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ToolStripStatusLabel label1;
        private System.Windows.Forms.ComboBox ProfileSelect;
        private System.Windows.Forms.PictureBox Stats;
        private System.Windows.Forms.Button button1;
    }
}

