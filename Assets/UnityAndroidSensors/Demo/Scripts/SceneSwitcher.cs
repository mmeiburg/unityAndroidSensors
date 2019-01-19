using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityAndroidSensors.Demo.Scripts
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField]
        private string sceneName; 
        
        public void Switch()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}