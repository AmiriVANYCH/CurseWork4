using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CurseWork
{
    public partial class SendForm : Form
    {
        public int packets;
        public int from;
        public List<Path> results;
        public List<int> stance; 
        public string text;
        public Graph gr;
        public SendForm()
        {
            InitializeComponent();
        }

        private void SendForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simulation form = new Simulation();
            form.Text = text;
            form.data = (ulong)numericUpDown1.Value;
            form.stance = stance;
            form.packetsize = (ulong)numericUpDown2.Value;
            form.service = (ulong)numericUpDown3.Value;
            form.results = results;
            form.from = from;
            form.gr = gr;
            form.scan = checkBox1.Checked;
            form.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
