using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Destroys this gameObject when the mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        } 
    }
}
