using UnityEngine.Events;

namespace UnityAndroidSensors.Scripts.Utils.SmartEvents
{
    [System.Serializable]
    public class SmartEventListener
    {
        public SmartEvent Event;
        public UnityEvent response;

        public void OnEnable()
        {
            Event?.AddListener(this);
        }

        public void OnDisable()
        {
            Event?.RemoveListener(this);
        }
        public void Invoke()
        {
            response?.Invoke();
        }
    }
}