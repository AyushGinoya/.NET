using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    internal class ExpressionEvaluator
    {
        static Dictionary<string, Func<double>> functions = new Dictionary< string, Func<double>>()
        {
            { "ET", ET },
            { "IP", IP },
            { "IT", IT },
            { "EP", EP }
        };

        public static double EP()
        {
            return 15.0;
        }

        public static double ET()
        {
            return 5.0;
        }

        public static double IP()
        {
            return 3.0;
        }

        public static double IT()
        {
            return 2.0;
        }

        public static void Main()
        {
            string input = "2*IP+ET*IT"; 

            string modifiedExpression = ReplaceFunctionsWithValues(input);

            double result = EvaluateExpression(modifiedExpression);

            Console.WriteLine("Final result: " + result);
        }
        public static string ReplaceFunctionsWithValues(string input)
        {
            foreach (var function in functions)
            {
                string functionName = function.Key;
                double functionValue = function.Value();
                input = input.Replace(functionName, functionValue.ToString());
            }
            return input;
        }
        public static double EvaluateExpression(string expression)
        {
            var dataTable = new DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
        }

    }
}
