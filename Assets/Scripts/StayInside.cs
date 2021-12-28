using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
/*
https://www.youtube.com/watch?v=CFf2woe4gdg

*/
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.8f, 2.8f),
            Mathf.Clamp(transform.position.y, -5f, 5f));
            // clamps the y values by -5, 5
            // the overall position represented by Vector2 restricts the 2d space
    }
}
