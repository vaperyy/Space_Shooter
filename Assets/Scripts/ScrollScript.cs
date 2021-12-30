using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
https://www.youtube.com/watch?v=IgZQjGyB9zg&list=PLxI_bfnfwf5ISnH12_Sx-0Ucei_O9QJIO&index=7

and comment from: https://www.youtube.com/watch?v=zit45k6CUMk&t


*/
public class ScrollScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed = -3f;
    Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 15.9f);
        transform.position = startPos + Vector2.up * newPos;
    }
}
