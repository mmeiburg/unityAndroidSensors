using UnityEngine;

namespace UnityAndroidSensors.Scripts.Modifier
{
    public abstract class SensorValueModifier : ScriptableObject
    {
        /**
         * Modify the values of the sensor in this method. values are
         * The values are given as a reference and can directly modified
         * within the method, no need for a return type
         */
        public abstract void Modify(ref float[] values);
    }
}