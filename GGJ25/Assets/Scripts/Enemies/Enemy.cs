using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float playerSpotDistance;
    [SerializeField]
    private float turnCheckDistanceForward;
    [SerializeField]
    private float turnCheckDistanceDown;
    [SerializeField]
    private float patrolSpeed;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float totalMercyTime;
    [SerializeField]
    private GameObject positionChecker;
    [SerializeField]
    private GameObject bubble1;
    [SerializeField]
    private GameObject bubble2;
    [SerializeField]
    private GameObject bouncer;

    private bool isReadyToMove;
    private bool isReadyToTurn;
    private float currentMercyTime;
    private float currentTurnBuffer;
    private float totalTurnBuffer;

    private bool isGummed;

    // Start is called before the first frame update
    void Start()
    {
        isReadyToMove = true;
        totalTurnBuffer = 1;
        bubble1.SetActive(false);
        bubble2.SetActive(false);
        bouncer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGummed)
            GumMode();
        else
        {
            transform.GetComponent<CapsuleCollider>().enabled = true;
            Patrol();
            Aggro();
            CountMercyTime();
        }

        //print("Is ready to move: " + isReadyToMove);
        //print("Current mercy time: " + currentMercyTime);

        //Bubblegum mode
        //Later: Patrol - move left and right
    }

    private void Patrol()
    {
        CheckPosition();

        if (transform.rotation.eulerAngles.y == 90)
        {
            rigidbody.velocity = new Vector3(patrolSpeed, 0, 0);
            //print("Moving right with " + rigidbody.velocity + " speed");
        }
        else if (transform.rotation.eulerAngles.y == 270)
        {
            rigidbody.velocity = new Vector3(-1 * patrolSpeed, 0, 0);
            //print("Moving left with " + rigidbody.velocity + " speed");
        }
        else
        {
            if (transform.rotation.eulerAngles.y < 270 && transform.rotation.eulerAngles.y > 90)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, -90, transform.rotation.z);
            }
            else if (transform.rotation.eulerAngles.y < 90)
                transform.eulerAngles = new Vector3(transform.rotation.x, 90, transform.rotation.z);
        }

        //print("Rotation: " + transform.rotation.eulerAngles.y);
    }

    private void CheckPosition()
    {
        RaycastHit hit;

        if (Physics.Raycast(positionChecker.transform.position, positionChecker.transform.TransformDirection(Vector3.forward), out hit, turnCheckDistanceForward))
        {
            Debug.DrawRay(positionChecker.transform.position, positionChecker.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            //Debug.DrawRay(positionChecker.transform.position, positionChecker.transform.TransformDirection(Vector3.down) * hit.distance, Color.green);

            if (hit.transform.gameObject.tag == "Wall")
            {
                TurnAround();
            }
            else if (hit.transform.gameObject.tag == "Enemy")
            {
                TurnAround();
            }
        }
    }

    private void TurnAround()
    {
        if (!isReadyToTurn)
        {
            if (transform.rotation.eulerAngles.y == 90)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, -90, transform.rotation.z);
            }
            else if (transform.rotation.eulerAngles.y == 270)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 90, transform.rotation.z);
            }
        }
    }

    private void Aggro()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, playerSpotDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.transform.gameObject.tag == "Player" && isReadyToMove)
                Attack(hit.transform.position.x);
        }
    }

    private void Attack(float playerPosition)
    {
        float direction = 0;

        if (playerPosition < transform.position.x)
            direction = -1;
        else if (playerPosition > transform.position.x)
            direction = 1;

        rigidbody.velocity = new Vector3(direction * attackSpeed, 0, 0);
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

    private void GumMode()
    {
        rigidbody.velocity = new Vector3(0,0,0);

        if (transform.rotation.eulerAngles.y < 270 && transform.rotation.eulerAngles.y > 90)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, -90, transform.rotation.z);
        }
        else if (transform.rotation.eulerAngles.y < 90)
            transform.eulerAngles = new Vector3(transform.rotation.x, 90, transform.rotation.z);

        if (transform.rotation.eulerAngles.y == 90)
        {
            print("Bubble 2");
            bubble2.SetActive(true);
        }
        else if (transform.rotation.eulerAngles.y == 270)
        {
            print("Bubble 1");
            bubble1.SetActive(true);
        }

        bouncer.SetActive(true);

        transform.GetComponent<CapsuleCollider>().enabled = false;
        transform.GetChild(3).gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //print("Touched deeply by player");
            isReadyToMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            print("Hit by bullet, ouch");
            isGummed = true;
        }
    }
}
