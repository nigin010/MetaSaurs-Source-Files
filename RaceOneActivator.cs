using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceOneActivator : MonoBehaviour
{
    public GameObject Lap;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Replace "Player" with the tag of the object that can activate Object A
        {
            Lap.SetActive(true);
        }
    }
}
