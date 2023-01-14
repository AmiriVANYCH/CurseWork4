using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CurseWork
{
    public partial class Results : Form
    {
        public string text;
        public List<Path> res;
        public int node;
        public List<int> stance;
        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            int endNode=0;
            this.Text = text;
            for (int i = 0; i < res.Count; i++)
            {
                for (int j = 1; j < res[i].path.Count; j++)
                    endNode = res[i].path[j];
                if (stance.Contains(endNode)){
                    string[] subs = new string[4];
                    subs[0] = node.ToString() + " - " + i.ToString();
                    if (res[i].weight > 0)
                        subs[1] = res[i].weight.ToString();
                    else
                        subs[1] = "-";
                    if (res[i].weight > 0)
                        subs[3] = res[i].path.Count.ToString();
                    else
                        subs[3] = "-";

                    if (res[i].path.Count > 0)
                    {
                        subs[2] = res[i].path[0].ToString();
                        for (int j = 1; j < res[i].path.Count; j++)
                            subs[2] += " > " + res[i].path[j].ToString();
                    }
                    else
                        subs[2] = "-";
                    listView1.Items.Add(new ListViewItem(subs));
                }
            }
        }
    }
}
