using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityAndroidSensors.Scripts.Utils.SmartEvents
{
    public class ListenSmartEvent : MonoBehaviour
    {
        public List<SmartEventListener> events = new List<SmartEventListener>();
        
        private void OnEnable()
        {
            foreach (SmartEventListener item in events) {
                item.OnEnable();
            }
        }

        private void OnDisable()
        {
            foreach (SmartEventListener item in events) {
                item.OnDisable();
            }
        }
    }
}