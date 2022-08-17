using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
/*
For Parallax background.
https://www.youtube.com/watch?v=IgZQjGyB9zg&list=PLxI_bfnfwf5ISnH12_Sx-0Ucei_O9QJIO&index=7
and comment from: https://www.youtube.com/watch?v=zit45k6CUMk&t
*/
{
    public float scrollSpeed = -3f;
    Vector2 startPos;
    void Start()
    {
        startPos = transform.position;  // sets the position of the object
        // from its instance at the start
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 15.9f);
        // loops the value so that it's never larger than length,
        // parameter is x, y, z, Vector2 represents x, y
        transform.position = startPos + Vector2.up * newPos;
        // new position is the starting position + coordinate (0,1) * loop
    }
}
