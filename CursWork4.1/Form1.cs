using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CurseWork
{
    public partial class Form1 : Form
    {
        Canvas container;
        int lastx, lasty;
        int delNode1, delNode2;
        bool deleting;
        public ConnectType type;
        public int weight;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            container = new Canvas(pictureBox1, new Rounded());
            container.Update += new EventHandler(container_Update);
        }

        void container_Update(object sender, EventArgs e)
        {
            int con = 0;
            for (int i = 0; i < container.relations.Count; i++)
                if (container.relations[i].type == ConnectType.Ground)
                    con++;
            label2.Text = container.nodes.Count.ToString();
            label3.Text = con.ToString();
            label5.Text = (container.relations.Count - con).ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                container.startMove(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                container.endMove();
                container.endLine(e.X, e.Y);
                if (deleting)
                {
                    delNode2 = container.getNode(e.X, e.Y);
                    if (delNode2 < 0)
                        deleting = false;
                    else
                        container.deleteLine(delNode1, delNode2);
                }
            }
            else
            {
                lastx = e.X;
                lasty = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (container.isNode(e.X, e.Y))
            {
                if (pictureBox1.ContextMenuStrip != nodeContext)
                    pictureBox1.ContextMenuStrip = nodeContext;
            }
            else if (pictureBox1.ContextMenuStrip == nodeContext)
                pictureBox1.ContextMenuStrip = generalContext;

            if (e.Button == MouseButtons.Left)
            {
                container.Move(e.X, e.Y);
            }
            else
            {
                container.Move(e.X, e.Y);
            }
        }

        private void наземныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            container.AddNode(lastx, lasty, ConnectType.Ground);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weight = -1;
            LineWeight x = new LineWeight();
            x.x = this;
            x.ShowDialog();
            if (weight > 0)
                container.startLine(lastx, lasty, weight, type);
        }

        private void removeConnectionToolStripMenuItem(object sender, EventArgs e)
        {
            deleting = true;
            delNode1 = container.getNode(lastx, lasty);
        }

        private void remuveSwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            container.deleteNode(lastx, lasty);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            container.Save("autosave.xml");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult save = saveFileDialog1.ShowDialog();
            if (save == DialogResult.OK)
                container.Save(saveFileDialog1.FileName);
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                container.Load(openFileDialog1.FileName);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            container.Clear();
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            container.AddNode(lastx, lasty, ConnectType.Satellite);
        }

        private void addStanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            container.AddStance(lastx, lasty, ConnectType.Satellite);
        }

        private void сохранитьКартинкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void shortestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (container.stances.Contains(container.getNode(lastx, lasty)))
            {
                Results x = new Results();
                x.text = "Таблиця маршрутизації, побудована за мінімальною довжиною шляху";
                x.stance = container.stances;
                Graph gr = new Graph(container.relations, container.nodes);
                x.node = container.getNode(lastx, lasty);
                x.res = gr.LeastWeight(x.node, new List<int>());
                x.Show();
            }
        }

        private void minSwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (container.stances.Contains(container.getNode(lastx, lasty)))
            {
                Results x = new Results();
                x.text = "Таблиця маршрутизації, побудована за мінімальною кількістю вузлів";
                x.stance = container.stances;
                Graph gr = new Graph(container.relations, container.nodes);
                x.node = container.getNode(lastx, lasty);
                x.res = gr.LeastCount(x.node);
                x.Show();
            }
        }

        private void logicalChannelModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int from = container.getNode(lastx, lasty);
            if (container.stances.Contains(from))
            {
                Graph x = new Graph(container.relations, container.nodes);
                SendForm form = new SendForm();
                form.gr = new Graph(container.relations, container.nodes);
                form.stance = container.stances;
                form.text = "Режим логічного каналу";
                form.results = x.LeastCount(from);
                form.from = from;
                form.packets = 20;
                form.Show();
            }
        }

        private void datagramModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int from = container.getNode(lastx, lasty);
            if (container.stances.Contains(from))
            {
                Graph x = new Graph(container.relations, container.nodes);
                SendForm form = new SendForm();
                form.gr = new Graph(container.relations, container.nodes);
                form.stance = container.stances;
                form.text = "Дейтаграмний режим";
                form.results = x.LeastWeight(from, new List<int>());
                form.from = from;
                form.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
