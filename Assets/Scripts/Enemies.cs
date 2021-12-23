using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// mainly spawns enemy planes
public class Enemies : MonoBehaviour
{
    // any public variable can be edited in UNITY 
    
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
    IEnumerator SpawnWaves() 
    // instantiate enemy planes
    {
        yield return new WaitForSeconds(startWait);

        // for loop allows spawning multiple planes
        while(true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                // spawnValues.y and spawnValues.z borrows values from Unity UI
                // randomly spawn an x value. 
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity; // no rotation
                GameObject ep = Instantiate(enemyPlane, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait); // wait between each plane
            }
            spawnWait -= 0.1f;  // planes get progressively tighter packed each wave
            waveWait -= 0.1f;  // time between waves progressively decreases
            
            yield return new WaitForSeconds(waveWait);
            
        }
    }

}
