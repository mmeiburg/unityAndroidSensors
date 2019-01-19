using UnityAndroidSensors.Scripts.Core;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Sensors
{
    [DisallowMultipleComponent]
    public class StepcounterSensor : IntSensorReader
    {
        protected override Sensor GetSensor()
        {
            return Sensor.stepcounter;
        }
    }
}