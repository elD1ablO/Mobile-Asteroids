using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    private void OnTriggerEnter(Collider other)
    {

        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player == null) { return; }

        player.Crash();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
