using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCloud : MonoBehaviour
{
    private GameObject cloud;
    private float x, z;
    void Start()
    {
        cloud = Resources.Load("cloud") as GameObject;
        for(int i = 0; i < 20; i++){
            x = Random.Range(-10, 10);
            z = Random.Range(-8, 20);
            Instantiate(cloud, new Vector3(x*30.0f, 200, z*30.0f), Quaternion.identity);
        }
    }
}
