using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private float _amplitude;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _startPoint;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Creates a sine wave and apply that wave to right-left movement of the obstacle
        transform.position = _targetPosition + Vector3.left * Mathf.Sin(Time.time * _amplitude);
    }
    // Checks if the player or opponent collides with this obstacle
    private void OnCollisionEnter(Collision collision)
    {
        // if it is player, then player needs to restart
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.transform.position = _startPoint.position;
        }
        // if it is opponent, then opponent needs to restart
        else if (collision.gameObject.CompareTag("Opponent"))
        {
            collision.gameObject.GetComponent<NavmeshController>().AgentRestart();
        }
    }
    

}
