using DG.Tweening;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.UI
{
    public class SetBackgroundColor : MonoBehaviour
    {
        public Color color;
        public float tweenDuration = 0.5f;

        public void SetColor()
        {
            Camera.main.DOColor(color, tweenDuration);
        }
    }
}