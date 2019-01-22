using System;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Utils.SmartVars
{
    public abstract class SmartVar<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [NonSerialized]
        //[HideInInspector]
        public T value;
        
        public T defaultValue;

        public void OnAfterDeserialize()
        {
            value = defaultValue;
        }
        
        public void OnBeforeSerialize() {}
    }
}