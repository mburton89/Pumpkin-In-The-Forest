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
        if ((key.Count > Value1.Count) || (key.Count < Value1.Count))
        {
            key.Clear();
            Value1.Clear();
            Value2.Clear();
        }
        else if ((key.Count > Value2.Count) || (key.Count < Value2.Count))
        {
            key.Clear();
            Value1.Clear();
            Value2.Clear();
        }
    }

    void Add(T newKey, B newValue1, S newValue2)
    {
        key.Add(newKey);
        Value1.Add(newValue1);
        Value2.Add(newValue2);
        Count++;
    }

    void Remove(T removeKey)
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

    T AtIndexKey(int index)
    {
        T tempValue = default(T);

        for (int i = 0; i < key.Count; i++)
        {
            if (i == index)
            {
                tempValue = key[i];
            }
        }

        return tempValue;
    }

    B AtFirst(T getKey)
    {
        B tempValue = default(B);

        for (int i = 0; i < key.Count; i++)
        {
            if (getKey.Equals(key[i]))
            {
                tempValue = Value1[i];
                break;
            }
        }
        
        return tempValue;
    }

    B AtIndexFirst(int index)
    {
        B tempValue = default(B);

        for (int i = 0; i < key.Count; i++)
        {
            if (i == index)
            {
                tempValue = Value1[i];
                break;
            }
        }

        return tempValue;
    }

    S AtSecond(T getKey)
    {
        S tempValue = default(S);

        for (int i = 0; i < key.Count; i++)
        {
            if (getKey.Equals(key[i]))
            {
                tempValue = Value2[i];
                break;
            }
        }

        return tempValue;
    }

    S AtIndexSecond(int index)
    {
        S tempValue = default(S);

        for (int i = 0; i < key.Count; i++)
        {
            if (i == index)
            {
                tempValue = Value2[i];
                break;
            }
        }

        return tempValue;
    }

    void SetFirst(T getKey, B value)
    {
        for (int i = 0; i < key.Count; i++)
        {
            if (getKey.Equals(key[i]))
            {
                Value1[i] = value;
                break;
            }
        }
    }

    void SetSecond(T getKey, S value)
    {
        for (int i = 0; i < key.Count; i++)
        {
            if (getKey.Equals(key[i]))
            {
                Value2[i] = value;
                break;
            }
        }
    }

    void Clear()
    {
        key.Clear();
        Value1.Clear();
        Value2.Clear();
    }
    
}
