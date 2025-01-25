using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool SharedInstance;

    public List<GameObject> ammoList; //List of ammo.
    public GameObject ammo;

    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammoList = new List<GameObject>();
        GameObject tmpAmmo;
        for (int i = 0; i < amountToPool; i++)
        {
            tmpAmmo = Instantiate(ammo);
            tmpAmmo.SetActive(false);
            ammoList.Add(tmpAmmo);
        }
    }

    public GameObject GetAmmo()  //Method to get ammo GameObject.
    {


        for (int i = 0; i < amountToPool; i++)
        {
            if (!ammoList[i].activeInHierarchy)
            {


                return ammoList[i];

            }
        }

        return null;
    }
}
