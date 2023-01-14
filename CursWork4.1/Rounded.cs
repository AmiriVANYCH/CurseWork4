using System;
using System.Drawing;

namespace CurseWork
{
    public class Rounded : Shapes
    {
        private Graphics _target;
        Color satelliteLine = Color.Blue;
        Color groundLine = Color.Black;

        public float nodeSide
        {
            get
            {
                return 25;
            }
        }

        public Graphics target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
        #region Shapes Members

        public void Node(Node node, int index)
        {
            SolidBrush b;
            if (node.stance == 1) { 
                b = new SolidBrush(Color.GreenYellow);
            } else
            {
                b = new SolidBrush(Color.White);
            }
            
            target.FillEllipse(b, node.x, node.y, node.side, node.side);
            target.DrawEllipse(new Pen(Color.Black), node.x, node.y, node.side, node.side);
            target.DrawString(index.ToString(), new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, new PointF(node.x + nodeSide / 3, node.y + nodeSide / 2 - 9));
        }

        public void Line(Line line, float weight, ConnectType type)
        {
            // target.DrawLine(new Pen((type==ConnectType.Ground?groundLine:satelliteLine), 2), line.fromX, line.fromY, line.toX, line.toY);
            target.DrawLine(new Pen((groundLine), 2), line.fromX, line.fromY, line.toX, line.toY);
            target.DrawString(weight.ToString(), new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold), Brushes.Black, new PointF((line.fromX + line.toX) / 2, (line.fromY + line.toY) / 2));
        }

        public bool inNode(Node node, float x, float y)
        {
            return (Math.Pow(x - node.x, 2) + Math.Pow(y - node.y, 2)) <= Math.Pow(node.side, 2);
        }

        #endregion

    }
}