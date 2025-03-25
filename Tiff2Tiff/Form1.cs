using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tiff2Tiff
{

    public partial class F_Tif2Tifv001_a : Form
    {
        FolderBrowserDialog ofd_dir = new FolderBrowserDialog();
        //     Class_par_plik_wej class_par_plik_wej = new Class_par_plik_wej();
        Form_RAW_op form_RAW_op = new Form_RAW_op();

        //List<string> tif_compr = new List<string> { "None", "Adaptive RLE", "JPEG", "LZ77", "LZW" };
        List<string> tif_compr = new List<string> { "None", "LZ77", "LZW", "PackBits", "JPEG" };
        List<string> rozm_kaf = new List<string> { "0", "128", "256", "512", "1024", "2048" };
        List<string> overviev = new List<string> { "None", "Single", "Full Set", "Full Set(no 2x)", "Copy Existing" };
        List<string> met_none = new List<string> { "None" };
        List<string> met_sing = new List<string> { "Subsampled" };
        List<string> met_fs = new List<string> { "Subsampled", "Averaged", "Gaussian" };
        List<string> met_fs2x = new List<string> { "Subsampled", "Averaged" };


        public F_Tif2Tifv001_a()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------------------------------------------------
        // 

        private void bt_p_wej_path_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog
                {
                    Filter = "Text Files (*.jpg)|*.jpg|*.tif)|*.tif|All files (*.*)|*.*",
                    Multiselect = true
                };

                if (dlg.ShowDialog() != DialogResult.OK) return;

                tb_p_wej_path.Text = Path.GetDirectoryName(dlg.FileName);
                foreach (string fileName in dlg.FileNames)
                {
                    lbox_p_wej.Items.Add(Path.GetFileName(fileName));
                    if (!string.IsNullOrEmpty(tb_p_wyj_path.Text))
                    {
                        lbox_p_wyj.Items.Add(Path.GetFileName(fileName));
                    }
                }
                lbox_p_wej.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------
        // obsługa przycisku do wskazania katalogu dla plików wyjściowych 

        private void bt__p_wyj_path_Click(object sender, EventArgs e)
        {
            try
            {
                lbox_p_wyj.Items.Clear();
                ofd_dir.SelectedPath = @"c:\";

                if (ofd_dir.ShowDialog() == DialogResult.OK)
                {
                    if (tb_p_wej_path.Text.Equals(ofd_dir.SelectedPath))
                    {
                        MessageBox.Show("Ścieżki dla plików wejściowych i wyjściowych muszą być różne", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        tb_p_wyj_path.Text = ofd_dir.SelectedPath;
                        lbox_p_wyj.Items.AddRange(lbox_p_wej.Items);
                        gb_fpwyj.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------
        // obsługa kasowania pliku w listoxie z plikami wejściowymi 

        private void lbox_p_wej_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && lbox_p_wej.SelectedIndex != -1)
                {
                    if (lbox_p_wyj.Items.Count > 0)
                    {
                        lbox_p_wyj.SelectedIndex = lbox_p_wyj.FindString(lbox_p_wej.SelectedItem.ToString());
                        lbox_p_wyj.Items.RemoveAt(lbox_p_wyj.SelectedIndex);
                    }
                    lbox_p_wej.Items.RemoveAt(lbox_p_wej.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        // obsługa radiobuton-a tiff 
        private void rb_fpw_tiff_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cb_ppw_kompresja.Items.AddRange(tif_compr.ToArray());
                SetPpwyjPojBitUnchecked();
                bt_gen_cmd.Enabled = true;
                bt_OK.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        // obsługa combobox-a overview 
        private void cb_ppw_ov_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb_ppw_met.Items.Clear();

                switch (cb_ppw_ov.SelectedItem)
                {
                    case "None":
                        cb_ppw_met.Items.AddRange(met_none.ToArray());
                        break;
                    case "Single":
                        cb_ppw_met.Items.AddRange(met_sing.ToArray());
                        break;
                    case "Full Set":
                        cb_ppw_met.Items.AddRange(met_fs.ToArray());
                        break;
                    case "Full Set(no 2x)":
                        cb_ppw_met.Items.AddRange(met_fs2x.ToArray());
                        break;
                }

                cb_ppw_met.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        // przycisk do generowania komendy w do cmd 
        private void bt_gen_cmd_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd_comand = GenerateCommand();
                OpenForm1(cmd_comand);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        // Przcisk RAW do obsługi danych dla pliku wejściowego 
        private void bt_iopw_RAWopt_Click(object sender, EventArgs e)
        {
            try
            {
                chb_iopw_raw.Enabled = true;
                chb_iopw_raw.Checked = true;

                form_RAW_op.Show();

                if (rb_fpw_B_TIFF.Checked || rb_fpw_jp2000.Checked || rb_fpw_raw.Checked || rb_fpw_tiff.Checked)
                {
                    bt_gen_cmd.Enabled = true;
                    bt_OK.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        //  włącznie lub wyłącznie przycisku do generowania CMD i OK 
        private void chb_iopw_raw_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bt_gen_cmd.Enabled = chb_iopw_raw.Checked;
                bt_OK.Enabled = chb_iopw_raw.Checked;
                chb_iopw_raw.Enabled = chb_iopw_raw.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        //
        private void chb_ppw_pb_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chb_ppw_pb.Checked)
                {
                    SetPpwyjPojBitChecked();
                }
                else
                {
                    SetPpwyjPojBitUnchecked();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        //
        private void cb_ppw_kompresja_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tb_ppw_qfa.Enabled = cb_ppw_kompresja.SelectedItem.ToString() == "JPEG";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        // wybór wyjściowego formatu pliku 
        private string wybierz_format_pliku(string RAW_in_file_option, string path_file_in, string path_file_out)
        {
            try
            {
                string cmd_comand = "";
                int f_grbox_wwl = -2;

                if (rb_wwl_Auto.Checked)
                {
                    f_grbox_wwl = 0;
                }
                else if (rb_wwl_poj.Checked)
                {
                    f_grbox_wwl = -1;
                }
                else if (rb_wwl_uzyt.Checked)
                {
                    f_grbox_wwl = int.Parse(tb_wwl_wart_uzty.Text);
                }

                if (rb_fpw_tiff.Checked)
                {
                    Class_par_plik_wyj class_par_plik_wyj = new Class_par_plik_wyj();
                    cmd_comand = class_par_plik_wyj.get_val_tiff_not_RAW(cb_iopw_paleta.SelectedItem.ToString(), chb_ppw_RGB.Checked, int.Parse(tb_ppw_bnp.Text), cb_ppw_kompresja.SelectedItem.ToString(), int.Parse(tb_ppw_qfa.Text), int.Parse(cb_ppw_rk.SelectedItem.ToString()), f_grbox_wwl, int.Parse(tb_ppw_ru.Text), cb_ppw_ov.SelectedItem.ToString(), cb_ppw_met.SelectedItem.ToString(), path_file_in, path_file_out);
                    return cmd_comand;
                }
                return "ERR";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERR";
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------
        // Funkcja otwierająca formę z komendą do bat 
        public void OpenForm1(string cmd_comand)
        {
            try
            {
                Form_CMD form_CMD = new Form_CMD
                {
                    MyValue = cmd_comand
                };
                form_CMD.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------
        // obsługa zdarzeń po odznaczeniu chceckcox pojedynczy bit 
        private void SetPpwyjPojBitUnchecked()
        {
            try
            {
                SetPpwyjNaNieaktywne();
                chb_ppw_RGB.Enabled = true;
                chb_ppw_RGB.Checked = true;
                tb_ppw_bnp.Enabled = true;
                cb_ppw_kompresja.Enabled = true;
                cb_ppw_rk.Enabled = true;
                tb_ppw_ru.Enabled = true;
                cb_ppw_ov.Enabled = true;
                cb_ppw_met.Enabled = true;

                cb_ppw_kompresja.Items.Clear();
                cb_ppw_kompresja.Items.AddRange(tif_compr.ToArray());

                cb_ppw_rk.Items.Clear();
                cb_ppw_rk.Items.AddRange(rozm_kaf.ToArray());

                cb_ppw_ov.Items.Clear();
                cb_ppw_ov.Items.AddRange(overviev.ToArray());

                cb_ppw_kompresja.SelectedIndex = 0;
                cb_ppw_rk.SelectedIndex = 1;
                cb_ppw_ov.SelectedIndex = 0;
                cb_ppw_met.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------
        // obsługa zdarzeń po zaznaczeniu chceckcox pojedynczy bit 
        private void SetPpwyjPojBitChecked()
        {
            try
            {
                SetPpwyjNaNieaktywne();
                chb_ppw_pb.Enabled = true;
                tb_ppw_wp.Enabled = true;
                cb_ppw_kompresja.Enabled = true;
                cb_ppw_rk.Enabled = true;
                tb_ppw_ru.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------
        //ustawienie wszystkich pól do definiowania pliku wyjściowego na nieaktywny 
        private void SetPpwyjNaNieaktywne()
        {
            chb_ppw_RGB.Enabled = false;
            chb_ppw_pb.Enabled = false;
            tb_ppw_wp.Enabled = false;
            tb_ppw_bnp.Enabled = false;
            cb_ppw_kompresja.Enabled = false;
            tb_ppw_qfa.Enabled = false;
            cb_ppw_rk.Enabled = false;
            tb_ppw_ru.Enabled = false;
            cb_ppw_fp.Enabled = false;
            chb_ppw_zkb.Enabled = false;
            chb_ppw_cap.Enabled = false;
            cb_ppw_ov.Enabled = false;
            cb_ppw_met.Enabled = false;
        }

        private void chb_ppw_RGB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cb_iopw_paleta.Enabled = !chb_ppw_RGB.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void F_Tif2Tifv001_a_Load(object sender, EventArgs e)
        {
            try
            {
                cb_iopw_paleta.SelectedIndex = 3;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_ppw_qfa_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(tb_ppw_qfa.Text, out int number) || number < 1 || number > 300)
                {
                    MessageBox.Show("Wartość musi być liczbą całkowitą od 1 do 300.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tb_ppw_qfa.Text = "";
                    tb_ppw_qfa.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_ppw_bnp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(tb_ppw_bnp.Text, out int number) || number < 1 || number > 32)
                {
                    MessageBox.Show("Wartość musi być liczbą całkowitą od 1 do 32.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tb_ppw_bnp.Text = "";
                    tb_ppw_bnp.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_ppw_ru_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(tb_ppw_qfa.Text, out int number) || number <= 0)
                {
                    MessageBox.Show("Wartość musi być liczbą całkowitą większą od 0.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tb_ppw_qfa.Text = "";
                    tb_ppw_qfa.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd_comand = GenerateCommand();
                RunCmdCommand(cmd_comand);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateCommand()
        {
            string cmd_comand = "";
            string RAW_in_file_option = "";

            foreach (string file_in in lbox_p_wej.Items)
            {
                cmd_comand += "start /b /wait mr_file ";
                string path_file_in = Path.Combine(tb_p_wej_path.Text, file_in);
                string path_file_out = Path.Combine(tb_p_wyj_path.Text, file_in);

                if (chb_iopw_raw.Checked)
                {
                    RAW_in_file_option = string.Format("-s {0} -n {1} -h {2} -t {3} -l {4} -p {5} ",
                        form_RAW_op.f_tb_RAW_bts, form_RAW_op.f_tb_RAW_bif, form_RAW_op.f_tb_RAW_nopilh,
                        form_RAW_op.f_tb_RAW_nopilt, form_RAW_op.f_tb_RAW_nolii, form_RAW_op.f_tb_RAW_noppl);
                }

                cmd_comand += wybierz_format_pliku(RAW_in_file_option, path_file_in, path_file_out) + "\n";
            }

            return cmd_comand;
        }

        private void RunCmdCommand(string cmd_comand)
        {
            try
            {
                Directory.SetCurrentDirectory(@"c:\Program Files\Hexagon\ISRU\bin");
                Process.Start("mr_file.exe", cmd_comand);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    //-------------------------------------------------------------------------------------------------
    public class Class_par_plik_wyj
    {
        public string get_val_tiff_not_RAW(string f_cb_iopw_paleta, bool f_chb_ppw_RGB, int f_tb_ppw_bnp, string f_cb_ppw_kompresja, int f_tb_ppw_qfa, int f_cb_ppw_rk, int f_grbox_wwl, int f_tb_ppw_ru, string f_ppw_ov, string f_ppw_met, string file_in, string file_out)
        {
            try
            {
                var cmd_comand = new StringBuilder("-i 1 -o 1 -H 1 ");

                cmd_comand.AppendFormat("-Y {0} ", f_tb_ppw_bnp);
                cmd_comand.Append(f_chb_ppw_RGB ? "-E " : $"-e {GetPaletteCode(f_cb_iopw_paleta)} ");
                cmd_comand.AppendFormat("-D {0} ", f_tb_ppw_ru);

                if (!string.IsNullOrEmpty(f_cb_ppw_kompresja))
                {
                    cmd_comand.Append(GetCompressionCode(f_cb_ppw_kompresja, f_tb_ppw_qfa));
                }

                if (f_cb_ppw_rk != 0)
                {
                    cmd_comand.AppendFormat("-S {0} ", f_cb_ppw_rk);
                }
                else
                {
                    cmd_comand.AppendFormat("-Z {0} ", f_grbox_wwl);
                }

                if (!string.IsNullOrEmpty(f_ppw_ov))
                {
                    cmd_comand.Append(GetOverviewCode(f_ppw_ov, f_ppw_met));
                }

                cmd_comand.AppendFormat("{0} {1}", file_in, file_out);

                return cmd_comand.ToString();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while generating the command.", ex);
            }
        }

        private string GetPaletteCode(string palette)
        {
            try
            {
                switch (palette)
                {
                    case "Red band":
                        return "r";
                    case "Green band":
                        return "g";
                    case "Blue band":
                        return "b";
                    case "8 bit":
                        return "c";
                    case "Average":
                        return "a";
                    default:
                        throw new ArgumentException("Invalid palette", nameof(palette));
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while getting the palette code.", ex);
            }
        }

        private string GetCompressionCode(string compression, int quality)
        {
            try
            {
                switch (compression)
                {
                    case "None":
                        return "";
                    case "LZ77":
                        return "-C z ";
                    case "LZW":
                        return "-C l ";
                    case "PackBits":
                        return "-C a ";
                    case "JPEG":
                        return $"-C j -Q {quality} ";
                    default:
                        throw new ArgumentException("Invalid compression", nameof(compression));
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while getting the compression code.", ex);
            }
        }

        private string GetOverviewCode(string overview, string method)
        {
            try
            {
                switch (overview)
                {
                    case "None":
                        return "";
                    case "Single":
                        return "-V ";
                    case "Full Set":
                        switch (method)
                        {
                            case "Subsampled":
                                return "-K s ";
                            case "Averaged":
                                return "-K a ";
                            case "Gaussian":
                                return "-K g ";
                            default:
                                throw new ArgumentException("Invalid method", nameof(method));
                        }
                    case "Full Set(no 2x)":
                        switch (method)
                        {
                            case "Subsampled":
                                return "-k s ";
                            case "Averaged":
                                return "-k a ";
                            default:
                                throw new ArgumentException("Invalid method", nameof(method));
                        }
                    case "Copy Existing":
                        return "-c ";
                    default:
                        throw new ArgumentException("Invalid overview", nameof(overview));
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while getting the overview code.", ex);
            }
        }
    }

    //-------------------------------------------------------------------------------------------------
}
