using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APJ_GeB.Core.Util;    

namespace APJ_GeB.Core.Playground
{
    public class UpdateLoop
    {
        private int _stepCount = 0;
        private TA<SF<object[], bool>, int> _updateFunctions;
        private TA<object[],bool> _updateObjectPool;
        private bool _isRunning = true;

        private UpdateLoop(object[] b)
        {
            _stepCount = b[2] != null && b[2].GetType() == new int().GetType() ? (int)b[2] : 0; 
            _updateFunctions = (TA<SF<object[], bool>, int>)b[0];
            _isRunning = (bool)b[1];
        }
        static Func<object[],UpdateLoop> BuildCopy = b => new UpdateLoop(b);
        public static Func<object[], UpdateLoop> getBuildCopy() { return BuildCopy; }

        private void AddUpdateFunction(SF<object[], bool> updateFunction)
        {
            _updateFunctions.Add(updateFunction);
        }
        static Func<object[],UpdateLoop> addFunctionToLoop = b =>
        {
            UpdateLoop loop = (UpdateLoop)b[0];
            SF<object[], bool> function = (SF<object[], bool>)b[1];
            loop.AddUpdateFunction(function);
            return loop;
        };
        public static Func<object[], UpdateLoop> getAddFunctionToLoop() { return addFunctionToLoop; }

        private void Update()
        {
            foreach (SF<object[], bool> function in _updateFunctions.TL)
            {
                if (!function.EX(new object[] { this }))
                {
                    isRunning = false;
                }
            }
        }


    }
}
