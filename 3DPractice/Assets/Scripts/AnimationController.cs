using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    private bool canJump = false;
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
        if(Input.GetKey(KeyCode.Space) && canJump == true)
        {
            canJump = false;
            Debug.Log("Can Jump " + canJump);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", true);
            gameObject.transform.position += new Vector3(0f, 10f * Time.deltaTime, 0f);
        }
        else
        {

            animator.SetBool("IsRunning", true);
            animator.SetBool("IsJumping", false);
        }

        
    }

    private void HandleRunning()
    {
        animator.SetBool("IsRunning", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            canJump = true;
            Debug.Log("Can Jump " + canJump);
        }
    
    }
}
