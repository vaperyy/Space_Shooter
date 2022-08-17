using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The Boundary object which deletes all objects that touch it except for the main shooter plane (controlled by the player)
to free space in the hierarchy.
*/

public class Boundary : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Shooter"))
        {
            Destroy(other.gameObject);
        }
    }
}
