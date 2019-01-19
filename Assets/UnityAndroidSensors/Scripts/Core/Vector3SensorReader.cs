using UnityAndroidSensors.Scripts.Utils;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Core
{
    /**
     * Gets all values of the float[] android sensor output as an vector3
     */
    public abstract class Vector3SensorReader : SensorReader
    {
        public Vector3Var Value { get; protected set; }

        protected override void Execute()
        {
            Value.value = new Vector3(FirstValue,SecondValue, ThirdValue);
        }
    }
}