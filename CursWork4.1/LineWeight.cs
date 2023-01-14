using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CurseWork
{
    public partial class LineWeight : Form
    {
        public Form1 x;
        public List<int> weights;
        public LineWeight()
        {
            InitializeComponent();
            weights = new List<int>();
            weights.Add(3);
            weights.Add(4);
            weights.Add(5);
            weights.Add(7);
            weights.Add(11);
            weights.Add(12);
            weights.Add(15);
            weights.Add(17);
            weights.Add(19);
            weights.Add(24);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Random rnd = new Random();
                x.weight = weights[rnd.Next(0, weights.Count - 1)];
            }
            else
                x.weight = (int)weights[comboBox1.SelectedIndex];
            x.type = ConnectType.Ground;//(radioButton1.Checked ? ConnectType.Ground : ConnectType.Satellite);
            this.Close();
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                button1_Click(sender, EventArgs.Empty);
        }

        private void LineWeight_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
