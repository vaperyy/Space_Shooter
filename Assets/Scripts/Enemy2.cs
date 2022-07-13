using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy2 : Entity
{
    public Weapon[] Weapons;


    public void Fire()
    {
        if (Weapons.Length == 0) return;
        foreach(Weapon weapon in Weapons)
        {
            weapon.Fire();
        }
    }
}
