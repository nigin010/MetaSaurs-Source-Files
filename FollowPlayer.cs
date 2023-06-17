using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // The player to follow
    public float speed = 5f; // The speed at which to follow the player

    private NavMeshAgent navMeshAgent; // The NavMeshAgent component used to move the entity

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Update the NavMeshAgent destination to follow the player
            navMeshAgent.SetDestination(playerTransform.position);
        }
    }
}