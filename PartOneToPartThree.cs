using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartOneToPartThree : MonoBehaviour
{
    public GameObject UI_Three;

    public void OnOkay()
    {
        UI_Three.gameObject.SetActive(false);
    }
}
