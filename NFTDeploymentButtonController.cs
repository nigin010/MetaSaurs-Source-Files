using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NFTDeploymentButtonController : MonoBehaviour
{
    public GameObject SlideOne;
    public GameObject SlideTwo;
    public TMP_Text NFT_Type_Data;

    public TMP_InputField ImageurlInputField;

    public string Common = "What you have here is a COMMON type dino. THEREFORE THE ALLOWABLE PRICE FOR YOUR DINO IS BETWEEN 1 AND 5";
    public string Rare = "What you have here is a RARE type dino. THEREFORE THE ALLOWABLE PRICE FOR YOUR DINO IS BETWEEN 1 AND 10";
    public string Epic = "What you have here is a EPIC type dino. THEREFORE THE ALLOWABLE PRICE FOR YOUR DINO IS BETWEEN 1 AND 15";
    public string Legendary = "What you have here is a LEGENDARY type dino. THEREFORE THE ALLOWABLE PRICE FOR YOUR DINO IS BETWEEN 1 AND 20";



    public void Start()
    {
        SlideOne.gameObject.SetActive(false);
        SlideTwo.gameObject.SetActive(false);
    }

    public void ShowInputFields()
    {
        SlideOne.gameObject.SetActive(false);
        SlideTwo.gameObject.SetActive(true);

        ImageurlInputField.text = BreedingController.ImageURL.ToString();

        BreedingController breedingController = FindObjectOfType<BreedingController>();     //Used to create a instance of BreedingController inorder to access the final_Rarity value

        if (breedingController.final_rarity == 1)
        {
            NFT_Type_Data.text = Common;
        }
        else if(breedingController.final_rarity == 2)
        {
            NFT_Type_Data.text = Rare;
        }
        else if(breedingController.final_rarity == 3)
        {
            NFT_Type_Data.text = Epic;
        }
        else
        {
            NFT_Type_Data.text = Legendary;
        }

    }
}
