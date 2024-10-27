using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private int _initialSize = 10;
    private readonly Queue<T> _pool = new();

    private void Awake()
    {
        GeneratePool(_initialSize);
    }

    private void GeneratePool(int poolSize)
    {
        for (var i = 0; i < poolSize; i++)
        {
            _pool.Enqueue(CreateNewObject());
        }
    }

    public T GetObject()
    {
        return _pool.Count > 0 ? _pool.Dequeue() : CreateNewObject();
    }

    private T CreateNewObject()
    {
        var newObject = Instantiate(_prefab, _container);
        newObject.gameObject.SetActive(true);
        return newObject;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.SetParent(_container);
        _pool.Enqueue(obj);
    }
}