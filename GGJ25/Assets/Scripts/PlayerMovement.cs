using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedInAir;
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

    private bool isStunned;

    [SerializeField]
    private float totalStunTime;
    private float currentStunTime;

    [SerializeField]
    private float knockBackForce;

    [SerializeField]
    private SFX_Manager sfxManager;

    [SerializeField]
    private AudioSource levitation;

    // Start is called before the first frame update
    void Start()
    {
        //currentStunTime = totalStunTime;

    }

    private void FixedUpdate()
    {
        if (!isStunned)
        {
            moveX = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.RightArrow) && grounded == true)
            {
                rb.velocity = new Vector3(moveX * speed, rb.velocity.y, rb.velocity.z);
                this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);

                //transform.Translate(new Vector3(moveX, 0, 0) * speed * Time.deltaTime);
                //this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);
                levitation.volume = 0.5f;

            }

            else if (Input.GetKey(KeyCode.LeftArrow) && grounded == true)
            {
                rb.velocity = new Vector3(moveX * speed, rb.velocity.y, rb.velocity.z);
                this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 180, this.transform.rotation.z);
                //transform.Translate(new Vector3(moveX, 0, 0) * speed * Time.deltaTime * -1);
                //this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 180, this.transform.rotation.z);
                levitation.volume = 0.5f;
            }

            else if (Input.GetKey(KeyCode.RightArrow) && grounded == false && Jumped == true)
            {

                rb.velocity = new Vector3(moveX * speedInAir, rb.velocity.y, rb.velocity.z);
                this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);

                //transform.Translate(new Vector3(moveX, 0, 0) * speedInAir * Time.deltaTime);
                //this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);
                levitation.volume = 0.5f;
            }

            else if (Input.GetKey(KeyCode.LeftArrow) && grounded == false && Jumped == true)
            {

                rb.velocity = new Vector3(moveX * speedInAir, rb.velocity.y, rb.velocity.z);
                this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 180, this.transform.rotation.z);

                //transform.Translate(new Vector3(moveX, 0, 0) * speedInAir * -1);
                //this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 180, this.transform.rotation.z);
                levitation.volume = 0.5f;
            }



            else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && grounded == true && Jumped == false)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                levitation.volume = 0;
            }
        }
    }



        // Update is called once per frame
        void Update()
    {
        if (!isStunned)
        {
            

            reloadTimer += Time.deltaTime;

            coyoteTimer += Time.deltaTime;

            

            if (Input.GetKeyDown(KeyCode.Z) && grounded == true && Jumped == false || Input.GetKeyDown(KeyCode.Space) && grounded == true && Jumped == false)
            {
                rb.AddForce(new Vector3(rb.velocity.x, jumpPower, rb.velocity.z));
                coyoteTimer = 0;
                Jumped = true;
                sfxManager.PlayRandmomJumpSound();
            }

            if (reloadTimer >= reloaded)
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
                    sfxManager.PlayGun();
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
                    sfxManager.PlayGun();
                }

                else if (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.UpArrow))
                {
                    GameObject Ammo = ObjectPool.SharedInstance.GetAmmo();
                    Ammo.transform.position = ammoSpawnpointUp.transform.position;
                    Ammo.transform.rotation = ammoSpawnpointUp.transform.rotation;
                    Ammo.transform.localScale = transform.localScale / 2;
                    Ammo.SetActive(true);
                    reloadTimer = 0;
                    sfxManager.PlayGun();
                }

                else if (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.DownArrow))
                {
                    GameObject Ammo = ObjectPool.SharedInstance.GetAmmo();
                    Ammo.transform.position = ammoSpawnpointDown.transform.position;
                    Ammo.transform.rotation = ammoSpawnpointDown.transform.rotation;
                    Ammo.transform.localScale = transform.localScale / 2;
                    Ammo.SetActive(true);
                    reloadTimer = 0;
                    sfxManager.PlayGun();

                }

                else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftControl))
                {
                    GameObject Ammo = ObjectPool.SharedInstance.GetAmmo();
                    Ammo.transform.position = ammoSpawnpointFront.transform.position;
                    Ammo.transform.rotation = ammoSpawnpointFront.transform.rotation;
                    Ammo.transform.localScale = transform.localScale / 2;
                    Ammo.SetActive(true);
                    reloadTimer = 0;
                    sfxManager.PlayGun();
                }

                

            }




            if (grounded == false && rb.velocity.y < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - fallSpeed, rb.velocity.z);
            }

            if (Jumped == true && coyoteTimer > coyoteMaxTime)
            {
                grounded = false;
            }
        }
        else
        {
            print("Stunned!");
            currentStunTime += Time.deltaTime;
            if (currentStunTime >= totalStunTime)
            {
                isStunned = false;
                currentStunTime = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            grounded = true;
            Jumped = false;            
        }

        if (collision.gameObject.tag == "Enemy")
        {
            print("Touched by enemy");
            isStunned = true;

            float playerPosition = collision.transform.position.x;
            float direction = 0;

            if (playerPosition < transform.position.x)
                direction = 1;
            else if (playerPosition > transform.position.x)
                direction = -1;

            rb.velocity = new Vector3(0,0,0);
            rb.AddForce(new Vector3(direction * knockBackForce, rb.velocity.y, rb.velocity.z));
            sfxManager.PlayEnemyHitPlayerSound();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            
            coyoteTimer = 0;
            if(rb.velocity.y < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
            
        }
    }
        
}
