using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Actions
{
    [Serializable]
    public class ScreenShake
    {
        [Header("ScreenShake")]
        
        private bool shaking;
        
        [SerializeField]
        private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin perlin;

        [SerializeField] private float shakeDuration = 0.2f;
        [SerializeField] private float shakeAmplitude = 1.5f;
        [SerializeField] private float shakeFrequency = 2.0f;

        private CinemachineBasicMultiChannelPerlin GetPerlin()
        {
            if (perlin == null) {
                perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            }

            return perlin;
        }

        public IEnumerator StartShaking(Action callback = null)
        {
            if (shaking) {
                yield break;
            }
            shaking = true;
            GetPerlin().m_AmplitudeGain = shakeAmplitude;
            GetPerlin().m_FrequencyGain = shakeFrequency;
            
            yield return new WaitForSeconds(shakeDuration);

            shaking = false;
            GetPerlin().m_AmplitudeGain = 0f;
            callback?.Invoke();
        }
    }
}