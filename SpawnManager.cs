using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    public string playerId; // Unique identifier for this player
    public GameObject player; // The player to follow
    public float followDistance = 5f; // The distance to follow the player at
    public GameObject[] playerPrefabs; // Array of prefabs to spawn for each player
    public int x; // The value used to determine which prefab to spawn for this player
    public float prefabSpawnOffset = 2f; // The offset at which to spawn the prefab behind the player
    public float avoidDistance = 3f; // The distance at which the prefab should avoid the player

    private GameObject playerPrefab; // The prefab to spawn for this player
    private NavMeshAgent agent; // The agent to move the spawned prefab
    private Vector3 targetPosition; // The position to move the spawned prefab towards

    private void Start()
    {
        if (playerId == "1" && MetamaskDataFetch.aliveDinoIdsList.Count >= 1)                         
        //if (playerId == "1")                                                                            //REMOVE THIS LINE                                                       
        //if (playerId == "1" && MetamaskDataFetch.aliveDinoIdsList.Count >= 1)
        {
            x = int.Parse(MetamaskDataFetch.aliveDinoIdsList[0]);
            //x = 1;      //Testing Purpose Only
        }
        else if (playerId == "2" && MetamaskDataFetch.aliveDinoIdsList.Count >= 2)                    
        //else if (playerId == "2")                                                                      //REMOVE THIS LINE
        {
            x = int.Parse(MetamaskDataFetch.aliveDinoIdsList[1]);
            //x = 2;      //Testing Purpose Only
        }
        else
        {
            Debug.LogWarning("Not enough alive dino IDs in the list for player " + playerId);
        }

        // Determine which prefab to spawn for this player based on x
        playerPrefab = playerPrefabs[x % playerPrefabs.Length];

        // Spawn the playerPrefab with an offset and assign it to the agent
        Vector3 spawnPosition = player.transform.position - player.transform.forward * prefabSpawnOffset;
        GameObject spawnedPrefab = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        agent = spawnedPrefab.GetComponent<NavMeshAgent>();

        // Set the agent's name to include the player's ID
        spawnedPrefab.name = playerPrefab.name + "_" + playerId;

        // Set the agent's destination to the player's current position
        agent.SetDestination(player.transform.position);
    }

    private void Update()
    {
        // Calculate the target position as the player's position plus the follow distance
        Vector3 targetPosition = player.transform.position + player.transform.forward * followDistance;

        // Check if the distance between the player and the prefab is less than a threshold
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 2 * prefabSpawnOffset)
        {
            // Calculate a new target position that is offset from the player's position and direction
            Vector3 playerOffset = player.transform.right * prefabSpawnOffset;
            Vector3 directionToTarget = (targetPosition - transform.position).normalized;
            targetPosition = player.transform.position + directionToTarget * followDistance + playerOffset;
        }

        // Update the agent's destination to the target position if it has changed
        if (targetPosition != this.targetPosition)
        {
            this.targetPosition = targetPosition;
            agent.SetDestination(targetPosition);
        }
    }


}