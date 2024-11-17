using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        private readonly Item[,] _grid;
        private Dictionary<Item, Vector2Int> _items;

        public int Width { get; }
        public int Height { get; }
        public int Count => _items.Count;

        public Inventory(in int width, in int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height cannot be negative or equal to 0");
            }

            Width = width;
            Height = height;
            _grid = new Item[width, height];
            _items = new Dictionary<Item, Vector2Int>();
        }

        public Inventory(in int width, in int height, params KeyValuePair<Item, Vector2Int>[] items) : this(width,
            height)
        {
            if (items == null) throw new ArgumentException("The list of items cannot be empty", nameof(items));
            AddItemsWithPosition(items);
        }

        public Inventory(in int width, in int height, params Item[] items) : this(width, height)
        {
            if (items == null) throw new ArgumentException("The list of items cannot be empty", nameof(items));
            AddItemsWithoutPosition(items);
        }

        public Inventory(in int width, in int height, in IEnumerable<KeyValuePair<Item, Vector2Int>> items) : this(
            width, height)
        {
            if (items == null) throw new ArgumentException("The list of items cannot be empty", nameof(items));
            AddItemsWithPosition(items);
        }

        public Inventory(in int width, in int height, in IEnumerable<Item> items) : this(width, height)
        {
            if (items == null) throw new ArgumentException("The list of items cannot be empty", nameof(items));
            AddItemsWithoutPosition(items);
        }

        private void AddItemsWithPosition(IEnumerable<KeyValuePair<Item, Vector2Int>> items)
        {
            foreach (var item in items)
            {
                if (item.Key == null)
                    throw new ArgumentException("Item cannot be null");

                if (!CanAddItem(item.Key, item.Value.x, item.Value.y))
                    throw new ArgumentException("Invalid item or position.");

                AddItem(item.Key, item.Value);
            }
        }

        private void AddItemsWithoutPosition(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                if (!FindFreePosition(item.Size, out var position))
                    throw new ArgumentException("Cannot place item in inventory");

                AddItem(item, position);
            }
        }

        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(in Item item, in Vector2Int position)
        {
            if (!IsValidItem(item) || Contains(item) || !IsPositionWithinBounds(position, item.Size))
                return false;

            return IsAreaFree(position, item.Size);
        }

        private bool CanAddItem(in Item item, in int posX, in int posY)
        {
            if (!IsValidItem(item) || Contains(item))
                return false;

            return IsPositionWithinBounds(new Vector2Int(posX, posY), item.Size) &&
                   IsAreaFree(new Vector2Int(posX, posY), item.Size);
        }

        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (item == null || Contains(item) || !CanAddItem(item, position))
                return false;

            PlaceItemInGrid(item, position);
            _items[item] = position;
            OnAdded?.Invoke(item, position);
            return true;
        }

        public bool AddItem(in Item item, in int posX, in int posY)
        {
            return AddItem(item, new Vector2Int(posX, posY));
        }

        private void PlaceItemInGrid(Item item, Vector2Int position)
        {
            _items[item] = position;
            for (var x = position.x; x < position.x + item.Size.x; x++)
            {
                for (var y = position.y; y < position.y + item.Size.y; y++)
                {
                    _grid[x, y] = item;
                }
            }
        }

        private bool IsValidItem(Item item)
        {
            if (item == null)
                return false;

            if (item.Size.x <= 0 || item.Size.y <= 0)
                throw new ArgumentException("Item size must be positive and greater than zero");

            return true;
        }

        private bool IsPositionWithinBounds(Vector2Int position, Vector2Int size)
        {
            return position.x >= 0 && position.y >= 0 &&
                   position.x + size.x <= Width && position.y + size.y <= Height;
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item)
        {
            if (item == null || Contains(item))
                return false;

            if (item.Size.x <= 0 || item.Size.y <= 0)
                throw new ArgumentException("Item size must be positive and greater than zero");

            return FindFreePosition(item.Size, out _);
        }

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item, bool triggerEvent = true)
        {
            if (item == null || Contains(item))
                return false;

            if (item.Size.x <= 0 || item.Size.y <= 0)
                throw new ArgumentException("Item size must be positive and greater than zero");

            if (!FindFreePosition(item.Size, out var position))
                return false;

            _items[item] = position;
            for (var x = position.x; x < position.x + item.Size.x; x++)
            {
                for (var y = position.y; y < position.y + item.Size.y; y++)
                {
                    _grid[x, y] = item;
                }
            }

            if (triggerEvent)
                OnAdded?.Invoke(item, position);

            return true;
        }

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
        {
            if (size.x <= 0 || size.y <= 0)
            {
                throw new ArgumentException("The size must be positive and greater than zero", nameof(size));
            }

            for (var y = 0; y <= Height - size.y; y++)
            {
                for (var x = 0; x <= Width - size.x; x++)
                {
                    var position = new Vector2Int(x, y);
                    if (IsAreaFree(position, size))
                    {
                        freePosition = position;
                        return true;
                    }
                }
            }

            freePosition = default;
            return false;
        }

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            return item != null && _items.ContainsKey(item);
        }

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        private bool IsOccupied(in Vector2Int position) => IsOccupied(position.x, position.y);

        public bool IsOccupied(in int x, in int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                throw new IndexOutOfRangeException("Position outside of inventory");

            return _grid[x, y] != null;
        }

        /// <summary>
        /// Checks if the a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position) => !IsOccupied(position);

        public bool IsFree(in int x, in int y)
        {
            return !IsOccupied(x, y);
        }

        private bool IsAreaFree(Vector2Int position, Vector2Int size)
        {
            for (var x = position.x; x < position.x + size.x; x++)
            {
                for (var y = position.y; y < position.y + size.y; y++)
                {
                    if (IsOccupied(x, y) && _grid[x, y] != null)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Removes a specified item if exists
        /// </summary>
        private bool RemoveItem(in Item item)
        {
            return RemoveItemFromGrid(item, out _);
        }

        public bool RemoveItem(in Item item, out Vector2Int position)
        {
            var removeItem = RemoveItemFromGrid(item, out position);
            if (removeItem)
                OnRemoved?.Invoke(item, position);

            return removeItem;
        }

        private bool RemoveItemFromGrid(in Item item, out Vector2Int position)
        {
            position = default;

            if (item == null || !_items.TryGetValue(item, out position))
                return false;

            var itemSize = item.Size;
            for (var x = position.x; x < position.x + itemSize.x; x++)
            {
                for (var y = position.y; y < position.y + itemSize.y; y++)
                {
                    _grid[x, y] = null;
                }
            }

            _items.Remove(item);
            return true;
        }

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(in Vector2Int position)
        {
            ValidatePositionInBounds(position);

            var item = _grid[position.x, position.y];
            return item ?? throw new NullReferenceException("No item was found at the specified position");
        }

        public Item GetItem(in int x, in int y)
        {
            ValidatePositionInBounds(x, y);

            var item = _grid[x, y];
            return item ?? throw new NullReferenceException("No item was found at the specified position");
        }

        public bool TryGetItem(in Vector2Int position, out Item item)
        {
            return TryGetItem(position.x, position.y, out item);
        }

        public bool TryGetItem(int x, int y, out Item item)
        {
            if (!IsPositionInBounds(x, y))
            {
                item = null;
                return false;
            }

            item = _grid[x, y];
            return item != null;
        }

        private void ValidatePositionInBounds(Vector2Int position)
        {
            ValidatePositionInBounds(position.x, position.y);
        }

        private void ValidatePositionInBounds(int x, int y)
        {
            if (!IsPositionInBounds(x, y))
                throw new IndexOutOfRangeException("Position outside of inventory");
        }

        private bool IsPositionInBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        /// <summary>
        /// Returns matrix positions of a specified item 
        /// </summary>
        public Vector2Int[] GetPositions(in Item item)
        {
            if (!TryGetPositions(item, out var positions))
                throw item == null
                    ? new NullReferenceException("Item cannot be empty")
                    : new KeyNotFoundException("Item not found in inventory");

            return positions;
        }

        public bool TryGetPositions(in Item item, out Vector2Int[] positions)
        {
            positions = null;

            if (item == null || !_items.TryGetValue(item, out var startPosition))
                return false;

            positions = new Vector2Int[item.CellSize];
            var itemSize = item.Size;
            var i = 0;

            for (var x = 0; x < itemSize.x; x++)
            {
                for (var y = 0; y < itemSize.y; y++)
                {
                    positions[i++] = new Vector2Int(startPosition.x + x, startPosition.y + y);
                }
            }

            return true;
        }

        /// <summary>
        /// Clears all inventory items
        /// </summary>
        public void Clear()
        {
            if (_items.Count > 0)
            {
                Array.Clear(_grid, 0, _grid.Length);
                _items.Clear();
                OnCleared?.Invoke();
            }
        }

        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name)
        {
            var count = 0;

            foreach (var item in _items.Keys)
            {
                if (item.Name == name)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Moves a specified item at target position if exists
        /// </summary>
        public bool MoveItem(in Item item, in Vector2Int position)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be empty");

            if (!Contains(item) || !RemoveItem(item))
                return false;

            if (!CanAddItem(item, position))
            {
                AddItem(item);
                return false;
            }

            if (!AddItem(item, false))
            {
                AddItem(item);
                return false;
            }

            OnMoved?.Invoke(item, position);
            return true;
        }

        /// <summary>
        /// Reorganizes a inventory space so that the free area is uniform
        /// </summary>
        public void ReorganizeSpace()
        {
            var sortedItems = new List<Item>(_items.Keys);
            sortedItems.Sort((a, b) => (b.CellSize).CompareTo(a.CellSize));

            Array.Clear(_grid, 0, _grid.Length);

            foreach (var item in sortedItems)
            {
                if (!FindFreePosition(item.Size, out var position))
                {
                    throw new ArgumentException("Error reorganizing space. Cannot add item.");
                }

               PlaceItemInGrid(item, position);
            }
        }

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix), "The matrix cannot be empty");

            if (matrix.GetLength(0) != Width || matrix.GetLength(1) != Height)
                throw new ArgumentException("The matrix size does not match the dimensions");

            Array.Copy(_grid, matrix, _grid.Length);
        }

        public IEnumerator<Item> GetEnumerator() => _items.Keys.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}