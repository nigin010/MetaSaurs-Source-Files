using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI loadingText;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        string[] loadingMessages = new string[] {
            "Dinosaurs may have been extinct for millions of years, but they still capture our imagination with their cute faces and fluffy feathers.", 
            "Complete Quests to Earn Coins Easily", 
            "Who needs unicorns when you have triceratops?,",
            "Feed The Dinos With Meet To increase their level",
            "Stegosauruses are like big, cuddly plant-eating tanks",
            "The Houses in Forest is so big because Giants used to leave there before",
            "The way that little dino arms wiggle when they run is just too precious",
            "Go to the Laboratory to breed them and get new Offspring Dinos",
            "Despite their size and strength, there's something endearingly goofy about dinosaurs",
            "You cant mint money from breeding process by selling them as NFT in the Marketplace"};
        int messageIndex = 0;

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            // Show random loading message every 5 seconds
            if (Time.timeSinceLevelLoad % 5 == 0 && messageIndex < loadingMessages.Length)
            {
                loadingText.text = loadingMessages[messageIndex];
                messageIndex++;
            }

            yield return null;
        }
    }
}
