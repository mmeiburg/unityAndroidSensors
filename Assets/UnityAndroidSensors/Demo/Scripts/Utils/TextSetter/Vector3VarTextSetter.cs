using UnityAndroidSensors.Scripts.Utils;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.TextSetter
{
    public class Vector3VarTextSetter : TextSetter<Vector3>
    {
        [SerializeField]
        private Vector3Var vector;

        public override Vector3 GetValue()
        {
            return vector.value;
        }
    }
}