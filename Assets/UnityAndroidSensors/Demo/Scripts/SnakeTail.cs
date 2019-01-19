using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    [RequireComponent(typeof(Snake))]
    public class SnakeTail : SnakePart
    {
        [SerializeField] private GameObject tailPrefab;
        
        private readonly List<Transform> tail = new List<Transform>();

        private Color headColor;

        protected override void Awake()
        {
            base.Awake();
            headColor = snake.GetComponentInChildren<SpriteRenderer>().color;
        }

        public void ExtentTail()
        {
            GameObject obj = Instantiate(tailPrefab,
                snake.HeadPosition,
                Quaternion.identity);

            tail.Insert(0, obj.transform);
            //ColorTailAtIndex(0);
            snake.Mouth.Ate = false;
        }

        public void ReorderTail()
        {
            tail.Last().position = snake.HeadPosition;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);

            /*for (int i = 0; i < tail.Count / 2; i++) {
                ColorTailAtIndex(i);
            }*/
        }

        private void ColorTailAtIndex(int i)
        {
            SpriteRenderer r = tail[i].GetComponent<SpriteRenderer>();
            Color c = headColor;
            c.a = 0.8f / (i + 1f);

            r.color = c;
        }

        public bool IsEmpty()
        {
            return tail.Count == 0;
        }
    }
}