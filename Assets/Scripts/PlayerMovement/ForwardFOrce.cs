using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardFOrce : MonoBehaviour
{
    
    public float Speed;
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // Moves player forward at the given speed if player is touching the screen.
            transform.position += Vector3.forward * Time.deltaTime * Speed;
        }
    }
}
