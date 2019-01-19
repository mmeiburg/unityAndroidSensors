using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    public class FoodSpawner : MonoBehaviour
    {
        public FoodSpawnSettings settings;
        private bool[,] field;
        
        private void Start () {
            field = new bool[settings.levelBounds.width * 2,settings.levelBounds.height * 2];
            Spawn();
        }
        
        public void Spawn()
        {
            int w = settings.levelBounds.width;
            int h = settings.levelBounds.height;
            
            int x = Random.Range(-w, w);
            int y = Random.Range(-h, h);

            if (!field[x + w, y + h]) {
                Spawn(x,y);
                field[x + w, y + h] = true;
            } else {
                Spawn();
            }
        }

        private void Spawn(int x, int y)
        {
            Food food = 
                Instantiate(
                    settings.foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity, transform).GetComponent<Food>();

            food.onAte += RemoveFood;
        }

        private void RemoveFood(Food food)
        {
            int w = settings.levelBounds.width;
            int h = settings.levelBounds.height;

            int x = (int)food.transform.position.x;
            int y = (int)food.transform.position.y;
            
            field[x + w, y + h] = false;
        }
    }
}