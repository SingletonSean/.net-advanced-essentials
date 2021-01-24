using ContinueWithDemo.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ContinueWithDemoTests.Models
{
    public class CarTests
    {
        private Car _car;

        [Test]
        public async Task CreateCarWithStartedEngine_StartsEngine()
        {
            TaskCompletionSource<object> taskSource = new TaskCompletionSource<object>();

            _car = Car.CreateCarWithStartedEngine(t =>
            {
                taskSource.SetResult(null);
            });
            await taskSource.Task;

            Assert.IsTrue(_car.IsEngineStarted);
        }
    }
}