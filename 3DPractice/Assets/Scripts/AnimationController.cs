using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    { 
        animator = GetComponent<Animator>();
        // animator.SetBool("IsRunning", false);
        Invoke(nameof(HandleRunning), 2f);
        animator.SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleRunning()
    {
        animator.SetBool("IsRunning", false);
    }
}
