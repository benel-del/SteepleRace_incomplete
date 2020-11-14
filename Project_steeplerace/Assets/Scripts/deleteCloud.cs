using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteCloud : MonoBehaviour
{
    void Update()
    {
        if(!GameObject.Find("Gcloud"))
            Destroy(gameObject);
    }
}
