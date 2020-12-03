using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heat : MonoBehaviour
{
    public GameObject heat_haze;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.Find("track 3") && heat_haze.activeSelf)
           heat_haze.SetActive(false);
        else if(!GameObject.Find("track 3"))
            heat_haze.SetActive(true);
    }
}
