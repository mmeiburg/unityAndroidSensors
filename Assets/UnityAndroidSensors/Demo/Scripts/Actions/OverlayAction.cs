using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UnityAndroidSensors.Demo.Scripts.Actions
{
    public class OverlayAction : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private Color lightOffColor;
        [SerializeField]
        private Color lightOnColor;

        [SerializeField]
        private float lerp = 0.3f;
        
        public void StartNight()
        {
            image.DOColor(lightOffColor, lerp);
        }

        public void StopNight()
        {
            image.DOColor(lightOnColor, lerp);
        }
    }
}