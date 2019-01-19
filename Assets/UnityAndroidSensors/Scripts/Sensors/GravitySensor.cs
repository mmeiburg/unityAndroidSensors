using UnityAndroidSensors.Scripts.Core;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Sensors
{
    [DisallowMultipleComponent]
    public class GravitySensor : Vector3SensorReader
    {
        protected override Sensor GetSensor()
        {
            return Sensor.gravity;
        }
    }
}