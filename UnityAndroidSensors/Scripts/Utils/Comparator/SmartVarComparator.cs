using System;
using UnityAndroidSensors.Scripts.Utils.SmartEvents;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;
using UnityEngine.Events;

namespace UnityAndroidSensors.Scripts.Utils.Comparator
{
    public enum CompareCondition
    {
        Equal,
        Greater,
        GreaterEqual,
        Less,
        LessEqual
    }

    public enum EventChoiceType
    {
        SmartEvent,
        UnityEvent,
        Both
    }

    public abstract class SmartVarComparator<TVarType, TType> : MonoBehaviour
        where TVarType : SmartVar<TType>
        where TType : IComparable<TType>
    {
        public UnityEvent unityEvent;
        public SmartEvent smartEvent;
        public EventChoiceType eventChoiceType;
        
        public CompareCondition condition;

        [Tooltip("Use constant")]
        public bool useConst = true;
        public TType constant;

        public TVarType var1;
        public TVarType var2;

        private TType lastValue;

        private void Update()
        {
            CompareAndInvoke();

            if (var1 != null) {
                lastValue = var1.value;
            }
        }

        private void CompareAndInvoke()
        {
            if (var1 == null) {
                Debug.LogError("Var1 should be set", gameObject);
                return;
            }

            if (var2 == null && !useConst) {
                Debug.LogError("Var2 should be set", gameObject);
                return;
            }

            int compare = var1.value.CompareTo(useConst ? constant : var2.value);
            int compareLast = lastValue.CompareTo(useConst ? constant : var2.value);

            if (condition == CompareCondition.GreaterEqual && compare >= 0 && compareLast < 0 ||
                condition == CompareCondition.Equal && compare == 0 && (compareLast < 0 || compareLast > 0) ||
                condition == CompareCondition.Greater && compare > 0 && compareLast <= 0 ||
                condition == CompareCondition.Less && compare < 0 && compareLast >= 0 ||
                condition == CompareCondition.LessEqual && compare <= 0 && compareLast > 0) {

                switch (eventChoiceType) {
                    case EventChoiceType.Both:
                        InvokeSmartEvent();
                        InvokeUnityEvent();
                        break;
                    case EventChoiceType.SmartEvent:
                        InvokeSmartEvent();
                        break;
                    case EventChoiceType.UnityEvent:
                        InvokeUnityEvent();
                        break;
                }
            }
        }

        private void InvokeSmartEvent()
        {
            smartEvent?.Invoke();
        }

        private void InvokeUnityEvent()
        {
            unityEvent?.Invoke();
        }
    }
}