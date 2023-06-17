using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class SceneTwoToSceneThree : MonoBehaviour
{
    public void ChangeScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainGame");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
