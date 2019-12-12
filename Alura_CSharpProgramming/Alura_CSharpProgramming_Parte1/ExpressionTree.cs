using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Alura_CSharpProgramming_Parte1
{
    public static class ExpressionTree
    {
        public static void Run()
        {             
            Expression<Func<int, int, int>> func = (int a, int b) => a + b;
            int result_1 = func.Compile()(3, 2);
            Console.WriteLine(result_1);

            ParameterExpression paramA = Expression.Parameter(typeof(int), "a");
            ParameterExpression paramB = Expression.Parameter(typeof(int), "a");
            ParameterExpression paramC = Expression.Parameter(typeof(int), "a");

            BinaryExpression sum = Expression.Add(paramA, paramB);

            Expression<Func<int, int, int>> lambda = Expression.Lambda<Func<int, int, int>>(sum, new ParameterExpression[] { paramA, paramB });

            int result_2 = lambda.Compile()(3, 2);
            Console.WriteLine(result_2);



        }
    }
}
