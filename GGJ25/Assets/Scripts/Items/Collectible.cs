using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;
    public AudioClip pickUpSound;
    public ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickUp(other);
            ScoreManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    protected virtual void OnPickUp(Collider player)
    {
        if(pickUpSound != null)
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
        }

        if(pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }

        Debug.Log("Collectible picked up!");
    }
}
