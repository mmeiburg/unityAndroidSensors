using DG.Tweening;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Actions
{
    public class OverlayAction : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Color lightOffColor;
        [SerializeField]
        private Color lightOnColor;

        [SerializeField]
        private float lerp = 0.3f;
        
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void StartSleep()
        {
            spriteRenderer.DOColor(lightOffColor, lerp);
        }

        public void EndSleep()
        {
            spriteRenderer.DOColor(lightOnColor, lerp);
        }
    }
}