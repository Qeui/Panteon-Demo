using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDropRestart : MonoBehaviour
{
    [SerializeField] private float _dropHeight;
    [SerializeField] private Transform _playerStart;

    // Update is called once per frame
    void Update()
    {
        // Checks if the player or the opponents are dropped from the level
        if(transform.position.y <= _dropHeight)
        {
            // If they are, it returns to start
            if (this.CompareTag("Player"))
            {
                this.transform.position = _playerStart.position;
            }
            else if (this.CompareTag("Opponent"))
            {
                this.GetComponent<NavmeshController>().AgentRestart();
            }
        }
        
    }
}
