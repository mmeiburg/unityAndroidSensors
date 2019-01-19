using UnityEngine;
using UnityEngine.Events;

namespace UnityAndroidSensors.Demo.Scripts
{
    public class LevelBoundsController : MonoBehaviour
    {
        public UnityEvent onGameOver;
        
        [SerializeField]
        private LevelBounds levelBounds;
        [SerializeField]
        private Snake snake;

        private void Update()
        {
            if (IsOutOfBounds(snake.transform.position)) {
                GameOver();
            }
        }

        private bool IsOutOfBounds(Vector2 position)
        {
            int x = (int) position.x;
            int y = (int) position.y;

            return x == levelBounds.width ||
                   x == -levelBounds.width ||
                   y == levelBounds.height ||
                   y == -levelBounds.height;
        }

        private void GameOver()
        {
            onGameOver?.Invoke();
        }
    }
}