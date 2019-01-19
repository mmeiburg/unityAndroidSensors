using DG.Tweening;
using UnityAndroidSensors.Demo.Scripts.Actions;
using UnityEngine;
using UnityEngine.Events;

namespace UnityAndroidSensors.Demo.Scripts
{
    [RequireComponent(typeof(Snake))]
    public class SnakeMouth : SnakePart
    {
        public bool Ate { get; set; }
        [SerializeField]
        private ScreenShake screenShake;
        [SerializeField]
        private UnityEvent onAteMyself;
        [SerializeField]
        private UnityEvent onAteFood;

        private void Feed()
        {
            snake.score.value++;
            Ate = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("SnakeTail")) {
                StartCoroutine(screenShake.StartShaking(AteMyself));
                return;
            }
            
            ProceedFood(other);
        }

        private void AteMyself()
        {
            onAteMyself?.Invoke();
        }

        private void ProceedFood(Collider2D other)
        {
            onAteFood?.Invoke();
            
            Food food = other.GetComponentInParent<Food>();
            
            if (!food) {
                return;
            }

            Feed();
            food.Ate();

            snake.model.transform
                .DOPunchScale(Vector3.one, 0.2f)
                .OnComplete(() =>
                {
                    snake.model.transform.localScale = Vector3.one;
                });
        }
    }
}