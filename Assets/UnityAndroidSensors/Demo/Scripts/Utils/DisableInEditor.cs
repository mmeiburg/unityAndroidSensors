using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils
{
    public class DisableInEditor : MonoBehaviour
    {
        private void Awake()
        {
            if (Application.isEditor) {
                gameObject.SetActive(false);
            }
        }
    }
}