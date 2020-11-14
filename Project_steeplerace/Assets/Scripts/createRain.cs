using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRain : MonoBehaviour
{
    private GameObject darkCloud;
    private float x, z;
    void Start()
    {
        darkCloud = Resources.Load("darkCloud") as GameObject;
        for(int i = 0; i < 60; i++){
            x = Random.Range(-25, 25);
            z = Random.Range(-7, 22);
            Instantiate(darkCloud, new Vector3(x*40.0f, 300, z*40.0f), Quaternion.identity);
        }
    }
}
