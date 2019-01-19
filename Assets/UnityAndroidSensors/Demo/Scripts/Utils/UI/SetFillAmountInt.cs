using UnityEngine;
using UnityEngine.UI;

namespace UnityAndroidSensors.Demo.Scripts.Utils.UI
{
    public class SetFillAmountInt : MonoBehaviour
    {
        public Image image;
        public int maxAmount;

        public void SetInt(int amount)
        {
            image.fillAmount = amount / (float)maxAmount;
        }
    }
}