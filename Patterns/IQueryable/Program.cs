using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IQueryable
{
    /// <summary>
    /// IQueryable is IEnumerable and much more. From practical perspective, IQueryable represents a logical query defined by an Expression Tree with a
    /// Provider that can convert and execute this logical query against a specific data source.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var a = ThreeFourths(4);
        }

        public static decimal ThreeFourths(int x) => (decimal)3 * x / 4;
    }


    public class Command
    {
        private int Execute() => 42;
    }

    public static class ReflectionDelegate
    {
        private static MethodInfo ExecuteMethod { get; } = typeof(Command)
            .GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);

        private static Func<Command, int> Impl { get; } =
            (Func<Command, int>) Delegate.CreateDelegate(typeof(Func<Command, int>), ExecuteMethod);

        public static int CallExecute(Command command) => Impl(command);
    }
}
