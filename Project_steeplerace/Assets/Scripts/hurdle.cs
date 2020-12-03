using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdle : MonoBehaviour
{
    bool one;   // player와 2번 부딪히면 소멸
    void Start(){
        one = false;
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            if(one)
                Destroy(gameObject);
            else
                one = true;
        }
    }
}