using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{

    [SerializeField]
    private AudioSource[] sfx;

    private int random;

    public void PlayRandmomJumpSound()
    {
        random = Random.Range(0, 11);
        Debug.Log(random);

        sfx[random].PlayOneShot(sfx[random].clip);
    }
}
