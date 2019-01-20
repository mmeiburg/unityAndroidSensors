using UnityAndroidSensors.Scripts.Utils;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts
{
    public class HighscoreSaver : MonoBehaviour
    {
        [SerializeField]
        private IntVar score;
        [SerializeField]
        private IntVar highscore;

        private const string HighscoreToken = "Highscore";

        public void Start()
        {
            highscore.value = PlayerPrefs.GetInt(HighscoreToken);
        }
        
        public void Save()
        {
            if (score.value <= highscore.value) {
                return;
            }

            PlayerPrefs.SetInt(HighscoreToken, score.value);
            highscore.value = score.value;
        }
    }
}