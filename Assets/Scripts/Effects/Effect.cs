using System;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField, TextArea(1, 3)] public string Description { get; protected set; }
    [field: SerializeField] public Sprite Sprite { get; protected set; }
    [field: SerializeField] public int Level { get; protected set; } = -1;

    public virtual void Activate()
    {
        Level++;
    }
}
