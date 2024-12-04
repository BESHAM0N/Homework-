using System;
using System.Collections.Generic;

namespace Converter
{
    public sealed class Converter
    {
        private Queue<IResource> _loadingArea;
        private Queue<IProduct> _unloadingArea;
        private List<IResource> _currentProcessing;

        private readonly int _loadingAreaCapacity;
        private readonly int _unloadingAreaCapacity;
        private readonly int _loadingBatchSize;
        private readonly int _unloadingBatchSize;
        private readonly float _conversionTime;

        private Timer _timer;
        private bool _isEnabled;

        public Converter(int loadingAreaCapacity, int unloadingAreaCapacity, int loadingBatchSize,
            int unloadingBatchSize, float conversionTime)
        {
            if (loadingAreaCapacity <= 0 ||
                unloadingAreaCapacity <= 0 ||
                loadingBatchSize <= 0 ||
                unloadingBatchSize <= 0 ||
                conversionTime < 0)
            {
                throw new ArgumentException("Invalid conversion parameters");
            }

            _loadingAreaCapacity = loadingAreaCapacity;
            _unloadingAreaCapacity = unloadingAreaCapacity;
            _loadingBatchSize = loadingBatchSize;
            _unloadingBatchSize = unloadingBatchSize;
            _conversionTime = conversionTime;

            _loadingArea = new Queue<IResource>();
            _unloadingArea = new Queue<IProduct>();
            _currentProcessing = new List<IResource>();
            _timer = new Timer(_conversionTime, OnCycleComplete);
            _isEnabled = false;
        }

        public void Enable()
        {
            if (_isEnabled)
                throw new InvalidOperationException("Converter is already enabled");
            
            if (_loadingArea.Count < _loadingBatchSize)
                throw new InvalidOperationException("Not enough resources in the loading area to start processing");

            if (_unloadingArea.Count + _unloadingBatchSize > _unloadingAreaCapacity)
                throw new InvalidOperationException("Not enough space in the unloading area to process products");

            _isEnabled = true;

            if (_loadingArea.Count >= _loadingBatchSize &&
                _unloadingArea.Count + _unloadingBatchSize <= _unloadingAreaCapacity)
            {
                StartProcessing();
                _timer.Start();
            }
            else
            {
                _timer.Stop();
            }
        }

        public void Disable()
        {
            if (!_isEnabled)
                throw new InvalidOperationException("Converter is already disabled");

            _isEnabled = false;
            _timer.Stop();
            ReturnToInputZone();
        }

        public void Update()
        {
            if (!_isEnabled)
                throw new InvalidOperationException("Cannot update a disabled converter");

            if (_loadingArea.Count < _loadingBatchSize)
                throw new InvalidOperationException("Not enough resources in the loading area to continue processing");

            if (_unloadingArea.Count + _unloadingBatchSize > _unloadingAreaCapacity)
                throw new InvalidOperationException("Not enough space in the unloading area to continue processing");

            while (_loadingArea.Count >= _loadingBatchSize &&
                   _unloadingArea.Count + _unloadingBatchSize <= _unloadingAreaCapacity)
            {
                if (_currentProcessing.Count == 0)
                {
                    StartProcessing();
                }

                CompleteProcessing();
            }

            if (_loadingArea.Count < _loadingBatchSize ||
                _unloadingArea.Count + _unloadingBatchSize > _unloadingAreaCapacity)
            {
                _timer.Stop();
            }
        }

        public int AddResourcesToLoadingArea(List<IResource> resources)
        {
            if (resources == null)
                throw new ArgumentNullException(nameof(resources), "Resources cannot be null");
            if (resources.Count == 0)
                throw new ArgumentException("No resources to add to loading area", nameof(resources));

            var availableSpace = _loadingAreaCapacity - _loadingArea.Count;
            var overflow = resources.Count > availableSpace ? resources.Count - availableSpace : 0;

            for (var i = 0; i < availableSpace && i < resources.Count; i++)
            {
                _loadingArea.Enqueue(resources[i]);
            }

            return overflow;
        }

        private void OnCycleComplete()
        {
            if (_currentProcessing.Count > 0)
            {
                CompleteProcessing();
            }

            if (_loadingArea.Count >= _loadingBatchSize &&
                _unloadingArea.Count + _unloadingBatchSize <= _unloadingAreaCapacity)
            {
                StartProcessing();
            }
            else
            {
                _timer.Stop();
            }
        }

        private void StartProcessing()
        {
            if (_loadingArea.Count < _loadingBatchSize)
                throw new InvalidOperationException("Not enough resources in loading area to start processing");

            for (var i = 0; i < _loadingBatchSize; i++)
            {
                _currentProcessing.Add(_loadingArea.Dequeue());
            }
        }

        private void CompleteProcessing()
        {
            var availableSpace = _unloadingAreaCapacity - _unloadingArea.Count;

            if (availableSpace < _unloadingBatchSize)
                throw new InvalidOperationException("Not enough space in unloading area to complete processing");

            for (var i = 0; i < Math.Min(_unloadingBatchSize, availableSpace); i++)
            {
                _unloadingArea.Enqueue(new Product(ProductType.Board));
            }

            _currentProcessing.Clear();
        }

        private void ReturnToInputZone()
        {
            foreach (var resource in _currentProcessing)
            {
                if (_loadingArea.Count < _loadingAreaCapacity)
                {
                    _loadingArea.Enqueue(resource);
                }
            }

            _currentProcessing.Clear();

            var excessResources = Math.Max(0, _loadingArea.Count - _loadingAreaCapacity);
            for (var i = 0; i < excessResources; i++)
            {
                _loadingArea.Dequeue();
            }
        }

        public int GetLoadingAreaCount() => _loadingArea.Count;
        public int GetUnloadingAreaCount() => _unloadingArea.Count;
        public int GetUnloadingBatchSize() => _unloadingBatchSize;
        public int GetLoadingBatchSize() => _loadingBatchSize;
        public int GetLoadingAreaCapacity() => _loadingAreaCapacity;
        public int GetUnloadingAreaCapacity() => _unloadingAreaCapacity;
    }
}