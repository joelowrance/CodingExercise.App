using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.App
{
    /// <summary>
    /// This scans each point and calculates the possible values in each direction.
    /// Assumption 1:  If you go beyond the boundry of the grid the value is ignored.
    /// Assumption 2:  The grid is always 20 * 20
    /// </summary>
    public class GridProcessor
    {
        private const int MaxHops = 4;
        private const int Cols = 20;
        private const int Rows = 20;

        /// <summary>
        /// process the data in the grid,
        /// </summary>
        /// <param name="sourceData">Data to process</param>
        /// <param name="printer">class used to print the grid,</param>
        /// <returns>The values with the greatest product</returns>
        public Sequence GetMax(int[,] sourceData, ReusltPrinter printer)
        {
            if (sourceData.GetLength(0) != Rows || sourceData.GetLength(1) != Cols) throw new ArgumentException("Only processing 20 * 20 grid");

            //We're scanning top down, left to right so we don't need to look 
            //at paths behind us.
            var calculations = new List<Func<int[,], int, int, Sequence>>()
            {
                ProductToRight,
                ProductToLowerRight,
                ProductDown,
                ProductLowerLeft,
            };

            var sequences = new List<Sequence>();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    foreach (var calc in calculations)
                    {
                        sequences.Add(calc(sourceData, row, col));
                    }
                }
            }

            var max = sequences.Max(x => x.Product());
            var bestSequence = sequences.First(x => x.Product() == max); 

            if(printer != null) printer.Print(sourceData, bestSequence);

            return bestSequence;
        }



        /// <summary>
        /// Determines the product of values heading to the left
        /// </summary>
        public Sequence ProductToRight(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow, x => col + x, "to the right");
        }


        /// <summary>
        /// Determines the product of values diagonally down to the left
        /// </summary>
        public Sequence ProductToLowerRight(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col + x, "diagonally down to the right");
        }

        /// <summary>
        /// Determines the product of values heading dosn
        /// </summary>

        public Sequence ProductDown(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col, "down");
        }

        /// <summary>
        /// Determines the product of values diagonally down to the right
        /// </summary>
        public Sequence ProductLowerLeft(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col - x, "diagonally down to the left");
        }


        /// <summary>
        /// Gets a squences of points to use in the product calculation.
        /// </summary>
        private Sequence GetSequence(int[,] data, Func<int, int> row, Func<int, int> col, string direction)
        {
            var seq = new Sequence(){ Direction = direction};

            for (var i = 0; i < MaxHops; i++)
            {
                var point = GetPoint(data, row(i), col(i));
                seq.Points.Add(point);
            }

            return seq;
        }
      
        /// <summary>
        /// Gets the value of a particular point on the grid.  
        /// If the value is outside of the grid, we return 1 as we are mutiplying and we 
        /// will not see any side effects from x * 1.
        /// </summary>
        /// <returns>A point</returns>
        private Point GetPoint(int[,] sourceData, int row, int col)
        {
            if ((row < 0) ||  
                (row > Rows - 1) ||  
                (col > Cols - 1) ||  
                (col < 0)) return new Point(row, col, 1);

            return new Point(row, col, sourceData[row, col]);

        }

    }
}