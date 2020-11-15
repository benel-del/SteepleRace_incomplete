using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed;
    public float jump;
    public AudioSource falling;

    private float sun;
    void Start()
    {
        speed = 10;
        jump = 60f;
        sun = 0;
        transform.position = new Vector3(0, 3, -255);
    }

    void FixedUpdate()
    {
        if(!GameObject.FindWithTag("result") && gameObject.GetComponent<PlayerCollision>().notMove == 0) {
            if(transform.position.y < -1)
                falling.Play();
            else{
                if(transform.position.z > 259)
                    transform.position = new Vector3(transform.position.x, transform.position.y, 259);
                if(Input.GetKey(KeyCode.Space))
                    if(transform.position.y < 0.5)
                        GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
                if(Input.GetKey(KeyCode.UpArrow)){
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    if(GameObject.FindWithTag("Gsun"))
                        sun += Time.deltaTime;
                    else 
                        sun = 0;
                }
                else{
                    sun = 0;
                }
                if(Input.GetKey(KeyCode.LeftArrow))
                    if(transform.position.x >= -24)
                        transform.Translate(Vector3.left * speed * Time.deltaTime);
                if(Input.GetKey(KeyCode.RightArrow))
                    if(transform.position.x <= 24)
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if(sun > 15){
                gameObject.GetComponent<PlayerCollision>().notMove = 3;
                sun = 0;
            }
        }
    }
}
