using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedController : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public GameObject feedButtonPrefab;
    public Transform feedButtonParent;
    public Animator playerAnimator;

    private GameObject feedButtonInstance;
    private Animator dinoAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dino"))
        {
            // Find the parent object that has the Animator component attached to it
            dinoAnimator = other.gameObject.GetComponentInParent<Animator>();
            EnableFeedButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Dino"))
        {
            DisableFeedButton();
        }
    }

    private void EnableFeedButton()
    {
        if (feedButtonInstance == null)
        {
            feedButtonInstance = Instantiate(feedButtonPrefab, feedButtonParent);
        }
        Button feedButton = feedButtonInstance.GetComponent<Button>();
        feedButton.onClick.AddListener(FeedDino);
        feedButton.interactable = (playerInventory.Meat >= 1 && playerInventory.DinoLevel < 10);

        // Set the interactive property to true
        feedButton.interactable = true;
    }

    private void DisableFeedButton()
    {
        if (feedButtonInstance != null)
        {
            Button feedButton = feedButtonInstance.GetComponent<Button>();
            feedButton.onClick.RemoveAllListeners();
            feedButton.interactable = false;
            Destroy(feedButtonInstance);
        }
    }

    private IEnumerator PlayAnimation(Animator animator, string animationName, string boolName, bool boolValue, float delay)
    {
        // Set the bool value to true to switch the animator to the specified animation
        animator.SetBool(boolName, boolValue);

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Play the specified animation
        animator.Play(animationName);

        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Set the bool value to false to switch the animator back to the idle animation
        animator.SetBool(boolName, !boolValue);
    }

    private IEnumerator DelayedAnimation(Animator animator, string animationName, string boolName, bool boolValue, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Start the specified animation with the specified bool value
        animator.SetBool(boolName, boolValue);
        animator.Play(animationName);
    }

    private void FeedDino()
    {
        if (playerInventory.Meat >= 1)
        {
            playerInventory.Meat--;
            playerInventory.DinoLevel++;

            // Play player and dino animations
            StartCoroutine(PlayAnimation(playerAnimator, "Throwing", "Throwing", true, 0f));
            StartCoroutine(DelayedAnimation(dinoAnimator, "DinoFeedAnimation", "IsEating", true, 0.8f));
            StartCoroutine(DelayedAnimation(dinoAnimator, "DinoFeedAnimation", "IsEating", false, 0.8f));
            DisableFeedButton();
        }
    }
}
