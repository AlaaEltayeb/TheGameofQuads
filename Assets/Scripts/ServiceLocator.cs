using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static readonly Dictionary<object, object> _container = new();

    public static void Add<T>(T value)
    {
        _container.Add(typeof(T), value);
    }

    public static T Get<T>()
    {
        try
        {
            return (T)_container[typeof(T)];
        }
        catch (Exception ex)
        {
            throw new NotImplementedException("Service not available.");
        }
    }

    public static void Remove<T>(T value)
    {
        _container.Remove(typeof(T));
    }
}
