using UnityAndroidSensors.Scripts.Utils;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    public class Snake : MonoBehaviour
    {
        public SnakeMouth Mouth { get; private set; }
        public SnakeTail Tail { get; private set; }
        public SnakeMovement Movement { get; private set; }
        public Vector2 HeadPosition { get; set; }
        public IntVar score;

        public GameObject model;

        private void Awake()
        {
            score.value = 0;
            Mouth = GetComponent<SnakeMouth>();
            Tail = GetComponent<SnakeTail>();
            Movement = GetComponent<SnakeMovement>();
        }
    }
}