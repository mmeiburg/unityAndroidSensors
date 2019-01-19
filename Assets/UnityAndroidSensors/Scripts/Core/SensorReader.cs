using UnityEngine;

namespace UnityAndroidSensors.Scripts.Core
{
    public abstract class SensorReader : MonoBehaviour
    {
#region Variables
        [Tooltip("Updates every x frames")]
        [Range(1,60)]
        [SerializeField]
        private int updateInterval = 3;
#endregion

#region Properties
        protected float[] Values => UnitySensorPlugin.Instance.GetSensorValue(GetSensor());
#endregion

        protected float FirstValue => Values[0];
        protected float SecondValue => Values[1];
        protected float ThirdValue => Values[2];
        
        private void Start()
        {
            #if UNITY_EDITOR
            return;
            #endif
            
            UnitySensorPlugin.Instance.StartListenting(GetSensor());
        }
        
        private void Update()
        {
            #if UNITY_EDITOR
            return;
            #endif
            
            if (Time.frameCount % updateInterval == 0) {
                Execute();
            }
        }

        protected abstract Sensor GetSensor();
        protected abstract void Execute();
    }
}