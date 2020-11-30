using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStick : MonoBehaviour
{
    private float speed = 20f;
    void Start(){
        if(transform.position.x < 0)
            speed *= -1;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.x >= 25 || transform.position.x <= -25)
         speed *= -1;
    }
}
