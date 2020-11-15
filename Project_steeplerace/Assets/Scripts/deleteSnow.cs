using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSnow : MonoBehaviour
{
    void Update()
    {
        if(!GameObject.FindWithTag("Gsnow") || GameObject.FindWithTag("track"))
            Destroy(gameObject);
    }
}
