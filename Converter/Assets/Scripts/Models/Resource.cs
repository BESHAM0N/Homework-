using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Converter
{
    public sealed class Resource : IResource
    {
        public ResourceType ResourceType { get; private set; }

        public Resource(ResourceType resourceType)
        {
            ResourceType = resourceType;
        }
    }
}