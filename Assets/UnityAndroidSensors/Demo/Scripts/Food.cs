using System;
using DG.Tweening;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    using Random = UnityEngine.Random;

    public class Food : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        
        private bool isHiding;
        private Color initColor;
        private Tween fade;
        
        public Action<Food> onAte;
        
        private void Awake()
        {
            initColor = spriteRenderer.color;
        }

        private void Start()
        {
            Hide();
        }

        public void Hide()
        {
            if (isHiding) {
                return;
            }

            isHiding = true;
            
            fade?.Kill();
            fade = spriteRenderer
                .DOFade(0, Random.Range(2f,3f))
                .OnComplete(() => { spriteRenderer.enabled = !isHiding; });
        }

        public void Show()
        {
            if (!isHiding) {
                return;
            }
            
            isHiding = false;
            spriteRenderer.enabled = !isHiding;
            Scale();
            fade?.Kill();
            fade = spriteRenderer.DOColor(initColor, 0.3f);
        }

        private void Scale()
        {
            spriteRenderer.transform
                .DOPunchScale(Vector3.one * 0.7f, 0.3f)
                .OnComplete(() =>
            {
                spriteRenderer.transform.localScale = Vector3.one;
            });
        }

        public void Ate()
        {
            onAte?.Invoke(this);
            Destroy(gameObject);
        }
    }
}