using UnityAndroidSensors.Scripts.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace UnityAndroidSensors.Scripts.Detectors
{
    /**
     * Detects if the acceleration sensor value change from one to another frame is higher than a threshold.
     * If it is, the onShakeEvent get triggered.
     */
    public class ShakeDetector : MonoBehaviour
    {
        [SerializeField]
        private Vector3Var acceleration;
        [SerializeField]
        private UnityEvent onShakeEvent;

        private const float AccelerometerUpdateInterval = 1.0f / 60.0f;
        private const float LowPassKernelWidthInSeconds = 1.0f;

        private float shakeDetectionThreshold = 2.0f;
        private float lowPassFilterFactor;
        private Vector3 lowPassValue;

        private void Start()
        {
            lowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds;
            shakeDetectionThreshold *= shakeDetectionThreshold;
            lowPassValue = Input.acceleration;
        }

        private void Update()
        {
            lowPassValue = Vector3.Lerp(lowPassValue, acceleration.value, lowPassFilterFactor);
            Vector3 deltaAcceleration = acceleration.value - lowPassValue;

            if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold) {
                onShakeEvent?.Invoke();
            }
            
            #if UNITY_EDITOR

            if (Input.GetKeyDown(KeyCode.Return)) {
                onShakeEvent?.Invoke();
            }
            
            #endif
        }
    }
}