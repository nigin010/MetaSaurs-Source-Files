using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI coinCountText1;
    public TextMeshProUGUI coinCountText2;
    public PlayerInventory playerInventory1;
    public PlayerInventory playerInventory2;

    void Start()
    {
        playerInventory1.onCoinCountChanged.AddListener(() => UpdateCoinCount(playerInventory1, coinCountText1));
        playerInventory2.onCoinCountChanged.AddListener(() => UpdateCoinCount(playerInventory2, coinCountText2));
    }

    private void UpdateCoinCount(PlayerInventory inventory, TextMeshProUGUI text)
    {
        text.text = inventory.NumberOfCoins.ToString();
    }
}
