using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketplacePublishButtonController : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField priceInputField;
    public TMP_InputField imageurlInputField;
    public TMP_Text ErrorData;
    public GameObject SlideTwo;
    BreedingController breedingController;

    public string ErrorMessage = "YOU HAVE ENTERED AN INVALID PRICE. ENTER A VALID PRICE AND TRY AGAIN!";
    public string BlankMessage = "";

    void Start()
    {
        breedingController = FindObjectOfType<BreedingController>();
    }

    public void OnDeployButtonClicked()
    {
        int finalRarity = breedingController.final_rarity;
        RarityManager.rarityValues[RarityManager.rarityValues.Length - 1] = finalRarity; // Add finalRarity to the next index position in the rarityValues array
        string name = nameInputField.text;
        string priceStr = priceInputField.text;
        int price = 0;
        bool isPriceValid = true;

        // Validate price based on finalRarity
        switch (finalRarity)
        {
            case 1:
                isPriceValid = int.TryParse(priceStr, out price) && price >= 1 && price <= 5;
                break;
            case 2:
                isPriceValid = int.TryParse(priceStr, out price) && price >= 1 && price <= 10;
                break;
            case 3:
                isPriceValid = int.TryParse(priceStr, out price) && price >= 1 && price <= 15;
                break;
            default:
                isPriceValid = int.TryParse(priceStr, out price) && price >= 1 && price <= 20;
                break;
        }

        if (!isPriceValid)
        {
            Debug.LogError("Invalid price input.");
            ErrorData.text = ErrorMessage;
            return;
        }
        else
        {
            ErrorData.text = BlankMessage;
        }

        string imageurl = BreedingController.ImageURL.ToString();
        string url = "http://localhost:3000/" + imageurl + "/" + name + "/" + price;

        Application.OpenURL(url);

        Debug.Log("Deploy button clicked.");

        SlideTwo.gameObject.SetActive(false);
    }
}
