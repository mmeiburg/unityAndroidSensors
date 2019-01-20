using UnityAndroidSensors.Scripts.Core;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Sensors
{
    /**
     * This class can be used to get a specific value from a specific android sensor.
     * Just chose a sensor and the the index of the float[] array to get the value each update.
     */
    public class WriteSensorToFloat : MonoBehaviour
    {
        [Header("Sensor")]
        public Sensor sensor;
        [Range(0,2)]
        public int sensorIndex;
        
        [Header("Variable")]
        public float value;
        
        private void Start()
        {
            UnitySensorPlugin.Instance.StartListenting(sensor);
        }

        private void Update()
        {
            value = UnitySensorPlugin.Instance.GetSensorValue(sensor)[sensorIndex];
        }
    }
}