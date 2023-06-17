using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestReceiver : MonoBehaviour
{
    public PlayerInventory Player1Inventory;
    public PlayerInventory Player2Inventory;
    public QuestGiver questGiver;

    public GameObject QuestReceiverItemPresent;
    public GameObject QuestReceiverItemAbsent;

    private bool hasReceivedReward = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasReceivedReward)
        {
            int playerNumber = other.GetComponent<PlayerInventory>().PlayerNumber;
            if (playerNumber == 1 && Player1Inventory.HasQuestItem)
            {
                QuestReceiverItemPresent.SetActive(true);
                Player1Inventory.NumberOfCoins += 200;
                Player1Inventory.HasQuestItem = false;
                Destroy(questGiver.GetQuestItemInstance());
                questGiver.ResetQuest();
                hasReceivedReward = true;
            }
            else if (playerNumber == 2 && Player2Inventory.HasQuestItem)
            {
                QuestReceiverItemPresent.SetActive(true);
                Player2Inventory.NumberOfCoins += 200;
                Player2Inventory.HasQuestItem = false;
                Destroy(questGiver.GetQuestItemInstance());
                questGiver.ResetQuest();
                hasReceivedReward = true;
            }
            else
            {
                QuestReceiverItemAbsent.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        QuestReceiverItemPresent.SetActive(false);
        QuestReceiverItemAbsent.SetActive(false);
        hasReceivedReward = false;
    }
}
