using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject ShopCanvasPlayerOne; 
    public GameObject ShopCanvasPlayerTwo; 
    
    private void OnTriggerEnter(Collider collision)
    {
        PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
        
        if (playerInventory != null && (playerInventory.PlayerNumber == 1))
        {
           ShopCanvasPlayerOne.gameObject.SetActive(true);
        }
        else
        {
            ShopCanvasPlayerTwo.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ShopCanvasPlayerOne.gameObject.SetActive(false);
            ShopCanvasPlayerTwo.gameObject.SetActive(false);
        }
    }

    public void Start()
    {
        ShopCanvasPlayerOne.gameObject.SetActive(false);
        ShopCanvasPlayerTwo.gameObject.SetActive(false);
    }
}
