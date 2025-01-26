using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;
    //public AudioClip pickUpSound;
    public ParticleSystem pickupEffect;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickUp(other);
            ScoreManager.Instance.AddScore(scoreValue);
            //Destroy(gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    protected virtual void OnPickUp(Collider player)
    {
        //if(pickUpSound != null)
        //{
            audioSource.PlayOneShot(audioSource.clip);
        //}

        /*if(pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }*/

        Debug.Log("Collectible picked up!");
    }
}
