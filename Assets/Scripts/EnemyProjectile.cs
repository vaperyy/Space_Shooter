using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
/*
OwnedBy determines where the pink bullets fire from.
*/
{
    public float Speed = 5.0f;
    public float Damage = 5.0f;
    public Entity OwnedBy;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
    }

}
