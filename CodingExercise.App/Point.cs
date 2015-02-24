namespace CodingExercise.App
{
    /// <summary>
    /// Represents a point on our grid
    /// </summary>
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public int Value { get; set; }

        public Point(int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
        }


    }
}