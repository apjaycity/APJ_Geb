using APJ_GeB.Core;
using APJ_GeB.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APJ_GeB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SF<int, int> sF = new SF<int, int>(x => x + 1);
            for (int i = 1; i < 100;)
            {
                i = sF.EX(i);
                sF = new SF<int, int>(x => x + 1 + i);
                Console.WriteLine(i);
            }
            
            Console.ReadKey();
        }
    }
}
