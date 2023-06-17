using Newtonsoft.Json;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class MetamaskDataFetch : MonoBehaviour
{
    public class DinoData
    {
        public string id { get; set; }
        public string owner { get; set; }
        public string imageurl { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public bool isAlive { get; set; }
    }

    public class ResponseData
    {
        public List<List<object>> response { get; set; }
        public bool success { get; set; }
    }

    public TextMeshProUGUI text;
    public TMP_InputField inputField;
    public GameObject errorButton;
    public GameObject goButton;
    public TextMeshProUGUI errorText;

    public static List<string> aliveDinoIdsList;

    void Fetch(string id)
    {
        StartCoroutine(GetRequest("http://localhost:4000/dino/getMyDino/" + id));
    }

    public void OnRefresh()
    {
        Fetch(inputField.text);
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));
                    errorText.text = "Error: " + webRequest.error;
                    errorButton.SetActive(true);
                    break;
                case UnityWebRequest.Result.Success:
                    ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(webRequest.downloadHandler.text);
                    if (!responseData.success)
                {
                    errorText.text = "Uh oh! It seems either the Metamask credentials are wrong or your account does not have any NFT. You need 2 NFTs to play the game. So check if the credentials are right. If yes, the go to the Marketplace and buy 2 NFTs for yourself and restart the game. ";
                    errorButton.SetActive(true);
                }
                    int aliveCount = 0;
                    List<string> aliveDinoIds = new List<string>();

                    foreach (var data in responseData.response)
                    {
                        DinoData dinoData = new DinoData
                        {
                            id = data[0].ToString(),
                            owner = data[2].ToString(),
                            imageurl = data[3].ToString(),
                            name = data[4].ToString(),
                            price = int.Parse(data[5].ToString()),
                            isAlive = bool.Parse(data[6].ToString())
                        };
                        if (dinoData.isAlive)
                        {
                            aliveCount++;
                            aliveDinoIds.Add(dinoData.id);
                        }

                        Debug.Log("Dino ID: " + dinoData.id);
                        Debug.Log("Owner: " + dinoData.owner);
                        Debug.Log("Image URL: " + dinoData.imageurl);
                        Debug.Log("Name: " + dinoData.name);
                        Debug.Log("Price: " + dinoData.price);
                        Debug.Log("Is Alive: " + dinoData.isAlive);
                        
                    }

                    Debug.Log("\n");
                    if (aliveCount == 2)
                    {
                        string[] aliveDinoIdArray = aliveDinoIds.ToArray();
                        
                        foreach (string id in aliveDinoIdArray)
                        {
                            goButton.SetActive(true);
                            Debug.Log("ID is: " + id);
                        }
                        aliveDinoIdsList = aliveDinoIds;
                    }
                    else
                    {
                        errorText.text = "Uh oh! It seems your Metamask account does not have any NFT. You need 2 NFTs to play the game. So go to the Marketplace and buy 2 NFTs for yourself and restart the game. ";
                        errorButton.SetActive(true);
                    }
                    break;
                default:
                    errorText.text = "Error: " + webRequest.error;
                    errorButton.SetActive(true);
                    break;
            }
        }
    }

    public void OnRetry()
    {
        errorButton.SetActive(false);
        Fetch(inputField.text);
    }
}