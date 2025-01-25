using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float sightDistance;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private float totalMercyTime;

    private bool isReadyToMove;
    private bool isGummed;
    private float currentMercyTime;

    // Start is called before the first frame update
    void Start()
    {
        isReadyToMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Aggro();
        CountMercyTime();

        print("Is ready to move: " + isReadyToMove);
        print("Current mercy time: " + currentMercyTime);

        //Bubblegum mode
        //Later: Patrol - move left and right
    }

    private void Aggro()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, sightDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.transform.gameObject.tag == "Player" && isReadyToMove)
                Move(hit.transform.position.x);
        }
    }

    private void Move(float playerPosition)
    {
        float direction = 0;

        if (playerPosition < transform.position.x)
            direction = -1;
        else if (playerPosition > transform.position.x)
            direction = 1;

        rigidbody.velocity = new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }

    private void CountMercyTime()
    {
        if (!isReadyToMove)
            currentMercyTime += Time.deltaTime;

        if (currentMercyTime >= totalMercyTime)
        {
            isReadyToMove = true;
            currentMercyTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Touched deeply by player");

        if(collision.gameObject.tag == "Player")
            isReadyToMove = false;
    }
}
