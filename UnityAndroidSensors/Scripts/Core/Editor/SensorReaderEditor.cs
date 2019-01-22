using System;
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
        private GUIStyle addModifierButtonStyle;
        private GUIStyle removeButtonStyle;

        private SensorReader sensor;
        private bool showModifier = true;
        
        private readonly Color removeButtonColor = new Color(1, 0.4f, 0.4f);
        private readonly Color addButtonColor = new Color(0, 0.8f, 0.4f);
        private readonly string descriptionText = "Add a smart event listener";
        
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
            EditorGUILayout.ObjectField("Script", script, typeof(SensorReader), false);
            GUI.enabled = true;
            
            EditorGUILayout.PropertyField(sensorProperty, new GUIContent("Sensor Type"));
            EditorGUILayout.PropertyField(returnTypeProperty);
            DrawOutput(sensor.returnType);
            EditorGUILayout.PropertyField(updateIntervalProperty);
            EditorGUILayout.Space();
            DrawModifiers();
            
            serializedObject.ApplyModifiedProperties();
        }
        
        private void DrawModifiers()
        {
            if (sensor.modifiers == null) {
                return;
            }
            
            showModifier = EditorGUILayout.Foldout(showModifier, "Modifiers");
                
            if (showModifier) {
                                
                DrawAddModifierButton();
                
                EditorGUILayout.BeginVertical();
                for (int i = 0; i < modifierProperty.arraySize; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    
                    removeButtonStyle = new GUIStyle(GUI.skin.button) {
                        fixedWidth = 20,
                        margin = new RectOffset(0, 15, 0, 0)
                    };
                    
                    Color defaultColor = GUI.backgroundColor;
                    GUI.backgroundColor = removeButtonColor;

                    DrawButton("-", removeButtonStyle, removeButtonColor,
                        () => { sensor.modifiers.Remove(sensor.modifiers[i]); });
                    
                    GUI.backgroundColor = defaultColor;
                    
                    EditorGUILayout.PropertyField(modifierProperty.GetArrayElementAtIndex(i), GUIContent.none);

                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();

            }
        }
        
        
        private void DrawButton(string text, GUIStyle style, Color color, Action callback)
        {
            Color defaultColor = GUI.backgroundColor;
            GUI.backgroundColor = color;
            
            if (GUILayout.Button(text, style)) {
                callback?.Invoke();
            }

            GUI.backgroundColor = defaultColor;
        }
        
        private void DrawAddModifierButton()
        {
            EditorGUILayout.Space();

            addModifierButtonStyle = new GUIStyle(GUI.skin.button) {fixedWidth = 100};

            EditorGUILayout.BeginHorizontal();
            //GUILayout.FlexibleSpace();

            DrawButton("Add Modifier", addModifierButtonStyle, addButtonColor, () =>
            {
                sensor.modifiers.Add(null); 
            });
            
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