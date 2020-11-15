using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteRain : MonoBehaviour
{
    void Update()
    {
        if(!GameObject.FindWithTag("Grain") && !GameObject.FindWithTag("Gsnow"))
            Destroy(gameObject);
    }
}
