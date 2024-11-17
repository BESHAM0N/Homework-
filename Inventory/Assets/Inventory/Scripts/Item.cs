using UnityEngine;

namespace Inventories
{
    ///Don't modify 
    public sealed class Item
    {
        private static int ID_GEN;

        public string Name => name;
        public Vector2Int Size => size;
        public int CellSize=> Size.x * Size.y;

        private readonly Vector2Int size;
        private readonly string name;
        private readonly int id;

        public Item(string name, Vector2Int size) : this()
        {
            this.name = name;
            this.size = size;
        }

        public Item(string name, int width, int height) : this()
        {
            this.name = name;
            size = new Vector2Int(width, height);
        }

        public Item(Vector2Int size) : this()
        {
            name = string.Empty;
            this.size = size;
        }

        public Item(int width, int height) : this()
        {
            name = string.Empty;
            size = new Vector2Int(width, height);
        }

        private Item()
        {
            id = ID_GEN++;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Item) obj);
        }

        public bool Equals(Item other)
        {
            return id == other.id;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}