using System;
using UnityAndroidSensors.Scripts.Utils;

namespace UnityAndroidSensors.Scripts.Core
{
    public interface IComparableSensor<T> : IComparable<T> where T : SmartVar<T>
    {
        T Value { get; set; }
    }
}