using UnityAndroidSensors.Scripts.Utils;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Core
{
    /**
     * Gets the first value of the float[] android sensor output as an integer
     */
    public abstract class IntSensorReader : SensorReader
    {
        [SerializeField]
        protected IntVar value;
        
        protected override void Execute()
        {
            value.value = (int) FirstValue;
        }

        public int CompareTo(int other)
        {
            return value.value.CompareTo(other);
        }
    }
}