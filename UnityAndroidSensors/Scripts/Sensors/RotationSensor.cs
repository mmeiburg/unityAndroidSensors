using UnityAndroidSensors.Scripts.Core;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Sensors
{
    [DisallowMultipleComponent]
    public class RotationSensor : Vector3SensorReader
    {
        protected override Sensor GetSensor()
        {
            return Sensor.gamerotationvector;
        }
    }
}