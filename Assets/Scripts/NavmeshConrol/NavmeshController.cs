using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshController : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] private Transform _agentTransform;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _anim;
    private bool _isGameStarted;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the animator and isGameStarted to false
        _isGameStarted = false;
        _anim.SetBool("IsRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks for the mouse click
        if (Input.GetMouseButtonDown(0) && !_isGameStarted)
        {
            // When player clicks, it starts the agent
            AgentStarter();
        }
        // Checks if the agent completed the path
        bool pathComplete()
        {
            // Checks if the distance between agent and the destinatin is smaller than the stopping distamce
            if (Vector3.Distance(_agent.destination, _agent.transform.position) <= _agent.stoppingDistance)
            {
                // If it is then it checks if the agent has a path or is stopped
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }

            return false;
        }
        // If path is complete, it stops the animation
        if (pathComplete())
        {
            _anim.SetBool("IsRunning", false);
        }
        // If the path is not complete and the game is started, it starts the animation
        else if(_isGameStarted && !pathComplete())
        {
            _anim.SetBool("IsRunning", true);
        }
    }
    // Changes the _isGameStarted to true andsets the agent destination
    public void AgentStarter()
    {
        _isGameStarted = true;
        _agent.SetDestination(_endPos.position);
    }
    // Returns the agent to the starting point
    public void AgentRestart()
    {
        _agent.enabled = false;
        _agentTransform.position = _startPos.position;
        _agent.enabled = true;
        AgentStarter();
    }
}
