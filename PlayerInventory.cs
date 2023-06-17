using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    private int numberOfCoins;
    public int NumberOfCoins 
    {
        get { return numberOfCoins; }
        set 
        { 
            numberOfCoins = value;
            onCoinCountChanged.Invoke();
        }
    }
    
    private int meatCount;
    public int Meat 
    {
        get { return meatCount; }
        set 
        { 
            meatCount = value;
            UpdateUIMeat();
        }
    }
    
    private int dinoLevel;
    public int DinoLevel 
    {
        get { return dinoLevel; }
        set 
        { 
            dinoLevel = value;
            UpdateUIDino();
        }
    }

    public int PlayerNumber;
    public bool HasQuestItem = false;
    public bool HasQuestItemTwo = false;
    public string PlayerName;
    public string ObjectName;
    public UnityEvent onCoinCountChanged;

    public Text dinoLevelText; // reference to the TextMeshPro object
    public Text numberOfMeatText; // reference to the TextMeshPro object for NumberOfMeat

    private void Start()
    {
        // Subscribe to the DinoLevel property changes
        DinoLevel = 1;

        // Initialize Meat to 0
        Meat = 0;
    }

    public void CoinCollected()
    {
        NumberOfCoins++;
    }

    public void ReduceCoins(int amount)
    {
        NumberOfCoins -= amount;
        NumberOfCoins = Mathf.Max(0, NumberOfCoins); // Ensure the number of coins doesn't go below 0
    }

    private void UpdateUIDino()
    {
        dinoLevelText.text = DinoLevel.ToString();
    }

    private void UpdateUIMeat()
    {
        numberOfMeatText.text = Meat.ToString();
    }
}
