using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private bool isDogIn = false;
    private bool isPlayerIn = false;
    public GameObject dog;

    private void Update()
    {
        if(isDogIn && isPlayerIn)
        {
            endLevel();
        }
        else if(isPlayerIn && dog.GetComponent<Get>().heldItem.name == "Dog")
        {
            endLevel();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            isPlayerIn = true;
        }
        if(collision.gameObject.name == "Dog")
        {
            isDogIn = true;
        }
    }

    private void endLevel()
    {
        Debug.Log("Level ending");
    }
}
