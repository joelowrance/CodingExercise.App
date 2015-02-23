using System.Collections.Generic;

namespace CodingExercise.App
{
    public class Sequence
    {
        public List<Point> Points { get; set; }
        public string Direction { get; set; }

        public Sequence()
        {
            Points = new List<Point>();
        }

        public int Product()
        {
            var val = 1;
            Points.ForEach(x => val = val*x.Value);
            return val;
        }
    }
}