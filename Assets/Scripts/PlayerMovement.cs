using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Ship velocity")]
    [Tooltip("How much a long touch inflicts velocity")]
    [SerializeField] float forceMagnitude;
    [Tooltip("Maximum velocity")]
    [SerializeField] float maxVelocity;

    [Header("ShipRotation")]
    [SerializeField] float rotationSpeed;


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
        KeepPlayerOnScreen();
        RotateForward();
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
    void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        else if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;
    }

    void RotateForward()
    {
        if(rb.velocity == Vector3.zero) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
