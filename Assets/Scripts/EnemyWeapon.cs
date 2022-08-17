using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Weapon
/*
Instantiates bullets from Parent OwnedBy (red enemy planes).
*/
{
    public override void Fire()
    {
        // if (_cooldown > 0) return;
        EnemyProjectile newProjectile = Instantiate(EnemyProjectile, transform.position, Parent.transform.rotation);
        Vector3 diff = Player.main.transform.position - newProjectile.transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        newProjectile.transform.eulerAngles = new Vector3(0, 0, rot_z - 90);
        newProjectile.OwnedBy = Parent;
        _cooldown = FireRate;
        // StartCoroutine(DestroyOverSeconds(5.0f, newProjectile.gameObject));
        PlaySound();
    }
}
