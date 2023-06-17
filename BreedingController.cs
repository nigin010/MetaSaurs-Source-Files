using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class BreedingController : MonoBehaviour
{
    public PlayerInventory player1;
    public PlayerInventory player2;

    public int id1;
    public int id2;

    public int id1_rarity;
    public int id2_rarity;
    public int final_rarity;

    public GameObject UI_One;
    public GameObject UI_Two;
    public GameObject UI_Three;
    public GameObject UI_Four;

    public Image imageUI;
    public Sprite ImageThree;
    public Sprite ImageFive;
    public Sprite ImageSix;

    public static string ImageURL;

    private VideoPlayer videoplayer;

    public GameObject VideoCamera;
    public GameObject audioPlayer;

    void Start()
    {
        UI_Two.gameObject.SetActive(false);
        UI_Three.gameObject.SetActive(false);
        UI_Four.gameObject.SetActive(false);

        VideoCamera.gameObject.SetActive(false);

        videoplayer = GetComponent<VideoPlayer>();
        videoplayer.loopPointReached += OnVideoFinished;
    }

    public void OnYes()
    {
        if (player1.NumberOfCoins >= 300 && player2.NumberOfCoins >= 300)                   
        {
            if(player1.DinoLevel >=5 && player2.DinoLevel >= 5)
            {
                UI_One.gameObject.SetActive(false);
                audioPlayer.gameObject.SetActive(false);
                VideoCamera.gameObject.SetActive(true);

                player1.ReduceCoins(300);             
                player2.ReduceCoins(300);            
                player1.DinoLevel = 1;
                player2.DinoLevel = 1;

                ChangeStartStop();
            }
            else
            {
                UI_One.gameObject.SetActive(false);
                UI_Four.gameObject.SetActive(true);
            }
            
        }
        else
        {
            UI_Three.gameObject.SetActive(true);
            UI_One.gameObject.SetActive(false);
        }
    }

    public void OnNo()
    {
        UI_One.gameObject.SetActive(false);
        UI_Four.gameObject.SetActive(false);
    }

    public void ChangeStartStop()
    {
        if(videoplayer.isPlaying == false)
        {
            videoplayer.Play();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        audioPlayer.gameObject.SetActive(true);
        VideoCamera.gameObject.SetActive(false);
        Debug.Log("Video finished playing.");
        Debug.Log("Coins reduced from both players.");


        id1 = int.Parse(MetamaskDataFetch.aliveDinoIdsList[0]);
        id2 = int.Parse(MetamaskDataFetch.aliveDinoIdsList[1]);
    
        //Testing Purpose
        //id1 = 1;
        //id2 = 2;

        id1_rarity = RarityManager.rarityValues[id1];
        id2_rarity = RarityManager.rarityValues[id2];
        final_rarity = UnityEngine.Random.Range(Mathf.Min(id1_rarity, id2_rarity), Mathf.Max(id1_rarity, id2_rarity) + 1);

        Debug.Log("id1: " + id1 + " Rarity: " + id1_rarity);
        Debug.Log("id2: " + id2 + " Rarity: " + id2_rarity);
        Debug.Log("Final rarity: " + final_rarity);

        if (id1 == 1 && id2 == 2)
        {
            UI_Two.gameObject.SetActive(true);
            imageUI.sprite = ImageThree;
            ImageURL = "DinoThree.png";

        }
        else if (id1 == 2 && id2 == 3)
        {
            UI_Two.gameObject.SetActive(true);
            imageUI.sprite = ImageFive;
            ImageURL = "DinoFive.png";
        }
        else
        {
            UI_Two.gameObject.SetActive(true);
            imageUI.sprite = ImageSix;
            ImageURL = "DinoSix.png";
        }
    }
}