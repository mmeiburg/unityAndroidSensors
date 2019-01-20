using System;
using UnityAndroidSensors.Scripts.Core;
using UnityAndroidSensors.Scripts.Utils.SmartEvents;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityAndroidSensors.Scripts.Utils
{
    public enum CompareOptions
    {
        Disabled,
        Equal,
        Greater,
        GreaterEqual,
        Less,
        LessEqual
    }
    
    public abstract class AbstractComparator<TType, TVar> : MonoBehaviour
        where TType : IComparable
        where TVar : SmartVar<TType>
    {
        [SerializeField]
        private SmartEvent onEvent;
        [Header("Compare")]
        [SerializeField]
        private TVar variable;
        [FormerlySerializedAs("option")] [SerializeField]
        private CompareOptions contition;
        [SerializeField]
        private TType constant;


        private TType lastValue;
        
        private void Update()
        {
            CompareAndInvoke();
            lastValue = variable.value;
        }

        private void CompareAndInvoke()
        {
            if (contition == CompareOptions.Disabled) {
                return;
            }

            int compare = variable.value.CompareTo(constant);
            int compareLast = lastValue.CompareTo(constant);

            if (contition == CompareOptions.GreaterEqual && compare >= 0 && compareLast < 0 ||
                contition == CompareOptions.Equal && compare == 0 && (compareLast < 0 || compareLast > 0) ||
                contition == CompareOptions.Greater && compare > 0 &&  compareLast <= 0 ||
                contition == CompareOptions.Less && compare < 0 &&  compareLast >= 0||
                contition == CompareOptions.LessEqual && compare <= 0 && compareLast > 0) {
                onEvent?.Invoke();
            }
        }
    }
}