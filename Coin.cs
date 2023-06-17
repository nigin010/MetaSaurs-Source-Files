using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if(playerInventory != null)
        {
            playerInventory.CoinCollected();
            gameObject.SetActive(false);
            Invoke("RespawnCoin", 180f);
        }
    }

    private void RespawnCoin()
    {
        gameObject.SetActive(true);
    }
}
