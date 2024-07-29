namespace NMH.Project.Infrastructure.Services;

using NMH.Project.Application.Core.Abstraction;
using NMH.Project.Application.DTOs;
using System.Collections.Concurrent;

public class KeyValueStorageService : IKeyValueStorageService
{
    private readonly ConcurrentDictionary<int, TimedValue> _storage = new ConcurrentDictionary<int, TimedValue>();
    public decimal GetValue(int key)
    {
        return _storage[key].Value;
    }

    public DateTime GetTimestamp(int key)
    {
        return _storage[key].Timestamp;
    }

    public bool Remove(int key)
    {
        return _storage.TryRemove(key, out _);
    }

    public void SetValue(int key, decimal value)
    {
        _storage[key] = new TimedValue(Value: value, Timestamp: DateTime.UtcNow);
    }

    public bool TryGetValue(int key, out TimedValue value)
    {
        if (_storage.TryGetValue(key, out var obj))
        {
            value = obj;
            return true;
        }
        value = default;
        return false;
    }
}