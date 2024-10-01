using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSinput : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.8f;

    private CharacterController charController;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3 (deltaX, 0, deltaY);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement = transform.TransformDirection(movement) * Time.deltaTime;
        charController.Move(movement);
    }
}
