using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpPower;

    private float moveX;

    [SerializeField]
    private Rigidbody rb;

    private bool grounded;

    [SerializeField]
    private GameObject ammoSpawnpointFront;

    [SerializeField]
    private GameObject ammoSpawnpointUp;

    [SerializeField]
    private GameObject ammoSpawnpointDown;

    [SerializeField]
    private GameObject ammoSpawnpointDownFront;

    [SerializeField]
    private GameObject ammoSpawnpointUpFront;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float fallSpeed;

    [SerializeField]
    private float reloadTimer;

    [SerializeField]
    private float reloaded;

    private float coyoteTimer;

    [SerializeField]
    private float coyoteMaxTime;

    private bool Jumped;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        reloadTimer += Time.deltaTime;

        coyoteTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow) && grounded == true)
        {
            rb.velocity = new Vector3(moveX + speed * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && grounded == true)
        {
            rb.velocity = new Vector3(moveX - speed * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 180, this.transform.rotation.z);
        }

        

        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && grounded == true)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.Z) && grounded == true && Jumped == false || Input.GetKeyDown(KeyCode.Space) && grounded == true && Jumped == false)
        {
            rb.AddForce(new Vector3(rb.velocity.x, jumpPower, rb.velocity.z));
            coyoteTimer = 0;
            Jumped = true;
        }

        if(reloadTimer >= reloaded)
        {
            if (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)
             || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)
             || Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)
             || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                GameObject Ammo = ObjectPool.SharedInstance.GetAmmo();
                Ammo.transform.position = ammoSpawnpointDownFront.transform.position;
                Ammo.transform.rotation = ammoSpawnpointDownFront.transform.rotation;
                Ammo.transform.localScale = transform.localScale / 2;
                Ammo.SetActive(true);
                reloadTimer = 0;
            }

            else if (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)
                || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)
                || Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)
                || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                GameObject Ammo = ObjectPool.SharedInstance.GetAmmo();
                Ammo.transform.position = ammoSpawnpointUpFront.transform.position;
                Ammo.transform.rotation = ammoSpawnpointUpFront.transform.rotation;
                Ammo.transform.localScale = transform.localScale / 2;
                Ammo.SetActive(true);
                reloadTimer = 0;
            }

            else if (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.UpArrow))
            {
                GameObject Ammo = ObjectPool.SharedInstance.GetAmmo();
                Ammo.transform.position = ammoSpawnpointUp.transform.position;
                Ammo.transform.rotation = ammoSpawnpointUp.transform.rotation;
                Ammo.transform.localScale = transform.localScale / 2;
                Ammo.SetActive(true);
                reloadTimer = 0;
            }

            else if (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.DownArrow))
            {
                GameObject Ammo = ObjectPool.SharedInstance.GetAmmo();
                Ammo.transform.position = ammoSpawnpointDown.transform.position;
                Ammo.transform.rotation = ammoSpawnpointDown.transform.rotation;
                Ammo.transform.localScale = transform.localScale / 2;
                Ammo.SetActive(true);
                reloadTimer = 0;

            }

            else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftControl))
            {
                GameObject Ammo = ObjectPool.SharedInstance.GetAmmo();
                Ammo.transform.position = ammoSpawnpointFront.transform.position;
                Ammo.transform.rotation = ammoSpawnpointFront.transform.rotation;
                Ammo.transform.localScale = transform.localScale/2;
                Ammo.SetActive(true);
                reloadTimer = 0;
            }
            
        }


        

        if(grounded == false && rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - fallSpeed, rb.velocity.z);
        }

        if(Jumped == true && coyoteTimer > coyoteMaxTime)
        {
            grounded = false;
        }



    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            grounded = true;
            Jumped = false;
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            
            coyoteTimer = 0;
        }
    }
}
