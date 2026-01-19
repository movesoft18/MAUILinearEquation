using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUILinearEquation.Classes
{
    internal class LinearEquationSolver
    {
        public static (double, int) Solve(double a, double b)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    return (0.0, 2);
                }
                return (0.0, 0);
            }
            return (-b / a, 1);
        }
    }
}
