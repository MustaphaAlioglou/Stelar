using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stelar
{
    public partial class BigForm : Form
    {
        public const int aa = 0xA1;
        public const int bb = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();
        private int CurrentSelectedID = 0;
        private string temp = string.Empty;
        private List<People> item;

        public BigForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disselect();
            temp = string.Empty;
            item = null;
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                temp = File.ReadAllText(opf.FileName);
                item = JsonConvert.DeserializeObject<List<People>>(temp);
                PrintData(0);
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            disselect();
            CurrentSelectedID--;
            PrintData(CurrentSelectedID);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            disselect();
            CurrentSelectedID++;
            PrintData(CurrentSelectedID);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                disselect();
                PrintData(Convert.ToInt32(textBox1.Text)-1);
                CurrentSelectedID = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void disselect()
        {
            
            TextBoxYesSpecify.Text = "";
            TextBox_ClientID.Text = "";
            TextBoxFirstName.Text = "";
            TextBoxMiddleName.Text = "";
            TextBoxLastName.Text = "";
            MaleRadio.Checked = false;
            FemaleRadio.Checked = false;
            CheckBoxCaucasian.Checked = false;
            CheckBoxAfricanAmerican.Checked = false;
            CheckBoxAsian.Checked = false;
            CheckBoxNativeAmerican.Checked = false;
            CheckBoxHispanic.Checked = false;
            CheckBoxOtherRace.Checked = false;
            RadioSpeak1.Checked = false;
            RadioSpeak2.Checked = false;
            RadioSpeak3.Checked = false;
            RadioEdu1.Checked = false;
            RadioEdu2.Checked = false;
            RadioEdu3.Checked = false;
            RadioEdu4.Checked = false;
            RadioEdu5.Checked = false;
            RadioButtonAnother1.Checked = false;
            RadioButtonAnother2.Checked = false;
            GiftedCheckBox.Checked = false;
            LearningDisabilityCheckBox.Checked = false;
            CheckBoxMath.Checked = false;
            CheckBoxReading.Checked = false;
            CheckBoxWriting.Checked = false;
            CheckBoxAttentionDisorter.Checked = false;
            CheckBoxHeadInjury.Checked = false;
            CheckBoxVisualImpairment.Checked = false;
            CheckBoxHearingImpairment.Checked = false;
            CheckBoxMentalRetardation.Checked = false;
            CheckBoxEmotional.Checked = false;
            CheckBoxOther.Checked = false;
            TextBoxOtherOptional.Text = "";
            RadioNoOptional.Checked = false;
            RadioYesOptional.Checked = false;
            TextBoxYesOptional.Text = "";
        }

        private void PrintData(int Id)
        {
            try
            {
                TextBox_ClientID.Text = Convert.ToString(item[Id].id);
                TextBoxFirstName.Text = Convert.ToString(item[Id].firstname);
                TextBoxLastName.Text = Convert.ToString(item[Id].lastname);
                TextBoxMiddleName.Text = Convert.ToString(item[Id].middlename);
                if (item[Id].Male == true)
                    MaleRadio.Checked = true;
                else
                    FemaleRadio.Checked = true;

                if (item[Id].Caucasian == true)
                    CheckBoxCaucasian.Checked = true;
                else
                    CheckBoxCaucasian.Checked = false;

                if (item[Id].African == true)
                    CheckBoxAfricanAmerican.Checked = true;
                else
                    CheckBoxAfricanAmerican.Checked = false;

                if (item[Id].NativaAmerican == true)
                    CheckBoxNativeAmerican.Checked = true;
                else
                    CheckBoxNativeAmerican.Checked = false;

                if (item[Id].Caucasian == true)
                    CheckBoxAfricanAmerican.Checked = true;
                else
                    CheckBoxAfricanAmerican.Checked = false;
                TextBoxOtherRace.Text = Convert.ToString(item[Id].otherethic);
                if (item[Id].otherethic == "")
                    CheckBoxOtherRace.Checked = false;
                else
                {
                    CheckBoxOtherRace.Checked = true;
                    TextBoxOtherRace.Text = (item[Id].otherethic.ToString());
                }

                if (item[Id].speakenglish == true)
                    RadioSpeak2.Checked = true;
                else
                    RadioSpeak1.Checked = false;

                if (item[Id].somewhat == true)
                {
                    RadioSpeak2.Checked = false;
                    RadioSpeak1.Checked = false;
                    RadioSpeak3.Checked = true;
                }

                if (item[Id].lessthatwelve == true)
                    RadioEdu1.Checked = true;

                if (item[Id].highschool == true)
                    RadioEdu2.Checked = true;

                if (item[Id].oneortwocollege == true)
                    RadioEdu3.Checked = true;

                if (item[Id].fourormore == true)
                    RadioEdu4.Checked = true;

                if (item[Id].unspecifiededucation == true)
                    RadioEdu5.Checked = true;

                if (item[Id].speakanotherlanguage == "")
                    CheckBoxOtherRace.Checked = false;
                else
                {
                    RadioButtonAnother1.Checked = true;
                    TextBoxYesSpecify.Text = (item[Id].speakanotherlanguage.ToString());

                    if (item[Id].gifted == true)
                        GiftedCheckBox.Checked = true;

                    if (item[Id].learningdis == true)
                        LearningDisabilityCheckBox.Checked = true;

                    if (item[Id].math == true)
                        CheckBoxMath.Checked = true;

                    if (item[Id].reading == true)
                        CheckBoxReading.Checked = true;

                    if (item[Id].writing == true)
                        CheckBoxWriting.Checked = true;

                    if (item[Id].attention == true)
                        CheckBoxAttentionDisorter.Checked = true;

                    if (item[Id].closedhead == true)
                        CheckBoxHeadInjury.Checked = true;

                    if (item[Id].visualimp == true)
                        CheckBoxVisualImpairment.Checked = true;

                    if (item[Id].hearingimp == true)
                        CheckBoxHearingImpairment.Checked = true;

                    if (item[Id].mental == true)
                        CheckBoxMentalRetardation.Checked = true;

                    if (item[Id].emotional == true)
                        CheckBoxEmotional.Checked = true;

                    if (item[Id].otherdis == "")
                        CheckBoxOther.Checked = false;
                    else
                    {
                        CheckBoxOther.Checked = true;
                        TextBoxOtherOptional.Text = (item[Id].otherdis.ToString());
                    }

                    if (item[Id].medication == "")
                        RadioNoOptional.Checked = false;
                    else
                    {
                        RadioYesOptional.Checked = true;
                        TextBoxYesOptional.Text = (item[Id].medication.ToString());
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("OutOfRangeError");
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}