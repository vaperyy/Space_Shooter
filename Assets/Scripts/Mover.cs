using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// moves enemy planes
public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody2D enemyPlane;
    private void Awake()
    // uses the velocity of the Rigidbody in order to move the plane
    {
        enemyPlane = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    // use velocity instead of AddForce in order to move it at a constant rate
    // FixedUpdate is specifically for physics as opposed to just Update()
    {
        enemyPlane.velocity = new Vector3(0f, -1f, 0f) * this.speed * Time.deltaTime;
        // Vector points downward with coordinates. 
    }
}
