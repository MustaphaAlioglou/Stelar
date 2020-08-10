using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Stats : Form

    {
        public const int a = 0xA1;
        public const int b = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();

        public Stats(string tem)
        {
            InitializeComponent();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Μηνας",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Εξοδα",
                LabelFormatter = value => value.ToString("C")
            });
            //--------------------------------------------------------
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Mustapha",
                    Values = new ChartValues<double> {0 },
                    PointGeometry = DefaultGeometries.Diamond,
                    PointGeometrySize = 15
                }
            };

            cartesianChart1.LegendLocation = LegendLocation.Left;
            richTextBox1.Text = tem;
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            listView1.Hide();
            richTextBox1.Hide();
            LoadObjectsToListView();
            int i = 0;
            foreach (var item in listView1.Items)
            {
                cartesianChart1.Series[0].Values.Add(Convert.ToDouble(listView1.Items[i].SubItems[0].Text));
                i++;
            }
        }

        private void LoadObjectsToListView()
        {
            int i = 0;
            foreach (string line in richTextBox1.Lines)
            {
                if (line == "-")
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = richTextBox1.Lines[i + 5];
                    //item.SubItems.Add(gg.save.Lines[i + 4]);
                    listView1.Items.Add(item);  //------ADDDED
                }
                i++;
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