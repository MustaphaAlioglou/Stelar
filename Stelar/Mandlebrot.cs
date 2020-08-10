using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Mandlebrot : Form
    {
        public const int a = 0xA1;
        public const int b = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();

        public Mandlebrot()
        {
            InitializeComponent();
        }

        private void Mandlebrot_Load_1(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int x = 0; x < pictureBox1.Height; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    double a = (double)(x - pictureBox1.Width / 2) / (double)(pictureBox1.Width / 4);
                    double b = (double)(y - pictureBox1.Height / 2) / (double)(pictureBox1.Height / 4);
                    Moose.Mandle.Complex c = new Moose.Mandle.Complex(a, b);
                    Moose.Mandle.Complex z = new Moose.Mandle.Complex(0, 0);
                    int it = 0;
                    do
                    {
                        it++;
                        z.square();
                        z.add(c);
                        if (z.magnitute() > 2.0) break;
                    } while (it < 100);
                    bm.SetPixel(x, y, it < 100 ? Color.DarkBlue : Color.White);
                }
            }
            pictureBox1.Image = bm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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