﻿namespace ApiaryManagementSystem.Domain.Common;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public abstract class Enumeration(int value, string name) : IComparable
{
    private static readonly ConcurrentDictionary<Type, IEnumerable<object>> EnumCache = new();

    public int Value { get; } = value;

    public string Name { get; } = name;

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        var type = typeof(T);

        var values = EnumCache.GetOrAdd(type, _ => type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null)!));

        return values.Cast<T>();
    }

    public static T FromValue<T>(int value) where T : Enumeration
        => Parse<T, int>(value, "value", item => item.Value == value);

    public static T FromName<T>(string name) where T : Enumeration
        => Parse<T, string>(name, "name", item => item.Name == name);

    public static string NameFromValue<T>(int value) where T : Enumeration
        => FromValue<T>(value).Name;

    public static bool HasValue<T>(int value) where T : Enumeration
    {
        try
        {
            FromValue<T>(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static T Parse<T, TValue>(TValue value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        return matchingItem is null
            ? throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}")
            : matchingItem;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Value.Equals(otherValue.Value);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => (GetType().ToString() + Value).GetHashCode();

    public int CompareTo(object? other) => Value.CompareTo(((Enumeration)other!).Value);
}
