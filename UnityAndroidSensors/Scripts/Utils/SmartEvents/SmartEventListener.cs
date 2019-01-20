using UnityEngine;
using UnityEngine.Events;

namespace UnityAndroidSensors.Scripts.Utils.SmartEvents
{
    public class SmartEventListener : MonoBehaviour
    {
        [SerializeField]
        private SmartEvent Event;
        
        [SerializeField]
        private UnityEvent Response;

        private void OnEnable()
        {
            Event?.AddListener(this);
        }

        private void OnDisable()
        {
            Event?.RemoveListener(this);
        }

        public void Invoke()
        {
            Response?.Invoke();
        }
    }
}