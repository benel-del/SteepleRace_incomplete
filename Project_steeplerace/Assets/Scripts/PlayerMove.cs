using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static int speed;
    public static float jump;
    public AudioSource bgm;
    private float sun;
    public static bool isJump;
    public static bool move1, move2;
    Animator anim;
    void Start()
    {
        sun = 0;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(transform.position.y > 0.2)
            isJump = true;
        else
            isJump = false;
        if(InitScene.oneTime && PlayerCollision.notMove == 0) {
            if(transform.position.y < -1)
                bgm.Pause();
            else{
                bgm.UnPause();
                if(transform.position.z > 259)
                    transform.position = new Vector3(transform.position.x, transform.position.y, 259);
                if(Input.GetKey(KeyCode.Space))
                    if(!isJump){
                        GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
                        anim.SetTrigger("jump");
                    }
                if(Input.GetKey(KeyCode.UpArrow)){
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    move1 = true;
                    if(GameObject.FindWithTag("Gsun"))
                        sun += Time.deltaTime;
                    else 
                        sun = 0;
                }
                else{
                    sun = 0;
                    move1 = false;
                }
                if(Input.GetKey(KeyCode.LeftArrow)){
                    if(transform.position.x >= -24)
                        transform.Translate(Vector3.left * speed * Time.deltaTime);
                    move2 = true;
                }
                else if(Input.GetKey(KeyCode.RightArrow)){
                    if(transform.position.x <= 24)
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                    move2 = true;
                }
                else
                    move2 = false;
            }
            if(sun > 15){
                PlayerCollision.notMove = 3;
                sun = 0;
            }
            if(move1 || move2)
                anim.SetInteger("Walk", 1);
            else
                anim.SetInteger("Walk", 0);
        }
        else{
            anim.SetInteger("Walk", 0);
            sun = 0;
            move1 = move2 = false;
        }

        if(!InitScene.oneTime)
            bgm.loop = false;
    }

    public void bgmplay(){
        bgm.Play();
    }
}
