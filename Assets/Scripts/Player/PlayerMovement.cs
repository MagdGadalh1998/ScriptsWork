using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D CharacterController;
    public  float horizontalMove = 0f;
    public static float speed = 1;
    [Range(20,100)]public  float actualSpeed = 60f;
    public bool isJumb ;
   
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        isJumb = false;
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * actualSpeed * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumb = true;
            print("Jump");
            animator.SetBool("IsJump", true);
        }
        if (!isJumb)
        {
            animator.SetBool("IsJump", false);
        }
    }
    public void StopJumpingOnTouchLand()
    {/*
        animator.SetBool("IsJump", false);*/
    }
    void LateUpdate() 
    {
        CharacterController.Move(horizontalMove * Time.smoothDeltaTime, false, isJumb);
        isJumb =false;
    }
   
}
