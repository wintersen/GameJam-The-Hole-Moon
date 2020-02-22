using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckMultipleItem : MonoBehaviour
{
    public GameObject desiredObj1, desiredObj2, desiredObj3;
    public GameObject gap;
    private int step = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player throws in correct object
        if (collision.gameObject == desiredObj1)
        {
            Debug.Log("first done");
            step = 2;
        }
        else if (collision.gameObject == desiredObj2 && step == 2)
        {
            Debug.Log("second done");
            step = 3;
        }
        else if (collision.gameObject == desiredObj3 && step == 3)
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            gap.SetActive(true);
        }
        else if (collision.gameObject.name == "Player")
        {
            Debug.Log("You fell in the hole");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.name == "Dog")
        {
            Debug.Log("Dog fell in the hole");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
