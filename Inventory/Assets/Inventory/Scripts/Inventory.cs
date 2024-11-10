using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        private readonly Item[,] grid;
        private readonly List<Item> items;

        public int Width { get; }
        public int Height { get; }
        public int Count => items.Count;

        public Inventory(in int width, in int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Ширина и высота не могут быть отрицательными или равны 0");
            }

            Width = width;
            Height = height;
            grid = new Item[width, height];
            items = new List<Item>();
        }

        public Inventory(in int width, in int height, params KeyValuePair<Item, Vector2Int>[] items) : this(width,
            height)
        {
            if (items == null)
            {
                throw new ArgumentException("список айтемов не может быть пустым", nameof(items));
            }

            foreach (var item in items)
            {
                if (item.Key == null)
                {
                    throw new ArgumentException("айтем не может быть пустым");
                }

                if (!CanAddItem(item.Key, item.Value))
                {
                    throw new ArgumentException("недопустимый айтем или позиция.");
                }

                AddItem(item.Key, item.Value);
            }
        }

        public Inventory(in int width, in int height, params Item[] items) : this(width, height)
        {
            try
            {
                foreach (var item in items)
                {
                    if (!FindFreePosition(item, out var position))
                    {
                        throw new ArgumentException("невозможно поместить айтем в инвентарь");
                    }

                    AddItem(item, position);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ошибка при инициализации инвентаря с массивом айтемов");
            }
        }

        public Inventory(in int width, in int height, in IEnumerable<KeyValuePair<Item, Vector2Int>> items) : this(
            width, height)
        {
            try
            {
                foreach (var pair in items)
                {
                    AddItem(pair.Key, pair.Value);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ошибка при инициализации инвентаря с парами айтемов.");
            }
        }

        public Inventory(in int width, in int height, in IEnumerable<Item> items) : this(width, height)
        {
            try
            {
                foreach (var item in items)
                {
                    if (!FindFreePosition(item, out var position))
                    {
                        throw new ArgumentException("невозможно поместить айтем в инвентарь");
                    }

                    AddItem(item, position);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ошибка при инициализации инвентаря при сборе айтемов");
            }
        }

        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(in Item item, in Vector2Int position)
        {
            if (item == null)
            {
                return false;
            }
          
            if (item.Size.x <= 0 || item.Size.y <= 0)
            {
                throw new ArgumentException("размер айтема должен быть положительным и больше нуля");
            }

            try
            {
                return CanAddItem(item, position.x, position.y);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ошибка при проверке возможности добавления айтема в указанную позицию",
                    ex);
            }
        }

        public bool CanAddItem(in Item item, in int posX, in int posY)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "элемент не может быть пустым");
            } 
           
            if (item.Size.x <= 0 || item.Size.y <= 0)
            {
                throw new ArgumentException("размер айтема должен быть положительным и больше нуля");
            }

            if (Contains(item))
            {
                return false;
            }
            
            if (posX < 0 || posY < 0 || posX + item.Size.x > Width || posY + item.Size.y > Height)
            {
                return false;
            }

            for (int x = posX; x < posX + item.Size.x; x++)
            {
                for (int y = posY; y < posY + item.Size.y; y++)
                {
                    if (IsOccupied(x, y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (item == null)
            {
                return false;
            }
            
            if (item.Size.x <= 0 || item.Size.y <= 0)
            {
                throw new ArgumentException("размер айтема должен быть положительным и больше нуля");
            }

            if (Contains(item))
            {
                return false;
            }

            if (!CanAddItem(item, position))
            {
                return false;
            }

            items.Add(item);
            for (int x = position.x; x < position.x + item.Size.x; x++)
            {
                for (int y = position.y; y < position.y + item.Size.y; y++)
                {
                    grid[x, y] = item;
                }
            }

            OnAdded?.Invoke(item, position);
            return true;
        }

        public bool AddItem(in Item item, in int posX, in int posY)
        {
            if (item == null)
            {
                return false;
            }

            if (Contains(item))
            {
                return false;
            }

            if (posX < 0 || posY < 0 || posX + item.Size.x > Width || posY + item.Size.y > Height)
            {
                return false;
            }

            for (int x = posX; x < posX + item.Size.x; x++)
            {
                for (int y = posY; y < posY + item.Size.y; y++)
                {
                    if (IsOccupied(x, y))
                    {
                        return false;
                    }
                }
            }

            items.Add(item);
            for (int x = posX; x < posX + item.Size.x; x++)
            {
                for (int y = posY; y < posY + item.Size.y; y++)
                {
                    grid[x, y] = item;
                }
            }

            OnAdded?.Invoke(item, new Vector2Int(posX, posY));
            return true;
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item)
        {
            if (item == null)
            {
                return false;
            }

            if (item.Size.x <= 0 || item.Size.y <= 0)
            {
                throw new ArgumentException("размер айтема должен быть положительным и больше нуля");
            }

            return FindFreePosition(item, out _);
        }

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item)
        {
            if (item == null)
            {
                return false;
            }
           
            if (item.Size.x <= 0 || item.Size.y <= 0)
            {
                throw new ArgumentException("размер айтема должен быть положительным и больше нуля");
            }

            if (!FindFreePosition(item, out var position))
            {
                return false;
            }

            return AddItem(item, position);
        }

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Item item, out Vector2Int freePosition)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item),
                    "ошибка при проверке возможности добавления айтема в указанную позицию");
            }
           
            if (item.Size.x <= 0 || item.Size.y <= 0)
            {
                throw new ArgumentException("размер айтема должен быть положительным и больше нуля");
            }
           
            for (int y = 0; y <= Height - item.Size.y; y++)
            {
                for (int x = 0; x <= Width - item.Size.x; x++)
                {
                    if (CanAddItem(item, x, y))
                    {
                        freePosition = new Vector2Int(x, y);
                        return true;
                    }
                }
            }

            freePosition = default;
            return false;
        }

        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition) =>
            FindFreePosition(new Item(size), out freePosition);

        public bool FindFreePosition(in int sizeX, int sizeY, out Vector2Int freePosition) =>
            FindFreePosition(new Vector2Int(sizeX, sizeY), out freePosition);

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            if (item == null)
            {
                return false;
            }
            
            try
            {
                return items.Contains(item);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ошибка при проверке наличия айтема в инвентаре");
            }
        }

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in Vector2Int position) => IsOccupied(position.x, position.y);

        public bool IsOccupied(in int x, in int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                throw new IndexOutOfRangeException("позиция за пределами инвентаря");
            }

            return grid[x, y] != null;
        }

        /// <summary>
        /// Checks if the a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position) => !IsOccupied(position);

        public bool IsFree(in int x, in int y)
        {
            try
            {
                return !IsOccupied(x, y);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ошибка при проверке, свободна ли позиция");
            }
        }

        /// <summary>
        /// Removes a specified item if exists
        /// </summary>
        public bool RemoveItem(in Item item)
        {
            return RemoveItemInternal(item, out _);
        }

        public bool RemoveItem(in Item item, out Vector2Int position)
        {
            try
            {
                return RemoveItemInternal(item, out position);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ошибка при удалении айтема из инвентаря");
            }
        }

        private bool RemoveItemInternal(in Item item, out Vector2Int position)
        {
            position = default;

            if (item == null || !items.Contains(item))
            {
                return false;
            }

            try
            {
                bool found = false;
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if (grid[x, y] == item)
                        {
                            grid[x, y] = null;
                            if (!found)
                            {
                                position = new Vector2Int(x, y);
                                found = true;
                            }
                        }
                    }
                }

                items.Remove(item);
                OnRemoved?.Invoke(item, position);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ошибка в процессе удаления айтема из инвентаря", ex);
            }
        }

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(in Vector2Int position)
        {
            try
            {
                if (position.x < 0 || position.y < 0 || position.x >= Width || position.y >= Height)
                {
                    throw new IndexOutOfRangeException("позиция за пределами инвентаря");
                }

                return grid[position.x, position.y] ??
                       throw new NullReferenceException("В указанной позиции не найден ни один айтем.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ошибка при получении айтема в указанной позиции", ex);
            }
        }

        public Item GetItem(in int x, in int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                throw new IndexOutOfRangeException("позиция за пределами инвентаря");
            }
            
            return grid[x, y] ?? throw new NullReferenceException("В указанной позиции не найден ни один айтем.");
        }

        public bool TryGetItem(in Vector2Int position, out Item item)
        {
            try
            {
                item = GetItem(position);
                return true;
            }
            catch
            {
                item = null;
                return false;
            }
        }

        public bool TryGetItem(in int x, in int y, out Item item)
        {
            try
            {
                item = GetItem(x, y);
                return true;
            }
            catch
            {
                item = null;
                return false;
            }
        }

        /// <summary>
        /// Returns matrix positions of a specified item 
        /// </summary>
        public Vector2Int[] GetPositions(in Item item)
        {
            if (item == null)
            {
                throw new NullReferenceException("айтем не может быть пустым");
            }

            if (!items.Contains(item))
            {
                throw new KeyNotFoundException("айтем не найден в инвенторе");
            }

            var positions = new List<Vector2Int>();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (grid[x, y] == item)
                    {
                        positions.Add(new Vector2Int(x, y));
                    }
                }
            }

            return positions.ToArray();
        }

        public bool TryGetPositions(in Item item, out Vector2Int[] positions)
        {
            try
            {
                if (item == null)
                {
                    throw new NullReferenceException("айтем не может быть пустым");
                }

                positions = GetPositions(item);
                return true;
            }
            catch (NullReferenceException)
            {
                positions = null;
                return false;
            }
            catch (KeyNotFoundException)
            {
                positions = null;
                return false;
            }
        }

        /// <summary>
        /// Clears all inventory items
        /// </summary>
        public void Clear()
        {
            try
            {
                if (items.Count > 0)
                {
                    Array.Clear(grid, 0, grid.Length);
                    items.Clear();
                    OnCleared?.Invoke();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ошибка при очистке инвентаря", ex);
            }
        }

        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name)
        {
            try
            {
                return items.Count(i => i.Name == name);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ошибка при подсчете айтемов с указанным именем", ex);
            }
        }

        /// <summary>
        /// Moves a specified item at target position if exists
        /// </summary>
        public bool MoveItem(in Item item, in Vector2Int position)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "айтем не может быть пустым");
            }

            if (!Contains(item))
            {
                Debug.Log("айтем не найден в инвенторе");
                return false;
            }
            
            Vector2Int[] originalPositions = GetPositions(item);
            RemoveItem(item, out _);
          
            bool isSamePosition = false;
            foreach (var pos in originalPositions)
            {
                if (pos == position)
                {
                    isSamePosition = true;
                    break;
                }
            }

            if (!CanAddItem(item, position) && !isSamePosition)
            {
                foreach (var pos in originalPositions)
                {
                    grid[pos.x, pos.y] = item;
                }
                items.Add(item);
                return false;
            }
           
            AddItem(item, position);
            OnMoved?.Invoke(item, position);
            return true;
        }

        /// <summary>
        /// Reorganizes a inventory space so that the free area is uniform
        /// </summary>
        public void ReorganizeSpace()
        {
            try
            {
                var sortedItems =
                    items.OrderByDescending(item => item.Size.x * item.Size.y)
                        .ToList();
                Clear();

                foreach (var item in sortedItems)
                {
                    if (!FindFreePosition(item, out var position))
                    {
                        throw new InvalidOperationException("ошибка при реорганизации пространства. Невозможно добавить товар");
                    }

                    AddItem(item, position);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ошибка при реорганизации инвентарного пространства", ex);
            }
        }

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "матрица не может быть пустой");
            }

            if (matrix.GetLength(0) != Width || matrix.GetLength(1) != Height)
            {
                throw new ArgumentException("Размер матрицы не соответствует размерам");
            }

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    matrix[x, y] = grid[x, y];
                }
            }
        }

        public IEnumerator<Item> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}