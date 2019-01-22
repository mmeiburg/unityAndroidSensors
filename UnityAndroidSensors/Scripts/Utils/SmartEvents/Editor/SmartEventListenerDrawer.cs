using UnityEditor;
using UnityEngine;

namespace UnityAndroidSensors.Scripts.Utils.SmartEvents.Editor
{
    [CustomPropertyDrawer(typeof(SmartEventListener))]
    public class SmartEventListenerDrawer : PropertyDrawer
    {
        private SerializedProperty smartEvent;
        private SerializedProperty unityEvent;

        private float smartEventHeight;
        private float unityEventHeight;

        private const float GabBetween = 10;
        private const float BottomSpace = 5;
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            smartEvent = property.FindPropertyRelative("Event");
            unityEvent = property.FindPropertyRelative("response");
            smartEventHeight = EditorGUI.GetPropertyHeight(smartEvent);
            unityEventHeight = EditorGUI.GetPropertyHeight(unityEvent);
            return smartEventHeight + unityEventHeight + GabBetween + BottomSpace;
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var smartEventRect = 
                new Rect(position.x, position.y, position.width, smartEventHeight);
            var unityEventRect = 
                new Rect(position.x, position.y + smartEventHeight + GabBetween, position.width, unityEventHeight);

            EditorGUI.PropertyField(smartEventRect, smartEvent, GUIContent.none);
            EditorGUI.PropertyField(unityEventRect, unityEvent, GUIContent.none);

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}