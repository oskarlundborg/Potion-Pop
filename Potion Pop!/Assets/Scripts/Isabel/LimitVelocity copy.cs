using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitVelocity : MonoBehaviour
{
    [SerializeField] private float terminalVelocity = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.magnitude > terminalVelocity) {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, terminalVelocity);
        }
    }
}
