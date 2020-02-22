using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject leader;
    public float goodBoyDistance = 1f;
    public bool stayIsActive = false;
    public float speed = 2;
    private float facingDirection;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        facingDirection = transform.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stayIsActive) //If not ordered to stay, follow
        {
            float currentDistance = leader.transform.position.x - transform.position.x;

            if (currentDistance >= -goodBoyDistance && currentDistance <= goodBoyDistance) //In good boy range
            {
                anim.SetBool("isMoving", false);
            }
            else //Not in good boy range
            {
                Vector2 targetPosition = new Vector2(leader.transform.position.x, transform.position.y);

                //Change direction of dog
                if (leader.transform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector2(-facingDirection, transform.localScale.y);
                }
                else
                {
                    transform.localScale = new Vector2(facingDirection, transform.localScale.y);
                }
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
                anim.SetBool("isMoving", true);
            }
        }
        
    }
}
