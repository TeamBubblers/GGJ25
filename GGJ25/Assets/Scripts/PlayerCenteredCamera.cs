using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenteredCamera : MonoBehaviour
{
    public float fixedYaw = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y = Mathf.Clamp(currentRotation.y, 0, 0);
        transform.eulerAngles = currentRotation;
    }
}
