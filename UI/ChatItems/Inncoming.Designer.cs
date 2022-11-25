
namespace UI.ChatItems
{
    partial class Inncoming
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inncoming));
            this.bunifuUserControl1 = new Bunifu.UI.WinForms.BunifuUserControl();
            this.pctAvatar = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuUserControl1
            // 
            this.bunifuUserControl1.AllowAnimations = false;
            this.bunifuUserControl1.AllowBorderColorChanges = false;
            this.bunifuUserControl1.AllowMouseEffects = false;
            this.bunifuUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuUserControl1.AnimationSpeed = 200;
            this.bunifuUserControl1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuUserControl1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(201)))), ((int)(((byte)(123)))));
            this.bunifuUserControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(60)))));
            this.bunifuUserControl1.BorderRadius = 30;
            this.bunifuUserControl1.BorderStyle = Bunifu.UI.WinForms.BunifuUserControl.BorderStyles.Solid;
            this.bunifuUserControl1.BorderThickness = 1;
            this.bunifuUserControl1.ColorContrastOnClick = 30;
            this.bunifuUserControl1.ColorContrastOnHover = 30;
            this.bunifuUserControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuUserControl1.Image = null;
            this.bunifuUserControl1.ImageMargin = new System.Windows.Forms.Padding(0);
            this.bunifuUserControl1.Location = new System.Drawing.Point(97, 13);
            this.bunifuUserControl1.Name = "bunifuUserControl1";
            this.bunifuUserControl1.ShowBorders = true;
            this.bunifuUserControl1.Size = new System.Drawing.Size(341, 98);
            this.bunifuUserControl1.Style = Bunifu.UI.WinForms.BunifuUserControl.UserControlStyles.Flat;
            this.bunifuUserControl1.TabIndex = 0;
            // 
            // pctAvatar
            // 
            this.pctAvatar.AllowFocused = false;
            this.pctAvatar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctAvatar.AutoSizeHeight = true;
            this.pctAvatar.BorderRadius = 35;
            this.pctAvatar.Image = ((System.Drawing.Image)(resources.GetObject("pctAvatar.Image")));
            this.pctAvatar.IsCircle = true;
            this.pctAvatar.Location = new System.Drawing.Point(19, 18);
            this.pctAvatar.Name = "pctAvatar";
            this.pctAvatar.Size = new System.Drawing.Size(70, 70);
            this.pctAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctAvatar.TabIndex = 1;
            this.pctAvatar.TabStop = false;
            this.pctAvatar.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(201)))), ((int)(((byte)(123)))));
            this.lblTitle.Location = new System.Drawing.Point(121, 47);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 54);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(201)))), ((int)(((byte)(123)))));
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblName.Location = new System.Drawing.Point(120, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 20);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(201)))), ((int)(((byte)(123)))));
            this.lblHour.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHour.Location = new System.Drawing.Point(360, 23);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(40, 19);
            this.lblHour.TabIndex = 4;
            this.lblHour.Text = "Hour";
            // 
            // Inncoming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pctAvatar);
            this.Controls.Add(this.bunifuUserControl1);
            this.Name = "Inncoming";
            this.Size = new System.Drawing.Size(634, 130);
            this.Load += new System.EventHandler(this.Inncoming_Load);
            this.Resize += new System.EventHandler(this.Inncoming_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pctAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuUserControl bunifuUserControl1;
        private Bunifu.UI.WinForms.BunifuPictureBox pctAvatar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHour;
    }
}
