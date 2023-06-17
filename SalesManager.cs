using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SalesManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public Text meatText;
    public TMP_Text coinsText;

    private void Start()
    {
        UpdateUI();
    }

    public void OnClick()
    {
        if (playerInventory.NumberOfCoins >= 5)
        {
            playerInventory.ReduceCoins(5);
            playerInventory.Meat++;
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    private void UpdateUI()
    {
        meatText.text = playerInventory.Meat.ToString();
        coinsText.text = playerInventory.NumberOfCoins.ToString();
    }
}
