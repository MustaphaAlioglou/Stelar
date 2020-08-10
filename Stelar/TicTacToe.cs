using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class TicTacToe : Form
    {
        public const int a = 0xA1;
        public const int b = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();

        private bool sa = false;

        public TicTacToe()
        {
            InitializeComponent();
        }

        #region button

        private void a1_Click(object sender, EventArgs e)
        {
            check(a1);
            checkwinner();
        }

        private void a2_Click(object sender, EventArgs e)
        {
            check(a2);
            checkwinner();
        }

        private void a3_Click(object sender, EventArgs e)
        {
            check(a3);
            checkwinner();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            check(b1);
            checkwinner();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            check(b2);
            checkwinner();
        }

    

        private void c1_Click(object sender, EventArgs e)
        {
            check(c1);
            checkwinner();
        }

        private void c2_Click(object sender, EventArgs e)
        {
            check(c2);
            checkwinner();
        }

        private void c3_Click(object sender, EventArgs e)
        {
            check(c3);
            checkwinner();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            check(b3);
            checkwinner();
        }

        #endregion button

        private void check(Button a)
        {
            if (a.Text == "X" || a.Text == "O")
            { MessageBox.Show("Hold on buckaroo", "hey !"); }
            else
            {
                if (sa == true)
                {
                    a.Text = "O";
                    sa = false;
                }
                else
                {
                    a.Text = "X";
                    sa = true;
                }
            }
        }

        private void checkwinner()
        {
            if ((a1.Text == "O" && a2.Text == "O" && a3.Text == "O") ||
                (b1.Text == "O" && b2.Text == "O" && b3.Text == "O") ||
                (c1.Text == "O" && c2.Text == "O" && c3.Text == "O") ||
                (a1.Text == "O" && b1.Text == "O" && c1.Text == "O") ||
                (a2.Text == "O" && b2.Text == "O" && c2.Text == "O") ||
                (a3.Text == "O" && b3.Text == "O" && c3.Text == "O") ||
                (a1.Text == "O" && b2.Text == "O" && c3.Text == "O") ||
                (a3.Text == "O" && b2.Text == "O" && c1.Text == "O"))
            {
                MessageBox.Show("O wins !", "O wins :-)");
            }
            else if ((a1.Text == "X" && a2.Text == "X" && a3.Text == "X") ||
                     (b1.Text == "X" && b2.Text == "X" && b3.Text == "X") ||
                     (c1.Text == "X" && c2.Text == "X" && c3.Text == "X") ||
                     (a1.Text == "X" && b1.Text == "X" && c1.Text == "X") ||
                     (a2.Text == "X" && b2.Text == "X" && c2.Text == "X") ||
                     (a3.Text == "X" && b3.Text == "X" && c3.Text == "X") ||
                     (a1.Text == "X" && b2.Text == "X" && c3.Text == "X") ||
                     (a3.Text == "X" && b2.Text == "X" && c1.Text == "X"))
            {
                MessageBox.Show(" X wins !", "X wins :-)");
            }
            else if ((!string.IsNullOrWhiteSpace(a1.Text)) && (!string.IsNullOrWhiteSpace(a2.Text)) &&
                    (!string.IsNullOrWhiteSpace(a3.Text)) && (!string.IsNullOrWhiteSpace(b1.Text)) &&
                    (!string.IsNullOrWhiteSpace(b2.Text)) && (!string.IsNullOrWhiteSpace(b3.Text)) &&
                    (!string.IsNullOrWhiteSpace(c1.Text)) && (!string.IsNullOrWhiteSpace(c2.Text)) &&
                    (!string.IsNullOrWhiteSpace(c3.Text)))
            {
                MessageBox.Show("Nobody wins");
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, a, b, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}