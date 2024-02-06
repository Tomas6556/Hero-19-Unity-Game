using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public static PlayerController instance;

    public string areaTransitionName;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    
    public bool canMove = true;
    // public Animator myAnim;
    

    public void Start()
    {
        

        if(instance == null)
        {
            instance = this;
        } else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
            
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if(canMove)
        {

            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

            ///AudioManager.instance.PlaySFX(0);
            // put here the animation code!
        }else
        {

            theRB.velocity =  Vector2.zero;

        }
       



        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        // change vector due to how big player is 
        bottomLeftLimit = botLeft + new Vector3(5f, 5f, 0);
        topRightLimit = topRight + new Vector3(-5f, -5f, 0);
    }

    
}
