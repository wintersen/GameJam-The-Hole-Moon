using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    public GameObject dog;
    public float horizontalDirection;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            horizontalDirection = Input.GetAxisRaw("Horizontal");
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

        }
        //Set Stay Command
        if (Input.GetKeyDown(KeyCode.E))
        {
            dog.GetComponent<Follow>().stayIsActive = !dog.GetComponent<Follow>().stayIsActive;
            if(dog.GetComponent<Follow>().stayIsActive == true)
            {
                SoundManager.PlaySound("stayBark");
                dog.GetComponent<Animator>().SetBool("isMoving", false);
            }
            else
            {
                SoundManager.PlaySound("followBark");
            }
        }
        //Reset level
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}