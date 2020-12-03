using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdle : MonoBehaviour
{
    void Start(){
    }
    // hurdle.cs
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}