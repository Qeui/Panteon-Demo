using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _rotator;
    [SerializeField] private float _magnitude;


    private void OnTriggerEnter(Collider other)
    {

        // Checks if the player collides with the stick
        if (other.CompareTag("Player"))
        {
            // if it is, then it checks if the player is passed the rotator or not
            if (_player.transform.position.z <= _rotator.position.z)
            {
                // if player is not passed the rotator, makes player jump back
                _player.GetComponent<Rigidbody>().AddForce((_player.transform.forward * _magnitude) + Vector3.up * (_magnitude * -1), ForceMode.Impulse);
            }
            else
            {
                // if player is passed the rotator, makes player jump forward
                _player.GetComponent<Rigidbody>().AddForce(_player.transform.forward + Vector3.up * (_magnitude * -1), ForceMode.Impulse);
            }
        }
        // Checks if the opponent player collides with the stick
        else if (other.CompareTag("Opponent"))
        {
            // if it is, then it checks if the opponent is passed the rotator or not
            if (other.transform.position.z <= _rotator.position.z)
            {
                // if opponent is not passed the rotator, calls the jump back coroutine
                other.GetComponent<ObstacleJump>().StartCoroutine("JumpBack");
            }
            else
            {
                // if opponent is passed the rotator, calls the jump forward coroutine
                other.GetComponent<ObstacleJump>().StartCoroutine("JumpForward");
            }
        }
    }
    


}
