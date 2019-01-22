using UnityAndroidSensors.Scripts.Utils.Comparator;
using UnityEditor;

namespace UnityAndroidSensors.Scripts.Utils.Editor
{
    [CustomEditor(typeof(IntVarComparator)), CanEditMultipleObjects]
    public class IntVarComparatorEditor : SmartVarComparatorEditor
    {
        protected override MonoScript GetScript()
        {
            return MonoScript.FromMonoBehaviour((IntVarComparator) target);
        }
    }
}