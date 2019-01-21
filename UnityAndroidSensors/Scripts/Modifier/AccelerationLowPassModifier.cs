using UnityAndroidSensors.Scripts.Core;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Modifier
{
    [CreateAssetMenu(menuName = "SensorPlugin/Modifiers/AccelerationLowPassModifier")]
    public class AccelerationLowPassModifier : SensorValueModifier
    {
        private const float Alpha = 10f;

        public override void Modify(ref float[] values)
        {
            values[0] = LowPass(values[0]) * -1f;
            values[1] = LowPass(values[1]) * -1f;
            values[2] = LowPass(values[2]) * -1f;
            
            // Could also archive with build in unity methods,
            // but hey we want to be real hackers and get the values by our self
            // value.value.x = Input.acceleration.x;
            // value.value.y = Input.acceleration.y;
            // value.value.z = Input.acceleration.z;
        }

        private float LowPass(float value)
        {
            return Mathf.Round((value / Alpha) * 100f) / 100f;
        }
    }
}