using UnityEngine;
using UnityEngine.Events;

namespace UnityAndroidSensors.Demo.Scripts.Actions
{
    public class ActionOnStart : MonoBehaviour
    {
        public UnityEvent onStart;

        private void Start()
        {
            onStart?.Invoke();
        }
    }
}