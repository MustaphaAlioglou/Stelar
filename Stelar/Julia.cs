using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Julia : Form
    {
        public const int aa = 0xA1;
        public const int bb = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();

        public Julia()
        {
            InitializeComponent();
        }

        private void Julia_Load(object sender, EventArgs e)
        {
            const int w = 800;
            const int h = 600;
            const int zoom = 1;
            const int maxiter = 255;
            const int moveX = 0;
            const int moveY = 0;
            const double cX = -0.7;
            const double cY = 0.27015;
            double zx, zy, tmp;
            int i;

            var colors = (from c in Enumerable.Range(0, 256)
                          select Color.FromArgb((c >> 5) * 36, (c >> 3 & 7) * 36, (c & 3) * 85)).ToArray();

            var bitmap = new Bitmap(w, h);
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    zx = 1.5 * (x - w / 2) / (0.5 * zoom * w) + moveX;
                    zy = 1.0 * (y - h / 2) / (0.5 * zoom * h) + moveY;
                    i = maxiter;
                    while (zx * zx + zy * zy < 4 && i > 1)
                    {
                        tmp = zx * zx - zy * zy + cX;
                        zy = 2.0 * zx * zy + cY;
                        zx = tmp;
                        i -= 1;
                    }
                    bitmap.SetPixel(x, y, colors[i]);
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            {
                ReleaseCapture();
                SendMessage(Handle, aa, bb, 0);
            }
        }
    }
}