using UnityAndroidSensors.Scripts.Utils;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    public class SnakeMovement : SnakePart
    {
        [SerializeField] private Vector3Var acceleration;
        [SerializeField] private LevelBounds bounds;
        [SerializeField] private float rangeOffset = 0.3f;
        [SerializeField] private float updateInterval = 1f;
        
        private Vector2 direction = Vector2.zero;
        private Vector2 lastDirection = Vector2.zero;
        private Vector3 velocity;
        
        private void OnEnable()
        {
            InvokeRepeating(nameof(Move), 0.0f, updateInterval);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Move));
        }

        private void Update()
        {
            velocity = acceleration.value;
            
            #if UNITY_EDITOR
            velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            #endif

            direction = GetDirection();
        }

        private Vector2 GetDirection()
        {
            Vector2 dir = direction;
            
            if (velocity.x > rangeOffset)
                dir = Vector2.right;
            else if (velocity.y < -rangeOffset)
                dir = -Vector2.up;
            else if (velocity.x < -rangeOffset)
                dir = -Vector2.right;
            else if (velocity.y > rangeOffset)
                dir = Vector2.up;

            return dir == -lastDirection ? lastDirection : dir;
        }

        private void Move()
        {
            lastDirection = direction;

            Vector3 position = transform.position;
            snake.HeadPosition = position;

            int x = (int) position.x;
            int y = (int) position.y;

            int w = bounds.width;
            int h = bounds.height;
            
            if (x > w - 1 && direction == Vector2.right) {
                transform.position = new Vector3(-w, y);
            } else if (x < -w + 1 && direction == Vector2.left) {
                transform.position = new Vector3(w, y);
            } else if (y > h - 1 && direction == Vector2.up) {
                transform.position = new Vector3(x, -h);
            } else if (y < -h + 1 && direction == Vector2.down) {
                transform.position = new Vector3(x, h);
            } else {
                transform.Translate(direction);
            }
            
            if (snake.Mouth.Ate) {
                snake.Tail.ExtentTail();
            } else if (!snake.Tail.IsEmpty()) {
                snake.Tail.ReorderTail();
            }
        }
    }
}