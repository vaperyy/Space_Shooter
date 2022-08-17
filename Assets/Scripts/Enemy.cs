using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
/*
Fires a weapon (pink bullets) and inherits OwnedBy from Entity to pinpoint firing bullets from red enemy planes.
*/
{
    public Weapon[] Weapons;
    public void Disappear()
    {
        Destroy(gameObject);
    }

    public void Fire()
    {
        if (Weapons.Length == 0) return;
        foreach(Weapon weapon in Weapons)
        {
            weapon.Fire();
        }
    }
}
