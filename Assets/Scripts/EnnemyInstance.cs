using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnnemyInstance : MonoBehaviour
{
    // Snippet of a MonoBehaviour that would control motion of a specific vehicle.
    // In PlayMode it accelerates up to the maximum speed permitted by its type

    [Range(0f, 200f)]
    public float m_CurrentSpeed;

    [Range(0f, 50f)]
    public float m_Acceleration;

    // Reference to the ScriptableObject asset
    public EnnemyType m_EnnemyType;

    public void Initialize(EnnemyType ennemyType)
    {
        m_EnnemyType = ennemyType;
        m_CurrentSpeed = 0f;
        m_Acceleration = Random.Range(0.05f, m_EnnemyType.m_MaxSpeed);
    }

    void Update()
    {
        m_CurrentSpeed += m_Acceleration * Time.deltaTime;

        // Use parameter from the ScriptableObject to control the behaviour of the Vehicle
        if (m_EnnemyType && m_EnnemyType.m_MaxSpeed < m_CurrentSpeed)
            m_CurrentSpeed = m_EnnemyType.m_MaxSpeed;

        gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * m_CurrentSpeed;
    }
}

public class ScriptableObjectVehicleExample
{
    [MenuItem("Example/Setup ScriptableObject Vehicle Example")]
    static void MenuCallback()
    {
        EnnemyType ennemy = AssetDatabase.LoadAssetAtPath<EnnemyType>("Assets/VehicleTypeWagon.asset");
        if (ennemy == null)
        {
            // Create and save ScriptableObject because it doesn't exist yet
            ennemy = ScriptableObject.CreateInstance<EnnemyType>();
            ennemy.m_MaxSpeed = 5f;
            ennemy.m_MaxDammage = 0.5f;
            AssetDatabase.CreateAsset(ennemy, "Assets/VehicleTypeWagon.asset");
        }

        // Step 2 - Create some example vehicles in the current scene
        {
            var _ennemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _ennemy.name = "ennemy";
            var ennemyBehaviour = _ennemy.AddComponent<EnnemyInstance>();
            ennemyBehaviour.Initialize(ennemy);
        }
    }
}

