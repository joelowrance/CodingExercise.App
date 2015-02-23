using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var ds = new DataSource();
            var data = ds.AsArray();
            var processor = new GridProcessor();
            processor.GetMax(data);

            Console.ReadKey();
        }
    }
}
