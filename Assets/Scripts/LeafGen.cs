using System.Collections.Generic;
using UnityEngine;

public class LeafGen : MonoBehaviour
{
    float x = 0;
    float y;
    float maxY = 3f;
    public List<GameObject> pyramids;
    [SerializeField] public GameObject pyramid;

    void Start()
    {
        while (x <= 100)
        {
            y = Random.Range(0.2f, maxY) * 10;
            pyramids.Add(Instantiate(pyramid, new Vector3(-1000, y, -1000), transform.rotation));
            pyramids[pyramids.Count - 1].transform.position = new Vector3(-75 + x, y,-20);
            x++;
        }

    }
}
