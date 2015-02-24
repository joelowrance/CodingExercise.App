using System;
using System.Linq;

namespace CodingExercise.App
{

    /// <summary>
    /// Prints out the grid showing the highlighted values used to determine
    /// the best sequence of points.
    /// </summary>
    public class ReusltPrinter
    {
        private const int Cols = 20;
        private const int Rows = 20;


        public void Print(int[,] sourceData, Sequence bestSequence)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    var match = bestSequence.Points.FirstOrDefault(x => x.Row == row && x.Column == col);

                    using (new HighlightConsoleOutput(match != null))
                    {
                        Console.Write(sourceData[row, col].ToString().PadLeft(2, '0') + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}