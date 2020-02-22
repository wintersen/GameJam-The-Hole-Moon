using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHit : MonoBehaviour
{
    public string color;
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
        if(collision.gameObject.name == "RedKey" && color == "red")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "BlueKey" && color == "blue")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
