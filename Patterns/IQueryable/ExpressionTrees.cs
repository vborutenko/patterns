using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IQueryable
{
    public class ExpressionTrees
    {
        /// <summary>
        /// (х) => Console.WriteLine(х + 5)
        /// </summary>
        public static void Test()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(double));
            ConstantExpression constant = Expression.Constant(5d, typeof(double));
            BinaryExpression add = Expression.Add(parameter, constant);
            MethodInfo writeLine = typeof(Console).GetMethod(nameof(Console.WriteLine), new[] { typeof(double) });
            MethodCallExpression methodCall = Expression.Call(null, writeLine, add);
            Expression<Action<double>> expressionlambda = Expression.Lambda<Action<double>>(methodCall, parameter);
            Action<double> delegateLambda = expressionlambda.Compile();
            delegateLambda(123321);

            Expression<Action<double>> write = х => Console.WriteLine(х + 5);
        }

        
    }
}
