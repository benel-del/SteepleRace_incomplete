using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteRain : MonoBehaviour
{
    void Update()
    {
        if(!GameObject.Find("Grain") && !GameObject.Find("Gsnow"))
            Destroy(gameObject);
    }
}
