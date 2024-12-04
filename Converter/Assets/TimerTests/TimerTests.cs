using System;
using System.Threading;
using NUnit.Framework;

namespace Converter
{
    public sealed class TimerTests
    {
        private Timer _timer;
        private int _cycleCompleteCount;

        [SetUp]
        public void SetUp()
        {
            _cycleCompleteCount = 0;
        }

        [Test]
        public void ConstructorThrowsArgumentExceptionWhenCycleDurationIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Timer(0, () => { }),
                "Cycle duration must be greater than zero");
            Assert.Throws<ArgumentException>(() => new Timer(-1, () => { }),
                "Cycle duration must be greater than zero");
        }

        [Test]
        public void ConstructorThrowsArgumentNullExceptionWhenActionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Timer(1, null), "onCycleComplete cannot be null");
        }

        [Test]
        public void SetCycleDurationThrowsArgumentExceptionWhenNewDurationIsZeroOrNegative()
        {
            _timer = new Timer(1, () => { });
          
            Assert.Throws<ArgumentException>(() => _timer.SetCycleDuration(0),
                "Cycle duration must be greater than zero");
            Assert.Throws<ArgumentException>(() => _timer.SetCycleDuration(-1),
                "Cycle duration must be greater than zero");
        }

        [Test]
        public void OnCycleCompleteIsCalledAfterSpecifiedDurationManualResetEvent()
        {
            var resetEvent = new ManualResetEvent(false);
            _timer = new Timer(0.1f, () =>
            {
                _cycleCompleteCount++;
                resetEvent.Set(); 
            });
            _timer.Start();
           
            var isSignaled = resetEvent.WaitOne(200);
          
            Assert.IsTrue(isSignaled, "Cycle complete should be signaled");
            Assert.AreEqual(1, _cycleCompleteCount, "Cycle complete should be called once");
        }

        [Test]
        public void StartDoesNotStartTimerTwice()
        {
            var cycleCompleteCount = 0;
            var timer = new Timer(0.2f, () => cycleCompleteCount++);

            timer.Start();
            Thread.Sleep(250); 
            timer.Start();
            Thread.Sleep(250);

           Assert.AreEqual(2, cycleCompleteCount, "Cycle complete should be called twice");
        }

        [Test]
        public void StopPreventsFurtherCycleCompletion()
        {
            var cycleCompleteCount = 0;
            var timer = new Timer(0.2f, () => cycleCompleteCount++);
            
            timer.Start();
            Thread.Sleep(250);
            timer.Stop();
            Thread.Sleep(250);
            timer.Start();
            Thread.Sleep(250);
            
            Assert.AreEqual(1, cycleCompleteCount, "Cycle complete should be called only once after stop");
        }

        [Test]
        public void SetCycleDurationDoesNotStartTimer()
        {
            _timer = new Timer(0.2f, () => _cycleCompleteCount++);
            
            _timer.SetCycleDuration(0.1f);

            Assert.AreEqual(0, _cycleCompleteCount, "Timer should not start after updating duration");
        }

        [Test]
        public void SetCycleDurationUpdatesDurationCorrectly()
        {
            var cycleCompleteCount = 0;
            var timer = new Timer(0.5f, () => cycleCompleteCount++); 
            
            timer.Start();
            Thread.Sleep(600); 
            timer.SetCycleDuration(0.2f); 
            Thread.Sleep(250);

            Assert.AreEqual(2, cycleCompleteCount, "Cycle complete should be called twice with updated duration");
        }
    }
}