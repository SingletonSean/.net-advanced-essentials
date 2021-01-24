using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContinueWithDemo.Models
{
    public class Car
    {
        public bool IsEngineStarted { get; private set; }

        private Car() { }

        public static Car CreateCarWithStartedEngine(Action<Task> onEngineStarted)
        {
            Car car = new Car();

            car.StartEngine().ContinueWith(t => onEngineStarted?.Invoke(t));

            return car;
        }

        private async Task StartEngine()
        {
            Console.WriteLine("Starting engine...");

            await Task.Delay(500);
            IsEngineStarted = true;

            Console.WriteLine("Engine started!");
        }
    }
}
