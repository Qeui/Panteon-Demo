using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationResetter : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        // I don' know why but boy keeps rotating and this resets the rotation
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
