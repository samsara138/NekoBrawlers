#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace HandyInspector
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class ButtonAttribute : PropertyAttribute
    {
    }

    [CustomEditor(typeof(MonoBehaviour), true)]
    public class ButtonAttributeDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            MonoBehaviour script = (MonoBehaviour)target;
            System.Type scriptType = target.GetType();

            // Find all methods in the script
            System.Reflection.MethodInfo[] methods = scriptType.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);

            foreach (System.Reflection.MethodInfo method in methods)
            {
                // Check if the method has the ButtonAttribute
                if (method.GetCustomAttributes(typeof(ButtonAttribute), true).Length > 0)
                {
                    // Display a button for the method
                    if (GUILayout.Button(method.Name))
                    {
                        method.Invoke(script, null);
                    }
                }
            }
        }
    }

}
#endif