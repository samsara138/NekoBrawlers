#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace HandyInspector
{
    public class ShowIfAttribute : PropertyAttribute
    {
        public string ConditionFieldName { get; }
        public bool ConditionValue { get; }
        public string ConditionEnumName { get; }

        public ShowIfAttribute(string conditionFieldName, bool conditionValue = true)
        {
            ConditionFieldName = conditionFieldName;
            ConditionValue = conditionValue;
        }

        public ShowIfAttribute(string conditionFieldName, string conditionEnumName)
        {
            ConditionFieldName = conditionFieldName;
            ConditionEnumName = conditionEnumName;
        }
    }

    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;

            if (ShouldShowProperty(showIf, property))
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;

            if (!ShouldShowProperty(showIf, property))
            {
                return 0f;
            }

            return EditorGUI.GetPropertyHeight(property, label);
        }

        private bool ShouldShowProperty(ShowIfAttribute showIf, SerializedProperty property)
        {
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIf.ConditionFieldName);

            if (conditionProperty != null)
            {
                if (conditionProperty.propertyType == SerializedPropertyType.Enum)
                {
                    string conditionEnumName = conditionProperty.enumNames[conditionProperty.enumValueIndex];
                    return conditionEnumName.Equals(showIf.ConditionEnumName);
                }
                else if (conditionProperty.propertyType == SerializedPropertyType.Boolean)
                {
                    return conditionProperty.boolValue == showIf.ConditionValue;
                }
                else
                {
                    Debug.LogError($"Condition field '{showIf.ConditionFieldName}' must be of type Enum or Boolean.");
                    return true; // Show the property by default if the condition field is not the expected type.
                }
            }

            Debug.LogError($"Condition field '{showIf.ConditionFieldName}' not found.");
            return true; // Show the property by default if the condition field is not found.
        }
    }
}
#endif
