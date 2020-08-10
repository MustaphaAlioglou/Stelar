using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Calculator : Form
    {
        public const int aa = 0xA1;
        public const int bb = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();

        public Calculator()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(a.Text) && string.IsNullOrWhiteSpace(b.Text))
            {
                MessageBox.Show("Pass Som numbers boi");
            }
            else
            {
                try
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case (0): c.Text = (Convert.ToDouble(a.Text) + Convert.ToDouble(b.Text)).ToString(); break;
                        case (1): c.Text = (Convert.ToDouble(a.Text) - Convert.ToDouble(b.Text)).ToString(); break;
                        case (2): c.Text = (Convert.ToDouble(a.Text) * Convert.ToDouble(b.Text)).ToString(); break;
                        case (3): c.Text = (Convert.ToDouble(a.Text) / Convert.ToDouble(b.Text)).ToString(); break;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("You can only enter numbers", "Error");
                    throw;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            {
                ReleaseCapture();
                SendMessage(Handle, aa, bb, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void a_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                b.Select();
            }
        }

        private void b_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}