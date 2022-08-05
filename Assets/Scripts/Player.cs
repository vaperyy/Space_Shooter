using UnityEngine;

// controls player plane, such as moving and shooting
public class Player : MonoBehaviour
/*
https://www.youtube.com/watch?v=tFblCEFQoTs

*/
{

    public GameOverScreen GameOverScreen;  // game over screen from that class
    int maxPlatform = 0;  // also new




    public Projectile laserPrefab;
    public float moveSpeed = 5.0f;
    public Rigidbody2D rb;  // adding a Rigidbody assigns physics properties to the sprite
    private Vector2 moveInput;

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");  // returns the value 
        // of the virtual axis identified by the Horizontal axis.
        moveInput.y = Input.GetAxisRaw("Vertical");  // GetAxis is more sensitive

        moveInput.Normalize();  // makes a vector have a magnitude of 1
        // ensures uniform speed

        rb.velocity = moveInput * moveSpeed;  // the player should travel like this
        // v2 * moveSpeed = v3, rb.velocity is a vector3

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    // for instantiating the (Projectile-attached) laser prefab
    {
        // instantiate the projectile at the position and rotation of this transformation
        // this.transform.position locates the GameObject in 3d world space
        // Quaternion.identity represents no rotation needed, object is perfectly aligned with world axises
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }



    void OnTriggerEnter2D(Collider2D other)
    /* 
    Just like in projectile except for the shooter and an enemy plane

    NOTE: OnTriggerEnter2D only works once you implement a box collider for objects involved, 
    as well as check the checkbox for trigger
    */
    
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyPlane")) 
        {
            // GameOverScreen.Setup(maxPlatform);
            // Destroy(other.gameObject);
        }
        // Destroy(this.gameObject);
    }
    
}
