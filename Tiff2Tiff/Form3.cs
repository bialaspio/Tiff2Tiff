using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tiff2Tiff
{
    public partial class Form_CMD : Form
    {
        public string MyValue { get; set; }

        public Form_CMD()
        {
            InitializeComponent();
        }

        private void bt_fcmd_copy_Click(object sender, EventArgs e)
        {
            try
            {
                rtb_fcmd_tk.SelectAll();
                rtb_fcmd_tk.Copy();
                MessageBox.Show("Tekst został skopiowany do schowka.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas kopiowania tekstu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_fcmd_zamk_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zamykania formularza: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_CMD_Load(object sender, EventArgs e)
        {
            try
            {
                rtb_fcmd_tk.Text = MyValue;
                rtb_fcmd_tk.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania formularza: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
