using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{

    private GameObject player;
    private Rigidbody playerRB;

    [SerializeField]
    private float bouncePower;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && playerRB.velocity.y < 0)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, playerRB.velocity.z);
            playerRB.AddForce(new Vector3(playerRB.velocity.x, bouncePower, playerRB.velocity.z));
            Debug.Log("Bounce");

            Destroy(transform.parent.transform.parent.gameObject);
        }
    }
}
