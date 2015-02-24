using System.Collections.Generic;

namespace CodingExercise.App
{
    /// <summary>
    /// A collection of points on the grid, with a descriptive "Direction" for use in the final
    /// output.
    /// </summary>
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