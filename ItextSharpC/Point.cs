namespace Com.Hp.SRA.Proofing.Chart
{
    public class Point
    {
        public Point(float x, float y) 
        {
            X = x;
            Y = y;
        }
        public float X { get; set; }
        public float Y { get; set; }

        public override string ToString() {
            return "X: " + X + " Y:" + Y;
        }
    }
}
