using System;
using UnityEngine;

[Serializable]
public struct MinMaxNumber
{
    [field:SerializeField] public float Min { get; private set; }
    [field:SerializeField] public float Max { get; private set; }

    public void SetMinValue(float newValue)
    {
        Min = newValue;
    }
    
    public void SetMaxValue(float newValue)
    {
        Max = newValue;
    }
}
