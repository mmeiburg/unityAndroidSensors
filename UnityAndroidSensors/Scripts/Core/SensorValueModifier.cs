using UnityEngine;

namespace UnityAndroidSensors.Scripts.Core
{
    public abstract class SensorValueModifier : ScriptableObject
    {
        public abstract void Modify(ref float[] values);
    }
}