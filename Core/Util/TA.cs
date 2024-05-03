using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAPJ_GeB.Core.Util
{
    public class TA<T, U>//type stored object array
    {
        public List<object> TL { get; set; }
        public List<Type> UL { get; set; }
        public TA()
        {
            TL = new List<object>();
            UL = new List<Type>();
        }
        public void Add(T obj)
        {
            TL.Add(obj);
            UL.Add(obj.GetType());
        }
        
        public bool Contains(T obj)
        {
            return TL.Contains(obj);
        }

        public bool ContainsType(Type type)
        {
            return UL.Contains(type);
        }

        public void remove(T obj)
        {
            int index = TL.IndexOf(obj);
            TL.RemoveAt(index);
            UL.RemoveAt(index);
        }   

        public bool[] TypeMatchList (List<Type> t)
        {
            Stack<bool> s = new Stack<bool>();
            bool mismatch = (t.Count != TL.Count) ? true:false;
            for (int i = 0; i < t.Count-1 && !mismatch; i++){s.Push(UL[i] == t[i]?true:false);}   
            return s.ToArray();
        }

        public U[] ApplyFunctionToAll(SF<T,U> sF)
        {
            Stack<U> s = new Stack<U>();
            foreach (T obj in TL ){sF.EX(obj);}
            return s.ToArray();
        }

        public U ApplyToIndex(SF<T, U> sF, int index)
        {
            return sF.EX((T)TL[index]);
        }
    }

}
