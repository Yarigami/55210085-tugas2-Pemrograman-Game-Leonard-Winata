using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    public RotationAxes axes = RotationAxes.MouseXY;
    public float sensitivityHorizontal = 2.0f;
    public float sensitivityVertical = 2.0f;

    public float minVertical = -45.0f;
    public float maxVertical = 45.0f;

    private float verticalRotate = 0;

    // Use this for initialization
    void Start()
    {
        // If there's a Rigidbody, freeze its rotation to prevent the physics system from changing the rotation
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }

        // Lock the cursor to the game screen for a better FPS experience
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            // Horizontal rotation (Yaw)
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorizontal, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            // Vertical rotation (Pitch)
            verticalRotate -= Input.GetAxis("Mouse Y") * sensitivityVertical;
            verticalRotate = Mathf.Clamp(verticalRotate, minVertical, maxVertical);

            float horizontalRotate = transform.localEulerAngles.y; // Keep the horizontal rotation unchanged
            transform.localEulerAngles = new Vector3(verticalRotate, horizontalRotate, 0);
        }
        else
        {
            // Both horizontal and vertical rotation
            verticalRotate -= Input.GetAxis("Mouse Y") * sensitivityVertical;
            verticalRotate = Mathf.Clamp(verticalRotate, minVertical, maxVertical);

            float delta = Input.GetAxis("Mouse X") * sensitivityHorizontal;
            float horizontalRotate = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRotate, horizontalRotate, 0);
        }
    }
}
