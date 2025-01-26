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
        Debug.Log(random);
        Debug.Log(sfx[random].clip.name.ToString());

        sfx[random].PlayOneShot(sfx[random].clip);
    }

    public void PlayEnemyHitPlayerSound()
    {
        randomHit = Random.Range(0, 2);
        Debug.Log(randomHit);
        Debug.Log(Hit_sfx[randomHit].clip.name.ToString());

        Hit_sfx[randomHit].PlayOneShot(Hit_sfx[randomHit].clip);
    }

    public void PlayGun()
    {
        randomGun = Random.Range(0, 2);
        Debug.Log(randomGun);
        Debug.Log(gun_sfx[randomGun].clip.name.ToString());

        gun_sfx[randomHit].PlayOneShot(gun_sfx[randomHit].clip);
    }

    
}
