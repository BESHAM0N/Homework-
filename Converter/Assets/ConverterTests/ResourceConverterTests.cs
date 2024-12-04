using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Converter
{
    public sealed class ResourceConverterTests
    {
        // Instantiate
        [TestCase(10, 10, 5, 1, 2)]
        [TestCase(6, 8, 8, 2, 1)]
        public void Instantiate(int loadingAreaCapacity, int unloadingAreaCapacity,
            int loadingBatchSize, int unloadingBatchSize, float conversionTime)
        {
            var converter = CreateConverter(loadingAreaCapacity, unloadingAreaCapacity, loadingBatchSize,
                unloadingBatchSize, conversionTime);

            Assert.AreEqual(loadingAreaCapacity, converter.GetLoadingAreaCapacity());
            Assert.AreEqual(unloadingAreaCapacity, converter.GetUnloadingAreaCapacity());
            Assert.AreEqual(loadingBatchSize, converter.GetLoadingBatchSize());
            Assert.AreEqual(unloadingBatchSize, converter.GetUnloadingBatchSize());
        }

        [TestCase(0, 10, 5, 2, 1)]
        [TestCase(10, 0, 5, 2, 1)]
        [TestCase(10, 10, 0, 2, 1)]
        [TestCase(10, 10, 5, 0, 1)]
        [TestCase(10, 10, 5, 2, -1)]
        public void WhenOneParameterException(int loadingAreaCapacity, int unloadingAreaCapacity,
            int loadingBatchSize, int unloadingBatchSize, float conversionTime)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                var _ = CreateConverter(loadingAreaCapacity, unloadingAreaCapacity, loadingBatchSize,
                    unloadingBatchSize, conversionTime);
            });
        }

        // Exceptions
        [Test]
        public void WhenAddResourcesIsNullThrowsArgumentNullException()
        {
            var converter = CreateDefaultConverter();
            Assert.Throws<ArgumentNullException>(() => converter.AddResourcesToLoadingArea(null));
        }

        [Test]
        public void WhenAddResourcesIsEmptyThrowsArgumentException()
        {
            var converter = CreateDefaultConverter();
            Assert.Throws<ArgumentException>(() => converter.AddResourcesToLoadingArea(new List<IResource>()));
        }

        [Test]
        public void WhenEnableAlreadyEnabledConverterThrowsInvalidOperationException()
        {
            var converter = CreateDefaultConverter();
            var resources = GetResources(2, ResourceType.Log);
            
            converter.AddResourcesToLoadingArea(resources);
            converter.Enable();
            
            Assert.Throws<InvalidOperationException>(() => converter.Enable());
        }

        [Test]
        public void WhenDisableAlreadyDisabledConverterThrowsInvalidOperationException()
        {
            var converter = CreateDefaultConverter();
            Assert.Throws<InvalidOperationException>(() => converter.Disable());
        }

        [Test]
        public void WhenUpdateOnDisabledConverterThrowsInvalidOperationException()
        {
            var converter = CreateDefaultConverter();
            Assert.Throws<InvalidOperationException>(() => converter.Update());
        }

        [Test]
        public void WhenProcessingWithInsufficientResourcesThrowsInvalidOperationException()
        {
            var converter = CreateDefaultConverter();
            var resources = GetResources(1, ResourceType.Log);
            converter.AddResourcesToLoadingArea(resources);

            Assert.Throws<InvalidOperationException>(() => converter.Enable());
        }

        [Test]
        public void WhenProcessingWithInsufficientUnloadingAreaSpaceThrowsInvalidOperationException()
        {
            var converter = CreateDefaultConverter();
            var resources = GetResources(4, ResourceType.Log);
            converter.AddResourcesToLoadingArea(resources);

            converter.Enable();
            converter.Update();

            Assert.Throws<InvalidOperationException>(() => converter.Update());
        }

        // Behaviors
        [TestCase(10, 10, 5, 2, 1)]
        [TestCase(2, 10, 5, 2, 1)]
        public void CanAddResourcesToLoadingArea(int resourceCount, int loadingAreaCapacity, int unloadingAreaCapacity,
            int loadingBatchSize, int unloadingBatchSize)
        {
            var converter = CreateConverter(loadingAreaCapacity, unloadingAreaCapacity, loadingBatchSize,
                unloadingBatchSize, 2.0f);
            var resources = GetResources(resourceCount, ResourceType.Log);

            var overflow = converter.AddResourcesToLoadingArea(resources);

            Assert.AreEqual(0, overflow, "All log on loading areas have been added.");
        }

        [Test]
        public void CreateProductsAutomaticallyUntilResourcesDepleted()
        {
            var converter = CreateDefaultConverter();
            var resources = GetResources(8, ResourceType.Log);
            converter.AddResourcesToLoadingArea(resources);
            converter.Enable();

            converter.Update();

            Assert.AreEqual(0, converter.GetLoadingAreaCount(), "All resources must be processed");
            Assert.AreEqual(4, converter.GetUnloadingAreaCount(), "All products must be in the unloading area");
        }

        [Test]
        public void ReturnsResourcesToLoadingAreaOnDisable()
        {
            var converter = CreateDefaultConverter();
            var resources = GetResources(8, ResourceType.Log);

            converter.AddResourcesToLoadingArea(resources);
            converter.Enable();

            converter.Disable();

            Assert.AreEqual(8, converter.GetLoadingAreaCount(), "All resources must be returned to the loading area");
        }

        [Test]
        public void BurnsResourcesOnOverload()
        {
            var converter = CreateConverter(5, 10, 2, 1, 1.0f);
            var initialResources = GetResources(3, ResourceType.Log);
            var additionalResources = GetResources(4, ResourceType.Log);

            converter.AddResourcesToLoadingArea(initialResources);
            converter.Enable();
            converter.AddResourcesToLoadingArea(additionalResources);

            converter.Disable();

            Assert.AreEqual(5, converter.GetLoadingAreaCount(),
                "There must be a maximum of 5 resources in the loading area");
        }

        [Test]
        public void ReturnsOverflowResources()
        {
            var converter = CreateConverter(5, 10, 2, 1, 1.0f);
            var resources = GetResources(7, ResourceType.Log);

            var overflow = converter.AddResourcesToLoadingArea(resources);

            Assert.AreEqual(2, overflow, "The change must be equal to the amount of resources that did not fit");
            Assert.AreEqual(5, converter.GetLoadingAreaCount(),
                "There must be a maximum of 5 resources in the loading area");
        }

        [Test]
        public void NoResourcesReturnedWhenProcessingIsEmpty()
        {
            var converter = CreateDefaultConverter();
            var resources = GetResources(3, ResourceType.Log);
            converter.AddResourcesToLoadingArea(resources);
    
            converter.Enable();
            converter.Disable();
            
            Assert.AreEqual(0, converter.GetUnloadingAreaCount(), "There should be no resources in the unloading area");
        }

        // Helpers
        private static Converter CreateDefaultConverter() =>
            CreateConverter(10, 10, 2, 1, 1.0f);

        private static Converter CreateConverter(int loadingAreaCapacity, int unloadingAreaCapacity,
            int loadingBatchSize, int unloadingBatchSize, float conversionTime)
        {
            return new Converter(loadingAreaCapacity, unloadingAreaCapacity, loadingBatchSize, unloadingBatchSize,
                conversionTime);
        }

        private static List<IResource> GetResources(int count, ResourceType resourceType)
        {
            var resources = new List<IResource>();

            for (var i = 0; i < count; i++)
            {
                var resource = new Resource(resourceType);
                resources.Add(resource);
            }

            return resources;
        }
    }
}