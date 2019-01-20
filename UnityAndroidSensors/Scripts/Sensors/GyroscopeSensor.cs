using UnityAndroidSensors.Scripts.Core;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Sensors
{
    [DisallowMultipleComponent]
    public class GyroscopeSensor : Vector3SensorReader
    {
        protected override Sensor GetSensor()
        {
            return Sensor.gyroscopeuncalibrated;
        }
    }
}