using UnityAndroidSensors.Scripts.Utils;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.TextSetter
{
    public class IntVarTextSetter : TextSetter<int>
    {
        [SerializeField]
        private IntVar intVar;
        
        public override int GetValue()
        {
            return intVar.value;
        }
    }
}