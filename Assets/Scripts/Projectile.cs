using UnityEngine;

// controls movement of the laser
public class Projectile : MonoBehaviour
{

    public Vector3 direction;
    public float speed;

    private void Update()
    // this transforms the laser, using a Vector3, so that it moves. 
    // shoots in the direction specified by the position in Unity UI (Projectile Script)
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    // OnTriggerEnter2D works once you implement a box collider for both
    // objects as well as check the trigger
    {
        // MonoBehavior automatically assigns gameObject to each class. 
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
