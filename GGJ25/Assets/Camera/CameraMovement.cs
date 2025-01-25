using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float movingUpSpeed;

    [SerializeField]
    private float speedIncrease;

    [SerializeField]
    private float timeUntilIncreaseSpeed;

    void Start()
    {
        StartCoroutine(IncreaseMovementSpeed());        
    }

    void FixedUpdate()
    {
        transform.Translate(0, movingUpSpeed * Time.deltaTime, 0);
    }

    //TODO: THIS!!

    IEnumerator IncreaseMovementSpeed()
    {
        for (int i = 0; i < 1000; i++) {
            yield return new WaitForSeconds(timeUntilIncreaseSpeed);
            movingUpSpeed = movingUpSpeed + speedIncrease;
        }
    }
}