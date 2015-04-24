using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
//支持类型
//int
//float
//bool
//string

//Vector2
//Vector3
//Vector4

//Quaternion
//Rect

//Bounds
//Color
//AnimationCurve

/// <summary>
///   1个类只有这一个就行了吧，通过这个SerializeField取获取类的所有信息，然后画出来
/// </summary>
/// 

public class BaseWrapper
{
    public string name;
    public Type type;

    public BaseWrapper(string name, string typeName)
    {
        this.name = name;
        switch (typeName)
        {
            case "int":
                type = typeof(int);
                break;
            case "float":
                type = typeof(float);
                break;
            case "string":
                type = typeof(string);
                break;
            case "bool":
                type = typeof(bool);
                break;
            case "Vector2":
                break;
            case "Vector3":
                break;
            case "Vector4":
                break;
            case "Quaternion":
                break;
            case "Rect":
                break;
            case "Bounds":
                break;
#region Int16
            case "Int16":
                type = typeof(Int16);
                break;
            case "Int16[]":
                type = typeof(Int16[]);
                break;
            case "List<Int16>":
                type = typeof(List<Int64>);
                break;
#endregion
#region Int64
            case "Int64":
                type = typeof(Int64);
                break;
            case "Int64[]":
                type = typeof(Int64[]);
                break;
            case "List<Int64>":
                type = typeof(List<Int64>);
                break;
#endregion
#region Dictionary
            case "IDictionary":
                type = typeof(IDictionary);
                break;
#endregion
        }
    }
}
public class GetEverythingAttribute : PropertyAttribute
{
    public List<BaseWrapper> wrappers = new List<BaseWrapper>();

    public GetEverythingAttribute(string desc)
    {
        string[] fields = desc.Split('|');
        foreach (var item in fields)
        {
            string[] vals = item.Split(' ');
            //if (vals.Length != 2)
            //{
            //    Debug.LogError("属性描述错误");
            //    continue;
            //}
            string type = vals[0].Trim();
            string field = vals[1].Trim();

            BaseWrapper wrapper = new BaseWrapper(field, type);

            wrappers.Add(wrapper);
        }
    }


}
