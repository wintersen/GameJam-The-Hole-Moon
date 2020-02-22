using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            // Game Over - Player is Dead
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

            // Restart Level
            Debug.Log("You dead m8");

        }
        else if (collision.gameObject.tag == "Object")
        {
            // Knock the Monster Out
            Debug.Log("Get Rekted Monster");
        }
    }
}