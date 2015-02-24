using System;

namespace CodingExercise.App
{
    /// <summary>
    /// I cheated with IDisposable to make switching the console color a quick and 
    /// unobtrusive process.
    /// </summary>
    public class HighlightConsoleOutput : IDisposable
    {
        private readonly ConsoleColor _oldColor;

        public HighlightConsoleOutput(bool highlight)
        {
            _oldColor = Console.ForegroundColor;

            if (highlight)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            
        }

        public void Dispose()
        {
            Console.ForegroundColor = _oldColor;
        }
    }
}