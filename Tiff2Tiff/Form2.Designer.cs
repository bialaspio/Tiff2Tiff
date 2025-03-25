
namespace Tiff2Tiff
{
    partial class Form_RAW_op
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_RAW_nopilt = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_RAW_bts = new System.Windows.Forms.TextBox();
            this.tb_RAW_bpp = new System.Windows.Forms.TextBox();
            this.tb_RAW_bif = new System.Windows.Forms.TextBox();
            this.tb_RAW_noppl = new System.Windows.Forms.TextBox();
            this.tb_RAW_nolii = new System.Windows.Forms.TextBox();
            this.tb_RAW_nopilh = new System.Windows.Forms.TextBox();
            this.tb_RAW_nopilt = new System.Windows.Forms.TextBox();
            this.cb_RAW_pf = new System.Windows.Forms.ComboBox();
            this.cb_RAW_slo = new System.Windows.Forms.ComboBox();
            this.chb_RAW_pp = new System.Windows.Forms.CheckBox();
            this.rb_RAW_s = new System.Windows.Forms.RadioButton();
            this.rb_RAW_ns = new System.Windows.Forms.RadioButton();
            this.bt_RAW_OK = new System.Windows.Forms.Button();
            this.bt_RAW_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bytes to Skip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bits Per Pixel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bands in File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pixel Format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Number of Pixels per Line";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Numbers of Lines in Image";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Numbers of pixel in Line Hider";
            // 
            // lb_RAW_nopilt
            // 
            this.lb_RAW_nopilt.AutoSize = true;
            this.lb_RAW_nopilt.Location = new System.Drawing.Point(15, 203);
            this.lb_RAW_nopilt.Name = "lb_RAW_nopilt";
            this.lb_RAW_nopilt.Size = new System.Drawing.Size(143, 13);
            this.lb_RAW_nopilt.TabIndex = 7;
            this.lb_RAW_nopilt.Text = "Numbers of pixel in line trailer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Scan Line Orietation";
            // 
            // tb_RAW_bts
            // 
            this.tb_RAW_bts.Location = new System.Drawing.Point(176, 17);
            this.tb_RAW_bts.Name = "tb_RAW_bts";
            this.tb_RAW_bts.Size = new System.Drawing.Size(113, 20);
            this.tb_RAW_bts.TabIndex = 9;
            this.tb_RAW_bts.TextChanged += new System.EventHandler(this.tb_RAW_bts_TextChanged);
            this.tb_RAW_bts.Validated += new System.EventHandler(this.tb_RAW_bts_Validated);
            // 
            // tb_RAW_bpp
            // 
            this.tb_RAW_bpp.Location = new System.Drawing.Point(176, 43);
            this.tb_RAW_bpp.Name = "tb_RAW_bpp";
            this.tb_RAW_bpp.Size = new System.Drawing.Size(113, 20);
            this.tb_RAW_bpp.TabIndex = 10;
            this.tb_RAW_bpp.Validated += new System.EventHandler(this.tb_RAW_bpp_Validated);
            // 
            // tb_RAW_bif
            // 
            this.tb_RAW_bif.Location = new System.Drawing.Point(176, 69);
            this.tb_RAW_bif.Name = "tb_RAW_bif";
            this.tb_RAW_bif.Size = new System.Drawing.Size(113, 20);
            this.tb_RAW_bif.TabIndex = 11;
            this.tb_RAW_bif.Validated += new System.EventHandler(this.tb_RAW_bif_Validated);
            // 
            // tb_RAW_noppl
            // 
            this.tb_RAW_noppl.Location = new System.Drawing.Point(176, 122);
            this.tb_RAW_noppl.Name = "tb_RAW_noppl";
            this.tb_RAW_noppl.Size = new System.Drawing.Size(113, 20);
            this.tb_RAW_noppl.TabIndex = 12;
            this.tb_RAW_noppl.Validated += new System.EventHandler(this.tb_RAW_noppl_Validated);
            // 
            // tb_RAW_nolii
            // 
            this.tb_RAW_nolii.Location = new System.Drawing.Point(176, 148);
            this.tb_RAW_nolii.Name = "tb_RAW_nolii";
            this.tb_RAW_nolii.Size = new System.Drawing.Size(113, 20);
            this.tb_RAW_nolii.TabIndex = 13;
            this.tb_RAW_nolii.Validated += new System.EventHandler(this.tb_RAW_nolii_Validated);
            // 
            // tb_RAW_nopilh
            // 
            this.tb_RAW_nopilh.Location = new System.Drawing.Point(176, 174);
            this.tb_RAW_nopilh.Name = "tb_RAW_nopilh";
            this.tb_RAW_nopilh.Size = new System.Drawing.Size(113, 20);
            this.tb_RAW_nopilh.TabIndex = 14;
            this.tb_RAW_nopilh.Validated += new System.EventHandler(this.tb_RAW_nopilh_Validated);
            // 
            // tb_RAW_nopilt
            // 
            this.tb_RAW_nopilt.Location = new System.Drawing.Point(176, 200);
            this.tb_RAW_nopilt.Name = "tb_RAW_nopilt";
            this.tb_RAW_nopilt.Size = new System.Drawing.Size(113, 20);
            this.tb_RAW_nopilt.TabIndex = 15;
            this.tb_RAW_nopilt.Validated += new System.EventHandler(this.tb_RAW_nopilt_Validated);
            // 
            // cb_RAW_pf
            // 
            this.cb_RAW_pf.FormattingEnabled = true;
            this.cb_RAW_pf.Items.AddRange(new object[] {
            "BIL",
            "BIP",
            "BSQ"});
            this.cb_RAW_pf.Location = new System.Drawing.Point(176, 95);
            this.cb_RAW_pf.Name = "cb_RAW_pf";
            this.cb_RAW_pf.Size = new System.Drawing.Size(113, 21);
            this.cb_RAW_pf.TabIndex = 16;
            // 
            // cb_RAW_slo
            // 
            this.cb_RAW_slo.FormattingEnabled = true;
            this.cb_RAW_slo.Items.AddRange(new object[] {
            "Row Major",
            "Column Major"});
            this.cb_RAW_slo.Location = new System.Drawing.Point(176, 226);
            this.cb_RAW_slo.Name = "cb_RAW_slo";
            this.cb_RAW_slo.Size = new System.Drawing.Size(113, 21);
            this.cb_RAW_slo.TabIndex = 17;
            // 
            // chb_RAW_pp
            // 
            this.chb_RAW_pp.AutoSize = true;
            this.chb_RAW_pp.Enabled = false;
            this.chb_RAW_pp.Location = new System.Drawing.Point(14, 265);
            this.chb_RAW_pp.Name = "chb_RAW_pp";
            this.chb_RAW_pp.Size = new System.Drawing.Size(93, 17);
            this.chb_RAW_pp.TabIndex = 18;
            this.chb_RAW_pp.Text = "Packed Pixels";
            this.chb_RAW_pp.UseVisualStyleBackColor = true;
            // 
            // rb_RAW_s
            // 
            this.rb_RAW_s.AutoSize = true;
            this.rb_RAW_s.Enabled = false;
            this.rb_RAW_s.Location = new System.Drawing.Point(14, 293);
            this.rb_RAW_s.Name = "rb_RAW_s";
            this.rb_RAW_s.Size = new System.Drawing.Size(58, 17);
            this.rb_RAW_s.TabIndex = 19;
            this.rb_RAW_s.TabStop = true;
            this.rb_RAW_s.Text = "Scaled";
            this.rb_RAW_s.UseVisualStyleBackColor = true;
            // 
            // rb_RAW_ns
            // 
            this.rb_RAW_ns.AutoSize = true;
            this.rb_RAW_ns.Enabled = false;
            this.rb_RAW_ns.Location = new System.Drawing.Point(78, 293);
            this.rb_RAW_ns.Name = "rb_RAW_ns";
            this.rb_RAW_ns.Size = new System.Drawing.Size(78, 17);
            this.rb_RAW_ns.TabIndex = 20;
            this.rb_RAW_ns.TabStop = true;
            this.rb_RAW_ns.Text = "Not Scaled";
            this.rb_RAW_ns.UseVisualStyleBackColor = true;
            // 
            // bt_RAW_OK
            // 
            this.bt_RAW_OK.Location = new System.Drawing.Point(211, 261);
            this.bt_RAW_OK.Name = "bt_RAW_OK";
            this.bt_RAW_OK.Size = new System.Drawing.Size(78, 23);
            this.bt_RAW_OK.TabIndex = 21;
            this.bt_RAW_OK.Text = "OK";
            this.bt_RAW_OK.UseVisualStyleBackColor = true;
            this.bt_RAW_OK.Click += new System.EventHandler(this.bt_RAW_OK_Click);
            // 
            // bt_RAW_Cancel
            // 
            this.bt_RAW_Cancel.Location = new System.Drawing.Point(211, 290);
            this.bt_RAW_Cancel.MaximumSize = new System.Drawing.Size(78, 23);
            this.bt_RAW_Cancel.MinimumSize = new System.Drawing.Size(78, 23);
            this.bt_RAW_Cancel.Name = "bt_RAW_Cancel";
            this.bt_RAW_Cancel.Size = new System.Drawing.Size(78, 23);
            this.bt_RAW_Cancel.TabIndex = 22;
            this.bt_RAW_Cancel.Text = "Cancel";
            this.bt_RAW_Cancel.UseVisualStyleBackColor = true;
            this.bt_RAW_Cancel.Click += new System.EventHandler(this.bt_RAW_Cancel_Click);
            // 
            // Form_RAW_op
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(301, 325);
            this.ControlBox = false;
            this.Controls.Add(this.bt_RAW_Cancel);
            this.Controls.Add(this.bt_RAW_OK);
            this.Controls.Add(this.rb_RAW_ns);
            this.Controls.Add(this.rb_RAW_s);
            this.Controls.Add(this.chb_RAW_pp);
            this.Controls.Add(this.cb_RAW_slo);
            this.Controls.Add(this.cb_RAW_pf);
            this.Controls.Add(this.tb_RAW_nopilt);
            this.Controls.Add(this.tb_RAW_nopilh);
            this.Controls.Add(this.tb_RAW_nolii);
            this.Controls.Add(this.tb_RAW_noppl);
            this.Controls.Add(this.tb_RAW_bif);
            this.Controls.Add(this.tb_RAW_bpp);
            this.Controls.Add(this.tb_RAW_bts);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_RAW_nopilt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(317, 364);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 364);
            this.Name = "Form_RAW_op";
            this.Text = "RAW in file option";
            this.Load += new System.EventHandler(this.Form_RAW_op_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_RAW_nopilt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_RAW_bts;
        private System.Windows.Forms.TextBox tb_RAW_bpp;
        private System.Windows.Forms.TextBox tb_RAW_bif;
        private System.Windows.Forms.TextBox tb_RAW_noppl;
        private System.Windows.Forms.TextBox tb_RAW_nolii;
        private System.Windows.Forms.TextBox tb_RAW_nopilh;
        private System.Windows.Forms.TextBox tb_RAW_nopilt;
        private System.Windows.Forms.ComboBox cb_RAW_pf;
        private System.Windows.Forms.ComboBox cb_RAW_slo;
        private System.Windows.Forms.CheckBox chb_RAW_pp;
        private System.Windows.Forms.RadioButton rb_RAW_s;
        private System.Windows.Forms.RadioButton rb_RAW_ns;
        private System.Windows.Forms.Button bt_RAW_OK;
        private System.Windows.Forms.Button bt_RAW_Cancel;
    }
}