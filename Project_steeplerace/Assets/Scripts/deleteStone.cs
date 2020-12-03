using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteStone : MonoBehaviour
{
    void Start(){
        
    }
    void OnCollisionEnter(Collision other){
        
        if(other.gameObject.name == "player"){
            Destroy(gameObject);
        }
        else{
            Destroy(gameObject, 2f);
        }
    }
}
