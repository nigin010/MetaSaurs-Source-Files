using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteMetamask : MonoBehaviour
{
    public void OpenURL ()
    {
        Application.OpenURL("http://localhost:3000/");
        Debug.Log("Working"); 
    }
}
