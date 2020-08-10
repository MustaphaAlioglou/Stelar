using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Menu : Form
    {
        public const int a = 0xA1;
        public const int b = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();
        public Menu()
        {
            InitializeComponent();
        }

        private void Calculator_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator();
            Hide();
            calculator.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lists calculator = new Lists();
            Hide();
            calculator.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Parov calculator = new Parov();
            Hide();
            calculator.ShowDialog();
            Show();
        }

        private void Tic_Click(object sender, EventArgs e)
        {
            TicTacToe calculator = new TicTacToe();
            Hide();
            calculator.ShowDialog();
            Show();
        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            Mandlebrot calculator = new Mandlebrot();
            Hide();
            calculator.ShowDialog();
            Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Julia calculator = new Julia();
            Hide();
            calculator.ShowDialog();
            Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            BigForm calculator = new BigForm();
            Hide();
            calculator.ShowDialog();
            Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, a, b, 0);
            }
        }

      
    }
}