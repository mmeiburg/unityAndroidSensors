using DG.Tweening;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.UI
{
    public enum TweenType {
        Scale,
        Rotate,
        Move
    }
    public class TweenAnimation : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField]
        private TweenType type = TweenType.Scale;
        [SerializeField]
        private Vector3 value;
        [SerializeField]
        private float duration;
        [SerializeField]
        private Ease ease = Ease.Linear;
        [SerializeField]
        private float delay;
        
        [Header("Looping")]
        [SerializeField]
        private int loops = 1;
        [SerializeField]
        private LoopType loopType = LoopType.Yoyo;

        private void Start()
        {
            switch (type) {
                case TweenType.Scale:
                    transform.DOScale(value, duration)
                        .SetLoops(loops, loopType)
                        .SetEase(ease)
                        .SetDelay(delay);
                    break;
                case TweenType.Rotate:
                    transform.DOLocalRotate(value, duration)
                        .SetLoops(loops, loopType)
                        .SetEase(ease)
                        .SetDelay(delay);
                    break;
                case TweenType.Move:
                    transform.DOMove(value, duration)
                        .SetLoops(loops, loopType)
                        .SetEase(ease)
                        .SetDelay(delay)
                        .SetRelative(true);
                    break;
            }

        }
    }
}