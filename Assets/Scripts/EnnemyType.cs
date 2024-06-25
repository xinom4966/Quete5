using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnnemyType : ScriptableObject
{
    [Range(0.1f, 100f)]
    public float m_MaxSpeed = 0.1f;

    [Range(0.1f, 10f)]
    public float m_MaxDammage = 0.1f;
}
