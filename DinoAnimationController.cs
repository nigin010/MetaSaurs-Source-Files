using UnityEngine;

public class DinoAnimationController : MonoBehaviour
{
    public Animator animator;
    public AnimationClip idleAnimation;
    public AnimationClip runningAnimation;
    
    private Vector3 previousPosition;
    
    void Start()
    {
        previousPosition = transform.position;
        animator.Play(idleAnimation.name);
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        
        if (currentPosition == previousPosition)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
        
        previousPosition = currentPosition;
    }
}
