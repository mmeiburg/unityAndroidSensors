using System.Collections.Generic;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Utils.SmartEvents
{
    [CreateAssetMenu(menuName = "SmartEvents/Event")]
    public class SmartEvent : ScriptableObject, ISerializationCallbackReceiver
    {
        private List<SmartEventListener> listener = new List<SmartEventListener>();
        
        public void Invoke()
        {
            foreach (SmartEventListener eventListener in listener)
            {
                eventListener.Invoke();
            }
        }

        public void AddListener(SmartEventListener listener)
        {
            this.listener.Add(listener);
        }
        
        public void RemoveListener(SmartEventListener listener)
        {
            this.listener.Remove(listener);
        }

        public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
            listener = new List<SmartEventListener>();
        }
    }
}