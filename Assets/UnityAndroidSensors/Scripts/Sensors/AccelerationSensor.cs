using UnityAndroidSensors.Scripts.Core;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Sensors
{
    [DisallowMultipleComponent]
    public class AccelerationSensor : Vector3SensorReader
    {
        private const float Alpha = 10f;
        
        protected override void Execute()
        {
            value.value = new Vector3(
                    LowPass(FirstValue),
                    LowPass(SecondValue),
                    LowPass(ThirdValue)) * -1f;
            
            // Could also archive with build in unity methods,
            // but hey we want to be real hackers and get the values by our self
            // x.value = Input.acceleration.x;
            // y.value = Input.acceleration.y;
            // z.value = Input.acceleration.z;
        }

        protected override Sensor GetSensor()
        {
            return Sensor.accelerometer;
        }

        private float LowPass(float value)
        {
            return Mathf.Round((value / Alpha) * 100f) / 100f;
        }
    }
}