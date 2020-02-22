using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get : MonoBehaviour
{
    private bool canGet, handsFull;
    public GameObject headAnchor;
    public GameObject player;
    public float strength;
    public bool isGrabbable;
    public GameObject heldItem;

    // Start is called before the first frame update
    void Start()
    {
        canGet = false;
        handsFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canGet && Input.GetKeyDown(KeyCode.L))
        {
            GetItem();
        }
        if(handsFull && !canGet && Input.GetKeyDown(KeyCode.L))
        {
            ThrowItem();
        }
    }

    //Register item in field
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && isGrabbable)
        {
            canGet = true;
        }
    }

    //Deegister item in field
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isGrabbable)
        {
            canGet = false;
        }
    }
    void GetItem()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        //Put in offset option for larger items later
        transform.position = headAnchor.transform.position;
        transform.parent = headAnchor.transform;
        handsFull = true;
        player.GetComponent<Animator>().SetBool("handsFull", handsFull);
        heldItem = gameObject;
    }

    void ThrowItem()
    {
        handsFull = false;
        player.GetComponent<Animator>().SetBool("handsFull", handsFull);
        heldItem = null;
        GetComponent<Rigidbody2D>().simulated = true;
        transform.parent = null;
        GetComponent<Rigidbody2D>().AddForce(transform.up * strength, ForceMode2D.Impulse);
        if(player.GetComponent<Movement>().horizontalDirection < 0) //Throw to the right
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,0) * strength, ForceMode2D.Impulse);
        }
        else if(player.GetComponent<Movement>().horizontalDirection > 0) //Throw to the left
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1,0) * strength, ForceMode2D.Impulse);
        }

    }
}
