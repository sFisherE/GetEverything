using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
class Test : MonoBehaviour
{
    [SerializeField, GetEverything(@"int endFrame
                                    |int destroyFrame
                                    |IDictionary dic
                                    |Int64 _int64
                                    |Int64[] _int64Array
                                    |List<Int64> _int64List
                                    |Int16 _int16")]
    int getEverything;

    public int endFrame
    {
        get { return 2; }
    }
    public int destroyFrame
    {
        get { return 1; }
    }
    public Int64 _int64 = 1000;
    public Int64[] _int64Array = new Int64[2]{1,2};

    public List<Int64> _int64List = new List<Int64> { 2, 3 };

    public Int16 _int16;
    public Int32 _int;
    public byte _byte;

    public Dictionary<string, int> dic;

    void Awake()
    {
        dic = new Dictionary<string, int>();
        dic.Add("key1", 1);
        dic.Add("key2", 2);
    }
}
