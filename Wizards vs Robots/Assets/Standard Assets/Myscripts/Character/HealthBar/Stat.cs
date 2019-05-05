using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField] BarHandler bar;
    [SerializeField] float maxValue;
    float lerpSpeed = 3f;
    float currentValue;

    public BarHandler Bar { get { return bar; }
                            set { bar = value; } }

    public float MaxValue { get { return maxValue; }
                            set { maxValue = value; bar.MaxValue = maxValue; } }

    public float CurrentValue{ get { return currentValue; }
                               set { currentValue = Mathf.Clamp(value, 0, MaxValue); bar.Value = currentValue; } }

    public void Initialize()
    {
        MaxValue = maxValue;
        CurrentValue = maxValue;
    }
}