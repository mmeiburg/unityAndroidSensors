namespace UnityAndroidSensors.Scripts.Utils.Editor
{
    using UnityEditor;
    using UnityEngine;
    
    [CanEditMultipleObjects]
    public abstract class SmartVarComparatorEditor : Editor
    {
        private MonoScript script;
        
        private SerializedProperty constant;
        private SerializedProperty unityEvent;
        private SerializedProperty smartEvent;
        private SerializedProperty eventChoiceType;
        private SerializedProperty condition;
        private SerializedProperty useConst;
        private SerializedProperty var1;
        private SerializedProperty var2;

        private static GUIStyle popupStyle;
        private readonly string[] comparisonChoice =
            { "Use Constant", "Use Variable"};
        
        private void OnEnable()
        {
            script = GetScript();
            
            var1 = serializedObject.FindProperty("var1");
            condition = serializedObject.FindProperty("condition");
            var2 = serializedObject.FindProperty("var2");
            unityEvent = serializedObject.FindProperty("unityEvent");
            smartEvent = serializedObject.FindProperty("smartEvent");
            eventChoiceType = serializedObject.FindProperty("eventChoiceType");
            constant = serializedObject.FindProperty("constant");
            useConst = serializedObject.FindProperty("useConst");
        }

        protected abstract MonoScript GetScript();

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
            {
                imagePosition = ImagePosition.ImageOnly,
            };

            GUILayout.BeginVertical();
            
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", script, GetType(), false);
            GUI.enabled = true;
            
            GUILayout.Label("Comparison", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(var1, GUIContent.none, true);
            EditorGUILayout.PropertyField(condition, GUIContent.none, true);

            GUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(useConst.boolValue ? constant : var2, GUIContent.none, true);
            
            useConst.boolValue = EditorGUILayout.Popup(
                         useConst.boolValue ? 0 : 1, comparisonChoice,
                         popupStyle, GUILayout.MaxWidth(20)) == 0;
            
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