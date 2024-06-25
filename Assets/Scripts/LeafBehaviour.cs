using UnityEngine;

public class LeafBehaviour : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }
}
