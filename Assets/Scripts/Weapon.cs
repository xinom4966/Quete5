using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;
    public float rotationX, rotationY;
    public MovementState state;
    public enum MovementState
    {
        normal,
        shooting
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotationX -= mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        StateHandler();
        Shoot();
    }

    private void StateHandler()
    {
        if (Input.GetMouseButton(0))
        {
            state = MovementState.shooting;
        }
        else
        {
            state = MovementState.normal;
        }
    }

    private void Shoot()
    {
        if (state == MovementState.shooting)
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position + orientation.forward, orientation.forward, Color.red, 5f);
            if (Physics.Raycast(transform.position + orientation.forward, orientation.forward, out hit, 300f))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.velocity += orientation.forward*10;
                }
            }
            state = MovementState.normal;
        }
    }
}
