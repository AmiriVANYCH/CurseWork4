using System.Drawing;

namespace CurseWork
{
    public interface Shapes
    {
        float nodeSide
        {
            get;
        }

        Graphics target
        {
            get;
            set;
        }

        void Node(Node node, int index);

        void Line(Line line, float weight, ConnectType type);

        bool inNode(Node node, float x, float y);
    }
}