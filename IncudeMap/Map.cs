using System;
using System.Collections.Generic;
using System.Text;

namespace IncudeMap
{
    public static class Map
    {
        public static IMap<T> Create<T>()
        {
            return new Map<T>();
        }
    }
    public interface IMap<out T>
    {
        Stack<string> propMap { get; set; }
    }
    public class Map<T> : IMap<T>
    {
        public Stack<string> propMap { get; set; } = new Stack<string>();
    }

    public interface IMap<out T, out P> : IMap<T>
    {
    }
    public class Map<T, P> : Map<T>, IMap<T, P>
    {
    }
}
