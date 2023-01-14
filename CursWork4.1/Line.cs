
namespace CurseWork
{
    public struct Connection
    {
        public int from;
        public int to;
        public float weight;
        public ConnectType type;
    }

    public struct Line
    {
        public float fromX;
        public float fromY;
        public float toX;
        public float toY;
    }
}