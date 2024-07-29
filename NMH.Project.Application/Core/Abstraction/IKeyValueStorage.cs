using NMH.Project.Application.DTOs;

namespace NMH.Project.Application.Core.Abstraction;

public interface IKeyValueStorageService
{
    void SetValue(int key, decimal value);
    decimal GetValue(int key);
    bool Remove(int key);
    bool TryGetValue(int key, out TimedValue value);
    DateTime GetTimestamp(int key);
}