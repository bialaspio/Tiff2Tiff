using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tiff2Tiff
{
    public partial class Form_RAW_op : Form
    {
        public int f_tb_RAW_bts { get; set; }
        public int f_tb_RAW_bpp { get; set; }
        public int f_tb_RAW_bif { get; set; }
        public string f_cb_RAW_pf { get; set; }
        public int f_tb_RAW_noppl { get; set; }
        public int f_tb_RAW_nolii { get; set; }
        public int f_tb_RAW_nopilh { get; set; }
        public int f_tb_RAW_nopilt { get; set; }
        public string f_cb_RAW_slo { get; set; }
        public bool f_chb_RAW_pp { get; set; }
        public bool f_rb_RAW_s { get; set; }
        public bool f_rb_RAW_ns { get; set; }
        public bool f_ok_cancel { get; set; }

        Par_plik_wej par_plik_wej = new Par_plik_wej();

        public Form_RAW_op()
        {
            InitializeComponent();
        }

        private void Form_RAW_op_Load(object sender, EventArgs e)
        {
            try
            {
                tb_RAW_bts.Text = "0";
                tb_RAW_bpp.Text = "8";
                tb_RAW_bif.Text = "1";
                cb_RAW_pf.Text = "BIL";
                tb_RAW_noppl.Text = "1";
                tb_RAW_nolii.Text = "1";
                tb_RAW_nopilh.Text = "0";
                tb_RAW_nopilt.Text = "0";
                cb_RAW_slo.Text = "Row Major";
                chb_RAW_pp.Checked = false;
                rb_RAW_s.Checked = false;
                rb_RAW_ns.Checked = false;
                load_data_to_par_plik_wej();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania formularza: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_RAW_OK_Click(object sender, EventArgs e)
        {
            try
            {
                f_ok_cancel = true;
                load_data_to_par_plik_wej();
                set_val_f_from_form();
                Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zatwierdzania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void set_val_f_from_form()
        {
            try
            {
                f_tb_RAW_bif = int.Parse(tb_RAW_bif.Text);
                f_tb_RAW_bpp = int.Parse(tb_RAW_bpp.Text);
                f_tb_RAW_bts = int.Parse(tb_RAW_bts.Text);
                f_tb_RAW_nolii = int.Parse(tb_RAW_nolii.Text);
                f_tb_RAW_nopilh = int.Parse(tb_RAW_nopilh.Text);
                f_tb_RAW_nopilt = int.Parse(tb_RAW_nopilt.Text);
                f_tb_RAW_noppl = int.Parse(tb_RAW_noppl.Text);
                f_cb_RAW_pf = cb_RAW_pf.SelectedItem.ToString();
                f_cb_RAW_slo = cb_RAW_slo.SelectedItem.ToString();
                f_chb_RAW_pp = chb_RAW_pp.Checked;
                f_rb_RAW_s = rb_RAW_s.Checked;
                f_rb_RAW_ns = rb_RAW_ns.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ustawiania wartości z formularza: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_RAW_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                f_ok_cancel = false;
                load_data_befor_cancel();
                Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas anulowania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_RAW_bif_Validated(object sender, EventArgs e)
        {
            ValidateIntegerField(tb_RAW_bif, 0, 256, "Wartość musi być liczbą całkowitą od 0 do 256");
        }

        private void tb_RAW_bpp_Validated(object sender, EventArgs e)
        {
            ValidateIntegerField(tb_RAW_bpp, 0, 32, "Wartość musi być liczbą całkowitą od 0 do 32");
        }

        private void tb_RAW_bts_Validated(object sender, EventArgs e)
        {
            ValidateIntegerField(tb_RAW_bts, 0, int.MaxValue, "Wartość musi być 0 lub liczbą całkowitą dodatnią");
        }

        private void tb_RAW_noppl_Validated(object sender, EventArgs e)
        {
            ValidateIntegerField(tb_RAW_noppl, 0, 500000, "Wartość musi być liczbą całkowitą od 0 do 500000");
        }

        private void tb_RAW_nolii_Validated(object sender, EventArgs e)
        {
            ValidateIntegerField(tb_RAW_nolii, 0, 500000, "Wartość musi być liczbą całkowitą od 0 do 500000");
        }

        private void tb_RAW_nopilh_Validated(object sender, EventArgs e)
        {
            ValidateIntegerField(tb_RAW_nopilh, 0, int.Parse(tb_RAW_noppl.Text), $"Wartość musi być liczbą całkowitą od 0 do {tb_RAW_noppl.Text}");
        }

        private void tb_RAW_nopilt_Validated(object sender, EventArgs e)
        {
            int maxValue = int.Parse(tb_RAW_nolii.Text) - 1;
            ValidateIntegerField(tb_RAW_nopilt, 0, maxValue, $"Wartość musi być liczbą całkowitą od 0 do {maxValue}");
        }

        private void ValidateIntegerField(TextBox textBox, int minValue, int maxValue, string errorMessage)
        {
            try
            {
                if (!int.TryParse(textBox.Text, out int number) || number < minValue || number > maxValue)
                {
                    MessageBox.Show(errorMessage, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox.Text = "";
                    textBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas walidacji pola: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void load_data_to_par_plik_wej()
        {
            try
            {
                par_plik_wej.f_tb_RAW_bts = int.Parse(tb_RAW_bts.Text);
                par_plik_wej.f_tb_RAW_bpp = int.Parse(tb_RAW_bpp.Text);
                par_plik_wej.f_tb_RAW_bif = int.Parse(tb_RAW_bif.Text);
                par_plik_wej.f_cb_RAW_pf = cb_RAW_pf.Text;
                par_plik_wej.f_tb_RAW_noppl = int.Parse(tb_RAW_noppl.Text);
                par_plik_wej.f_tb_RAW_nolii = int.Parse(tb_RAW_nolii.Text);
                par_plik_wej.f_tb_RAW_nopilh = int.Parse(tb_RAW_nopilh.Text);
                par_plik_wej.f_tb_RAW_nopilt = int.Parse(tb_RAW_nopilt.Text);
                par_plik_wej.f_cb_RAW_slo = cb_RAW_slo.Text;
                par_plik_wej.f_chb_RAW_pp = chb_RAW_pp.Checked;
                par_plik_wej.f_rb_RAW_s = rb_RAW_s.Checked;
                par_plik_wej.f_rb_RAW_ns = rb_RAW_ns.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania danych do par_plik_wej: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void load_data_befor_cancel()
        {
            try
            {
                f_tb_RAW_bts = par_plik_wej.f_tb_RAW_bts;
                f_tb_RAW_bpp = par_plik_wej.f_tb_RAW_bpp;
                f_tb_RAW_bif = par_plik_wej.f_tb_RAW_bif;
                f_cb_RAW_pf = par_plik_wej.f_cb_RAW_pf;
                f_tb_RAW_noppl = par_plik_wej.f_tb_RAW_noppl;
                f_tb_RAW_nolii = par_plik_wej.f_tb_RAW_nolii;
                f_tb_RAW_nopilh = par_plik_wej.f_tb_RAW_nopilh;
                f_tb_RAW_nopilt = par_plik_wej.f_tb_RAW_nopilt;
                f_cb_RAW_slo = par_plik_wej.f_cb_RAW_slo;
                f_chb_RAW_pp = par_plik_wej.f_chb_RAW_pp;
                f_rb_RAW_s = par_plik_wej.f_rb_RAW_s;
                f_rb_RAW_ns = par_plik_wej.f_rb_RAW_ns;

                tb_RAW_bts.Text = par_plik_wej.f_tb_RAW_bts.ToString();
                tb_RAW_bpp.Text = par_plik_wej.f_tb_RAW_bpp.ToString();
                tb_RAW_bif.Text = par_plik_wej.f_tb_RAW_bif.ToString();
                cb_RAW_pf.Text = par_plik_wej.f_cb_RAW_pf.ToString();
                tb_RAW_noppl.Text = par_plik_wej.f_tb_RAW_noppl.ToString();
                tb_RAW_nolii.Text = par_plik_wej.f_tb_RAW_nolii.ToString();
                tb_RAW_nopilh.Text = par_plik_wej.f_tb_RAW_nopilh.ToString();
                tb_RAW_nopilt.Text = par_plik_wej.f_tb_RAW_nopilt.ToString();
                cb_RAW_slo.Text = par_plik_wej.f_cb_RAW_slo;
                chb_RAW_pp.Checked = par_plik_wej.f_chb_RAW_pp;
                rb_RAW_s.Checked = par_plik_wej.f_rb_RAW_s;
                rb_RAW_ns.Checked = par_plik_wej.f_rb_RAW_ns;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania danych przed anulowaniem: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_RAW_bts_TextChanged(object sender, EventArgs e)
        {
            // Obsługa zdarzenia zmiany tekstu w polu tb_RAW_bts
        }
    }

    public class Par_plik_wej
    {
        public int f_tb_RAW_bts { get; set; }
        public int f_tb_RAW_bpp { get; set; }
        public int f_tb_RAW_bif { get; set; }
        public string f_cb_RAW_pf { get; set; }
        public int f_tb_RAW_noppl { get; set; }
        public int f_tb_RAW_nolii { get; set; }
        public int f_tb_RAW_nopilh { get; set; }
        public int f_tb_RAW_nopilt { get; set; }
        public string f_cb_RAW_slo { get; set; }
        public bool f_chb_RAW_pp { get; set; }
        public bool f_rb_RAW_s { get; set; }
        public bool f_rb_RAW_ns { get; set; }
    }
}
