using System;
using System.Collections.Generic;


namespace CurseWork
{
    public class Graph
    {

        private List<int> nodes;

        private List<Connection> relations;

        private List<int> visited;
        private const int satMultiplyer = 1;

        public Graph(List<Connection> relations, List<Node> nodes)
        {
            this.relations = relations;
            this.nodes = new List<int>();
            for (int i = 0; i < nodes.Count; i++)
                this.nodes.Add(i);
        }


        public float Weight(int from, int to)
        {
            for (int i = 0; i < relations.Count; i++)
                if (((relations[i].from == from) && (relations[i].to == to)) || ((relations[i].from == to) && (relations[i].to == from)))
                {
                    return (relations[i].type == ConnectType.Ground ? (float)relations[i].weight : (float)(relations[i].weight * satMultiplyer));
                }
            return -1;
        }


        public List<Path> LeastWeight(int point, List<int> disabled)
        {
            visited = new List<int>();
            List<Path> res = new List<Path>();
            if (disabled.Count > 0)
            {
                disabled.Remove(disabled[0]);
                disabled.Remove(disabled[disabled.Count - 1]);
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                Path tmp = new Path();
                tmp.weight = -1;
                tmp.path = new List<int>();
                res.Add(tmp);
            }
            Path t = new Path();
            t.weight = 0;
            t.path = new List<int>();
            t.path.Add(point);
            res[point] = t;
            while ((visited.Count + disabled.Count) != nodes.Count)
            {
                //Получаем список все непосещённых вершин
                List<int> unvisited = nonVisited(visited, disabled);
                //Находим вершину среди непосещённых, путь из которой к искомой минимальный
                float min = res[unvisited[0]].weight;
                int v = 0;
                for (int i = 1; i < unvisited.Count; i++)
                    if (((res[unvisited[i]].weight < min) || (min == -1)) && (res[unvisited[i]].weight != -1))
                    {
                        v = i;
                        min = res[unvisited[i]].weight;
                    }
                if (min != -1)
                    for (int i = 0; i < unvisited.Count; i++)
                    {
                        if (Weight(unvisited[i], unvisited[v]) != -1)
                        {
                            if ((res[unvisited[i]].weight > (res[unvisited[v]].weight + Weight(unvisited[i], unvisited[v]))) || (res[unvisited[i]].weight == -1))
                            {
                                Path tmp = res[unvisited[i]];
                                tmp.weight = (res[unvisited[v]].weight + Weight(unvisited[i], unvisited[v]));
                                tmp.path = new List<int>();
                                tmp.path.AddRange(res[unvisited[v]].path);
                                tmp.path.Add(unvisited[i]);
                                res[unvisited[i]] = tmp;

                            }
                        }
                    }
                visited.Add(unvisited[v]);
            }
            return res;
        }

        private List<int> nonVisited(List<int> visited, List<int> disabled)
        {

            List<int> res = new List<int>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!disabled.Contains(nodes[i]))
                    res.Add(i);
            }
            for (int i = 0; i < visited.Count; i++)
                res.Remove(visited[i]);
            return res;
        }


        public List<Path> LeastCount(int point)
        {
            visited = new List<int>();
            List<Path> res = new List<Path>();
            for (int i = 0; i < nodes.Count; i++)
            {
                Path tmp = new Path();
                tmp.weight = -1;
                tmp.path = new List<int>();
                res.Add(tmp);
            }
            Path t = new Path();
            t.weight = 0;
            t.path = new List<int>();
            t.path.Add(point);
            res[point] = t;

            while (visited.Count != nodes.Count)
            {

                List<int> unvisited = nonVisited(visited, new List<int>());

                float min = res[unvisited[0]].weight;
                int v = 0;
                for (int i = 1; i < unvisited.Count; i++)
                    if (((res[unvisited[i]].weight < min) || (min == -1)) && (res[unvisited[i]].weight != -1))
                    {
                        v = i;
                        min = res[unvisited[i]].weight;
                    }
                if (min != -1)
                    for (int i = 0; i < unvisited.Count; i++)
                    {
                        if (Weight(unvisited[i], unvisited[v]) != -1)
                        {
                            if ((res[unvisited[i]].path.Count > (res[unvisited[v]].path.Count + 1)) || (res[unvisited[i]].weight == -1))
                            {
                                Path tmp = res[unvisited[i]];
                                tmp.weight = (res[unvisited[v]].weight + Weight(unvisited[i], unvisited[v]));
                                tmp.path = new List<int>();
                                tmp.path.AddRange(res[unvisited[v]].path);
                                tmp.path.Add(unvisited[i]);
                                res[unvisited[i]] = tmp;

                            }
                        }
                    }
                visited.Add(unvisited[v]);
            }
            return res;
        }



        

        public Info logical(Path path, int packets, ulong packetSize, int serviceSize, bool noService)
        {


            List<int> visited = new List<int>();
            List<int> query = new List<int>();
            Info inf = new Info();
            Random rnd = new Random();

            double speed;
            inf.connect =  3;
            inf.disconnect =  1;
            inf.information = (ulong)packets;
            inf.ack = inf.information;
            inf.path = new Path();
            inf.path.path = new List<int>();
            if (path.path.Count > 0)
            {
                
                speed = path.weight / 1024.0;
                ulong time = 0;
                time = (ulong)Math.Ceiling((double)(speed * inf.ack * serviceSize));
                if (!noService)
                {

                    for (int i = 1; i < path.path.Count; i++)
                        time += (ulong)Math.Ceiling((double)(Weight(path.path[i - 1], path.path[i]) / 1024.0 * serviceSize * (inf.connect + inf.disconnect + inf.ack)));
                }
                else
                {
                    inf.connect = 0;
                    inf.disconnect = 0;
                    inf.ack = 0;
                }
                if (path.path.Count > 1)
                {
                    float max = Weight(path.path[0], path.path[1]);
                    for (int j = 2; j < path.path.Count; j++)
                        if (Weight(path.path[j - 1], path.path[j]) > max)
                            max = Weight(path.path[j - 1], path.path[j]);
                    time += (ulong)Math.Ceiling((double)(max / 1024.0 * (packets - 1) * (double)packetSize));
                    time += (ulong)Math.Ceiling((double)(speed * (double)packetSize));
                    inf.time = time;
                    inf.servTrafic = (inf.connect + inf.disconnect + inf.ack) * (ulong)serviceSize;
                    inf.infTrafic = (ulong)packets * packetSize;
                    inf.AllTrafic = inf.servTrafic + inf.infTrafic;
                    if (!noService)
                    {
                        double multipli = Math.Round((double)(rnd.Next(0, packets) / 10));
                        inf.information += (ulong)multipli;
                        inf.err = (ulong)multipli;
                        inf.ack += (ulong)multipli * 2;
                        time += (ulong)Math.Ceiling((double)(max / 1024.0 * (multipli - 1) * (double)packetSize));
                        time += (ulong)Math.Ceiling((double)(speed * (double)packetSize));
                        inf.time = time;
                        inf.servTrafic += (ulong)multipli * (ulong)serviceSize;
                        inf.infTrafic += (ulong)multipli * packetSize;
                        inf.AllTrafic += ((ulong)multipli * (ulong)serviceSize) + ((ulong)multipli * packetSize);
                    }
                    
                }
                else
                    inf.time = 0;
            }
            else
                inf.time = 0;
            return inf;
        }

        public Info DataGramm(Path path, int packets, ulong packetSize, int serviceSize)
        {
            Info res, r1, r2;
            int packets1 = 0;
            int packets2 = 0;
            List<int> visited = new List<int>();
            List<int> query = new List<int>();
            res = new Info();
            //test = new Info();
            if (path.path.Count == 0)
                return res;
            List<int> disabled = new List<int>();
            for (int i = 1; i < path.path.Count - 1; i++)
                disabled.Add(path.path[i]);
            Path route1, route2;
            route1 = LeastWeight(path.path[0], new List<int>())[path.path[path.path.Count - 1]];
            route2 = LeastWeight(path.path[0], disabled)[path.path[path.path.Count - 1]];
            if (route2.path.Count > 0)
            {
                packets1 = (int)Math.Ceiling(packets / 2.0);
                packets2 = packets - packets1;

            }
            else
            {
                packets1 = packets;
                packets2 = 0;
            }
            r1 = logical(route1, packets1, packetSize, serviceSize, true);
            r2 = logical(route2, packets2, packetSize, serviceSize, true);
            res.time = Math.Max(r1.time, r2.time);
            res.information = r1.information + r2.information;
            res.ack = r1.ack + r2.ack;
            res.path = route2;
            res.servTrafic = r1.servTrafic+r2.servTrafic;
            res.infTrafic = r1.infTrafic+r2.infTrafic;
            res.AllTrafic = r1.AllTrafic+r2.AllTrafic;
            res.err = r1.err + r2.err;
 
            return res;
        }
    }



    public struct Path
    {
        public List<int> path;
        public float weight;
    }

    public struct RouteRes
    {
        public int querys;
        public int info;
        public int time;
    }

    public struct Info
    {
        public ulong err;
        public ulong connect;
        public ulong disconnect;
        public ulong information;
        public ulong ack;
        public ulong servTime;
        public ulong discover;
        public ulong time;
        public ulong AllTrafic;
        public ulong servTrafic;
        public ulong infTrafic;
        public Path path;
    }
}