using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public GameObject QuestItemPrefab;
    public PlayerInventory Player1Inventory;
    public PlayerInventory Player2Inventory;
    public GameObject QuestGiverDialog;

    private bool hasGivenQuest = false;
    private GameObject questItemInstance;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null && !hasGivenQuest)
        {
            QuestGiverDialog.SetActive(true);
            hasGivenQuest = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null && Input.GetKeyDown(KeyCode.E) && !Player1Inventory.HasQuestItem && !Player2Inventory.HasQuestItem)
        {
            questItemInstance = Instantiate(QuestItemPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            if (playerInventory.PlayerNumber == 1) {
                Player1Inventory.HasQuestItem = true;
            } else if (playerInventory.PlayerNumber == 2) {
                Player2Inventory.HasQuestItem = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        QuestGiverDialog.SetActive(false);
    }

    public GameObject GetQuestItemInstance()
    {
        return questItemInstance;
    }

    public void ResetQuest()
    {
        hasGivenQuest = false;
        if (questItemInstance != null)
        {
            Destroy(questItemInstance);
        }
    }
}
