using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMovement : MonoBehaviour
{

    private float lifeTime;

    [SerializeField]
    private float maxLifeTime;

    [SerializeField]
    private float ammoSpeed;


    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;

        transform.Translate(transform.right * ammoSpeed * Time.deltaTime, Space.World);

        if(lifeTime >= maxLifeTime)
        {
            gameObject.SetActive(false);
            lifeTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Platform" || other.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
