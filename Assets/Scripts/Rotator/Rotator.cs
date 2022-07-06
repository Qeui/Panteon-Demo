using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // This rotates the platform
        transform.Rotate(new Vector3(0, _rotationSpeed, 0));
    }
}
