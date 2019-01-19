using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityAndroidSensors.Demo.Scripts.Actions
{
    public class OverlayFlash : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        public Color color = Color.red;

        [SerializeField]
        private UnityEvent onFlashDone;

        private Color oldColor;

        private void Awake()
        {
            oldColor = image.color;
        }

        public void Shake()
        {
            Sequence seq = DOTween.Sequence();

            seq.Append(image.DOColor(color, 0.2f));
            seq.Append(image.DOColor(oldColor, 0.2f)).OnComplete(() =>
            {
                onFlashDone?.Invoke();
            });
            
        }
    }
}