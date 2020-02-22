using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckItem : MonoBehaviour
{
    public GameObject desiredObj;
    public GameObject gap;

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
        //If player throws in correct object
        if(collision.gameObject == desiredObj)
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            gap.SetActive(true);
        }
        else if(collision.gameObject.name == "Player")
        {
            Debug.Log("You fell in the hole");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(collision.gameObject.name == "Dog")
        {
            Debug.Log("Dog fell in the hole");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
