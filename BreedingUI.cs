using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreedingUI : MonoBehaviour
{
    public GameObject breedingPanel;
    public Button yesButton;
    public Button noButton;
    public TextMeshProUGUI breedingText;

    public void ShowUI()
    {
        breedingPanel.SetActive(true);
    }
}
