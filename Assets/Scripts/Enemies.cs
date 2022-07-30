using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Spawns enemy planes during each wave. Also displays "Wave #x" between each wave. 

*/

public class Enemies : MonoBehaviour


{

    public Enemy2 SimpleEnemy;
    public Enemy2 SimpleEnemyOpposite;
    public Enemy2 ShooterEnemyLeft;
    public Enemy2 ShooterEnemyRight;
    public Enemy2 ShooterSideScroller;



    public Text waveWarning;
    public string waveWarn;  // for convenience in altering the message in Inspector
    public GameObject enemyPlane;  // change this to a class?
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait; // time between each spawn
    public float startWait; // delayed time before start
    public float waveWait;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }
    public IEnumerator SpawnWaves() 
    /*
    Instantiates enemy planes in a predictable, boring way. 
    */

    {
        yield return new WaitForSeconds(startWait);

        int j = 0;  // iterator for displaying "Wave #x"
        
        while(true)
        // for loop allows spawning multiple planes
        {
            j++;
            waveWarn = "Wave " + j;
            StartCoroutine(Warning());

            yield return new WaitForSeconds(waveWait);
            // returning an instance of the wait for seconds class, which delays the proceeding code

            for (int i = 0; i < enemyCount; i++)
            {
                // spawnValues.y and spawnValues.z borrows values from Unity UI
                // randomly spawn an x value. 
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity; // no rotation
                GameObject ep = Instantiate(enemyPlane, spawnPosition, spawnRotation);


                yield return new WaitForSeconds(spawnWait); // wait between each plane
            }

            yield return StartSequence();

            spawnWait -= 0.1f;  // planes get progressively tighter packed each wave
            waveWait -= 0.1f;  // time between waves progressively decreases

        }
    }

    IEnumerator Warning()
    /*
    Displays a blinking text message, "Wave #x".
    The advantage of containing it in a method 
    is that it doesn't interfere with the custom spawnWait time we set
    */
    {
        waveWarning.text = waveWarn;

        for (int k = 0; k < 3; k++)
        {
            yield return new WaitForSeconds(0.3f);
            waveWarning.enabled = true;
            yield return new WaitForSeconds(0.3f);
            waveWarning.enabled = false;
        }
    }



    public IEnumerator SpawnSimple(Enemy2 enemy, float wait, int amount)
    {
        for (int t = 0; t < amount; t++)
        {
            yield return new WaitForSeconds(wait);
            Enemy2 anEnemy = Instantiate(enemy);
        }
    }

    
    public IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(4.0f);
        StartCoroutine(SpawnSimple(SimpleEnemy, 0.2f, 10));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SpawnSimple(SimpleEnemyOpposite, 0.2f, 10));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnSimple(ShooterEnemyLeft, 0.2f, 1));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnSimple(ShooterEnemyRight, 0.2f, 1));
        StartCoroutine(SpawnSimple(ShooterSideScroller, 0.2f, 10));
        yield return new WaitForSeconds(4.0f);

    }


}


