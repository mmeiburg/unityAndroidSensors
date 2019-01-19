using UnityAndroidSensors.Scripts.Utils;

namespace UnityAndroidSensors.Scripts.Core
{
    /**
     * Gets the first value of the float[] android sensor output as an integer
     */
    public abstract class IntSensorReader : SensorReader
    {
        public IntVar Value { get; set; }
        
        protected override void Execute()
        {
            Value.value = (int) FirstValue;
        }

        public int CompareTo(int other)
        {
            return Value.value.CompareTo(other);
        }
    }
}