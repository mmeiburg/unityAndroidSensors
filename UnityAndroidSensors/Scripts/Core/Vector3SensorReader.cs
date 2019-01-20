using UnityAndroidSensors.Scripts.Utils;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Core
{
    /**
     * Gets all values of the float[] android sensor output as an vector3
     */
    public abstract class Vector3SensorReader : SensorReader
    {
        [SerializeField]
        protected Vector3Var value;

        protected override void Execute()
        {
            value.value = new Vector3(FirstValue,SecondValue, ThirdValue);
        }
    }
}