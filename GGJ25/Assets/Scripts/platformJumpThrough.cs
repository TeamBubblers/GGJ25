using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformJumpThrough : MonoBehaviour
{

    private GameObject player;
    private Collider m_ObjectCollider;

    [SerializeField]
    private float Y_Offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_ObjectCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > transform.position.y + Y_Offset)
        {
            m_ObjectCollider.isTrigger = false;
        }

        else if(player.transform.position.y < transform.position.y + Y_Offset)
        {
            m_ObjectCollider.isTrigger = true;
        }
    }
}
