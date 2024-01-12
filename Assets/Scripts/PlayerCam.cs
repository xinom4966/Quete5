using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Camera cam;
    public float sensX;
    public float sensY;
    public Transform orientation;
    public float rotationX, rotationY;
    public MovementState state;
    public enum MovementState
    {
        normal,
        aiming
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
        StateHandler();
        if (state == MovementState.aiming)
        {
            cam.fieldOfView = 30.0f;
        }
        else
        {
            cam.fieldOfView = 60.0f;
        }
        float mouseX = Input.GetAxisRaw("Mouse X")*Time.deltaTime*sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*sensY;

        rotationX -= mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    private void StateHandler()
    {
        if (Input.GetMouseButton(1))
        {
            state = MovementState.aiming;
        }
        else
        {
            state = MovementState.normal;
        }
    }
}
