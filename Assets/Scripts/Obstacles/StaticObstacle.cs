using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacle : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _startPoint;

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
