using UnityEngine;
using UnityEngine.UI;

public class RaceOneUITrigger : MonoBehaviour
{
    public GameObject RaceOneUI; // The UI object to show/hide

    void Start()
    {
        RaceOneUI.SetActive(false); // Hide the UI object at the beginning
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaceOneUI.SetActive(true); // Show the UI object when the player enters the trigger
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaceOneUI.SetActive(false); // Hide the UI object when the player leaves the trigger
        }
    }
}
