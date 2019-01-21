using System.Collections.Generic;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Core
{
   
    public class SensorReader : MonoBehaviour
    {
#region Variables

        public Sensor sensor;
        
        [Tooltip("Updates every x frames")]
        [Range(1,60)]
        public int updateInterval = 3;

        public SmartVarType returnType;
        public SensorReturnIndex sensorOutputNumber;
        public Vector3Var vector3Value;
        public IntVar intValue;
        public FloatVar floatValue;

        public List<SensorValueModifier> modifiers;
        
#endregion

        private void Start()
        {
            #if UNITY_EDITOR
            return;
            #endif
            
            UnitySensorPlugin.Instance.StartListenting(sensor);
        }
        
        private void Update()
        {
            #if UNITY_EDITOR
            return;
            #endif
            
            if (Time.frameCount % updateInterval == 0) {

                float[] values = UnitySensorPlugin.Instance.GetSensorValue(sensor);
                ApplyModifier(ref values);
                
                switch (returnType)
                {
                    case SmartVarType.Vector3:
                        vector3Value.value = new Vector3(
                            values[0],
                            values[1],
                            values[2]);
                        
                        break;
                    case SmartVarType.Int:
                        intValue.value = (int) values[(int) sensorOutputNumber];
                        break;
                    case SmartVarType.Float:
                        floatValue.value = values[(int)sensorOutputNumber];
                        break;
                }
            }
        }

        private void ApplyModifier(ref float[] values)
        {
            if (modifiers == null) {
                return;
            }
            
            foreach (SensorValueModifier modifier in modifiers) {
                if (modifier == null) {
                    continue;
                }
                
                modifier.Modify(ref values);
            }
        }
    }
}