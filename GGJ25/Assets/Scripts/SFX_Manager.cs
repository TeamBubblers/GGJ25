using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{

    [SerializeField]
    private AudioSource[] sfx;


    [SerializeField]
    private AudioSource[] Hit_sfx;

    [SerializeField]
    private AudioSource[] gun_sfx;


    private int random;

    private int randomHit;

    private int randomGun;

    public void PlayRandmomJumpSound()
    {
        random = Random.Range(0, 11);

        sfx[random].PlayOneShot(sfx[random].clip);
    }

    public void PlayEnemyHitPlayerSound()
    {
        randomHit = Random.Range(0, 2);

        Hit_sfx[randomHit].PlayOneShot(Hit_sfx[randomHit].clip);
    }

    public void PlayGun()
    {
        randomGun = Random.Range(0, 2);

        gun_sfx[randomHit].PlayOneShot(gun_sfx[randomHit].clip);
    }

    
}
