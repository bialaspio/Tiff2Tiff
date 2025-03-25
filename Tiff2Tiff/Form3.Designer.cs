
namespace Tiff2Tiff
{
    partial class Form_CMD
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_fcmd_tk = new System.Windows.Forms.RichTextBox();
            this.bt_fcmd_copy = new System.Windows.Forms.Button();
            this.bt_fcmd_zamk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tresc komendy ";
            // 
            // rtb_fcmd_tk
            // 
            this.rtb_fcmd_tk.Location = new System.Drawing.Point(16, 29);
            this.rtb_fcmd_tk.Name = "rtb_fcmd_tk";
            this.rtb_fcmd_tk.Size = new System.Drawing.Size(346, 92);
            this.rtb_fcmd_tk.TabIndex = 1;
            this.rtb_fcmd_tk.Text = "";
            // 
            // bt_fcmd_copy
            // 
            this.bt_fcmd_copy.Location = new System.Drawing.Point(207, 135);
            this.bt_fcmd_copy.Name = "bt_fcmd_copy";
            this.bt_fcmd_copy.Size = new System.Drawing.Size(75, 23);
            this.bt_fcmd_copy.TabIndex = 2;
            this.bt_fcmd_copy.Text = "Kopiuj";
            this.bt_fcmd_copy.UseVisualStyleBackColor = true;
            this.bt_fcmd_copy.Click += new System.EventHandler(this.bt_fcmd_copy_Click);
            // 
            // bt_fcmd_zamk
            // 
            this.bt_fcmd_zamk.Location = new System.Drawing.Point(287, 135);
            this.bt_fcmd_zamk.Name = "bt_fcmd_zamk";
            this.bt_fcmd_zamk.Size = new System.Drawing.Size(75, 23);
            this.bt_fcmd_zamk.TabIndex = 3;
            this.bt_fcmd_zamk.Text = "Zamknij";
            this.bt_fcmd_zamk.UseVisualStyleBackColor = true;
            this.bt_fcmd_zamk.Click += new System.EventHandler(this.bt_fcmd_zamk_Click);
            // 
            // Form_CMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(374, 171);
            this.ControlBox = false;
            this.Controls.Add(this.bt_fcmd_zamk);
            this.Controls.Add(this.bt_fcmd_copy);
            this.Controls.Add(this.rtb_fcmd_tk);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 210);
            this.Name = "Form_CMD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CMD";
            this.Load += new System.EventHandler(this.Form_CMD_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_fcmd_tk;
        private System.Windows.Forms.Button bt_fcmd_copy;
        private System.Windows.Forms.Button bt_fcmd_zamk;
    }
}