using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
/*
Specifies movement of the LASER projectile, (not enemy planes or enemy bullets) as well as self destructing once hitting an object,
destroying enemy planes at the same time.
*/
    public Vector3 direction;
    public float speed;

    private void Update()
    /*
    this transforms the laser, using a Vector3, so that it moves. 
    shoots in the direction specified by the position in Unity UI (Projectile Script)
    */
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    /* 
    Once the laser projectile enters the area of an enemy plane, both objects are simultaneously destroyed.
    
    NOTE: OnTriggerEnter2D only works once you implement a box collider for objects involved, 
    as well as check the checkbox for trigger
    */
    
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("EnemyPlane")) && (this.gameObject.layer == LayerMask.NameToLayer("Laser")))
        /*
        if the other gameObject's layer is an EnemyPlane, which identifies it as an enemy plane, 
        then destroy it. This avoids destroying the boundary which the laser will come into contact with a lot.
        this requires setting the enemy plane prefab to an EnemyPlane layer.
        */
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
        }
    }
}
