using UnityAndroidSensors.Scripts.Utils.SmartEvents;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Actions
{
    public class ActionOnStart : MonoBehaviour
    {
        public SmartEvent onStart;

        private void Start()
        {
            onStart?.Invoke();
        }
    }
}