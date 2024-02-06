using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //amimator

        //Left and Right
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isWalking", true);

        }
        else
        {
         animator.SetBool("isWalking", false);
        }

        //Up
        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("isWalkingUp", true);
        }
        else
        {
            animator.SetBool("isWalkingUp", false);
        }

        //Down
        if (Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("isWalkingDown", true);
        }
        else
        {
            animator.SetBool("isWalkingDown", false);
        }

        //Flip
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -2;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 2;
        }
        transform.localScale = characterScale;

    }
}
