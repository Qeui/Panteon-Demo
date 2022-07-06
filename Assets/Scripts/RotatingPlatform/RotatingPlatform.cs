using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _rotationForce;
    [SerializeField] private Rigidbody _player;
    private bool _isPlayerOn = false;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // This rotates the platform
        transform.Rotate(new Vector3(0, 0, _rotationSpeed));
        // Checks if the player is on the platform
        if (_isPlayerOn)
        {
            // If it is, then it add force to player
            _player.AddForce(_rotationForce);
        }
    }
    // This checks if the player is colliding with the platform
    private void OnCollisionEnter(Collision collision)
    {
        // If player is colliding that means player is on the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerOn = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // If player don't collide that means player is not on the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerOn = false;

        }
    }
}
