using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStick : MonoBehaviour
{
    void Start()
    {
        if(Random.Range(0,2) == 0)
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(-25, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if(transform.position.x <= -25)
            GetComponent<Rigidbody>().AddForce(Vector3.right * 400f * Time.deltaTime);
        if(transform.position.x >= 25)
            GetComponent<Rigidbody>().AddForce(Vector3.left * 400f * Time.deltaTime);
    }
}
