using UnityAndroidSensors.Scripts.Utils.SmartVars;

namespace UnityAndroidSensors.Scripts.Core.Editor
{
    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(SensorReader), true), CanEditMultipleObjects]
    public class SensorReaderEditor : Editor
    {
        private MonoScript script;
        
        private SerializedProperty returnTypeProperty;
        private SerializedProperty updateIntervalProperty;
        private SerializedProperty vector3ValueProperty;
        private SerializedProperty intValueProperty;
        private SerializedProperty floatValueProperty;
        private SerializedProperty sensorProperty;
        private SerializedProperty sensorOutputNumberProperty;
        private SerializedProperty modifierProperty;

        private SensorReader sensor;

        private void OnEnable()
        {
            sensor = (SensorReader) target;
            
            script = MonoScript.FromMonoBehaviour((SensorReader) target);
            
            returnTypeProperty = serializedObject.FindProperty("returnType");
            updateIntervalProperty = serializedObject.FindProperty("updateInterval");
            vector3ValueProperty = serializedObject.FindProperty("vector3Value");
            intValueProperty = serializedObject.FindProperty("intValue");
            floatValueProperty = serializedObject.FindProperty("floatValue");
            sensorOutputNumberProperty = serializedObject.FindProperty("sensorOutputNumber");
            sensorProperty = serializedObject.FindProperty("sensor");
            modifierProperty = serializedObject.FindProperty("modifiers");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", script, GetType(), false);
            GUI.enabled = true;
            
            EditorGUILayout.PropertyField(sensorProperty, new GUIContent("Sensor Type"));
            EditorGUILayout.PropertyField(returnTypeProperty);
            DrawOutput(sensor.returnType);
            EditorGUILayout.PropertyField(updateIntervalProperty);
            EditorGUILayout.Space();
            DrawModifiers();
            
            serializedObject.ApplyModifiedProperties();
        }

        private bool showModifier = true;
        
        private void DrawModifiers()
        {
            if (sensor.modifiers == null) {
                return;
            }
            if (sensor.modifiers.Count > 0) {
                showModifier = EditorGUILayout.Foldout(showModifier, "Modifiers");
                
                if (showModifier) {

                    for (int i = 0; i < modifierProperty.arraySize; i++)
                    {
                        EditorGUILayout.BeginHorizontal();

                        EditorGUILayout.PropertyField(modifierProperty.GetArrayElementAtIndex(i), GUIContent.none);
                        if (GUILayout.Button("Remove")) {
                            sensor.modifiers.Remove(sensor.modifiers[i]);
                        }
                        EditorGUILayout.EndHorizontal();
                    }

                    DrawAddModifierButton();
                }
            } else {
                DrawAddModifierButton();
            }
        }

        private void DrawAddModifierButton()
        {
            EditorGUILayout.Space();
            GUIStyle style = new GUIStyle(GUI.skin.button) {
                fixedWidth = 100,
            };
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Add Modifier", style)) {
                sensor.modifiers.Add(null);
            }
            EditorGUILayout.EndHorizontal();
        }

        private void DrawOutput(SmartVarType returnType)
        {
            GUIContent valueLabel = new GUIContent("Value");
            switch (returnType)
            {
                case SmartVarType.Vector3:
                    EditorGUILayout.PropertyField(vector3ValueProperty, valueLabel);
                    break;
                case SmartVarType.Int:
                    EditorGUILayout.PropertyField(sensorOutputNumberProperty, new GUIContent("Index"));
                    EditorGUILayout.PropertyField(intValueProperty, valueLabel);
                    break;
                case SmartVarType.Float:
                    EditorGUILayout.PropertyField(sensorOutputNumberProperty, new GUIContent("Index"));
                    EditorGUILayout.PropertyField(floatValueProperty, valueLabel);
                    break;
            }  
        }
    }
}