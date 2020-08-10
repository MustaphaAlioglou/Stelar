using System;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Menu : Form
    {
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
    }
}