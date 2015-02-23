using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.App
{
    public class GridProcessor
    {
        private const int MaxHops = 4;
        private const int Cols = 20;
        private const int Rows = 20;

 
        public void GetMax(int[,] sourceData)
        {
            if (sourceData.GetLength(0) != Rows || sourceData.GetLength(1) != Cols) throw new ArgumentException("Only processing 20 * 20 grid");

            var calls = new List<Func<int[,], int, int, Sequence>>()
            {
                ProductNorth,
                ProductNorthEast,
                ProductEast,
                ProductSouthEast,
                ProductSouth,
                ProductSouthWest,
                ProductWest,
                ProductNorthEast
            };

            var sequences = new List<Sequence>();


            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    foreach (var call in calls)
                    {
                        sequences.Add(call(sourceData, row, col));
                    }
                }
            }

            var max = sequences.Max(x => x.Product());
            var actuaal = sequences.First(x => x.Product() == max);

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    var match = actuaal.Points.FirstOrDefault(x => x.Row == row && x.Column == col);

                    if (match != null)
                    {
                        var oldColod = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(sourceData[row, col].ToString().PadLeft(2, '0') + " ");
                        Console.ForegroundColor = oldColod;
                    }
                    else
                    {
                        Console.Write(sourceData[row, col].ToString().PadLeft(2, '0') + " ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("The max sum was {0} starting on row {1} at column {2} and heading {3}", actuaal.Product(), actuaal.Points[0].Row, actuaal.Points[0].Column, actuaal.Direction);
        }


    
        public Sequence ProductNorth(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow - x, x => col, "North");
        }

        public Sequence ProductNorthEast(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow - x, x => col + x, "Northeast" );
        }

        public Sequence ProductEast(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow, x => col + x, "East");
        }

        public Sequence ProductSouthEast(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col + x, "Southeast");
        }


        public Sequence ProductSouth(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col, "South");
        }

        public Sequence ProductSouthWest(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col - x, "Southwest");
        }

        public Sequence ProductWest(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow, x => col - x, "West");
        }

        public Sequence ProductNorthWest(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow - x, x => col - x, "Northwest");
        }


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
      
        private Point GetPoint(int[,] sourceData, int row, int col)
        {
            if (row < 0) return new Point(row, col, 1);//return null and do nothing
            if (row > Rows - 1) return new Point(row, col, 1);//return null and do nothing
            if (col > Cols - 1) return new Point(row, col, 1);//return null and do nothing
            if (col < 0)  return new Point(row, col, 1); //return null and do nothing

            return new Point(row, col, sourceData[row, col]);

        }

    }
}