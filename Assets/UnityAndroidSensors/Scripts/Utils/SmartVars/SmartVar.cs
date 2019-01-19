using System;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Utils
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