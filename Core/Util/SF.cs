using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APJ_GeB.Core
{
    /// <summary>
    /// Represents a stored function.
    /// </summary>
    /// <typeparam name="T">The type of the input argument.</typeparam>
    /// <typeparam name="U">The type of the output result.</typeparam>
    public class SF<T, U>//Stored Function 
    {
        private Func<T, U> _f;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF{T, U}"/> class.
        /// </summary>
        /// <param name="func">The function to be stored.</param>
        public SF(Func<T, U> func)
        {
            _f = func;
        }

        /// <summary>
        /// Executes the stored function with the specified argument.
        /// </summary>
        /// <param name="arg">The input argument.</param>
        /// <returns>The result of the stored function.</returns>
        public U EX(T arg)
        {
            return _f(arg);
        }
    }
}
