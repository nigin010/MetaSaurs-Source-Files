using UnityEngine;
using UnityEngine.AI;

public class TileChecker : MonoBehaviour
{
    public bool isWalkable;
    public bool isRoad;
    private NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Walkable"))
        {
            if (isWalkable)
            {
                navAgent.enabled = true;
            }
        }
        else if (other.gameObject.CompareTag("Road"))
        {
            if (isRoad || isWalkable)
            {
                navAgent.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Walkable") || other.gameObject.CompareTag("Road"))
        {
            navAgent.enabled = false;
        }
    }
}
