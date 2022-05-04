namespace SP_Management
{
    partial class Toast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toast));
            this.PictureAlert = new System.Windows.Forms.PictureBox();
            this.LabelAlert = new System.Windows.Forms.Label();
            this.TimerAlert = new System.Windows.Forms.Timer(this.components);
            this.TimerAnimated = new System.Windows.Forms.Timer(this.components);
            this.TimerClose = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureAlert
            // 
            this.PictureAlert.ErrorImage = null;
            this.PictureAlert.Image = ((System.Drawing.Image)(resources.GetObject("PictureAlert.Image")));
            this.PictureAlert.Location = new System.Drawing.Point(12, 12);
            this.PictureAlert.Name = "PictureAlert";
            this.PictureAlert.Size = new System.Drawing.Size(65, 65);
            this.PictureAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureAlert.TabIndex = 0;
            this.PictureAlert.TabStop = false;
            // 
            // LabelAlert
            // 
            this.LabelAlert.AutoSize = true;
            this.LabelAlert.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAlert.Location = new System.Drawing.Point(123, 33);
            this.LabelAlert.Name = "LabelAlert";
            this.LabelAlert.Size = new System.Drawing.Size(143, 22);
            this.LabelAlert.TabIndex = 1;
            this.LabelAlert.Text = "Message show";
            // 
            // TimerAlert
            // 
            this.TimerAlert.Interval = 3000;
            this.TimerAlert.Tick += new System.EventHandler(this.TimerAlert_Tick);
            // 
            // TimerAnimated
            // 
            this.TimerAnimated.Interval = 10;
            this.TimerAnimated.Tick += new System.EventHandler(this.TimerAnimated_Tick);
            // 
            // TimerClose
            // 
            this.TimerClose.Interval = 10;
            this.TimerClose.Tick += new System.EventHandler(this.TimerClose_Tick);
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(387, 89);
            this.Controls.Add(this.LabelAlert);
            this.Controls.Add(this.PictureAlert);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Toast";
            this.Opacity = 0.9D;
            this.Text = "ToastAlert";
            this.Load += new System.EventHandler(this.Toast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureAlert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureAlert;
        private System.Windows.Forms.Label LabelAlert;
        private System.Windows.Forms.Timer TimerAlert;
        private System.Windows.Forms.Timer TimerAnimated;
        private System.Windows.Forms.Timer TimerClose;
    }
}