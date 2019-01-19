using System;
using UnityAndroidSensors.Scripts.Core;
using UnityEngine;
using UnityEngine.Events;

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
        private UnityEvent onEvent;
        [SerializeField]
        private CompareOptions option;
        [SerializeField]
        private TVar variable;
        [SerializeField]
        private TType constant;

        private void Update()
        {
            CompareAndInvoke();
        }

        private void CompareAndInvoke()
        {
            if (option == CompareOptions.Disabled) {
                return;
            }

            int compare = variable.value.CompareTo(constant);

            if (option == CompareOptions.GreaterEqual && compare >= 0 ||
                option == CompareOptions.Equal && compare == 0 ||
                option == CompareOptions.Greater && compare > 0 ||
                option == CompareOptions.Less && compare < 0 ||
                option == CompareOptions.LessEqual && compare <= 0) {
                onEvent?.Invoke();
            }
        }
    }
}