using UnityEngine;
using UnityEngine.UI;

/*
Specifies movement of the laser projectile, as well as self destructing once hitting an object,
destroying enemy planes at the same time.

*/

public class Projectile : MonoBehaviour
{
    public Text scoreText;
    static int score;
    // With static, each projectile object no longer have their own score (instances). The class would have ownership 
    // of the score variable and do changes as necessary, and all projectile objects would now show the score. 

    // this past bug was only because I had to bring out the laser prefab to the scene hiearchy 
    // just to work with putting the projectile script and Text object inside the prefab. 
    // and the laser prefab had a default, unchanging value of 0 in the scene. 

    public Vector3 direction;
    public float speed;

    public void Start()
    {

    }

    private void Update()
    // this transforms the laser, using a Vector3, so that it moves. 
    // shoots in the direction specified by the position in Unity UI (Projectile Script)
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    /* 
    Once the laser projectile enters the area of an object, either an enemy plane or boundary,
    it will, depending on whether it's an enemy plane or boundary, either:
    Destroy the enemy plane and the laser itself 
    or just destroy the laser itself
    
    NOTE: OnTriggerEnter2D only works once you implement a box collider for objects involved, 
    as well as check the checkbox for trigger
    */

        
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyPlane")) // returns the layer index to see if it matches the gameObject's layer index
        // if the other gameObject's layer is an EnemyPlane, which identifies it as an enemy plane, 
        // then destroy it. This avoids destroying the boundary which the laser will come into contact with a lot.
        // so this requires setting the enemy plane prefab to an EnemyPlane layer.
        {
            Destroy(other.gameObject);
            score += 1;
            scoreText.text = "" + score;  // not just for the below code but also display in UI


        }
        Destroy(this.gameObject);
        // MonoBehavior automatically assigns gameObject to each class.



    }
}
