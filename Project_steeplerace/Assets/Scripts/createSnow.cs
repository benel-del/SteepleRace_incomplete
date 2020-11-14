using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createSnow : MonoBehaviour
{
    private GameObject darkCloud, ice, snow_set;
    private float x, z;
    private int count;
    void Start()
    {
        count = 0;
        ice = Resources.Load("ice") as GameObject;
        snow_set = Resources.Load("snow_set") as GameObject;
        darkCloud = Resources.Load("darkCloud") as GameObject;
        for(int i = 0; i < 60; i++){
            x = Random.Range(-25, 25);
            z = Random.Range(-7, 22);
            Instantiate(darkCloud, new Vector3(x*40.0f, 300, z*40.0f), Quaternion.identity);
        }       
    }

    void FixedUpdate(){
        if(++count == 50){
            CreateSub();
        }
        if(count > 50 && !GameObject.FindWithTag("track") &&!GameObject.FindWithTag("snow_set"))
            CreateSub();
    }
    void CreateSub(){
        for(int i = 0; i < 15; i++){
                x = Random.Range(-10, 10);
                z = Random.Range(-23, 23);
                Instantiate(ice, new Vector3(x*2.0f, 0.02f, z*10.0f), Quaternion.identity);
            }
            for(int i = 0; i < 80; i++){
                x = Random.Range(-10, 10);
                z = Random.Range(-23, 23);
                Instantiate(snow_set, new Vector3(x*2.0f, 0.02f, z*10.0f), Quaternion.identity);
            }
    }
}