using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneOneToTwo : MonoBehaviour
{
    public void ChangeScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("2_MetamaskLink");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
