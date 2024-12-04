using System;

namespace Converter
{
    public sealed class Timer
    {        
        private Action _onCycleComplete;
        private float _cycleDuration;
        private bool _isRunning;
        private System.Timers.Timer Timers { get; }

        public Timer(float cycleDuration, Action onCycleComplete)
        {
            if (cycleDuration <= 0)
                throw new ArgumentException("Cycle duration must be greater than zero", nameof(cycleDuration));

            _cycleDuration = cycleDuration * 1000;
            _onCycleComplete = onCycleComplete ?? throw new ArgumentNullException(nameof(onCycleComplete));

            Timers = new System.Timers.Timer(_cycleDuration);
            Timers.Elapsed += HandleCycleCompletion;
            _isRunning = false;
        }

        private void HandleCycleCompletion(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!_isRunning) return;
            _onCycleComplete?.Invoke();
        }

        public void Start()
        {
            if (_isRunning) return;

            lock (Timers)
            {
                _isRunning = true;
                Timers.Start();
            }
        }

        public void Stop()
        {
            if (!_isRunning) return;  
            _isRunning = false;       
            Timers.Stop();            
            Timers.Elapsed -= HandleCycleCompletion;
        }
        
        public void SetCycleDuration(float newDuration)
        {
            if (newDuration <= 0)
                throw new ArgumentException("Cycle duration must be greater than zero", nameof(newDuration));

            _cycleDuration = newDuration * 1000; 
            Timers.Interval = _cycleDuration;    
          
            if (_isRunning)
            {
                Timers.Stop();
                Timers.Start();
            }
        }
    }
}