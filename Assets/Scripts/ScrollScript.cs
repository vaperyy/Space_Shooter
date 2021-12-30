using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    // Start is called before the first frame update
    float scrollSpeed = -3f;
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
