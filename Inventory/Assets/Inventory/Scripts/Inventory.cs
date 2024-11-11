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

        private readonly Item[,] _grid;
        private readonly List<Item> _items;

        public int Width { get; }
        public int Height { get; }
        public int Count => _items.Count;

        public Inventory(in int width, in int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("ширина и высота не могут быть отрицательными или равны 0");
            }

            Width = width;
            Height = height;
            _grid = new Item[width, height];
            _items = new List<Item>();
        }

        public Inventory(in int width, in int height, params KeyValuePair<Item, Vector2Int>[] items) : this(width,
            height)
        {
            if (items == null) throw new ArgumentException("список айтемов не может быть пустым", nameof(items));
            AddItemsWithPosition(items);
        }

        public Inventory(in int width, in int height, params Item[] items) : this(width, height)
        {
            if (items == null) throw new ArgumentException("список айтемов не может быть пустым", nameof(items));
            AddItemsWithoutPosition(items);
        }

        public Inventory(in int width, in int height, in IEnumerable<KeyValuePair<Item, Vector2Int>> items) : this(
            width, height)
        {
            if (items == null) throw new ArgumentException("список айтемов не может быть пустым", nameof(items));
            AddItemsWithPosition(items);
        }

        public Inventory(in int width, in int height, in IEnumerable<Item> items) : this(width, height)
        {
            if (items == null) throw new ArgumentException("список айтемов не может быть пустым", nameof(items));
            AddItemsWithoutPosition(items);
        }

        private void AddItemsWithPosition(IEnumerable<KeyValuePair<Item, Vector2Int>> items)
        {
            foreach (var item in items)
            {
                if (item.Key == null)
                {
                    throw new ArgumentException("айтем не может быть пустым");
                }

                if (!CanAddItem(item.Key, item.Value.x, item.Value.y))
                {
                    throw new ArgumentException("недопустимый айтем или позиция.");
                }

                AddItem(item.Key, item.Value);
            }
        }

        private void AddItemsWithoutPosition(IEnumerable<Item> items)
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

            // Проверка границ инвентаря
            if (position.x < 0 || position.y < 0 || position.x + item.Size.x > Width || position.y + item.Size.y > Height)
            {
                Debug.Log("Координаты за пределами инвентаря.");
                return false;
            }

            // Проверка каждой ячейки, чтобы убедиться, что позиции свободны
            for (int x = position.x; x < position.x + item.Size.x; x++)
            {
                for (int y = position.y; y < position.y + item.Size.y; y++)
                {
                    if (IsOccupied(x, y) && _grid[x, y] != item)
                    {
                        return false;
                    }
                }
            }

            Debug.Log("Все проверенные ячейки свободны, элемент можно добавить.");
            return true;
        }
        
        public bool CanAddItem(in Item item, in int posX, in int posY)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Элемент не может быть пустым");
            }
        
            if (item.Size.x <= 0 || item.Size.y <= 0)
            {
                throw new ArgumentException("Размер айтема должен быть положительным и больше нуля");
            }
           
            if (posX < 0 || posY < 0 || posX + item.Size.x > Width || posY + item.Size.y > Height)
            {
                Debug.Log("Координаты за пределами инвентаря.");
                return false;
            }
            
            if (Contains(item))
            {
                return false;
            }
          
            for (int x = posX; x < posX + item.Size.x; x++)
            {
                for (int y = posY; y < posY + item.Size.y; y++)
                {
                    if (IsOccupied(x, y))
                    {
                        if (IsOccupied(x, y) && _grid[x, y] != item)
                        {
                            return false;
                        }
                    }
                }
            }
            
            Debug.Log("Все проверенные ячейки свободны, элемент можно добавить.");
            return true;
        }
        
        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (item == null || Contains(item) || !CanAddItem(item, position))
            {
                return false;
            }
           
            _items.Add(item);
            for (int x = position.x; x < position.x + item.Size.x; x++)
            {
                for (int y = position.y; y < position.y + item.Size.y; y++)
                {
                    _grid[x, y] = item;
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
        
            _items.Add(item);
            for (int x = posX; x < posX + item.Size.x; x++)
            {
                for (int y = posY; y < posY + item.Size.y; y++)
                {
                    _grid[x, y] = item;
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
            
            if (Contains(item))
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

            // Добавление элемента в список и установка его позиций в grid
            _items.Add(item);
            for (int x = position.x; x < position.x + item.Size.x; x++)
            {
                for (int y = position.y; y < position.y + item.Size.y; y++)
                {
                    _grid[x, y] = item;
                }
            }

            // Вызов события после добавления
            OnAdded?.Invoke(item, position);
            return true;
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
                    // Создаем объект Vector2Int и вызываем перегрузку CanAddItem, принимающую Vector2Int
                    var position = new Vector2Int(x, y);
                    if (CanAddItem(item, position))
                    {
                        freePosition = position;
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
                return _items.Contains(item);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ошибка при проверке наличия айтема в инвентаре", ex);
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

            return _grid[x, y] != null;
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
                throw new ArgumentException("ошибка при проверке, свободна ли позиция", ex);
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
                throw new InvalidOperationException("ошибка при удалении айтема из инвентаря", ex);
            }
        }

        private bool RemoveItemInternal(in Item item, out Vector2Int position)
        {
            position = default;

            if (item == null || !_items.Contains(item))
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
                        if (_grid[x, y] == item)
                        {
                            _grid[x, y] = null;
                            if (!found)
                            {
                                position = new Vector2Int(x, y);
                                found = true;
                            }
                        }
                    }
                }

                _items.Remove(item);
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

                return _grid[position.x, position.y] ??
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

            return _grid[x, y] ?? throw new NullReferenceException("В указанной позиции не найден ни один айтем.");
        }

        public bool TryGetItem(in Vector2Int position, out Item item)
        {
            return TryGetItem(position.x, position.y, out item);
        }

        public bool TryGetItem(int x, int y, out Item item)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                item = null;
                return false;
            }

            item = _grid[x, y];
            return item != null;
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

            if (!_items.Contains(item))
            {
                throw new KeyNotFoundException("айтем не найден в инвенторе");
            }

            var positions = new List<Vector2Int>();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (_grid[x, y] == item)
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
                if (_items.Count > 0)
                {
                    Array.Clear(_grid, 0, _grid.Length);
                    _items.Clear();
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
                return _items.Count(i => i.Name == name);
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

            // Проверка, находится ли элемент в инвентаре
            if (!Contains(item))
            {
                Debug.Log("айтем не найден в инвенторе");
                return false;
            }

            // Попытка удалить элемент перед перемещением
            if (!RemoveItem(item, out _))
            {
                Debug.LogError("Не удалось удалить айтем перед перемещением");
                return false;
            }

            // Проверка возможности добавления элемента на новую позицию
            if (!CanAddItem(item, position))
            {
                // Восстановление оригинальных позиций при невозможности перемещения
                AddItem(item);
                Debug.Log("Перемещение не удалось, айтем возвращен на исходные позиции");
                return false;
            }
            //
            // // Добавление элемента на новую позицию
            // if (!AddItem(item, position))
            // {
            //     // Восстановление оригинальных позиций при неудаче добавления
            //     AddItem(item);
            //     Debug.LogError("Не удалось добавить айтем на новую позицию, айтем возвращен на исходные позиции");
            //     return false;
            // }

            // Вызов события успешного перемещения
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
                    _items.OrderByDescending(item => item.Size.x * item.Size.y)
                        .ToList();
                Clear();

                foreach (var item in sortedItems)
                {
                    if (!FindFreePosition(item, out var position))
                    {
                        throw new InvalidOperationException(
                            "ошибка при реорганизации пространства. Невозможно добавить товар");
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
                    matrix[x, y] = _grid[x, y];
                }
            }
        }

        public IEnumerator<Item> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}