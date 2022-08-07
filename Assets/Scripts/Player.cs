using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Player : MonoBehaviour
/*
Controls player plane, such as moving and shooting
https://www.youtube.com/watch?v=tFblCEFQoTs
*/
{
    private float timer;
    private int score;
    public Text scoreText;
    public Projectile laserPrefab;
    public float moveSpeed = 5.0f;
    public Rigidbody2D rb;  // adding a Rigidbody assigns physics properties to the sprite
    private Vector2 moveInput;
    public static Player main;

    private void Awake()
    {
        main = this;  // set main so that bullets know where to try to hit.
    }

    private void Start()
    {
        PlayerPrefs.SetString("currentScore", "0");
    }

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");  // GetAxis is more sensitive comparatively.

        moveInput.Normalize();  // ensures uniform speed; makes a vector magnitude 1
        rb.velocity = moveInput * moveSpeed;  // moveInput is V2 * moveSpeed which is V1 which makes a 3D Vector

        timer += Time.deltaTime;
        if(timer >= 0.07)
        {
            Shoot();
            timer = 0;
        }
        // or to enable manual shooting...
        // if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        // {
        //     Shoot();
        // }
    }

    void Shoot()
    /* 
    for instantiating the (Projectile-attached) laser prefab
    */
    {

        // instantiate the projectile at the position and rotation of this transformation
        // this.transform.position locates the GameObject in 3d world space
        // Quaternion.identity represents no rotation needed, object is perfectly aligned with world axises
        Projectile instance = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);

        score++;
        scoreText.text = "" + score;  // not just for the below code but also display in UI
    }

    void OnTriggerEnter2D(Collider2D other)
    /* 
    Just like in projectile except for the shooter and an enemy plane

    NOTE: OnTriggerEnter2D only works once you implement a box collider for objects involved, 
    as well as check the checkbox for trigger
    */
    
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("EnemyPlane") || other.gameObject.layer == LayerMask.NameToLayer("EnemyLaser")) && 
        (this.gameObject.layer == LayerMask.NameToLayer("Shooter")))
        {
            PlayerPrefs.SetString("currentScore", scoreText.text);
            SceneManager.LoadScene("Game Over");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
