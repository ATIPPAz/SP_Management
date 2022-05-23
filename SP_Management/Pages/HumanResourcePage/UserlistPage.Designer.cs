namespace SP_Management.Pages.HumanResourcePage
{
    partial class UserlistPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.ToExcelBtn = new System.Windows.Forms.Button();
            this.TablePanel = new System.Windows.Forms.Panel();
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.ToPdfBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.AscBtn = new System.Windows.Forms.PictureBox();
            this.DescBtn = new System.Windows.Forms.PictureBox();
            this.SearchBtn = new System.Windows.Forms.PictureBox();
            this.TablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AscBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBar
            // 
            this.SearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBar.Location = new System.Drawing.Point(6, 84);
            this.SearchBar.Margin = new System.Windows.Forms.Padding(6);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(1293, 29);
            this.SearchBar.TabIndex = 0;
            // 
            // ToExcelBtn
            // 
            this.ToExcelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToExcelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(147)))), ((int)(((byte)(206)))));
            this.ToExcelBtn.FlatAppearance.BorderSize = 0;
            this.ToExcelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToExcelBtn.Location = new System.Drawing.Point(1224, 6);
            this.ToExcelBtn.Name = "ToExcelBtn";
            this.ToExcelBtn.Size = new System.Drawing.Size(151, 39);
            this.ToExcelBtn.TabIndex = 1;
            this.ToExcelBtn.Text = "NewEmployee";
            this.ToExcelBtn.UseVisualStyleBackColor = false;
            this.ToExcelBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // TablePanel
            // 
            this.TablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablePanel.AutoScroll = true;
            this.TablePanel.Controls.Add(this.BodyPanel);
            this.TablePanel.Controls.Add(this.HeaderPanel);
            this.TablePanel.Location = new System.Drawing.Point(0, 157);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Size = new System.Drawing.Size(1385, 681);
            this.TablePanel.TabIndex = 1;
            // 
            // BodyPanel
            // 
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 50);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(1385, 631);
            this.BodyPanel.TabIndex = 2;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1385, 50);
            this.HeaderPanel.TabIndex = 1;
            // 
            // ToPdfBtn
            // 
            this.ToPdfBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToPdfBtn.BackColor = System.Drawing.Color.Red;
            this.ToPdfBtn.FlatAppearance.BorderSize = 0;
            this.ToPdfBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToPdfBtn.Location = new System.Drawing.Point(1308, 116);
            this.ToPdfBtn.Name = "ToPdfBtn";
            this.ToPdfBtn.Size = new System.Drawing.Size(67, 39);
            this.ToPdfBtn.TabIndex = 1;
            this.ToPdfBtn.Text = "PDF";
            this.ToPdfBtn.UseVisualStyleBackColor = false;
            this.ToPdfBtn.Click += new System.EventHandler(this.ToPdfBtn_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LimeGreen;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(1224, 116);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 39);
            this.button5.TabIndex = 3;
            this.button5.Text = "Excel";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // AscBtn
            // 
            this.AscBtn.Image = global::SP_Management.Properties.Resources.DownArrow;
            this.AscBtn.Location = new System.Drawing.Point(50, 122);
            this.AscBtn.Name = "AscBtn";
            this.AscBtn.Size = new System.Drawing.Size(44, 29);
            this.AscBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AscBtn.TabIndex = 4;
            this.AscBtn.TabStop = false;
            this.AscBtn.Click += new System.EventHandler(this.AscBtn_Click);
            // 
            // DescBtn
            // 
            this.DescBtn.Image = global::SP_Management.Properties.Resources.UpArrowIcon;
            this.DescBtn.Location = new System.Drawing.Point(0, 122);
            this.DescBtn.Name = "DescBtn";
            this.DescBtn.Size = new System.Drawing.Size(44, 29);
            this.DescBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DescBtn.TabIndex = 4;
            this.DescBtn.TabStop = false;
            this.DescBtn.Click += new System.EventHandler(this.DescBtn_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Image = global::SP_Management.Properties.Resources.SearchIcon;
            this.SearchBtn.Location = new System.Drawing.Point(1312, 84);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(63, 29);
            this.SearchBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.TabStop = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // UserlistPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.AscBtn);
            this.Controls.Add(this.DescBtn);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.TablePanel);
            this.Controls.Add(this.ToPdfBtn);
            this.Controls.Add(this.ToExcelBtn);
            this.Controls.Add(this.SearchBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UserlistPage";
            this.Size = new System.Drawing.Size(1385, 838);
            this.TablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AscBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button ToExcelBtn;
        private System.Windows.Forms.Panel TablePanel;
        private System.Windows.Forms.Button ToPdfBtn;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox SearchBtn;
        private System.Windows.Forms.PictureBox DescBtn;
        private System.Windows.Forms.PictureBox AscBtn;
    }
}
