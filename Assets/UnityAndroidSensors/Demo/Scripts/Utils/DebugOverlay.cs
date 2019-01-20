using DG.Tweening;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils
{
    public class DebugOverlay : MonoBehaviour
    {
        [SerializeField]
        private GameObject canvas;
        
        private Ease ease = Ease.InOutBack;
        
        private bool itsUp;
        private bool shakedRecently;
        
        private void Start()
        {
            canvas.transform.DOLocalMoveX(-Screen.width, 0f);
            itsUp = true;
        }

        public void Toggle()
        {
            if (canvas == null || shakedRecently) {
                return;
            }
          
            shakedRecently = true;

            canvas.transform
                .DOLocalMoveX(itsUp ? 0 : -Screen.width, 0.4f)
                .SetEase(ease)
                .OnComplete(() =>
                {
                    itsUp = !itsUp;
                    shakedRecently = false;
                });
        }
    }
}