using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTitleMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("TitleMusic"))
        {
            Destroy(GameObject.Find("TitleMusic"));
        }
        
    }

}
