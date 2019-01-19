using UnityAndroidSensors.Scripts.Utils;

namespace UnityAndroidSensors.Scripts.Core
{
    /**
     * Gets the first value of the float[] android sensor output
     */
    public abstract class FloatSensorReader : SensorReader
    {
        public FloatVar Value { get; set; }
        
        protected override void Execute()
        {
            Value.value = FirstValue;
        }

        public int CompareTo(float other)
        {
            return Value.value.CompareTo(other);
        }
    }
}