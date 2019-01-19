using TMPro;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.TextSetter
{
    public abstract class TextSetter<T> : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textMeshPro;
        
        private void Update()
        {
            if (textMeshPro == null) {
                return;
            }
            
            textMeshPro.text = GetValue().ToString();
        }

        public abstract T GetValue();
    }
}