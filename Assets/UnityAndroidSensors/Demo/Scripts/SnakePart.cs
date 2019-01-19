using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    public abstract class SnakePart : MonoBehaviour
    {
        protected Snake snake;

        protected virtual void Awake()
        {
            snake = GetComponent<Snake>();
        }
    }
}