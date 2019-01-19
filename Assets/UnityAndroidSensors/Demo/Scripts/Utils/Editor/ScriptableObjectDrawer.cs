using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityAndroidSensors.Demo.Scripts.Utils.Editor
{
    // Script from : https://forum.unity.com/threads/editor-tool-better-scriptableobject-inspector-editing.484393/
    [CustomPropertyDrawer(typeof(ScriptableObject), true)]
    public class ScriptableObjectDrawer : PropertyDrawer
    {
        // Static foldout dictionary
        private static readonly Dictionary<int, bool> FoldoutByType = new Dictionary<int, bool>();

        // Cached scriptable object editor
        private UnityEditor.Editor editor;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Draw label
            EditorGUI.PropertyField(position, property, label, true);

            // Draw foldout arrow
            bool foldout = false;
            if (property.objectReferenceValue != null) {
                // Store foldout values in a dictionary per object
                bool foldoutExists =
                    FoldoutByType.TryGetValue(property.objectReferenceValue.GetHashCode(), out foldout);
                foldout = EditorGUI.Foldout(position, foldout, GUIContent.none);

                if (foldoutExists) {
                    FoldoutByType[property.objectReferenceValue.GetHashCode()] = foldout;
                } else {
                    FoldoutByType.Add(property.objectReferenceValue.GetHashCode(), foldout);
                }
            }

            // Draw foldout properties
            if (!foldout) {
                return;
            }

            // Make child fields be indented
            EditorGUI.indentLevel++;

            // Draw object properties
            if (!editor) {
                UnityEditor.Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor);
            }

            editor.OnInspectorGUI();

            // Set indent back to what it was
            EditorGUI.indentLevel--;
        }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(ScriptableObject), true)]
    public class ScriptableObjectEditor : UnityEditor.Editor { }

    [CanEditMultipleObjects, CustomEditor(typeof(MonoBehaviour), true)]
    public class MonoBehaviourEditor : UnityEditor.Editor { }
}