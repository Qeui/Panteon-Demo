using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleJump : MonoBehaviour
{
    [SerializeField] private Transform _rotator;
    [SerializeField] private NavmeshController _nav;
    [SerializeField] private float _magnitude;
    
    public IEnumerator JumpBack()
    {
        // Disables the NavMeshAgent
        GetComponent<NavMeshAgent>().enabled = false;
        // Makes the opponent jump back
        GetComponent<Rigidbody>().AddForce((transform.forward * _magnitude) + Vector3.up * (_magnitude * -1), ForceMode.Impulse);
        // Waits for the opponent to land on the ground
        yield return new WaitForSeconds(0.5f);
        // Enables the NavMeshAgent and starts the agent
        GetComponent<NavMeshAgent>().enabled = true;
        _nav.AgentStarter();
    }
    public IEnumerator JumpForward()
    {
        // Disables the NavMeshAgent
        GetComponent<NavMeshAgent>().enabled = false;
        // Makes the opponent jump forward
        GetComponent<Rigidbody>().AddForce(transform.forward + Vector3.up * (_magnitude * -1), ForceMode.Impulse);
        // Waits for the opponent to land on the ground
        yield return new WaitForSeconds(0.5f);
        // Enables the NavMeshAgent and starts the agent
        GetComponent<NavMeshAgent>().enabled = true;
        _nav.AgentStarter();
    }
}
