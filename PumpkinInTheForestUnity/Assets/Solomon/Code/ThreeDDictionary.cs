using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ThreeDDictionary<T, B, S>
{
    public List<T> key;
    public List<B> Value1;
    public List<S> Value2;

    [HideInInspector] public int Count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Add(T newKey, B newValue1, S newValue2)
    {
        key.Add(newKey);
        Value1.Add(newValue1);
        Value2.Add(newValue2);
        Count++;
    }

    void Remove(T removeKey, B removeValue1, S removeValue2)
    {
        for (int i = 0; i < key.Count; i++)
        {
            if (removeKey.Equals(key[i]))
            {
                key.RemoveAt(i);
                Value1.RemoveAt(i);
                Value2.RemoveAt(i);
                Count--;
                break;
            }
        }
    }

    ThreeDDictionary<T, B, S> At(T key)
    { }


}
