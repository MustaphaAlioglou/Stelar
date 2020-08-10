using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Lists : Form
    {
        public const int a = 0xA1;
        public const int b = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();

        public Lists()
        {
            InitializeComponent();
            Remove.Enabled = false;
            update.Enabled = false;
            add.Enabled = false;
            clear.Enabled = false;
            usrInput.Select();
        }

        private void usrInput_TextChanged_1(object sender, EventArgs e)
        {
            add.Enabled = !string.IsNullOrWhiteSpace(usrInput.Text);
        }

        private void usrInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add.PerformClick();
            }
        }

        private void list_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                usrInput.Text = list.Items[list.SelectedIndex].ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            if (list.SelectedIndex != -1)
            {
                update.Enabled = true;
                Remove.Enabled = true;
            }
            else
            {
                update.Enabled = false;
                Remove.Enabled = false;
            }
        }

        #region OPEN

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            list.Items.Clear();
            OpenFileDialog ee = new OpenFileDialog();
            if (ee.ShowDialog() == DialogResult.OK)
            {
                int i = 0;
                RichTextBox save = new RichTextBox();
                save.Text = File.ReadAllText(ee.FileName);
                foreach (var item in save.Lines)
                {
                    list.Items.Add(save.Lines[i]);
                    i++;
                }
            }
        }

        #endregion OPEN

        #region SAVE

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog ee = new SaveFileDialog();
            if (ee.ShowDialog() == DialogResult.OK)
            {
                string save = "";
                for (int i = 0; i < list.Items.Count; i++)
                {
                    save += list.Items[i].ToString() + Environment.NewLine;
                }

                if (ee.FileName.Contains("txt"))
                {
                    File.WriteAllText(ee.FileName, save);
                }
                else
                {
                    File.WriteAllText(ee.FileName + ".txt", save);
                }
            }
        }

        #endregion SAVE

        #region BUTTONS

        private void add_MouseUp(object sender, MouseEventArgs e)
        {
            if (list.Items.Count >= 0)
            {
                clear.Enabled = true;
            }
            else
            {
                clear.Enabled = false;
            }
        }

        private void Remove_Click_1(object sender, EventArgs e)
        {
            list.Items.RemoveAt(list.SelectedIndex);
        }

        private void update_Click_1(object sender, EventArgs e)
        {
            list.Items.Insert(list.SelectedIndex, usrInput.Text);
            list.Items.RemoveAt(list.SelectedIndex);
        }

        private void clear_Click_1(object sender, EventArgs e)
        {
            list.Items.Clear();
            clear.Enabled = false;
            update.Enabled = false;
            Remove.Enabled = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            list.Items.Add(usrInput.Text);
            usrInput.Clear();
            usrInput.Select();
            if (list.Items.Count >= 0)
            {
                clear.Enabled = true;
            }
        }

        #endregion BUTTONS

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