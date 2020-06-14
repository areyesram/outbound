using System;
using System.Collections.Generic;

namespace areyesram
{
    internal class Program
    {
        private const int N = 50;
        private const int M = 50;
        private const int Z = 50;
        private const int X0 = 25;
        private const int Y0 = 25;

        private static void Main()
        {
            var start = new Cell(X0, Y0);
            var result = Solve(start, Z);
            Console.WriteLine("{0:N0}", result);
        }

        private const int MAX_VALUE = 1000000007;
        private static readonly Cell[] _moves = { new Cell(0, 1), new Cell(1, 0), new Cell(0, -1), new Cell(-1, 0) };
        private static readonly Dictionary<string, int> _cache = new Dictionary<string, int>();

        private static int Solve(Cell current, int steps)
        {
            if (steps == 0) return 0;
            if (current.X < 0 || current.X >= N || current.Y < 0 || current.Y >= M)
                return 1;
            var key = $"{current.X} {current.Y} {steps}";
            if (_cache.ContainsKey(key))
                return _cache[key];
            var res = 0;
            foreach (var move in _moves)
            {
                res += Solve(current + move, steps - 1);
                if (res > MAX_VALUE)
                    res -= MAX_VALUE;
            }
            _cache[key] = res;
            return res;
        }
    }
}
