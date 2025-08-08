using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool<T> : MonoBehaviour
    where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;
    [SerializeField, Min(0)] private int _initialCount;

    private Stack<T> _pool;
    private HashSet<T> _gettedObjects;

    public event Action<T> Getted;

    public event Action<T> Released;

    private void Awake()
    {
        _pool = new(_initialCount);
        _gettedObjects = new();

        while (_pool.Count < _initialCount)
        {
            T obj = Create();
            obj.gameObject.SetActive(false);

            _pool.Push(obj);
        }
    }

    public T Get()
    {
        T obj = _pool.Count == 0 ? Create() : _pool.Pop();
        Getted?.Invoke(obj);
        _gettedObjects.Add(obj);
        obj.gameObject.SetActive(true);

        return obj;
    }

    public void Release(T obj)
    {
        _pool.Push(obj);
        Released?.Invoke(obj);
        _gettedObjects.Remove(obj);
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        foreach (T obj in _gettedObjects.ToList())
            Release(obj);

        _pool.Clear();
    }

    private T Create()
    {
        return Instantiate(_prefab, _container);
    }
}