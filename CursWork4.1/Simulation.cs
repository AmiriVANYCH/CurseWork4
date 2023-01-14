using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace CurseWork
{
    public partial class Simulation : Form
    {

        public ulong data;
        public int from;
        public List<Path> results;
        public List<int> stance;
        public ulong packetsize;
        public ulong service;
        public List<Info> stats;
        public Graph gr;
        public bool scan;
        public Simulation()
        {
            InitializeComponent();
        }

        private void Simulation_Load(object sender, EventArgs e)
        {
            int endNode = 0;
            stats = new List<Info>();
            listView1.Items.Clear();
            stats.Clear();
            ulong packets = (ulong)Math.Ceiling((double)data / (double)packetsize);
            for (int i = 0; i < results.Count; i++)
            {
                for (int j = 1; j < results[i].path.Count; j++)
                    endNode = results[i].path[j];
                if (stance.Contains(endNode))
                {
                    string[] subs = new string[10];
                    if (this.Text == "Режим логічного каналу")
                    {
                        Info inf = gr.logical(results[i], (int)packets, (ulong)packetsize, (int)service,false);
                        subs[0] = from.ToString();
                        subs[1] = i.ToString();


                        if (results[i].path.Count > 0)
                        {
                            subs[2] = (inf.connect + inf.disconnect + inf.ack).ToString();
                            subs[3] = (inf.information).ToString();
                            subs[4] = inf.time.ToString();
                            subs[5] = inf.AllTrafic.ToString();
                            subs[6] = inf.infTrafic.ToString();
                            subs[7] = inf.servTrafic.ToString();

                            subs[8] = inf.err.ToString();
                            subs[9] = results[i].path[0].ToString();
                            for (int j = 1; j < results[i].path.Count; j++)
                            {
                                subs[9] += " - " + results[i].path[j].ToString();
                            }
                            
                        }
                        else
                        {
                            subs[2] = "-";
                            subs[3] = "-";
                            subs[4] = "-";
                            subs[5] = "-";
                            subs[6] = "-";
                            subs[7] = "-";
                            inf.information = 0;
                        }
                        stats.Add(inf);
                    }
                    else
                    {
                        Info inf = gr.DataGramm(results[i], (int)packets, (ulong)packetsize, (int)service);
                        subs[0] = from.ToString();
                        subs[1] = i.ToString();
                        subs[2] = (inf.ack).ToString();
                        subs[3] = (inf.information).ToString();
                        subs[4] = inf.time.ToString();

                        subs[5] = inf.AllTrafic.ToString();
                        subs[6] = inf.infTrafic.ToString();
                        subs[7] = inf.servTrafic.ToString();
                        subs[8] = inf.err.ToString();


                        if (results[i].path.Count > 0)
                        {
                            subs[9] = results[i].path[0].ToString();
                            for (int j = 1; j < results[i].path.Count; j++)
                            {
                                subs[9] += " -> " + results[i].path[j].ToString();
                            }
                            if (inf.path.path.Count > 0)
                            {
                                subs[9] += " та " + inf.path.path[0].ToString();
                                for (int j = 1; j < inf.path.path.Count; j++)
                                {
                                    subs[9] += " -> " + inf.path.path[j].ToString();
                                }
                            }
                            
                        }
                        else
                        {
                            subs[2] = "Вузол недоступний";
                            subs[3] = "-";
                            subs[4] = "-";
                            subs[5] = "-";
                            subs[6] = "-";
                            subs[7] = "-";
                            inf.information = 0;
                        }
                        stats.Add(inf);
                    }
                    listView1.Items.Add(new ListViewItem(subs));
                }
            }
        }


    }
}
