using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed;
    public float jump;
    public AudioSource falling;
    void Start()
    {
        speed = 10;
        jump = 60f;
        transform.position = new Vector3(0, 3, -255);
    }

    void FixedUpdate()
    {
        if(!GameObject.FindWithTag("result") && gameObject.GetComponent<PlayerCollision>().notMove == 0) {
            if(transform.position.y < -1)
                falling.Play();
            else{
                if(Input.GetKey(KeyCode.Space))
                    if(transform.position.y < 0.5)
                        GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
                if(Input.GetKey(KeyCode.UpArrow))
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if(Input.GetKey(KeyCode.LeftArrow))
                    if(transform.position.x >= -24)
                        transform.Translate(Vector3.left * speed * Time.deltaTime);
                if(Input.GetKey(KeyCode.RightArrow))
                    if(transform.position.x <= 24)
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}
