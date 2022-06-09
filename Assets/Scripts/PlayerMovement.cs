using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forceMagnitude;
    [SerializeField] float maxVelocity;

    Camera mainCamera;
    Rigidbody rb;

    Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }
        
    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        if(moveDirection == Vector3.zero) { return; }

        rb.AddForce(moveDirection * forceMagnitude, ForceMode.Force);
        
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    void Movement()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {            
            //finding position of touch on screen and converting it to units instead of pixels
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            moveDirection = worldPosition - transform.position;
            moveDirection.z = 0f;
            moveDirection.Normalize();
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }
}
