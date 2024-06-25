using UnityEngine;

public class MoveWeapon : MonoBehaviour
{
    public Transform weaponPos;

    void Update()
    {
        transform.position = new Vector3(weaponPos.position.x, weaponPos.position.y, weaponPos.position.z - 1);
    }
}
