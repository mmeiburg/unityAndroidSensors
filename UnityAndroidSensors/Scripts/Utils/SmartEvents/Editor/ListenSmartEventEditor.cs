using System;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Utils.SmartEvents.Editor
{
    using UnityEditor;
    
    [CustomEditor(typeof(ListenSmartEvent))]
    public class ListenSmartEventEditor : Editor
    {
        private SerializedProperty events;
        private ListenSmartEvent listenSmartEvent;
        private MonoScript script;

        private readonly Color removeButtonColor = new Color(1, 0.4f, 0.4f);
        private readonly Color addButtonColor = new Color(0, 0.8f, 0.4f);
        private readonly string descriptionText = "Add a smart event listener";
        
        private void OnEnable()
        {
            script = MonoScript.FromMonoBehaviour((ListenSmartEvent) target);
            listenSmartEvent = (ListenSmartEvent) target;
            events = serializedObject.FindProperty("events");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", script, typeof(ListenSmartEvent), false);
            GUI.enabled = true;
            EditorGUILayout.BeginVertical();
            
            int countOfSmartEvents = listenSmartEvent.events?.Count ?? 0;

            GUIStyle addButtonStyle = new GUIStyle(GUI.skin.button) {
                fixedWidth = 100,
                margin = new RectOffset(0, 15, 0, 0)
            };
            
            DrawButton("Add Listener", addButtonStyle, addButtonColor, () =>
            {
                SmartEventListener listener = new SmartEventListener();
                
                if (countOfSmartEvents > 0) {
                    listener.Event = listenSmartEvent.events[countOfSmartEvents - 1].Event;
                }
                listenSmartEvent.events.Add(listener);
            });

            EditorGUILayout.Space();
            
            for (int i = 0; i < events.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();

                GUIStyle removeButtonStyle = new GUIStyle(GUI.skin.button) {
                    fixedWidth = 30,
                    fixedHeight = 30,
                    margin = new RectOffset(0, 15, 0, 0)
                };

                DrawButton("-", removeButtonStyle, removeButtonColor,
                    () => { listenSmartEvent.events.Remove(listenSmartEvent.events[i]); });
                
                EditorGUILayout.PropertyField(events.GetArrayElementAtIndex(i), GUIContent.none);
                        
                EditorGUILayout.EndHorizontal();
            }
            
            EditorGUILayout.EndVertical();
            serializedObject.ApplyModifiedProperties();
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
    }
}