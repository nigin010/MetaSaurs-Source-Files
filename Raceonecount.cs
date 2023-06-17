using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raceonecount : MonoBehaviour
{
    public List<GameObject> checkpoints;
    private int currentCheckpointIndex = 0;
    private GameObject currentCheckpoint;
    public PlayerInventory playerInventory;

    void Start()
    {
        // Activate the first checkpoint
        ActivateCheckpoint(0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == currentCheckpoint)
        {
            // Deactivate the current checkpoint
            currentCheckpoint.SetActive(false);

            // Increment the checkpoint index
            currentCheckpointIndex++;

            // Check if all checkpoints have been passed
            if (currentCheckpointIndex == checkpoints.Count)
            {
                // Activate all checkpoints
                for (int i = 0; i < checkpoints.Count; i++)
                {
                    checkpoints[i].SetActive(true);
                }

                // Reset the checkpoints
                ResetCheckpoints();

                Debug.Log("Race has ended. Thank you for participating!");
                return;
            }

            // Activate the next checkpoint
            ActivateCheckpoint(currentCheckpointIndex);
        }
    }

    void ActivateCheckpoint(int index)
    {
        currentCheckpoint = checkpoints[index];

        // Increment the number of coins by 10
        playerInventory.NumberOfCoins += 10;

        currentCheckpoint.SetActive(true);
        Debug.Log("Activated checkpoint " + (index + 1));
    }

    void ResetCheckpoints()
    {
        // Reset the checkpoint index
        currentCheckpointIndex = 0;

        // Activate the first checkpoint
        ActivateCheckpoint(0);
    }
}
