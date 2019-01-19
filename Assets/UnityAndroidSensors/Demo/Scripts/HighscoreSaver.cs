using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    public class HighscoreSaver : MonoBehaviour
    {
        [SerializeField]
        private int score;
        [SerializeField]
        private int highscore;
        
        public void Save()
        {
            if (score <= highscore) {
                return;
            }

            PlayerPrefs.SetInt("Highscore", score);
            highscore = score;
        }
    }
}