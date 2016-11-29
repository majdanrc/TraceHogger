using System.Diagnostics;


namespace TraceHogger
{
    class Program
    {
        static void Main(string[] args)
        {
            const int repeats = 3;

            for (var i = 0; i < repeats; i++)
            {
                var witcher = new Stopwatch();
                witcher.Start();


                witcher.Stop();
                Debug.WriteLine("## BOX - NEW time: " + witcher.ElapsedMilliseconds);
                witcher.Reset();
            }

            for (var i = 0; i < repeats; i++)
            {
                var witcher = new Stopwatch();
                witcher.Start();


                witcher.Stop();
                Debug.WriteLine("## BOX - OLD time: " + witcher.ElapsedMilliseconds);
                witcher.Reset();
            }
        }
    }
}
