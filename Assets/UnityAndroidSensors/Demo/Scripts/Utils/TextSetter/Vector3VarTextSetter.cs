using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.TextSetter
{
    public class Vector3VarTextSetter : TextSetter<Vector3>
    {
        public Vector3 vector;

        public override Vector3 GetValue()
        {
            return vector;
        }
    }
}