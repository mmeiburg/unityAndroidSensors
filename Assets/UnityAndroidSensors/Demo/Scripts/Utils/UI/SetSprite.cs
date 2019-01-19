using DG.Tweening;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.UI
{
    public class SetSprite : MonoBehaviour
    {
        public float tweenDuration;
        public SpriteRenderer sprite;

        public void SetTransparency(float transparency)
        {
            sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, transparency), tweenDuration);
        }
    }
}