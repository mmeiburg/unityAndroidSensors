using UnityEngine;

namespace UnityAndroidSensors.Scripts.Utils.SmartVars
{
    public abstract class SmartVar<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        //[NonSerialized]
        public T value;
        
        public T defaultValue;
        
        public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
            value = defaultValue;
        }
    }
}