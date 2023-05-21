using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Float", fileName = "New Scriptable Float")]
public class ScriptableFloat : ScriptableObject
{
    private float _value;
    [SerializeField] private float initialValue = 30f;
    public float Value
    {
        get => _value;
        set => _value = value;
    }
    
    public float InitialValue
    {
        get => initialValue;
    }
    
    public void OnAfterDeserialize()
    {
        _value = initialValue;
    }
}
