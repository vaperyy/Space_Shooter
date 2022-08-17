using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
/*
Instantiate enemy bullets from red enemy planes.
*/
{
    public EnemyProjectile EnemyProjectile;
    public Entity Parent;
    public float FireRate = 0;
    public float _cooldown;
    public AudioClip FireSound;
    public float FireVolume;

    public virtual void Fire()
    {
        // if (_cooldown > 0) return;
        EnemyProjectile newProjectile = Instantiate(EnemyProjectile, transform.position, Parent.transform.rotation);
        newProjectile.OwnedBy = Parent;
        _cooldown = FireRate;
        // StartCoroutine(DestroyOverSeconds(5.0f, newProjectile.gameObject));
        PlaySound();
    }

    public void PlaySound()
    {
        if (FireSound == null) return;
        GameObject newAC = new GameObject();
        AudioSource audioSource = newAC.AddComponent<AudioSource>();
        audioSource.volume = FireVolume;
        audioSource.PlayOneShot(FireSound);
        // StartCoroutine(DestroyOverSeconds(FireSound.length + 0.1f, newAC));
    }
}
