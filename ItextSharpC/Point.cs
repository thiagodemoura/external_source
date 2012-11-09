namespace Com.Hp.SRA.Proofing.Chart
{
    public class Point
    {
        public Point(float _X, float _Y) 
        {
            X = _X;
            Y = _Y;
        }
        public float X { get; set; }
        public float Y { get; set; }

        public override string ToString() {
            return "X: " + X + " Y:" + Y;
        }
    }
}
