using UnityAndroidSensors.Scripts.Core;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Sensors
{
    [DisallowMultipleComponent]
    public class LightSensor : FloatSensorReader
    {      
        protected override Sensor GetSensor()
        {
            return Sensor.light;
        }
    }
}