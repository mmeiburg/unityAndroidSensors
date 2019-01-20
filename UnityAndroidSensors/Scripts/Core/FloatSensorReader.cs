using UnityAndroidSensors.Scripts.Utils;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Core
{
    /**
     * Gets the first value of the float[] android sensor output
     */
    public abstract class FloatSensorReader : SensorReader
    {
        [SerializeField]
        protected FloatVar value;
        
        protected override void Execute()
        {
            value.value = FirstValue;
        }

        public int CompareTo(float other)
        {
            return value.value.CompareTo(other);
        }
    }
}