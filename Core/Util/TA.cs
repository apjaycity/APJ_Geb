using APJ_GeB.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APJ_GeB.Core.Util
{
    /// <summary>
    /// Represents a type-stored object array.
    /// </summary>
    /// <typeparam name="T">The type of objects stored in the array.</typeparam>
    /// <typeparam name="U">The type of objects returned by the functions.</typeparam>
    public class TA<T, U>
    {
        /// <summary>
        /// Gets or sets the list of objects stored in the array.
        /// </summary>
        public List<object> TL { get; set; }

        /// <summary>
        /// Gets or sets the list of types of objects stored in the array.
        /// </summary>
        public List<Type> UL { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TA{T, U}"/> class.
        /// </summary>
        public TA()
        {
            TL = new List<object>();
            UL = new List<Type>();
        }

        /// <summary>
        /// Adds an object to the array.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        public void Add(T obj)
        {
            TL.Add(obj);
            UL.Add(obj.GetType());
        }

        /// <summary>
        /// Determines whether the array contains a specific object.
        /// </summary>
        /// <param name="obj">The object to locate in the array.</param>
        /// <returns><c>true</c> if the object is found in the array; otherwise, <c>false</c>.</returns>
        public bool Contains(T obj)
        {
            return TL.Contains(obj);
        }

        /// <summary>
        /// Determines whether the array contains a specific type.
        /// </summary>
        /// <param name="type">The type to locate in the array.</param>
        /// <returns><c>true</c> if the type is found in the array; otherwise, <c>false</c>.</returns>
        public bool ContainsType(Type type)
        {
            return UL.Contains(type);
        }

        /// <summary>
        /// Removes an object from the array.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        public void Remove(T obj)
        {
            int index = TL.IndexOf(obj);
            TL.RemoveAt(index);
            UL.RemoveAt(index);
        }

        /// <summary>
        /// Checks if the types in the array match the given list of types.
        /// </summary>
        /// <param name="t">The list of types to compare with.</param>
        /// <returns>An array of booleans indicating whether the types match or not.</returns>
        public bool[] TypeMatchList(List<Type> t)
        {
            Stack<bool> s = new Stack<bool>();
            bool mismatch = (t.Count != TL.Count) ? true : false;
            for (int i = 0; i < t.Count - 1 && !mismatch; i++)
            {
                s.Push(UL[i] == t[i] ? true : false);
            }
            return s.ToArray();
        }

        /// <summary>
        /// Applies a function to all objects in the array and returns the results.
        /// </summary>
        /// <param name="sF">The function to apply.</param>
        /// <returns>An array of objects returned by the function.</returns>
        public U[] ApplyFunctionToAll(SF<T, U> sF)
        {
            Stack<U> s = new Stack<U>();
            foreach (T obj in TL)
            {
                sF.EX(obj);
            }
            return s.ToArray();
        }

        /// <summary>
        /// Applies a function to the object at the specified index in the array and returns the result.
        /// </summary>
        /// <param name="sF">The function to apply.</param>
        /// <param name="index">The index of the object in the array.</param>
        /// <returns>The object returned by the function.</returns>
        public U ApplyToIndex(SF<T, U> sF, int index)
        {
            return sF.EX((T)TL[index]);
        }
    }
}
       