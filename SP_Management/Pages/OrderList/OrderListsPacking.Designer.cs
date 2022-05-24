namespace SP_Management.Pages.PackingPage
{
    partial class OrderListsPacking
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.ToPdfBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.AutoScroll = true;
            this.TopPanel.Controls.Add(this.button5);
            this.TopPanel.Controls.Add(this.ToPdfBtn);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(6);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1385, 150);
            this.TopPanel.TabIndex = 0;
            // 
            // BodyPanel
            // 
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 150);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(1385, 688);
            this.BodyPanel.TabIndex = 1;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 150);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1385, 60);
            this.HeaderPanel.TabIndex = 1;
            // 
            // ToPdfBtn
            // 
            this.ToPdfBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToPdfBtn.BackColor = System.Drawing.Color.Red;
            this.ToPdfBtn.FlatAppearance.BorderSize = 0;
            this.ToPdfBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToPdfBtn.ForeColor = System.Drawing.Color.White;
            this.ToPdfBtn.Location = new System.Drawing.Point(1297, 94);
            this.ToPdfBtn.Name = "ToPdfBtn";
            this.ToPdfBtn.Size = new System.Drawing.Size(67, 39);
            this.ToPdfBtn.TabIndex = 3;
            this.ToPdfBtn.Text = "PDF";
            this.ToPdfBtn.UseVisualStyleBackColor = false;
            this.ToPdfBtn.Click += new System.EventHandler(this.ToPdfBtn_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LimeGreen;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(1197, 94);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 39);
            this.button5.TabIndex = 5;
            this.button5.Text = "Excel";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // OrderListsPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.BodyPanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OrderListsPacking";
            this.Size = new System.Drawing.Size(1385, 838);
            this.Load += new System.EventHandler(this.OrderLists_Load);
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button ToPdfBtn;
        private System.Windows.Forms.Button button5;
    }
}
