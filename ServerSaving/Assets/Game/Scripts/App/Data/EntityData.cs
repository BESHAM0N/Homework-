using System;
using System.Collections.Generic;
using SampleGame.Common;

namespace Modules.Entities
{
    [Serializable]
    public class EntityData
    {
        public int Id;
        public string Name;
        public SerializedVector3 Position;
        public SerializedVector3 Rotation;
        public Dictionary<string, object> Components = new();
    }
}