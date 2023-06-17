using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject breedingUI;
    public GameObject SlideOneCanvas;

    private bool player1Collided;
    private bool player2Collided;


    void Start()
    {
        breedingUI.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1Collided = true;
            Debug.Log("Player 1 Collided");
        }

        if (other.gameObject == player2)
        {
            player2Collided = true;
            Debug.Log("Player 2 Collided");
        }

        if (player1Collided && player2Collided)
        {
            breedingUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1Collided = false;
            breedingUI.gameObject.SetActive(false);
        }

        if (other.gameObject == player2)
        {
            player2Collided = false;
            breedingUI.gameObject.SetActive(false);
        }

         
    }
}
