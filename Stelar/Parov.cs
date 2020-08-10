using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Parov : Form
    {
        public const int a = 0xA1;
        public const int b = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();

        public string temp = "";

        public Parov()
        {
            InitializeComponent();
            textBox1.Select();
        }

        private void infoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nothing to see here backaroo", "Nothing");
        }
        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = textBox1.Text;
            item.SubItems.Add(textBox2.Text);
            item.SubItems.Add(textBox3.Text);
            item.SubItems.Add(textBox4.Text);
            item.SubItems.Add(textBox5.Text);
            listView1.Items.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
        #endregion
        #region open and save 
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {
                RichTextBox shit = new RichTextBox();
                shit.Text = File.ReadAllText(opd.FileName);
                int i = 0;
                foreach (string line in shit.Lines)
                {
                    if (line == "-")
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = shit.Lines[i + 1];
                        item.SubItems.Add(shit.Lines[i + 2]);
                        item.SubItems.Add(shit.Lines[i + 3]);
                        item.SubItems.Add(shit.Lines[i + 4]);
                        item.SubItems.Add(shit.Lines[i + 5]);
                        listView1.Items.Add(item);
                    }
                    i++;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string temp = "";
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    temp += "-" + Environment.NewLine +
                    listView1.Items[i].Text + Environment.NewLine +
                    listView1.Items[i].SubItems[1].Text + Environment.NewLine +
                    listView1.Items[i].SubItems[2].Text + Environment.NewLine +
                    listView1.Items[i].SubItems[3].Text + Environment.NewLine +
                    listView1.Items[i].SubItems[4].Text + Environment.NewLine;
                }
                if (sf.FileName.Contains("txt"))
                {
                    File.WriteAllText(sf.FileName, temp);
                }
                else
                {
                    File.WriteAllText(sf.FileName + ".txt", temp);
                }
            }
        }
        #endregion
        public void ss()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                temp += "-" + Environment.NewLine +
                listView1.Items[i].Text + Environment.NewLine +
                listView1.Items[i].SubItems[1].Text + Environment.NewLine +
                listView1.Items[i].SubItems[2].Text + Environment.NewLine +
                listView1.Items[i].SubItems[3].Text + Environment.NewLine +
                listView1.Items[i].SubItems[4].Text + Environment.NewLine;
            }
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp = "";
            ss();
            Stats ee = new Stats(temp);
            ee.ShowDialog();
        }

        private void Exitb_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Textbox Events
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, a, b, 0);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Select();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Select();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Select();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Select();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Select();
            }
        }
        #endregion

    }
}