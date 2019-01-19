using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.TextSetter
{
    public class UnityAccelerationTextSetter : TextSetter<Vector3>
    {
        public override Vector3 GetValue()
        {
            return Input.acceleration;
        }
    }
}