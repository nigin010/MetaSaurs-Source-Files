using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartOneToTwo : MonoBehaviour
{
    public GameObject UI_Two;
    public GameObject SlideOne;

    public void OnContinue()
    {
        UI_Two.gameObject.SetActive(false);
        SlideOne.gameObject.SetActive(true);
    }
}
