using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace CurseWork
{
    public class Canvas
    {
        private System.Windows.Forms.PictureBox target;
        private Shapes draws;
        public List<Node> nodes;
        public List<int> stances;
        private bool moving;
        private int movingNode;
        public List<Line> lines;
        public List<Connection> relations;
        private bool line;
        private int drawingLine;
        public event EventHandler Update;

        
        public Canvas(System.Windows.Forms.PictureBox target, Shapes draws)
        {
            this.target = target;
            this.draws = draws;
            nodes=new List<Node>();
            stances = new List<int>();
            draws.target = target.CreateGraphics();
            lines = new List<Line>();
            relations = new List<Connection>();
        }

        public void AddNode(float x, float y, ConnectType type)
        {
            Node node = new Node();
            node.x = x;
            node.y = y;
            node.stance = 0;
            node.side = draws.nodeSide;
            nodes.Add(node);
            draws.Node(node,nodes.Count-1);
            if (Update != null)
                Update(this, EventArgs.Empty);
        }
        public void AddStance(float x, float y, ConnectType type)
        {
            Node node = new Node();
            node.x = x;
            node.y = y;
            node.side = draws.nodeSide;
            node.stance = 1;
            nodes.Add(node);
            stances.Add(nodes.Count - 1);
            draws.Node(node, nodes.Count - 1);
            if (Update != null)
                Update(this, EventArgs.Empty);
        }

        public bool isNode(float x, float y)
        {
            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (draws.inNode(nodes[i],x,y))
                        return true;
                }
            }
            return false;
        }

        public int getNode(float x, float y)
        {
            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (draws.inNode(nodes[i], x, y))
                        return i;
                }
            }
            return -1;
        }

        public void startMove(float x, float y)
        {
            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (draws.inNode(nodes[i], x, y))
                    {
                        moving = true;
                        movingNode = i;
                        return;
                    }
                }
            }
            movingNode = -1;
            moving = false;
        }

        public void Move(float x, float y)
        {
            if (moving)
            {
                if (movingNode < 0)
                    return;
                Node tmp = nodes[movingNode];
                tmp.x = x;
                tmp.y = y;
                for (int j = 0; j < relations.Count; j++)                    
                {
                    if (relations[j].to == movingNode) 
                    {
                        Line t = lines[j];
                        t.toX = x+draws.nodeSide/2;
                        t.toY = y + draws.nodeSide / 2;
                        lines[j] = t;
                    }
                    if (relations[j].from == movingNode)
                    {
                        Line t = lines[j];
                        t.fromX = x + draws.nodeSide / 2;
                        t.fromY = y + draws.nodeSide / 2;
                        lines[j] = t;
                    }

                }
                nodes[movingNode] = tmp;
                Redraw();
            }
            if (line)
            {
                Line tmp = lines[drawingLine];
                tmp.toX = x;
                tmp.toY = y;
                lines[drawingLine] = tmp;
                Redraw();
            }
            
        }

        public void endMove()
        {
            if (moving)
                for (int j = 0; j < relations.Count; j++)
                {
                    if (relations[j].to == movingNode)
                    {
                        Line t = lines[j];
                        t.toX = nodes[movingNode].x + draws.nodeSide / 2;
                        t.toY = nodes[movingNode].y + draws.nodeSide / 2;
                        lines[j] = t;
                    }
                    if (relations[j].from == movingNode)
                    {
                        Line t = lines[j];
                        t.fromX = nodes[movingNode].x + draws.nodeSide / 2;
                        t.fromY = nodes[movingNode].y + draws.nodeSide / 2;
                        lines[j] = t;
                    }

                }
            Redraw();
            moving = false;
        }

        public void Redraw()
        {            
            Bitmap b = new Bitmap(target.Width, target.Height);
            Graphics g = Graphics.FromImage(b);
            draws.target = g;
            g.Clear(target.BackColor);
            if (lines.Count>0)
                for (int i = 0; i < lines.Count; i++)
                    draws.Line(lines[i],relations[i].weight,relations[i].type);
            if (nodes.Count > 0)
                for (int i = 0; i < nodes.Count; i++)
                    draws.Node(nodes[i], i);
            draws.target = target.CreateGraphics();
            target.Image = b;
            GC.Collect();
        }

        public void startLine(float x, float y, int weight, ConnectType type)
        {
            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (draws.inNode(nodes[i], x, y))
                    {
                        line = true;
                        Line tmp = new Line();
                        tmp.fromX = nodes[i].x+draws.nodeSide/2;
                        tmp.fromY = nodes[i].y + draws.nodeSide / 2;
                        tmp.toX = x;
                        tmp.toY = y;
                        lines.Add(tmp);
                        Connection con = new Connection();
                        con.from = i;
                        con.to = i;
                        con.weight = weight;
                        con.type = type;
                        relations.Add(con);
                        Redraw();
                        drawingLine = lines.Count - 1;
                        return;
                    }
                }
            }
            drawingLine = -1;
            line = false;
            if (Update != null)
                Update(this, EventArgs.Empty);
        }

        public void endLine(float x, float y)
        {
            if (!line)
                return;
            line = false;
            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (draws.inNode(nodes[i], x, y))
                    {     
                        Line tmp = lines[drawingLine];
                        tmp.toX = nodes[i].x + draws.nodeSide / 2;
                        tmp.toY = nodes[i].y + draws.nodeSide / 2;
                        lines[drawingLine] = tmp;
                        Connection con = relations[drawingLine];
                        bool f = false;
                        for (int j=0;j<relations.Count;j++)
                            if (((relations[j].from == con.from) && (relations[j].to == i)) || ((relations[j].from == i) && (relations[j].to == con.from)))
                            {
                                f = true;
                                break;
                            }
                        if (!f)
                        {
                            con.to = i;
                            relations[drawingLine] = con;
                            drawingLine = -1;
                            Redraw();
                            if (Update != null)
                                Update(this, EventArgs.Empty);
                            return;
                        }
                        else
                            break;
                        
                    }
                }
            }
            lines.RemoveAt(drawingLine);
            relations.RemoveAt(drawingLine);
            Redraw();
            if (Update != null)
                Update(this, EventArgs.Empty);
        }

        public void deleteLine(int from, int to)
        {
            for (int j = 0; j < relations.Count; j++)
                if (((relations[j].from == from) && (relations[j].to == to)) || ((relations[j].from == to) && (relations[j].to == from)))
                {
                    relations.RemoveAt(j);
                    lines.RemoveAt(j);
                    Redraw();                    
                }
            if (Update != null)
                Update(this, EventArgs.Empty);
        }

        public void deleteNode(float x, float y)
        {
            int i = getNode(x, y);
            if (i < 0)
                return;
            for (int j = 0; j < relations.Count; j++)
            {
                if ((relations[j].to == i)||(relations[j].from==i))
                {
                    relations.RemoveAt(j);
                    lines.RemoveAt(j);
                    j--;
                    continue;
                }
                if (relations[j].to > i) 
                {
                    Connection con = relations[j];
                    con.to--;
                    relations[j] = con;
                }
                if (relations[j].from > i)
                {
                    Connection con = relations[j];
                    con.from--;
                    relations[j] = con;
                }
            }
            nodes.RemoveAt(i);
            Redraw();
            if (Update != null)
                Update(this, EventArgs.Empty);
        }

        public void Save(string filename)
        {
            XmlTextWriter doc = new XmlTextWriter(filename, null);
            doc.WriteStartDocument();
            doc.WriteStartElement("Nodes");
            for (int i = 0; i < nodes.Count; i++)
            {
                doc.WriteStartElement("Node");
                doc.WriteStartAttribute("index");
                doc.WriteValue(i);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("side");
                doc.WriteValue(nodes[i].side);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("x");
                doc.WriteValue(nodes[i].x);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("y");
                doc.WriteValue(nodes[i].y);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("stance");
                doc.WriteValue(nodes[i].stance);
                doc.WriteEndAttribute();
                doc.WriteEndElement();
            }
            //doc.WriteEndElement(); 
            doc.WriteStartElement("Connections");
            for (int i = 0; i < relations.Count; i++)
            {
                doc.WriteStartElement("Connection");
                doc.WriteStartAttribute("index");
                doc.WriteValue(i);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("from");
                doc.WriteValue(relations[i].from);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("to");
                doc.WriteValue(relations[i].to);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("weight");
                doc.WriteValue(relations[i].weight);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("type");
                doc.WriteValue((int)relations[i].type);
                doc.WriteEndAttribute();              
                doc.WriteEndElement();
            }
            doc.WriteEndElement(); 
            doc.WriteStartElement("Lines");
            for (int i = 0; i < lines.Count; i++)
            {
                doc.WriteStartElement("Line");
                doc.WriteStartAttribute("index");
                doc.WriteValue(i);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("fromX");
                doc.WriteValue((double)lines[i].fromX);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("fromY");
                doc.WriteValue(lines[i].fromY);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("toX");
                doc.WriteValue(lines[i].toX);
                doc.WriteEndAttribute();
                doc.WriteStartAttribute("toY");
                doc.WriteValue(lines[i].toY);
                doc.WriteEndAttribute();
                doc.WriteEndElement();
            }
            doc.WriteStartElement("Stances");
            for (int i = 0; i < stances.Count; i++)
            {
                doc.WriteStartElement("Stance");
                doc.WriteStartAttribute("num");
                doc.WriteValue(stances[i]);
                doc.WriteEndAttribute();
                doc.WriteEndElement();
            }
            doc.WriteEndElement();
            doc.WriteEndDocument();
            doc.Close();
            
        }

        public void Load(string filename)
        {
            if (!System.IO.File.Exists(filename))
                return;
            XmlTextReader doc = new XmlTextReader(filename);            
            nodes.Clear();
            relations.Clear();
            lines.Clear();
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US").NumberFormat;
            while (doc.Read())
            {
                if (doc.Name == "Node")
                {
                    Node tmp=new Node();
                    tmp.side=float.Parse(doc.GetAttribute("side"));
                    tmp.x = float.Parse(doc.GetAttribute("x"), nfi);
                    tmp.y = float.Parse(doc.GetAttribute("y"), nfi);
                    tmp.stance= int.Parse(doc.GetAttribute("stance"), nfi);
                    nodes.Add(tmp);
                }
                if (doc.Name == "Stance")
                {
                    stances.Add(int.Parse(doc.GetAttribute("num")));
                }
                if (doc.Name == "Connection")
                {
                    Connection tmp = new Connection();
                    tmp.from = int.Parse(doc.GetAttribute("from"));
                    tmp.to = int.Parse(doc.GetAttribute("to"));
                    tmp.weight = float.Parse(doc.GetAttribute("weight"), nfi);
                    int x = int.Parse(doc.GetAttribute("type"));
                    tmp.type = (x == 1 ? ConnectType.Ground : ConnectType.Satellite);
                    relations.Add(tmp);
                }
                if (doc.Name == "Line")
                {
                    Line tmp = new Line();
                    tmp.fromX = float.Parse(doc.GetAttribute("fromX"), nfi);
                    tmp.fromY = float.Parse(doc.GetAttribute("fromY"), nfi);
                    tmp.toX = float.Parse(doc.GetAttribute("toX"), nfi);
                    tmp.toY = float.Parse(doc.GetAttribute("toY"), nfi);
                    lines.Add(tmp);
                }
            }
            doc.Close();
            Redraw();
            if (Update != null)
                Update(this, EventArgs.Empty);
        }

        public void Clear()
        {
            nodes.Clear();
            relations.Clear();
            lines.Clear();
            Redraw();
        }
    }
}