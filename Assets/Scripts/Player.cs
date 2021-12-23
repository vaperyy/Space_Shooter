using UnityEngine;

// controls player plane, such as moving and shooting
public class Player : MonoBehaviour
{
    public Projectile laserPrefab;
    public float speed = 5.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += Vector3.up * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += Vector3.down * this.speed * Time.deltaTime;
        }

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
    
}
