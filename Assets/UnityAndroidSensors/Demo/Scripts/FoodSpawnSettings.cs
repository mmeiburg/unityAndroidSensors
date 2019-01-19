using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    [CreateAssetMenu]
    public class FoodSpawnSettings : ScriptableObject
    {
        public float updateDuration = 2f;
        public LevelBounds levelBounds;
        public GameObject foodPrefab;
    }
}