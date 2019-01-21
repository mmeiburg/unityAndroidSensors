namespace UnityAndroidSensors.Scripts.Utils.Editor
{
    using UnityEditor;
    using UnityEngine;
    
    [CanEditMultipleObjects]
    public abstract class SmartVarComparatorEditor : Editor
    {
        private SerializedProperty constant;
        private SerializedProperty unityEvent;
        private SerializedProperty smartEvent;
        private SerializedProperty eventChoiceType;
        private SerializedProperty condition;
        private SerializedProperty useConst;
        private SerializedProperty var1;
        private SerializedProperty var2;

        private static GUIStyle toggleButtonStyleNormal;
        private static GUIStyle toggleButtonStyleToggled;
        
        private static string[] comparisonChoice = { "Const", "Var" };

        private void OnEnable()
        {
            var1 = serializedObject.FindProperty("var1");
            condition = serializedObject.FindProperty("condition");
            var2 = serializedObject.FindProperty("var2");
            unityEvent = serializedObject.FindProperty("unityEvent");
            smartEvent = serializedObject.FindProperty("smartEvent");
            eventChoiceType = serializedObject.FindProperty("eventChoiceType");
            constant = serializedObject.FindProperty("constant");
            useConst = serializedObject.FindProperty("useConst");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            if ( toggleButtonStyleNormal == null )
            {
                toggleButtonStyleNormal = "Button";
                toggleButtonStyleNormal.fixedWidth = 60;
                toggleButtonStyleToggled = new GUIStyle(toggleButtonStyleNormal);
                toggleButtonStyleToggled.normal.background = toggleButtonStyleToggled.active.background;
                toggleButtonStyleToggled.fixedWidth = 60;
            }

            GUILayout.BeginVertical();

            GUILayout.Label("Comparison", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(var1, GUIContent.none, true);
            EditorGUILayout.PropertyField(condition, GUIContent.none, true);

            GUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(useConst.boolValue ? constant : var2, GUIContent.none, true);
            
            useConst.boolValue = EditorGUILayout.Popup(useConst.boolValue ? 0 : 1, comparisonChoice) == 0;

            GUILayout.EndHorizontal();
            GUILayout.EndHorizontal();
            GUILayout.Label("Event",  EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(eventChoiceType, GUIContent.none);
            int enumIndex = eventChoiceType.enumValueIndex;
            
            if (enumIndex == 0 || enumIndex == 2) {
                EditorGUILayout.PropertyField(smartEvent, GUIContent.none);
            }

            if (enumIndex == 1 || enumIndex == 2) {
                EditorGUILayout.PropertyField(unityEvent, GUIContent.none);
                
            }

            GUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}