using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteStone : MonoBehaviour
{
    void Start(){
        
    }
    void OnCollisionEnter(Collision other){
        GameObject.Find("ScriptObject").GetComponent<InitScene>().StonePlay();  // TODO: sound 원거리
        Destroy(gameObject, 2f);
    }
}
