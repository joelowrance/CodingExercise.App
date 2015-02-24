using System;

namespace CodingExercise.App
{
    class Program
    {
        static void Main()
        {
        
            var ds = new DataSource();
            var data = ds.AsArray();
            var result = new GridProcessor().GetMax(data, new ReusltPrinter());

            Console.WriteLine();

            Console.WriteLine("The greatest product is {0}, find by starting at row {1}, col {2} and heading {3}",
                result.Product(), result.Points[0].Row, result.Points[0].Column, result.Direction);

            Console.ReadKey();
        }
    }
}
