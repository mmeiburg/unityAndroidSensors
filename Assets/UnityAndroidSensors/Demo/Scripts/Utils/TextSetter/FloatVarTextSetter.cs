using UnityAndroidSensors.Scripts.Utils;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.TextSetter
{
    public class FloatVarTextSetter : TextSetter<float>
    {
        [SerializeField]
        private FloatVar floatVar;
        
        public override float GetValue()
        {
            return floatVar.value;
        }
    }
}