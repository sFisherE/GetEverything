#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[CustomPropertyDrawer(typeof(GetEverythingAttribute))]
public class GetEverythingDrawer : PropertyDrawer
{
    int drawNum = 0;
    int height = 16;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        drawNum = 0;

        Rect curPosition = position;
        GetEverythingAttribute getProperty = attribute as GetEverythingAttribute;

        // The propertyPath may reference something that is a child field of a field on this Object, so it is necessary
        // to find which object is the actual parent before attempting to set the property with the current value.
        object parent = GetParentObjectOfProperty(property.propertyPath, property.serializedObject.targetObject);
        Type type = parent.GetType();

        foreach (var item in getProperty.wrappers)
        {
            PropertyInfo pi = type.GetProperty(item.name);
            if (pi != null)
            {
                //Debug.Log("property:"+item.name);
                if (item.type == typeof(int))
                {
                    int val = (int)pi.GetValue(parent, null);

                    EditorGUI.LabelField(curPosition, item.name, val.ToString());
                    drawNum++;
                    curPosition.y += height;
                    //EditorGUILayout.LabelField(item.name, val.ToString());
                }
                else if (item.type == typeof(float))
                {
                    //property.floatValue = (float)pi.GetValue(parent, null);
                    float val = (float)pi.GetValue(parent, null);
                    EditorGUI.LabelField(curPosition, item.name, val.ToString());
                    drawNum++;
                    curPosition.y += height;
                    //EditorGUILayout.LabelField(item.name, val.ToString());
                }

                else if (item.type == typeof(string))
                {
                    //property.stringValue = (string)pi.GetValue(parent, null);
                    string val = (string)pi.GetValue(parent, null);
                    //EditorGUI.LabelField(position, item.name, val.ToString());
                }
                else if (item.type == typeof(bool))
                {
                    bool val = (bool)pi.GetValue(parent, null);
                    //property.boolValue = (bool)pi.GetValue(parent, null);
                    EditorGUI.LabelField(curPosition, item.name, val.ToString());
                    drawNum++;
                    curPosition.y += height;
                }
                else if (item.type == typeof(Vector2))
                {
                    property.vector2Value = (Vector2)pi.GetValue(parent, null);
                }
                else if (item.type == typeof(Vector3))
                {
                    property.vector3Value = (Vector3)pi.GetValue(parent, null);
                }
                else if (item.type == typeof(Vector4))
                {
                    property.vector4Value = (Vector4)pi.GetValue(parent, null);
                }
                else if (item.type == typeof(Quaternion))
                {
                    property.quaternionValue = (Quaternion)pi.GetValue(parent, null);
                }
                else if (item.type == typeof(Rect))
                {
                    property.rectValue = (Rect)pi.GetValue(parent, null);
                }
                else if (item.type == typeof(Bounds))
                {
                    property.boundsValue = (Bounds)pi.GetValue(parent, null);
                }
                else if (item.type == typeof(Color))
                {
                    property.colorValue = (Color)pi.GetValue(parent, null);
                }
                else if (item.type == typeof(AnimationCurve))
                {
                    property.animationCurveValue = (AnimationCurve)pi.GetValue(parent, null);
                }
            }
            else
            {
                //Debug.Log("field:" + item.name+" ");
                FieldInfo fi = type.GetField(item.name);
                //Debug.Log("field:" + fi.Name);
                #region Int64
                if (item.type == typeof(Int64))
                {
                    Int64 val = (Int64)fi.GetValue(parent);
                    EditorGUI.LabelField(curPosition, item.name, val.ToString());
                    drawNum++;
                    curPosition.y += height;
                }
                else if (item.type == typeof(Int64[]))
                {
                    Int64[] val = (Int64[])fi.GetValue(parent);
                    StringBuilder sb = new StringBuilder();

                    foreach (var item2 in val)
                    {
                        sb.Append(item2.ToString() + " | ");
                    }
                    EditorGUI.LabelField(curPosition, item.name, sb.ToString());
                    drawNum++;
                    curPosition.y += height;
                }
                else if (item.type == typeof(List<Int64>))
                {
                    List<Int64> val = (List<Int64>)fi.GetValue(parent);
                    StringBuilder sb = new StringBuilder();

                    foreach (var item2 in val)
                    {
                        sb.Append(item2.ToString() + " | ");
                    }
                    EditorGUI.LabelField(curPosition, item.name, sb.ToString());
                    drawNum++;
                    curPosition.y += height;
                }
                #endregion
                #region Int16
                else if (item.type == typeof(Int16))
                {
                    Int16 val = (Int16)fi.GetValue(parent);
                    EditorGUI.LabelField(curPosition, item.name, val.ToString());
                    drawNum++;
                    curPosition.y += height;
                }
                else if (item.type == typeof(Int16[]))
                {
                    Int16[] val = (Int16[])fi.GetValue(parent);
                    StringBuilder sb = new StringBuilder();

                    foreach (var item2 in val)
                    {
                        sb.Append(item2.ToString() + " | ");
                    }
                    EditorGUI.LabelField(curPosition, item.name, sb.ToString());
                    drawNum++;
                    curPosition.y += height;
                }
                else if (item.type == typeof(List<Int16>))
                {
                    List<Int16> val = (List<Int16>)fi.GetValue(parent);
                    StringBuilder sb = new StringBuilder();

                    foreach (var item2 in val)
                    {
                        sb.Append(item2.ToString() + " | ");
                    }
                    EditorGUI.LabelField(curPosition, item.name, sb.ToString());
                    drawNum++;
                    curPosition.y += height;
                }
                #endregion
                else if (item.type == typeof(IDictionary))
                {
                    IDictionary val = (IDictionary)fi.GetValue(parent);

                    if (val == null)
                    {
                        EditorGUI.LabelField(curPosition, item.name, "null");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        if (val != null)
                        {
                            foreach (var key in val.Keys)
                                sb.Append(key + "=" + val[key] + " | ");
                        }
                        EditorGUI.LabelField(curPosition, item.name, sb.ToString());
                    }

                    drawNum++;
                    curPosition.y += height;
                }
            }
        }
    }
    // Overriding the GetPropertyHeight gives us the possibility to specify the property height
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Twice as high as a default property height
        return base.GetPropertyHeight(property, label) * drawNum;
    }

    private object GetParentObjectOfProperty(string path, object obj)
    {
        string[] fields = path.Split('.');

        // We've finally arrived at the final object that contains the property
        if (fields.Length == 1)
        {
            return obj;
        }

        // We may have to walk public or private fields along the chain to finding our container object, so we have to allow for both
        FieldInfo fi = obj.GetType().GetField(fields[0], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        obj = fi.GetValue(obj);

        // Keep searching for our object that contains the property
        return GetParentObjectOfProperty(string.Join(".", fields, 1, fields.Length - 1), obj);
    }
}
#endif
