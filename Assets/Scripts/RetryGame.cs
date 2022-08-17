using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
/* 
Simply reloads the main scene.
*/
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
    }
}
