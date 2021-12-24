using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The Boundary object which deletes all laser objects that leave the player's gameview
to free space in the hierarchy.

*/

public class Boundary : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    /*
    If the boundary collides with another object (only the laser for now),
    it will destroy it.
    */
    {
        Destroy(other.gameObject);
    }
}
