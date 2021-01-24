using ContinueWithDemo.Models;
using System;
using System.Threading.Tasks;

namespace ContinueWithDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = Car.CreateCarWithStartedEngine(OnEngineStarted);

            Console.ReadKey();
        }

        private static void OnEngineStarted(Task task)
        {
            Console.WriteLine("Done.");
        }
    }
}
